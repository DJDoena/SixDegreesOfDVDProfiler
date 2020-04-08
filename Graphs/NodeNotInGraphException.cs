using System;

namespace mitoSoft.Math.Graphs
{
    public sealed class NodeNotInGraphException : Exception
    {
        public GraphNode Node { get; }

        public GraphNodeKey Key { get; }

        public NodeNotInGraphException(GraphNode node) : base($"Node '{node.Name}' is not in graph.")
        {
            this.Node = node;
        }

        public NodeNotInGraphException(GraphNodeKey key) : base($"Node '{key.GetKeyDisplayValue()}' is not in graph.")
        {
            this.Key = key;
        }
    }
}
