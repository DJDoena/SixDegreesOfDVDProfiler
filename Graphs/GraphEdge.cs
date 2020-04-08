using System;
using System.Diagnostics;

namespace mitoSoft.Math.Graphs
{
    [DebuggerDisplay("{SourceNode.Name} -> {TargetNode.Name} ({Distance})")]
    public class GraphEdge
    {
        public GraphEdge(GraphNode sourceNode, GraphNode targetNode, double distance)
        {
            this.Id = Guid.NewGuid();

            this.SourceNode = sourceNode ?? throw new ArgumentNullException(nameof(sourceNode));

            this.TargetNode = targetNode ?? throw new ArgumentNullException(nameof(targetNode));

            this.Distance = distance;
        }

        public Guid Id { get; }

        public GraphNode SourceNode { get; }

        public GraphNode TargetNode { get; }

        public double Distance { get; }
    }
}
