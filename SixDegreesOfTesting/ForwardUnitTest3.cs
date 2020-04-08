using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Math.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [TestClass]
    public class ForwardUnitTest3
    {
        private static DistanceGraph _graph;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var fileName = "Test3.xml";

            var collection = DVDProfilerSerializer<Collection>.Deserialize(fileName);

            _graph = GraphBuilder.Build(collection.DVDList, true, true);
        }

        [TestMethod]
        public void TomWellingToGeorgeLucasDegree2()
        {
            DistanceNode sourceNode = new PersonNode(new SearchPerson(firstName: "Tom", lastName: "Welling", birthYear: 1977));
            DistanceNode targetNode = new PersonNode(new SearchPerson(firstName: "George", lastName: "Lucas", birthYear: 1944));

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