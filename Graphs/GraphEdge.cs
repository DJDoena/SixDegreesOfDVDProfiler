using System;
using System.Diagnostics;

namespace mitoSoft.Math.Graphs
{
    [DebuggerDisplay("{SourceNode.Name} -> {TargetNode.Name} ({Distance})")]
    public class GraphEdge
    {
        public GraphEdge(GraphNode sourceNode, GraphNode targetNode, double distance)
        {
            Id = Guid.NewGuid();

            SourceNode = sourceNode ?? throw new ArgumentNullException(nameof(sourceNode));
            TargetNode = targetNode ?? throw new ArgumentNullException(nameof(targetNode));

            Distance = distance;
        }

        public Guid Id { get; }

        public GraphNode SourceNode { get; }

        public GraphNode TargetNode { get; }

        public double Distance { get; }
    }
}
