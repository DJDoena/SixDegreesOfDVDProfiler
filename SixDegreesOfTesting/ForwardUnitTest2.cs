using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Graphs;
using mitoSoft.Graphs.Analysis;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [TestClass]
    public class ForwardUnitTest2
    {
        private static DirectedGraph _graph;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var fileName = "Test2.xml";

            var collection = DVDProfilerSerializer<Collection>.Deserialize(fileName);

            _graph = (new ProfileGraphBuilder()).Build(collection.DVDList);
        }

        [TestMethod]
        public void Test1Deep()
        {
            var sourcePerson = new SearchPerson(firstName: "Max", lastName: "von Sydow");
            var targetPerson = new SearchPerson(firstName: "Pat", lastName: "Boone");

            var sourceNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(sourcePerson));
            var targetNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(targetPerson));

            var calculator = new DeepFirstAlgorithm(_graph);

            var shortestGraph = calculator.GetShortestGraph(sourceNode.Name, targetNode.Name);

            var shortestGraphTargetNode = shortestGraph.GetDistanceNode(PersonNode.BuildNodeName(targetPerson));

            var movieDistance = ForwardUnitTestSample.GetRealMovieDistance(shortestGraphTargetNode);

            Assert.AreEqual(1, movieDistance);

            var stepsList = GraphHelper.GetPaths(shortestGraphTargetNode).ToList();

            Assert.AreEqual(1, stepsList.Count);

            ForwardUnitTestSample.CheckSteps(sourceNode, targetNode, stepsList, movieDistance * 2);
        }

        [TestMethod]
        public void Test2Deep()
        {
            var sourcePerson = new SearchPerson(firstName: "Oscar", lastName: "Ljung");
            var targetPerson = new SearchPerson(firstName: "Pat", lastName: "Boone");

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

        [TestMethod]
        public void Test3Deep()
        {
            var sourcePerson = new SearchPerson(firstName: "Hans", lastName: "Alfredson");
            var targetPerson = new SearchPerson(firstName: "John", lastName: "Wayne");

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

        [TestMethod]
        public void Test4Deep()
        {
            var sourcePerson = new SearchPerson(firstName: "John", lastName: "Wayne");
            var targetPerson = new SearchPerson(firstName: "Hans", lastName: "Alfredson");

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