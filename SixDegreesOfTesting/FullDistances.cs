using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Graphs;
using mitoSoft.Graphs.ShortestPathAlgorithms;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{   
    [TestClass]
    public class FullDistances
    {
        private static Graph _graph;

        private object _threadLock;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            const string SampleXml = "sample.xml";

            if (File.Exists(SampleXml))
            {
                File.Delete(SampleXml);
            }

            System.IO.Compression.ZipFile.ExtractToDirectory(@"..\..\..\..\sample_xml.zip", ".");

            var collection = DVDProfilerSerializer<Collection>.Deserialize(SampleXml);

            _graph = GraphBuilder.Build(collection.DVDList);
        }

        [TestCategory("Long Running")]
        [TestMethod]
        public void FullTestWithWinner()
        {
            _threadLock = new object();

            var startNodes = _graph.Nodes.Where(n => n.Tag is PersonNode).ToList();

            var maxUndefined = -1;

            var minUndefined = int.MaxValue;

            var maxMaxDistance = -1d;

            var minMaxDistance = double.PositiveInfinity;

            const int MaxParallel = 8;

            for (var nodeIndex = 0; nodeIndex < startNodes.Count;)
            {
                var tasks = new List<Task>(MaxParallel);

                for (var taskIndex = 0; taskIndex < MaxParallel && nodeIndex < startNodes.Count; taskIndex++, nodeIndex++)
                {
                    var startNode = startNodes[nodeIndex];

                    var task = Task.Run(() => GetAllDistancesWithWinner(ref maxUndefined, ref minUndefined, ref maxMaxDistance, ref minMaxDistance, startNode));

                    tasks.Add(task);
                }

                Task.WaitAll(tasks.ToArray());
            }
        }

        [TestMethod]
        public void SylvesterStallone()
        {
            var actor = new SearchPerson(firstName: "Sylvester", lastName: "Stallone", birthYear: 1946);

            var startNode = _graph.Nodes.First(n => n.Name == PersonNode.BuildNodeName(actor));

            var results = (new DeepFirstAlgorithm(_graph)).GetAllDistances(startNode);

            var distances = results.Values.Where(d => d > 2 && d < double.PositiveInfinity).ToList();

            var maxDistance = distances.Max();

            var maxDistances = results.Where(kvp => kvp.Value == maxDistance).ToList();
        }

        [TestMethod]
        public void AudreyDana()
        {
            var actor = new SearchPerson(firstName: "Audrey", lastName: "Dana", birthYear: 1977);

            var startNode = _graph.Nodes.First(n => n.Name == PersonNode.BuildNodeName(actor));

            var results = (new DeepFirstAlgorithm(_graph)).GetAllDistances(startNode);

            var distances = results.Values.Where(d => d > 2 && d < double.PositiveInfinity).ToList();

            var maxDistance = distances.Max();

            var maxDistances = results.Where(kvp => kvp.Value == maxDistance).ToList();
        }

        [TestMethod]
        public void EricElmosnino()
        {
            var actor = new SearchPerson(firstName: "Eric", lastName: "Elmosnino", birthYear: 1964);

            var startNode = _graph.Nodes.First(n => n.Name == PersonNode.BuildNodeName(actor));

            var results = (new DeepFirstAlgorithm(_graph)).GetAllDistances(startNode);

            var distances = results.Values.Where(d => d > 2 && d < double.PositiveInfinity).ToList();

            var maxDistance = distances.Max();

            var maxDistances = results.Where(kvp => kvp.Value == maxDistance).ToList();
        }

        private void GetAllDistancesWithWinner(ref int maxUndefined, ref int minUndefined, ref double maxMaxDistance, ref double minMaxDistance, GraphNode startNode)
        {
            var results = (new DeepFirstAlgorithm(_graph)).GetAllDistances(startNode);

            var distances = results.Values.Where(d => d > 2 && d < double.PositiveInfinity).ToList();

            var numMaxDistance = distances.Any()
                ? distances.Max()
                : (double?)null;

            var numUndefined = distances.Any()
                ? results.Values.Where(d => d == double.PositiveInfinity).Count()
                : (int?)null;

            lock (_threadLock)
            {
                CheckNewWinner(ref maxUndefined, ref minUndefined, ref maxMaxDistance, ref minMaxDistance, startNode, numUndefined, numMaxDistance);
            }
        }

        private static void CheckNewWinner(ref int maxUndefined, ref int minUndefined, ref double maxMaxDistance, ref double minMaxDistance, GraphNode startNode, int? numUndefined, double? numMaxDistance)
        {
            if ((numUndefined.HasValue && numUndefined > maxUndefined)
                || (numUndefined.HasValue && numUndefined < minUndefined)
                || (numMaxDistance.HasValue && numMaxDistance.Value > maxMaxDistance)
                || (numMaxDistance.HasValue && numMaxDistance.Value < minMaxDistance))
            {
                var person = ((PersonNode)startNode.Tag).Person;

                var name = PersonFormatter.GetName(person);

                if (numUndefined.HasValue && numUndefined > maxUndefined)
                {
                    maxUndefined = numUndefined.Value;

                    Trace.WriteLine($"new max undefined: {name}: {maxUndefined}");
                }

                if (numUndefined.HasValue && numUndefined < minUndefined)
                {
                    minUndefined = numUndefined.Value;

                    Trace.WriteLine($"new min undefined: {name}: {minUndefined}");
                }

                if (numMaxDistance.HasValue && numMaxDistance.Value > maxMaxDistance)
                {
                    maxMaxDistance = numMaxDistance.Value;

                    Trace.WriteLine($"new max max distance: {name}: {maxMaxDistance}");
                }

                if (numMaxDistance.HasValue && numMaxDistance < minMaxDistance)
                {
                    minMaxDistance = numMaxDistance.Value;

                    Trace.WriteLine($"new min max distance: {name}: {minMaxDistance}");
                }
            }
        }

        private void ExportFile(GraphNode startNode, IDictionary<string, double> results)
        {
            var fileName = MakeFileName(startNode.Name);

            using (var sw = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                var sourcePerson = ((PersonNode)startNode.Tag).Person;

                sw.WriteLine(PersonFormatter.GetName(sourcePerson));
                sw.WriteLine();

                var relevantResults = results.Where(kvp => kvp.Value != double.PositiveInfinity).OrderByDescending(kvp => kvp.Value);

                foreach (var kvp in relevantResults)
                {
                    var targetNode = _graph.GetNode(kvp.Key);

                    if (targetNode.Tag is PersonNode targetPersonNode)
                    {
                        var targetPerson = targetPersonNode.Person;

                        sw.WriteLine($"{PersonFormatter.GetName(targetPerson)}: {kvp.Value / 2}");
                    }
                }

            }
        }

        private string MakeFileName(string name)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '_');
            }

            return $"{name}.txt";
        }
    }
}