using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace mitoSoft.Math.Graphs
{
    [DebuggerDisplay("Graph ({_nodes.Count} nodes)")]
    public class Graph
    {
        private readonly IDictionary<GraphNodeKey, GraphNode> _nodes;

        public Graph()
        {
            _nodes = new Dictionary<GraphNodeKey, GraphNode>();
        }

        public IEnumerable<GraphNode> Nodes
        {
            get
            {
                foreach (var node in _nodes.Values)
                {
                    yield return node;
                }
            }
        }

        public bool TryGetNode(GraphNodeKey nodeKey, out GraphNode node) => _nodes.TryGetValue(nodeKey, out node);

        /// <summary>
        /// Tries to add the given node to the system. If the node already exists, the existing node will be returned.
        /// </summary>
        /// <param name="node">The node to be added or upon return the existing node.</param>
        /// <returns>True when the node was actually added or false when an existing node is returned.</returns>
        public virtual bool TryAddNode(ref GraphNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (_nodes.TryGetValue(node.Key, out var existing))
            {
                node = existing;

                return false;
            }
            else
            {
                _nodes.Add(node.Key, node);

                return true;
            }
        }

        public virtual void AddNode(GraphNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            _nodes.Add(node.Key, node);
        }

        public virtual void AddConnection(GraphNode sourceNode, GraphNode targetNode, double distance, bool twoWay)
        {
            if (sourceNode == null)
            {
                throw new ArgumentNullException(nameof(sourceNode));
            }
            else if (targetNode == null)
            {
                throw new ArgumentNullException(nameof(targetNode));
            }
            else if (!_nodes.ContainsKey(sourceNode.Key))
            {
                throw new NodeNotInGraphException(sourceNode);
            }
            else if (!_nodes.ContainsKey(targetNode.Key))
            {
                throw new NodeNotInGraphException(targetNode);
            }

            sourceNode.AddConnection(targetNode, distance, twoWay);
        }
    }
}