using System.Collections.Generic;
using System.Diagnostics;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using mitoSoft.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [DebuggerDisplay(nameof(PersonNode) + " ({ToString()})")]
    public sealed partial class PersonNode : DistanceNode
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
    }
}