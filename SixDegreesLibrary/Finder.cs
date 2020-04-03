using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerXML;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public sealed class Finder
    {
        private readonly Persons _persons;

        private PersonKey _targetPersonKey;

        public Finder(Persons persons)
        {
            _persons = persons ?? throw new ArgumentNullException(nameof(persons));
        }

        public Steps Find(IPerson startPerson, IPerson targetPerson, byte maxSearchDepth)
        {
            if (startPerson == null)
            {
                throw new ArgumentNullException(nameof(startPerson));
            }
            else if (targetPerson == null)
            {
                throw new ArgumentNullException(nameof(targetPerson));
            }

            if (!_persons.TryGetValue(new PersonKey(startPerson), out var startingEntries))
            {
                throw new PersonNotInCollectionException(startPerson);
            }

            _targetPersonKey = new PersonKey(targetPerson);

            if (!_persons.TryGetValue(_targetPersonKey, out _))
            {
                throw new PersonNotInCollectionException(targetPerson);
            }

            for (var targetSubLevel = 0; targetSubLevel < maxSearchDepth; targetSubLevel++)
            {
                foreach (var startingEntry in startingEntries)
                {
                    var steps = new Steps();

                    var profiles = GetSubProfiles(startingEntry, 0, targetSubLevel, steps);

                    var result = FindFlat(profiles);

                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        #region GetSubProfiles

        private IEnumerable<DeepProfiles> GetSubProfiles(ProfileEntry left, int currentSubLevel, int targetSubLevel, Steps steps)
        {
            var relevantCoProfiles = left.CoProfiles.Where(p => StepsDontContainProfile(steps, p)); //do not go back

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

        private IEnumerable<DeepProfiles> GetSubProfiles(ProfileEntry left, ProfileEntry right, int currentSubLevel, int targetSubLevel, Steps steps)
        {
            var personProfiles = _persons[right.PersonKey];

            var nextStep = steps.Add(left, right);

            var relevantProfiles = personProfiles.Where(p => StepsDontContainProfile(steps, p)); //do not go back

            foreach (var relevantProfile in relevantProfiles)
            {
                var deepProfiles = GetSubProfiles(relevantProfile, currentSubLevel + 1, targetSubLevel, nextStep);

                foreach (var deepProfile in deepProfiles)
                {
                    yield return deepProfile;
                }
            }
        }

        private static bool StepsDontContainProfile(Steps steps, ProfileEntry profile)
        {
            var stepEntries = GetStepEntries(steps);

            var stepProfileIds = stepEntries.Select(s => s.Profile.ID);

            var result = !stepProfileIds.Contains(profile.Profile.ID);

            return result;
        }

        private static IEnumerable<ProfileEntry> GetStepEntries(Steps steps)
        {
            var stepList = steps.GetSteps();

            var result = stepList.Select(s => s.Left).Concat(stepList.Select(s => s.Right));

            return result;
        }

        #endregion

        private Steps FindFlat(IEnumerable<DeepProfiles> deepProfiles)
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
