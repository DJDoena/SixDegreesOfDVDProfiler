using System.Collections.Generic;
using System.Diagnostics;
using DoenaSoft.DVDProfiler.DVDProfilerXML;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [DebuggerDisplay(nameof(Jobs) + " ({ToString()})")]
    public sealed class Jobs
    {
        private readonly Dictionary<string, IPerson> _jobs;

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

        public override string ToString() => $"Jobs: {_jobs.Count}";

        internal void AddJob(IPerson person)
        {
            var job = PersonFormatter.GetJob(person);

            _jobs[job] = person;
        }
    }
}