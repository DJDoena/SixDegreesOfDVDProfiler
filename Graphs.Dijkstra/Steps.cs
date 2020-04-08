using System.Collections.Generic;
using System.Diagnostics;

namespace mitoSoft.Math.Graphs.Dijkstra
{
    [DebuggerDisplay("Degree: {Degree}")]
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

        public int Degree => _steps.Count;

        public IEnumerable<Step> GetSteps()
        {
            foreach (var step in _steps)
            {
                yield return step;
            }
        }

        internal Steps Add(DistanceNode left, DistanceNode right) => new Steps(_steps, new Step(left, right));
    }
}
