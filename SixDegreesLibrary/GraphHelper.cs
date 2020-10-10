using System.Collections.Generic;
using System.Linq;
using mitoSoft.Graphs.Analysis;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public static class GraphHelper
    {
        public static IEnumerable<Steps> GetPaths(DistanceNode targetNode)
        {
            var result = GetSteps(targetNode, new Steps());

            return result;
        }

        private static IEnumerable<Steps> GetSteps(DistanceNode targetNode, Steps steps)
        {
            if (targetNode.Distance == 0)
            {
                yield return steps;
            }
            else
            {
                var predecessorNodes = targetNode.Predecessors.Cast<DistanceNode>();

                foreach (var predecessorNode in predecessorNodes)
                {
                    var nextStep = steps.Add(targetNode, predecessorNode);

                    var stepsList = GetSteps(predecessorNode, nextStep);

                    foreach (var stepItem in stepsList)
                    {
                        yield return stepItem;
                    }
                }
            }
        }
    }
}
