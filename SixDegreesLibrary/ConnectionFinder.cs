using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerXML;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public sealed class ConnectionFinder
    {
        private readonly Persons _persons;

        private PersonKey _targetPersonKey;

        public ConnectionFinder(Persons persons)
        {
            _persons = persons ?? throw new ArgumentNullException(nameof(persons));
        }

        public Steps Find(IPerson startPerson, IPerson targetPerson, byte maxSearchDepth)
        {
            if (Init(startPerson, targetPerson, out var startingEntries, out var steps))
            {
                return steps;
            }

            for (byte targetSubLevel = 0; targetSubLevel < maxSearchDepth; targetSubLevel++)
            {
                var result = Find(startingEntries, targetSubLevel);

                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        public Steps FindReverse(IPerson startPerson, IPerson targetPerson, byte maxSearchDepth)
        {
            if (Init(startPerson, targetPerson, out var startingEntries, out var steps))
            {
                return steps;
            }

            if (maxSearchDepth == 0)
            {
                return null;
            }

            for (byte targetSubLevel = (byte)(maxSearchDepth - 1); targetSubLevel >= 0; targetSubLevel--)
            {
                var result = Find(startingEntries, targetSubLevel);

                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        private bool Init(IPerson startPerson, IPerson targetPerson, out ProfileEntries startingEntries, out Steps steps)
        {
            if (startPerson == null)
            {
                throw new ArgumentNullException(nameof(startPerson));
            }
            else if (targetPerson == null)
            {
                throw new ArgumentNullException(nameof(targetPerson));
            }

            var startPersonKey = new PersonKey(startPerson);

            _targetPersonKey = new PersonKey(targetPerson);

            if (!_persons.TryGetValue(startPersonKey, out startingEntries))
            {
                throw new PersonNotInCollectionException(startPerson);
            }

            if (!_persons.TryGetValue(_targetPersonKey, out _))
            {
                throw new PersonNotInCollectionException(targetPerson);
            }

            if (startPersonKey.Equals(_targetPersonKey))
            {
                steps = new Steps();

                return true;
            }

            steps = null;

            return false;
        }

        #region Find

        private Steps Find(ProfileEntries startingEntries, byte targetSubLevel)
        {
            foreach (var startingEntry in startingEntries)
            {
                var steps = new Steps();

                var profiles = GetSubProfiles(startingEntry, 0, targetSubLevel, steps);

                var result = Find(profiles);

                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        private Steps Find(IEnumerable<DeepProfiles> deepProfiles)
        {
            var match = deepProfiles.FirstOrDefault(dp => dp.Profile.PersonKey.Equals(_targetPersonKey));

            if (match != null)
            {
                var result = match.Steps;

                return result;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region GetSubProfiles

        private IEnumerable<DeepProfiles> GetSubProfiles(ProfileEntry left, byte currentSubLevel, byte targetSubLevel, Steps steps)
        {
            var relevantCoProfiles = left.CoProfiles.Where(p => StepsDontContainPreviouslyUsed(steps, p)); //do not go back

            foreach (var right in relevantCoProfiles)
            {
                if (currentSubLevel == targetSubLevel)
                {
                    yield return new DeepProfiles(left, right, steps);
                }
                else
                {
                    var deepProfiles = GetSubProfiles(left, right, currentSubLevel, targetSubLevel, steps);

                    foreach (var deepProfile in deepProfiles)
                    {
                        yield return deepProfile;
                    }
                }
            }
        }

        private IEnumerable<DeepProfiles> GetSubProfiles(ProfileEntry left, ProfileEntry right, byte currentSubLevel, byte targetSubLevel, Steps steps)
        {
            var personProfiles = _persons[right.PersonKey];

            var nextStep = steps.Add(left, right);

            var relevantProfiles = personProfiles.Where(p => StepsDontContainPreviouslyUsed(steps, p)); //do not go back

            foreach (var relevantProfile in relevantProfiles)
            {
                var deepProfiles = GetSubProfiles(relevantProfile, (byte)(currentSubLevel + 1), targetSubLevel, nextStep);

                foreach (var deepProfile in deepProfiles)
                {
                    yield return deepProfile;
                }
            }
        }

        private static bool StepsDontContainPreviouslyUsed(Steps steps, ProfileEntry profile)
        {
            var entries = GetStepEntries(steps).ToList();

            var profileIds = entries.Select(e => e.ProfileId);

            var persons = entries.Select(e => e.PersonKey);

            var titles = entries.Select(e => e.Title);

            var result = !profileIds.Contains(profile.ProfileId)
                && !persons.Contains(profile.PersonKey)
                && !titles.Contains(profile.Title);

            return result;
        }

        private static IEnumerable<ProfileEntry> GetStepEntries(Steps steps)
        {
            var stepList = steps.GetSteps();

            var result = stepList.Select(s => s.Left).Concat(stepList.Select(s => s.Right));

            return result;
        }

        #endregion

        [DebuggerDisplay("{Profile}")]
        private sealed class DeepProfiles
        {
            public ProfileEntry Profile { get; }

            public Steps Steps { get; }

            public DeepProfiles(ProfileEntry left, ProfileEntry right, Steps steps)
            {
                Profile = right;

                Steps = steps.Add(left, right);
            }
        }
    }
}
