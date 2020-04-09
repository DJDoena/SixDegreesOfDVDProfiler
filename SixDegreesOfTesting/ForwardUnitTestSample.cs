using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [TestClass]
    public class ForwardUnitTestSample
    {
        private static DistanceGraph _graph;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            const string SampleXml = "sample.xml";

            if (File.Exists(SampleXml))
            {
                File.Delete(SampleXml);
            }

            ZipFile.ExtractToDirectory(@"..\..\..\..\sample_xml.zip", ".");

            var collection = DVDProfilerSerializer<Collection>.Deserialize(SampleXml);

            _graph = GraphBuilder.Build(collection.DVDList);
        }

        [TestMethod]
        public void ToshiroMifuneToTomHollandDegree4()
        {
            DistanceNode sourceNode = new PersonNode(new SearchPerson(firstName: "Toshirô", lastName: "Mifune", birthYear: 1920));
            DistanceNode targetNode = new PersonNode(new SearchPerson(firstName: "Tom", lastName: "Holland", birthYear: 1996));

            var calculator = new DistanceCalculator(_graph);

            var nodeDistance = calculator.CalculateDistancesByDeepFirst(ref sourceNode, ref targetNode);

            var movieDistance = GetRealMovieDistance(nodeDistance);

            Assert.AreEqual(4, movieDistance);

            var stepsList = calculator.GetShortestPath(targetNode).ToList();

            Assert.AreEqual(18, stepsList.Count);

            CheckSteps(sourceNode, targetNode, stepsList, nodeDistance);
        }

        [TestMethod]
        public void ToshiroMifuneToTakashiShimuraDegree1()
        {
            DistanceNode sourceNode = new PersonNode(new SearchPerson(firstName: "Toshirô", lastName: "Mifune", birthYear: 1920));
            DistanceNode targetNode = new PersonNode(new SearchPerson(firstName: "Takashi", lastName: "Shimura", birthYear: 1905));

            var calculator = new DistanceCalculator(_graph);

            var nodeDistance = calculator.CalculateDistancesByDeepFirst(ref sourceNode, ref targetNode);

            var movieDistance = GetRealMovieDistance(nodeDistance);

            Assert.AreEqual(1, movieDistance);

            var stepsList = calculator.GetShortestPath(targetNode).ToList();

            Assert.AreEqual(2, stepsList.Count);

            CheckSteps(sourceNode, targetNode, stepsList, nodeDistance);
        }

        [TestMethod]
        public void TomHollandToToshiroMifuneDegree4()
        {
            DistanceNode sourceNode = new PersonNode(new SearchPerson(firstName: "Tom", lastName: "Holland", birthYear: 1996));
            DistanceNode targetNode = new PersonNode(new SearchPerson(firstName: "Toshirô", lastName: "Mifune", birthYear: 1920));

            var calculator = new DistanceCalculator(_graph);

            var nodeDistance = calculator.CalculateDistancesByDeepFirst(ref sourceNode, ref targetNode);

            var movieDistance = GetRealMovieDistance(nodeDistance);

            Assert.AreEqual(4, movieDistance);

            var stepsList = calculator.GetShortestPath(targetNode).ToList();

            Assert.AreEqual(18, stepsList.Count);

            CheckSteps(sourceNode, targetNode, stepsList, nodeDistance);
        }

        //Hier werden die Filme rausgefiltert
        internal static double GetRealMovieDistance(double nodeDistance)
        {
            return nodeDistance / 2;
        }

        internal static void CheckSteps(DistanceNode sourceNode, DistanceNode targetNode, List<Steps> stepsList, double nodeDistance)
        {
            StepsChecker.Check(stepsList);

            foreach (var steps in stepsList)
            {
                StepsChecker.Check(sourceNode, targetNode, steps, nodeDistance);
            }
        }
    }
}