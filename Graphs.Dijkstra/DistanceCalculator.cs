using System;
using System.Collections.Generic;
using System.Linq;

namespace mitoSoft.Math.Graphs.Dijkstra
{
    /// <summary>
    /// https://de.wikipedia.org/wiki/Dijkstra-Algorithmus
    /// </summary>
    public class DistanceCalculator
    {
        private readonly DistanceGraph _graph;

        private bool _hasCalculated;

        public DistanceCalculator(DistanceGraph graph)
        {
            _graph = graph ?? throw new ArgumentNullException(nameof(graph));

            _hasCalculated = false;
        }

        public double CalculateDistancesByBreadthFirst(GraphNodeKey sourceNodeKey, GraphNodeKey targetNodeKey, bool equallyWeighted = false)
        {
            Check(sourceNodeKey, targetNodeKey, out var sourceNode, out var targetNode);

            var distance = CalculateDistancesByBreadthFirst(ref sourceNode, ref targetNode, equallyWeighted);

            _hasCalculated = true;

            return distance;
        }

        public double CalculateDistancesByBreadthFirst(ref DistanceNode sourceNode, ref DistanceNode targetNode, bool equallyWeighted = false)
        {
            Check(ref sourceNode, ref targetNode);

            var distance = DoCalculateDistancesByBreadthFirst(sourceNode, targetNode, equallyWeighted);

            _hasCalculated = true;

            return distance;
        }

        public double CalculateDistancesByDeepFirst(GraphNodeKey sourceNodeKey, GraphNodeKey targetNodeKey, int maxDistance = 20)
        {
            Check(sourceNodeKey, targetNodeKey, out var sourceNode, out var targetNode);

            var distance = DoCalculateDistancesByDeepFirst(sourceNode, targetNode, maxDistance);

            _hasCalculated = true;

            return distance;
        }

        public double CalculateDistancesByDeepFirst(ref DistanceNode sourceNode, ref DistanceNode targetNode, int maxDistance = 20)
        {
            Check(ref sourceNode, ref targetNode);

            var distance = DoCalculateDistancesByDeepFirst(sourceNode, targetNode, maxDistance);

            _hasCalculated = true;

            return distance;
        }

        public IEnumerable<Steps> GetShortestPath(DistanceNode targetNode)
        {
            if (!_hasCalculated)
            {
                throw new InvalidOperationException("No calulation has taken place.");
            }

            var result = GetSteps(targetNode, new Steps());

            return result;
        }

        private IEnumerable<Steps> GetSteps(DistanceNode targetNode, Steps steps)
        {
            if (targetNode.DistanceFromStart == 0)
            {
                yield return steps;
            }
            else
            {
                var predecessorNodes = targetNode.GetShortestPathPredecessors();

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

        private double DoCalculateDistancesByBreadthFirst(DistanceNode sourceNode, DistanceNode targetNode, bool equallyWeighted)
        {
            InitializeGraph(sourceNode);

            ProcessGraphByBreadthFirst(targetNode, equallyWeighted);

            return targetNode.DistanceFromStart;
        }

        private double DoCalculateDistancesByDeepFirst(DistanceNode sourceNode, DistanceNode targetNode, int maxDistance)
        {
            InitializeGraph(sourceNode);

            ProcessGraphByDeepFirst(sourceNode, false, maxDistance);

            return targetNode.DistanceFromStart;
        }

        private void ProcessGraphByBreadthFirst(DistanceNode targetNode, bool equallyWeighted)
        {
            var finished = false;

            var queue = _graph.Nodes.Cast<DistanceNode>().ToList();

            while (!finished)
            {
                queue.Sort((left, right) => left.DistanceFromStart.CompareTo(right.DistanceFromStart));

                DistanceNode nextNode = queue.FirstOrDefault(n => !double.IsPositiveInfinity(n.DistanceFromStart));

                if (nextNode != null)
                {
                    //only possible by equally weighted graphs
                    if (equallyWeighted == true && ReferenceEquals(nextNode, targetNode))
                    {
                        finished = true;
                    }

                    UpdateDistance(nextNode);

                    queue.Remove(nextNode);
                }
                else
                {
                    finished = true;
                }
            }
        }

        private void ProcessGraphByDeepFirst(DistanceNode sourceNode, bool finished, int maxDistance)
        {
            foreach (var connection in sourceNode.Connections)
            {
                var targetNode = (DistanceNode)connection.TargetNode;

                var distance = checked(sourceNode.DistanceFromStart + connection.Distance);

                if (distance > maxDistance)
                {
                    //nothing to do
                }
                else if (distance < targetNode.DistanceFromStart)
                {
                    targetNode.SetDistanceFromStart(distance);

                    ProcessGraphByDeepFirst(targetNode, finished, maxDistance);
                }
            }
        }

        private void UpdateDistance(DistanceNode sourceNode)
        {
            foreach (var connection in sourceNode.Connections)
            {
                var node = (DistanceNode)connection.TargetNode;

                var distance = checked(sourceNode.DistanceFromStart + connection.Distance);

                if (distance < node.DistanceFromStart)
                {
                    node.SetDistanceFromStart(distance);
                }
            }
        }

        private void InitializeGraph(DistanceNode sourceNode)
        {
            foreach (DistanceNode node in _graph.Nodes)
            {
                node.ResetDistanceFromStart();
            }

            sourceNode.SetDistanceFromStart(0);
        }

        private void Check(GraphNodeKey sourceNodeKey, GraphNodeKey targetNodeKey, out DistanceNode startNode, out DistanceNode targetNode)
        {
            if (sourceNodeKey == null)
            {
                throw new ArgumentNullException(nameof(sourceNodeKey));
            }

            if (!_graph.TryGetNode(sourceNodeKey, out startNode))
            {
                throw new NodeNotInGraphException(sourceNodeKey);
            }

            if (targetNodeKey == null)
            {
                throw new ArgumentNullException(nameof(targetNodeKey));
            }

            if (!_graph.TryGetNode(targetNodeKey, out targetNode))
            {
                throw new NodeNotInGraphException(targetNodeKey);
            }
        }

        private void Check(ref DistanceNode sourceNode, ref DistanceNode targetNode)
        {
            if (sourceNode == null)
            {
                throw new ArgumentNullException(nameof(sourceNode));
            }
            else if (targetNode == null)
            {
                throw new ArgumentNullException(nameof(targetNode));
            }

            if (!_graph.TryGetNode(sourceNode.Key, out var existingSourceNode))
            {
                throw new NodeNotInGraphException(sourceNode);
            }
            else
            {
                sourceNode = existingSourceNode;
            }

            if (!_graph.TryGetNode(targetNode.Key, out var existingTargetNode))
            {
                throw new NodeNotInGraphException(targetNode);
            }
            else
            {
                targetNode = existingTargetNode;
            }
        }
    }
}