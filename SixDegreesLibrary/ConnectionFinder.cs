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

        private PersonKey _sourcePersonKey;

        private PersonKey _targetPersonKey;

        private uint _maxSearchRequests;

        private uint _currentSearchRequest;

        public ConnectionFinder(Persons persons)
        {
            _persons = persons ?? throw new ArgumentNullException(nameof(persons));
        }

        public IEnumerable<Steps> FindForward(IPerson sourcePerson, IPerson targetPerson, byte maxSearchDepth, uint maxSearchRequests)
        {
            if (Init(sourcePerson, targetPerson, maxSearchRequests, out var startingEntries, out var steps))
            {
                yield return steps;

                yield break;
            }

            for (byte targetSubLevel = 0; targetSubLevel < maxSearchDepth; targetSubLevel++)
            {
                var results = startingEntries.SelectMany(startingEntry => FindForward(startingEntry, targetSubLevel));

                if (results.Any())
                {
                    foreach (var result in results)
                    {
                        yield return result;
                    }

                    Debug.WriteLine($"Match(es) found. Number of search requests: {_currentSearchRequest} (max: {_maxSearchRequests})");

                    yield break;
                }
            }

            Debug.WriteLine($"No Match found. Number of search requests: {_currentSearchRequest} (max: {_maxSearchRequests})");
        }

        private IEnumerable<Steps> FindForward(ProfileEntry startingEntry, byte targetSubLevel)
        {
            var profiles = GetSubProfiles(startingEntry, 0, targetSubLevel, new Steps());

            var matches = profiles.Where(IsPersonMatch);

            var results = matches.Select(m => m.Steps);

            return results;
        }

        public IEnumerable<Steps> FindReverse(IPerson sourcePerson, IPerson targetPerson, byte maxSearchDepth, uint maxSearchRequests)
        {
            if (Init(sourcePerson, targetPerson, maxSearchRequests, out var startingEntries, out var steps))
            {
                yield return steps;

                yield break;
            }

            if (maxSearchDepth == 0)
            {
                yield break;
            }

            for (byte targetSubLevel = maxSearchDepth; targetSubLevel > 0; targetSubLevel--)
            {
                var result = FindReverse(startingEntries, (byte)(targetSubLevel - 1));

                if (result != null)
                {
                    yield return result;

                    Debug.WriteLine($"Match found. Number of search requests: {_currentSearchRequest} (max: {_maxSearchRequests})");

                    yield break;
                }
            }

            Debug.WriteLine($"No match found. Number of search requests: {_currentSearchRequest} (max: {_maxSearchRequests})");
        }

        private Steps FindReverse(ProfileEntries startingEntries, byte targetSubLevel)
        {
            foreach (var startingEntry in startingEntries)
            {
                var profiles = GetSubProfiles(startingEntry, 0, targetSubLevel, new Steps());

                var matches = profiles.Where(IsPersonMatch);

                var match = matches.FirstOrDefault(IsNotReverseDisqualified); //everything but the first is just too performance-heavy

                if (match != null)
                {
                    var result = match.Steps;

                    return result;
                }
            }

            return null;
        }

        private bool Init(IPerson sourcePerson, IPerson targetPerson, uint maxSearchRequests, out ProfileEntries startingEntries, out Steps steps)
        {
            if (sourcePerson == null)
            {
                throw new ArgumentNullException(nameof(sourcePerson));
            }
            else if (targetPerson == null)
            {
                throw new ArgumentNullException(nameof(targetPerson));
            }

            _sourcePersonKey = new PersonKey(sourcePerson);

            _targetPersonKey = new PersonKey(targetPerson);

            _maxSearchRequests = maxSearchRequests;

            _currentSearchRequest = 0;

            if (!_persons.TryGetValue(_sourcePersonKey, out startingEntries))
            {
                throw new PersonNotInCollectionException(sourcePerson);
            }

            if (!_persons.TryGetValue(_targetPersonKey, out _))
            {
                throw new PersonNotInCollectionException(targetPerson);
            }

            if (_sourcePersonKey.Equals(_targetPersonKey))
            {
                steps = new Steps();

                return true;
            }

            steps = null;

            return false;
        }

        /// <summary>
        /// source person may only appear in last step, otherwise it's an invalid chain
        /// target person may only appear in last step, otherwise it's an invalid chain
        /// </summary>
        private bool IsNotReverseDisqualified(DeepProfiles profile)
        {
            var steps = profile.Steps.GetSteps().ToList();

            var isDisqualified = steps.Any(s => IsPersonMatch(s.Left, _sourcePersonKey))
                || steps.Any(s => IsPersonMatch(s.Right, _targetPersonKey));

            return !isDisqualified;
        }

        #region GetSubProfiles

        private IEnumerable<DeepProfiles> GetSubProfiles(ProfileEntry left, byte currentSubLevel, byte targetSubLevel, Steps steps)
        {
            if (_currentSearchRequest < _maxSearchRequests)
            {
                var relevantCoProfiles = left.CoProfiles.Where(p => StepsDontContainPreviouslyUsed(steps, p)); //do not go back

                foreach (var right in relevantCoProfiles)
                {
                    if (_currentSearchRequest < _maxSearchRequests)
                    {
                        if (currentSubLevel == targetSubLevel)
                        {
                            _currentSearchRequest++;

                            yield return new DeepProfiles(left, right, steps);
                        }
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
                && !persons.Any(p => IsPersonMatch(p, profile.PersonKey)
                && !titles.Contains(profile.Title));

            return result;
        }

        private static IEnumerable<ProfileEntry> GetStepEntries(Steps steps)
        {
            var stepList = steps.GetSteps();

            var result = stepList.Select(s => s.Left).Concat(stepList.Select(s => s.Right));

            return result;
        }

        #endregion

        #region IsPersonMatch

        private bool IsPersonMatch(ProfileEntry entry, PersonKey personKey) => entry.CoProfiles.Any(p => IsPersonMatch(p.PersonKey, personKey));

        private bool IsPersonMatch(DeepProfiles profiles) => IsPersonMatch(profiles.Profile.PersonKey, _targetPersonKey);

        private static bool IsPersonMatch(PersonKey left, PersonKey right)
        {
            if (left.GetHashCode() != right.GetHashCode())
            {
                return false;
            }
            else
            {
                var equals = left.Equals(right);

                return equals;
            }
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
