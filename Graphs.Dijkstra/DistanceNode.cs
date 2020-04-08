using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace mitoSoft.Math.Graphs.Dijkstra
{
    [DebuggerDisplay("Node {Name} (Connections = {System.Linq.Enumerable.Count(Connections)}, Distance = {DistanceFromStart})")]
    public class DistanceNode : GraphNode
    {
        public DistanceNode(string name, GraphNodeKey key) : base(name, key)
        {
            ResetDistanceFromStart();
        }

        public double DistanceFromStart { get; private set; }

        public void SetDistanceFromStart(double distance)
        {
            if (distance < 0)
            {
                throw new ArgumentException("Distance must be 0 or positive.");
            }

            DistanceFromStart = distance;
        }

        public void ResetDistanceFromStart()
        {
            DistanceFromStart = double.PositiveInfinity;
        }

        public IEnumerable<DistanceNode> GetShortestPathPredecessors()
        {
            var predecessors = Predecessors.Cast<DistanceNode>().ToList();

            if (predecessors.Count > 0)
            {
                var min = predecessors.Min(p => p.DistanceFromStart);

                var result = predecessors.Where(p => p.DistanceFromStart == min);

                return result;
            }
            else
            {
                return Enumerable.Empty<DistanceNode>();
            }
        }
    }
}