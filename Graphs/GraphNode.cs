using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace mitoSoft.Math.Graphs
{
    [DebuggerDisplay("Node {Name} (Connections = {_connections.Count})")]
    public class GraphNode
    {
        private static ulong _edgeCounter = 0;

        private readonly List<GraphEdge> _connections;

        public GraphNode(string name, GraphNodeKey key)
        {
            this._connections = new List<GraphEdge>();

            this.Id = Guid.NewGuid();

            this.Name = name ?? throw new ArgumentNullException(nameof(name));

            this.Key = key;
        }

        public Guid Id { get; }

        public string Name { get; }

        public GraphNodeKey Key { get; }

        public IEnumerable<GraphEdge> Connections
        {
            get
            {
                foreach (var connection in this._connections)
                {
                    yield return connection;
                }
            }
        }

        public IEnumerable<GraphNode> Predecessors => this._connections.Where(c => ReferenceEquals(c.TargetNode, this)).Select(c => c.SourceNode);

        public IEnumerable<GraphNode> Successors => this._connections.Where(c => ReferenceEquals(c.SourceNode, this)).Select(c => c.TargetNode);

        internal ulong ObjectNumber { get; set; }

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

            forward.ObjectNumber = ++_edgeCounter;

            this._connections.Add(forward);

            var backward = new GraphEdge(targetNode, this, distance);

            backward.ObjectNumber = ++_edgeCounter;

            if (twoWay)
            {
                this._connections.Add(backward);
            }

            targetNode.AddConnection(forward, backward, twoWay);
        }

        private void AddConnection(GraphEdge forward, GraphEdge backward, bool twoWay)
        {
            this._connections.Add(backward);

            if (twoWay)
            {
                this._connections.Add(forward);
            }
        }
    }
}