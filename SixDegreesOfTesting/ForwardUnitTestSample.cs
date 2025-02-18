using System.IO.Compression;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using DoenaSoft.ToolBox.Generics;
using mitoSoft.Graphs;
using mitoSoft.Graphs.Analysis;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [TestClass]
    public class ForwardUnitTestSample
    {
        private static DirectedGraph _graph;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            const string SampleXml = "sample.xml";

            if (File.Exists(SampleXml))
            {
                File.Delete(SampleXml);
            }

            ZipFile.ExtractToDirectory(@"..\..\..\..\..\sample_xml.zip", ".");

            var collection = XmlSerializer<Collection>.Deserialize(SampleXml);

            _graph = (new ProfileGraphBuilder()).Build(collection.DVDList);
        }

        [TestMethod]
        public void ToshiroMifuneToTomHollandDegree4()
        {
            var sourcePerson = new SearchPerson(firstName: "Toshirô", lastName: "Mifune", birthYear: 1920);
            var targetPerson = new SearchPerson(firstName: "Tom", lastName: "Holland", birthYear: 1996);

            var sourceNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(sourcePerson));
            var targetNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(targetPerson));

            var calculator = new DeepFirstAlgorithm(_graph);

            var shortestGraph = calculator.GetShortestGraph(sourceNode.Name, targetNode.Name);

            var shortestGraphTargetNode = shortestGraph.GetDistanceNode(PersonNode.BuildNodeName(targetPerson));

            var movieDistance = ForwardUnitTestSample.GetRealMovieDistance(shortestGraphTargetNode);

            Assert.AreEqual(4, movieDistance);

            var stepsList = GraphHelper.GetPaths(shortestGraphTargetNode).ToList();

            Assert.AreEqual(18, stepsList.Count);

            CheckSteps(sourceNode, targetNode, stepsList, movieDistance * 2);
        }

        [TestMethod]
        public void ToshiroMifuneToTakashiShimuraDegree1()
        {
            var sourcePerson = new SearchPerson(firstName: "Toshirô", lastName: "Mifune", birthYear: 1920);
            var targetPerson = new SearchPerson(firstName: "Takashi", lastName: "Shimura", birthYear: 1905);

            var sourceNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(sourcePerson));
            var targetNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(targetPerson));

            var calculator = new DeepFirstAlgorithm(_graph);

            var shortestGraph = calculator.GetShortestGraph(sourceNode.Name, targetNode.Name);

            var shortestGraphTargetNode = shortestGraph.GetDistanceNode(PersonNode.BuildNodeName(targetPerson));

            var movieDistance = ForwardUnitTestSample.GetRealMovieDistance(shortestGraphTargetNode);

            Assert.AreEqual(1, movieDistance);

            var stepsList = GraphHelper.GetPaths(shortestGraphTargetNode).ToList();

            Assert.AreEqual(2, stepsList.Count);

            CheckSteps(sourceNode, targetNode, stepsList, movieDistance * 2);
        }

        [TestMethod]
        public void TomHollandToToshiroMifuneDegree4()
        {
            var sourcePerson = new SearchPerson(firstName: "Tom", lastName: "Holland", birthYear: 1996);
            var targetPerson = new SearchPerson(firstName: "Toshirô", lastName: "Mifune", birthYear: 1920);

            var sourceNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(sourcePerson));
            var targetNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(targetPerson));

            var calculator = new DeepFirstAlgorithm(_graph);

            var shortestGraph = calculator.GetShortestGraph(sourceNode.Name, targetNode.Name);

            var shortestGraphTargetNode = shortestGraph.GetDistanceNode(PersonNode.BuildNodeName(targetPerson));

            var movieDistance = ForwardUnitTestSample.GetRealMovieDistance(shortestGraphTargetNode);

            Assert.AreEqual(4, movieDistance);

            var stepsList = GraphHelper.GetPaths(shortestGraphTargetNode).ToList();

            Assert.AreEqual(18, stepsList.Count);

            CheckSteps(sourceNode, targetNode, stepsList, movieDistance * 2);
        }

        [TestMethod]
        public void ToshiroMifuneToToshiroMifuneDegree0()
        {
            var sourcePerson = new SearchPerson(firstName: "Toshirô", lastName: "Mifune", birthYear: 1920);
            var targetPerson = new SearchPerson(firstName: "Toshirô", lastName: "Mifune", birthYear: 1920);

            var sourceNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(sourcePerson));
            var targetNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(targetPerson));

            var calculator = new DeepFirstAlgorithm(_graph);

            var shortestGraph = calculator.GetShortestGraph(sourceNode.Name, targetNode.Name);

            var shortestGraphTargetNode = shortestGraph.GetDistanceNode(PersonNode.BuildNodeName(targetPerson));

            var movieDistance = shortestGraphTargetNode.Distance;

            Assert.AreEqual(0, movieDistance);

            var stepsList = GraphHelper.GetPaths(shortestGraphTargetNode).ToList();

            Assert.AreEqual(1, stepsList.Count);

            CheckSteps(sourceNode, targetNode, stepsList, movieDistance * 2);
        }

        //Hier werden die Filme rausgefiltert
        internal static double GetRealMovieDistance(DistanceNode targetNode)
        {
            return targetNode.Distance / 2;
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