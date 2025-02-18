using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using DoenaSoft.ToolBox.Generics;
using mitoSoft.Graphs;
using mitoSoft.Graphs.Analysis;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [TestClass]
    public class ForwardUnitTest3
    {
        private static DirectedGraph _graph;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var fileName = "Test3.xml";

            var collection = XmlSerializer<Collection>.Deserialize(fileName);

            _graph = (new ProfileGraphBuilder()).Build(collection.DVDList, true, true);
        }

        [TestMethod]
        public void TomWellingToGeorgeLucasDegree2Deep()
        {
            var sourcePerson = new SearchPerson(firstName: "Tom", lastName: "Welling", birthYear: 1977);
            var targetPerson = new SearchPerson(firstName: "George", lastName: "Lucas", birthYear: 1944);

            var sourceNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(sourcePerson));
            var targetNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(targetPerson));

            var calculator = new DeepFirstAlgorithm(_graph);

            var shortestGraph = calculator.GetShortestGraph(sourceNode.Name, targetNode.Name);

            var shortestGraphTargetNode = shortestGraph.GetDistanceNode(PersonNode.BuildNodeName(targetPerson));

            var movieDistance = ForwardUnitTestSample.GetRealMovieDistance(shortestGraphTargetNode);

            Assert.AreEqual(2, movieDistance);

            var stepsList = GraphHelper.GetPaths(shortestGraphTargetNode).ToList();

            Assert.AreEqual(1, stepsList.Count);

            ForwardUnitTestSample.CheckSteps(sourceNode, targetNode, stepsList, movieDistance * 2);
        }
    }
}