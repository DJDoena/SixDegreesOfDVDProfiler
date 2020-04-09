using System.Collections.Generic;
using System.Diagnostics;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using mitoSoft.Graphs;
using mitoSoft.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [DebuggerDisplay(nameof(PersonNode) + " ({ToString()})")]
    public sealed class PersonNode : DistanceNode
    {
        private readonly Dictionary<string, Jobs> _profiles;

        public PersonNode(IPerson person) : base(PersonFormatter.GetName(person), new PersonNodeKey(person))
        {
            _profiles = new Dictionary<string, Jobs>();

            Person = new SearchPerson(person.FirstName, person.MiddleName, person.LastName, person.BirthYear);
        }

        public IPerson Person { get; }

        public void AddJob(ProfileNode profile, IPerson person)
        {
            if (!_profiles.TryGetValue(profile.Name, out var jobs))
            {
                jobs = new Jobs();

                _profiles.Add(profile.Name, jobs);
            }

            jobs.AddJob(person);
        }

        public IEnumerable<IPerson> GetJobs(ProfileNode profile)
        {
            var jobs = _profiles[profile.Name];

            foreach (var job in jobs.JobList)
            {
                yield return job;
            }
        }

        #region class PersonNodeKey

        [DebuggerDisplay(nameof(PersonNodeKey) + " ({ToString()})")]
        private sealed class PersonNodeKey : GraphNodeKeyBase
        {
            private readonly IPerson _person;

            private readonly PersonKey _key;

            public PersonNodeKey(IPerson person)
            {
                _person = person;
                _key = new PersonKey(person);
            }

            public override string GetKeyDisplayValue() => PersonFormatter.GetName(_person);

            public override int GetKeyHashCode() => _key.GetHashCode();

            public override bool KeysAreEqual(GraphNodeKeyBase other)
            {
                if (!(other is PersonNodeKey pnk))
                {
                    return false;
                }
                else
                {
                    var areEqual = _key.Equals(pnk._key);

                    return areEqual;
                }
            }
        }

        #endregion
    }
}