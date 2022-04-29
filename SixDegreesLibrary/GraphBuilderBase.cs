using System.Collections.Generic;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using mitoSoft.Graphs;
using mitoSoft.Graphs.Analysis;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public abstract class GraphBuilderBase
    {
        public DirectedGraph Build(IEnumerable<DVD> collection, bool considerCast = true, bool considerCrew = false)
        {
            var graph = new DirectedGraph();

            var duplicateChecker = new Dictionary<string, HashSet<string>>(); //for multiple movies with the same people we con't want to add multiple connections

            foreach (var profile in collection)
            {
                if (!graph.TryGetDistanceNode(ProfileNode.BuildNodeName(profile), out var profileNode))
                {
                    profileNode = new ProfileNode(profile);

                    graph.AddNode(profileNode);

                    duplicateChecker.Add(profileNode.Name, new HashSet<string>());
                }

                if (considerCast)
                {
                    var castMembers = profile.CastList?.OfType<IPerson>() ?? Enumerable.Empty<IPerson>();

                    this.AddPersonNodes(graph, profileNode, castMembers, duplicateChecker[profileNode.Name]);
                }

                if (considerCrew)
                {
                    var crewMembers = profile.CrewList?.OfType<IPerson>() ?? Enumerable.Empty<IPerson>();

                    this.AddPersonNodes(graph, profileNode, crewMembers, duplicateChecker[profileNode.Name]);
                }
            }

            return graph;
        }

        private void AddPersonNodes(DirectedGraph graph, DistanceNode profileNode, IEnumerable<IPerson> people, HashSet<string> duplicateChecker)
        {
            foreach (var person in people)
            {
                if (!graph.TryGetDistanceNode(PersonNode.BuildNodeName(person), out var personNode))
                {
                    personNode = new PersonNode(person);

                    graph.AddNode(personNode);
                }

                if (duplicateChecker.Add(personNode.Name)) //a person can have multiple jobs in the same profiles
                {
                    this.AddEdge(graph, profileNode, personNode);
                }

                ((PersonNode)personNode).AddJob((ProfileNode)profileNode, person);
            }
        }

        protected abstract void AddEdge(DirectedGraph graph, DistanceNode profileNode, DistanceNode personNode);
    }
}