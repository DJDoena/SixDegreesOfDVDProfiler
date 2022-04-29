using mitoSoft.Graphs;
using mitoSoft.Graphs.Analysis;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public sealed class PersonGraphBuilder : GraphBuilderBase
    {
        protected override void AddEdge(DirectedGraph graph, DistanceNode profileNode, DistanceNode personNode) => graph.AddEdge(personNode, profileNode, 1, true);
    }
}