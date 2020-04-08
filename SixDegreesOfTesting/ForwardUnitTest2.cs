using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Math.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [TestClass]
    public class ForwardUnitTest2
    {
        private static DistanceGraph _graph;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var fileName = "Test2.xml";

            var collection = DVDProfilerSerializer<Collection>.Deserialize(fileName);

            _graph = GraphBuilder.Build(collection.DVDList);
        }

        [TestMethod]
        public void Test1()
        {
            DistanceNode sourceNode = new PersonNode(new SearchPerson(firstName: "Max", lastName: "von Sydow"));
            DistanceNode targetNode = new PersonNode(new SearchPerson(firstName: "Pat", lastName: "Boone"));

            var calculator = new DistanceCalculator(_graph);

            var nodeDistance1 = calculator.CalculateDistancesByDeepFirst(ref sourceNode, ref targetNode);
            var nodeDistance2 = calculator.CalculateDistancesByBreadthFirst(ref sourceNode, ref targetNode);

            Assert.AreEqual(nodeDistance1, nodeDistance2);

            var movieDistance = ForwardUnitTestSample.GetRealMovieDistance(nodeDistance1);

            Assert.AreEqual(1, movieDistance);

            var stepsList = calculator.GetShortestPath(targetNode).ToList();

            Assert.AreEqual(1, stepsList.Count);

            ForwardUnitTestSample.CheckSteps(sourceNode, targetNode, stepsList, nodeDistance1);
        }

        [TestMethod]
        public void Test2()
        {
            DistanceNode sourceNode = new PersonNode(new SearchPerson(firstName: "Oscar", lastName: "Ljung"));
            DistanceNode targetNode = new PersonNode(new SearchPerson(firstName: "Pat", lastName: "Boone"));

            var calculator = new DistanceCalculator(_graph);

            var nodeDistance1 = calculator.CalculateDistancesByDeepFirst(ref sourceNode, ref targetNode);
            var nodeDistance2 = calculator.CalculateDistancesByBreadthFirst(ref sourceNode, ref targetNode);

            Assert.AreEqual(nodeDistance1, nodeDistance2);

            var movieDistance = ForwardUnitTestSample.GetRealMovieDistance(nodeDistance1);

            Assert.AreEqual(2, movieDistance);

            var stepsList = calculator.GetShortestPath(targetNode).ToList();

            Assert.AreEqual(1, stepsList.Count);

            ForwardUnitTestSample.CheckSteps(sourceNode, targetNode, stepsList, nodeDistance1);
        }

        [TestMethod]
        public void Test3()
        {
            DistanceNode sourceNode = new PersonNode(new SearchPerson(firstName: "Hans", lastName: "Alfredson"));
            DistanceNode targetNode = new PersonNode(new SearchPerson(firstName: "John", lastName: "Wayne"));

            var calculator = new DistanceCalculator(_graph);

            var nodeDistance1 = calculator.CalculateDistancesByDeepFirst(ref sourceNode, ref targetNode);
            var nodeDistance2 = calculator.CalculateDistancesByBreadthFirst(ref sourceNode, ref targetNode);

            Assert.AreEqual(nodeDistance1, nodeDistance2);

            var movieDistance = ForwardUnitTestSample.GetRealMovieDistance(nodeDistance1);

            Assert.AreEqual(2, movieDistance);

            var stepsList = calculator.GetShortestPath(targetNode).ToList();

            Assert.AreEqual(1, stepsList.Count);

            ForwardUnitTestSample.CheckSteps(sourceNode, targetNode, stepsList, nodeDistance1);
        }

        [TestMethod]
        public void Test4()
        {
            DistanceNode sourceNode = new PersonNode(new SearchPerson(firstName: "John", lastName: "Wayne"));
            DistanceNode targetNode = new PersonNode(new SearchPerson(firstName: "Hans", lastName: "Alfredson"));

            var calculator = new DistanceCalculator(_graph);

            var nodeDistance1 = calculator.CalculateDistancesByDeepFirst(ref sourceNode, ref targetNode);
            var nodeDistance2 = calculator.CalculateDistancesByBreadthFirst(ref sourceNode, ref targetNode);

            Assert.AreEqual(nodeDistance1, nodeDistance2);

            var movieDistance = ForwardUnitTestSample.GetRealMovieDistance(nodeDistance1);

            Assert.AreEqual(2, movieDistance);

            var stepsList = calculator.GetShortestPath(targetNode).ToList();

            Assert.AreEqual(1, stepsList.Count);

            ForwardUnitTestSample.CheckSteps(sourceNode, targetNode, stepsList, nodeDistance1);
        }
    }
}