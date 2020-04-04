using System;
using System.Collections.Generic;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public sealed class PersonsBuilder
    {
        private Persons _persons;

        private Dictionary<string, ProfileEntries> _profiles;

        public Persons Build(IEnumerable<DVD> collection, bool considerCast = true, bool considerCrew = false)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else if (collection.Any(p => p == null))
            {
                throw new ArgumentException("Collection contains profiles that are null", nameof(collection));
            }

            _persons = new Persons();

            _profiles = new Dictionary<string, ProfileEntries>();

            foreach (var profile in collection)
            {
                AddProfileToRoot(profile, considerCast, considerCrew);
            }

            foreach (var profile in collection)
            {
                var profileProfileItems = _profiles[profile.ID];

                CrossLinkProfiles(profileProfileItems);
            }

            return _persons;
        }

        private void AddProfileToRoot(DVD profile, bool considerCast, bool considerCrew)
        {
            if (!_profiles.TryGetValue(profile.ID, out var profileProfileItems))
            {
                profileProfileItems = new ProfileEntries();

                _profiles.Add(profile.ID, profileProfileItems);
            }

            var processedPersonsInProfile = new HashSet<PersonKey>();

            if (considerCast)
            {
                var castMember = (profile.CastList?.OfType<IPerson>() ?? Enumerable.Empty<IPerson>());

                AddPersonToRoot(castMember, profile, processedPersonsInProfile, profileProfileItems);
            }

            if (considerCrew)
            {
                var crewMember = (profile.CrewList?.OfType<IPerson>() ?? Enumerable.Empty<IPerson>());

                AddPersonToRoot(crewMember, profile, processedPersonsInProfile, profileProfileItems);
            }
        }

        private void AddPersonToRoot(IEnumerable<IPerson> persons, DVD profile, HashSet<PersonKey> processedPersonsInProfile, ProfileEntries profileProfileItems)
        {
            foreach (var person in persons)
            {
                var key = new PersonKey(person);

                if (!processedPersonsInProfile.Add(key))
                {
                    continue;
                }

                if (!_persons.TryGetValue(key, out var personProfileItems))
                {
                    personProfileItems = new ProfileEntries();

                    _persons.Add(key, personProfileItems);
                }

                var profileItem = new ProfileEntry(profile, person);

                personProfileItems.Add(profileItem);

                profileProfileItems.Add(profileItem);
            }
        }

        private static void CrossLinkProfiles(ProfileEntries profileProfileItems)
        {
            foreach (var profileItem in profileProfileItems)
            {
                var otherProfileItems = profileProfileItems.Except(new[] { profileItem });

                foreach (var otherProfileItem in otherProfileItems)
                {
                    profileItem.CoProfiles.Add(otherProfileItem);
                }
            }
        }
    }
}