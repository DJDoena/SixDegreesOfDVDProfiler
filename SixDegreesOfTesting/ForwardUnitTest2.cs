using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SixDegreesOfTesting
{
    [TestClass]
    public class ForwardUnitTest2
    {
        private static Collection _collection;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _collection = DVDProfilerSerializer<Collection>.Deserialize("Test2.xml");
        }

        [TestMethod]
        public void JohnWayneToMaxVonSydowDegree1()
        {
            var sourcePerson = new SearchPerson(firstName: "John", lastName: "Wayne");

            var targetPerson = new SearchPerson(firstName: "Max", lastName: "von Sydow");

            var results = SixDegrees.FindForward(_collection.DVDList, sourcePerson, targetPerson, 10, 10000, true, false).ToList();

            Assert.AreEqual(1, results.Count);

            var result1 = results[0];

            Assert.AreEqual(1, result1.Degree);

            var steps = result1.GetSteps().ToList();

            Assert.AreEqual(1, steps.Count);

            StepsChecker.Check(sourcePerson, targetPerson, steps);
        }

        [TestMethod]
        public void MaxVonSydowToJohnWayneDegree1()
        {
            var sourcePerson = new SearchPerson(firstName: "Max", lastName: "von Sydow");

            var targetPerson = new SearchPerson(firstName: "John", lastName: "Wayne");

            var results = SixDegrees.FindForward(_collection.DVDList, sourcePerson, targetPerson, 10, 10000, true, false).ToList();

            Assert.AreEqual(1, results.Count);

            var result1 = results[0];

            Assert.AreEqual(1, result1.Degree);

            var steps = result1.GetSteps().ToList();

            Assert.AreEqual(1, steps.Count);

            StepsChecker.Check(sourcePerson, targetPerson, steps);
        }

        [TestMethod]
        public void JohnWayneToHansAlfredsonDegree2()
        {
            var sourcePerson = new SearchPerson(firstName: "John", lastName: "Wayne");

            var targetPerson = new SearchPerson(firstName: "Hans", lastName: "Alfredson");

            var results = SixDegrees.FindForward(_collection.DVDList, sourcePerson, targetPerson, 10, 10000, true, false).ToList();

            Assert.AreEqual(1, results.Count);

            var result1 = results[0];

            Assert.AreEqual(2, result1.Degree);

            var steps = result1.GetSteps().ToList();

            Assert.AreEqual(2, steps.Count);

            StepsChecker.Check(sourcePerson, targetPerson, steps);
        }

        [TestMethod]
        public void HansAlfredsonToJohnWayneDegree2()
        {
            var sourcePerson = new SearchPerson(firstName: "Hans", lastName: "Alfredson");

            var targetPerson = new SearchPerson(firstName: "John", lastName: "Wayne");

            var results = SixDegrees.FindForward(_collection.DVDList, sourcePerson, targetPerson, 10, 10000, true, false).ToList();

            Assert.AreEqual(1, results.Count);

            var result1 = results[0];

            Assert.AreEqual(2, result1.Degree);

            var steps = result1.GetSteps().ToList();

            Assert.AreEqual(2, steps.Count);

            StepsChecker.Check(sourcePerson, targetPerson, steps);
        }
    }
}
