using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace mitoSoft.Math.Graphs
{
    [DebuggerDisplay("Node {Name} (Connections = {_connections.Count})")]
    public class GraphNode
    {
        private readonly IList<GraphEdge> _connections;

        public GraphNode(string name, GraphNodeKey key)
        {
            _connections = new List<GraphEdge>();

            Id = Guid.NewGuid();

            Name = name ?? throw new ArgumentNullException(nameof(name));

            Key = key;
        }

        public Guid Id { get; }

        public string Name { get; }

        public GraphNodeKey Key { get; }

        public IEnumerable<GraphEdge> Connections
        {
            get
            {
                foreach (var connection in _connections)
                {
                    yield return connection;
                }
            }
        }

        public IEnumerable<GraphNode> Predecessors => _connections.Where(c => ReferenceEquals(c.TargetNode, this)).Select(c => c.SourceNode);

        public IEnumerable<GraphNode> Successors => _connections.Where(c => ReferenceEquals(c.SourceNode, this)).Select(c => c.TargetNode);

        internal void AddConnection(GraphNode targetNode, double distance, bool twoWay)
        {
            if (targetNode == null)
            {
                throw new ArgumentNullException(nameof(targetNode));
            }
            else if (ReferenceEquals(targetNode, this))
            {
                throw new ArgumentException("Node must not connect to itself.");
            }
            else if (distance <= 0)
            {
                throw new ArgumentException("Distance must be positive.");
            }

            var forward = new GraphEdge(this, targetNode, distance);

            _connections.Add(forward);

            var backward = new GraphEdge(targetNode, this, distance);

            if (twoWay)
            {
                _connections.Add(backward);
            }

            targetNode.AddConnection(forward, backward, twoWay);
        }

        private void AddConnection(GraphEdge forward, GraphEdge backward, bool twoWay)
        {
            _connections.Add(backward);

            if (twoWay)
            {
                _connections.Add(forward);
            }
        }
    }
}