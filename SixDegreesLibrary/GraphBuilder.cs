using System.Collections.Generic;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using mitoSoft.Graphs;
using mitoSoft.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public static class GraphBuilder
    {
        public static DistanceGraph Build(IEnumerable<DVD> collection, bool considerCast = true, bool considerCrew = false)
        {
            var graph = new DistanceGraph(true);

            var duplicateChecker = new Dictionary<GraphNodeKeyBase, HashSet<GraphNodeKeyBase>>(); //for multiple movies with the same people we con't want to add multiple connections

            foreach (var profile in collection)
            {
                DistanceNode profileNode = new ProfileNode(profile);

                if (graph.TryAddNode(ref profileNode))
                {
                    duplicateChecker.Add(profileNode.Key, new HashSet<GraphNodeKeyBase>());
                }

                if (considerCast)
                {
                    var castMembers = profile.CastList?.OfType<IPerson>() ?? Enumerable.Empty<IPerson>();

                    AddPersonNodes(graph, profileNode, castMembers, duplicateChecker[profileNode.Key]);
                }

                if (considerCrew)
                {
                    var crewMembers = profile.CrewList?.OfType<IPerson>() ?? Enumerable.Empty<IPerson>();

                    AddPersonNodes(graph, profileNode, crewMembers, duplicateChecker[profileNode.Key]);
                }
            }

            return graph;
        }

        private static void AddPersonNodes(DistanceGraph graph, DistanceNode profileNode, IEnumerable<IPerson> people, HashSet<GraphNodeKeyBase> duplicateChecker)
        {
            foreach (var person in people)
            {
                DistanceNode personNode = new PersonNode(person);

                graph.TryAddNode(ref personNode);

                if (duplicateChecker.Add(personNode.Key)) //a person can have multiple jobs in the same profiles
                {
                    graph.AddConnection(profileNode, personNode, 1);
                }

                ((PersonNode)personNode).AddJob((ProfileNode)profileNode, person);
            }
        }
    }
}