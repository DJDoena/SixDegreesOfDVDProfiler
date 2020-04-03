using System;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var collection = DVDProfilerSerializer<Collection>.Deserialize(@"D:\DVD Profiler\Collections\DVDs\collection.xml");

            var kevinBacon = new CastMember()
            {
                FirstName = "Kevin",
                LastName = "Bacon",
                BirthYear = 1958,
            };

            var clintEastwood = new CrewMember()
            {
                FirstName = "Clint",
                LastName = "Eastwood",
                BirthYear = 1930,
            };

            var michaelCHall = new CastMember()
            {
                FirstName = "Michael",
                MiddleName = "C.",
                LastName = "Hall",
                BirthYear = 1971,
            };

            var johnLithgow = new CastMember()
            {
                FirstName = "John",
                LastName = "Lithgow",
                BirthYear = 1945,
            };

            var deanCain = new CastMember()
            {
                FirstName = "Dean",
                LastName = "Cain",
                BirthYear = 1966,
            };

            var kevinSmith1963 = new CastMember()
            {
                FirstName = "Kevin",
                LastName = "Smith",
                BirthYear = 1963,
            };

            var kyraSedgwick = new CastMember()
            {
                FirstName = "Kyra",
                LastName = "Sedgwick",
                BirthYear = 1965,
            };

            var kevinSmith1970 = new CastMember()
            {
                FirstName = "Kevin",
                LastName = "Smith",
                BirthYear = 1970,
            };

            var efrainGomez = new CastMember()
            {
                FirstName = "Efrain",
                LastName = "Gomez",
                BirthYear = 35663,
            };

            var trishCook = new CastMember()
            {
                FirstName = "Trish",
                LastName = "Cook",
                BirthYear = 44406,
            };

            var persons = (new GraphBuilder()).Build(collection.DVDList);

            var r1 = (new Finder(persons)).Find(johnLithgow, kevinBacon, 10);
            var r2 = (new Finder(persons)).Find(michaelCHall, kevinBacon, 10);
            var r3 = (new Finder(persons)).Find(clintEastwood, kevinBacon, 10);
            var r4 = (new Finder(persons)).Find(deanCain, kevinBacon, 10);
            var r5 = (new Finder(persons)).Find(kevinSmith1963, kevinBacon, 10);
            var r6 = (new Finder(persons)).Find(kyraSedgwick, kevinBacon, 10);
            var r7 = (new Finder(persons)).Find(kevinSmith1970, kevinBacon, 10);
            var r8 = (new Finder(persons)).Find(efrainGomez, kevinBacon, 10);
            var r9 = (new Finder(persons)).Find(trishCook, kevinBacon, 10);
            var r10 = (new Finder(persons)).Find(efrainGomez, trishCook, 10);
            var r11 = (new Finder(persons)).Find(trishCook, efrainGomez, 10);

            var result = r11.GetSteps().ToList();

            var left = result[0].Left;

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
        }
    }
}
