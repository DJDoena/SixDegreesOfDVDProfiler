using System.IO;
using System.IO.Compression;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SixDegreesOfTesting
{
    [TestClass]
    public class ForwardUnitTestSample
    {
        private static Collection _collection;

        private static Persons _persons;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            const string SampleXml = "sample.xml";

            if (File.Exists(SampleXml))
            {
                File.Delete(SampleXml);
            }

            ZipFile.ExtractToDirectory(@"..\..\..\..\sample_xml.zip", ".");

            _collection = DVDProfilerSerializer<Collection>.Deserialize(SampleXml);

            _persons = (new PersonsBuilder()).Build(_collection.DVDList, true, false);
        }

        [TestMethod]
        public void ToshiroMifuneToTomHollandDegree4()
        {
            var sourcePerson = new SearchPerson(firstName: "Toshirô", lastName: "Mifune", birthYear: 1920);

            var targetPerson = new SearchPerson(firstName: "Tom", lastName: "Holland", birthYear: 1996);

            var results = (new ConnectionFinder(_persons)).FindForward(sourcePerson, targetPerson, 10, 1500000).ToList();

            Assert.AreEqual(18, results.Count);

            var result1 = results[0];

            Assert.AreEqual(4, result1.Degree);

            var steps = result1.GetSteps().ToList();

            Assert.AreEqual(4, steps.Count);

            StepsChecker.Check(sourcePerson, targetPerson, steps);
        }

        [TestMethod]
        public void TomHollandToshiroMifuneDegree4()
        {
            var sourcePerson = new SearchPerson(firstName: "Tom", lastName: "Holland", birthYear: 1996);

            var targetPerson = new SearchPerson(firstName: "Toshirô", lastName: "Mifune", birthYear: 1920);

            var results = (new ConnectionFinder(_persons)).FindForward(sourcePerson, targetPerson, 10, 10000000).ToList();

            Assert.AreEqual(18, results.Count);

            var result1 = results[0];

            Assert.AreEqual(4, result1.Degree);

            var steps = result1.GetSteps().ToList();

            Assert.AreEqual(4, steps.Count);

            StepsChecker.Check(sourcePerson, targetPerson, steps);
        }

        //[TestMethod]
        //public void MaxVonSydowToJohnWayneDegree1()
        //{
        //    var sourcePerson = new SearchPerson(firstName: "Max", lastName: "von Sydow");

        //    var targetPerson = new SearchPerson(firstName: "John", lastName: "Wayne");

        //    var results = SixDegrees.FindForward(_collection.DVDList, sourcePerson, targetPerson, 2, 10000, true, false).ToList();

        //    Assert.AreEqual(1, results.Count);

        //    var result1 = results[0];

        //    Assert.AreEqual(1, result1.Degree);

        //    var steps = result1.GetSteps().ToList();

        //    Assert.AreEqual(1, steps.Count);

        //    StepsChecker.Check(sourcePerson, targetPerson, steps);
        //}

        //[TestMethod]
        //public void JohnWayneToHansAlfredsonDegree2()
        //{
        //    var sourcePerson = new SearchPerson(firstName: "John", lastName: "Wayne");

        //    var targetPerson = new SearchPerson(firstName: "Hans", lastName: "Alfredson");

        //    var results = SixDegrees.FindForward(_collection.DVDList, sourcePerson, targetPerson, 2, 10000, true, false).ToList();

        //    Assert.AreEqual(1, results.Count);

        //    var result1 = results[0];

        //    Assert.AreEqual(2, result1.Degree);

        //    var steps = result1.GetSteps().ToList();

        //    Assert.AreEqual(2, steps.Count);

        //    StepsChecker.Check(sourcePerson, targetPerson, steps);
        //}

        //[TestMethod]
        //public void HansAlfredsonToJohnWayneDegree2()
        //{
        //    var sourcePerson = new SearchPerson(firstName: "Hans", lastName: "Alfredson");

        //    var targetPerson = new SearchPerson(firstName: "John", lastName: "Wayne");

        //    var results = SixDegrees.FindForward(_collection.DVDList, sourcePerson, targetPerson, 2, 10000, true, false).ToList();

        //    Assert.AreEqual(1, results.Count);

        //    var result1 = results[0];

        //    Assert.AreEqual(2, result1.Degree);

        //    var steps = result1.GetSteps().ToList();

        //    Assert.AreEqual(2, steps.Count);

        //    StepsChecker.Check(sourcePerson, targetPerson, steps);
        //}
    }
}
