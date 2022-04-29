using mitoSoft.Graphs;
using mitoSoft.Graphs.Analysis;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public sealed class ProfileGraphBuilder : GraphBuilderBase
    {
        protected override void AddEdge(DirectedGraph graph, DistanceNode profileNode, DistanceNode personNode) => graph.AddEdge(profileNode, personNode, 1, true);
    }
}