using System.Collections.Generic;
using System.Diagnostics;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using mitoSoft.Math.Graphs;
using mitoSoft.Math.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [DebuggerDisplay("{Name}")]
    public sealed class PersonNode : DistanceNode
    {
        private Dictionary<string, Jobs> _profiles;

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

        public sealed class Jobs
        {
            private Dictionary<string, IPerson> _jobs;

            public Jobs()
            {
                _jobs = new Dictionary<string, IPerson>();
            }

            public IEnumerable<IPerson> JobList
            {
                get
                {
                    foreach (var job in _jobs.Values)
                    {
                        yield return job;
                    }
                }
            }

            internal void AddJob(IPerson person)
            {
                var job = PersonFormatter.GetJob(person);

                _jobs[job] = person;
            }
        }

        private sealed class PersonNodeKey : GraphNodeKey
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

            public override bool KeysAreEqual(GraphNodeKey other)
            {
                if (!(other is PersonNodeKey pnk))
                {
                    return false;
                }

                var areEqual = _key.Equals(pnk._key);

                return areEqual;
            }
        }
    }
}
