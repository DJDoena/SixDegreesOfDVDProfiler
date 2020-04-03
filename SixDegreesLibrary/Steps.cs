using System.Collections.Generic;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public sealed class Steps
    {
        private readonly List<Step> _steps;

        internal Steps()
        {
            _steps = new List<Step>();
        }

        private Steps(List<Step> previous, Step next)
        {
            _steps = new List<Step>(previous)
            {
                next,
            };
        }

        public IEnumerable<Step> GetSteps()
        {
            foreach (var step in _steps)
            {
                yield return step;
            }
        }

        internal Steps Add(ProfileEntry left, ProfileEntry right) => new Steps(_steps, new Step(left, right));
    }
}