using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using mitoSoft.Graphs.Analysis;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [DebuggerDisplay(nameof(PersonNode) + " ({Person})")]
    public sealed partial class PersonNode : DistanceNode
    {
        private readonly Dictionary<string, Jobs> _profiles;

        public PersonNode(IPerson person) : base(BuildNodeName(person))
        {
            _profiles = new Dictionary<string, Jobs>();

            this.Person = new SearchPerson(person.FirstName, person.MiddleName, person.LastName, person.BirthYear);

            this.Tag = this;
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
            if (_profiles.TryGetValue(profile.Name, out var jobs))
            {
                foreach (var job in jobs.JobList)
                {
                    yield return job;
                }
            }
        }

        public static string BuildNodeName(IPerson person) => "Person: " + PersonFormatter.GetName(person).ToLower(Thread.CurrentThread.CurrentUICulture);
    }
}