using System.Collections.Generic;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using mitoSoft.Math.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public static class GraphBuilder
    {
        public static DistanceGraph Build(IEnumerable<DVD> collection, bool considerCast = true, bool considerCrew = false)
        {
            var graph = new DistanceGraph();

            foreach (var profile in collection)
            {
                DistanceNode profileNode = new ProfileNode(profile);

                graph.TryAddNode(ref profileNode);

                if (considerCast)
                {
                    var castMembers = profile.CastList?.OfType<IPerson>() ?? Enumerable.Empty<IPerson>();

                    AddPersonNodes(graph, profileNode, castMembers);
                }

                if (considerCrew)
                {
                    var crewMembers = profile.CrewList?.OfType<IPerson>() ?? Enumerable.Empty<IPerson>();

                    AddPersonNodes(graph, profileNode, crewMembers);
                }
            }

            return graph;
        }

        private static void AddPersonNodes(DistanceGraph graph, DistanceNode profileNode, IEnumerable<IPerson> people)
        {
            var hashSet = new HashSet<PersonKey>();

            foreach (var person in people)
            {
                DistanceNode personNode = new PersonNode(person);

                graph.TryAddNode(ref personNode);

                var key = new PersonKey(person);

                if (hashSet.Add(key)) //a person can have multiple jobs in the same profiles
                {
                    graph.AddConnection(profileNode, personNode, 1, true);
                }

                ((PersonNode)personNode).AddJob((ProfileNode)profileNode, person);
            }
        }
    }
}