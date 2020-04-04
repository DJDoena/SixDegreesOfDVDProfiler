using System;
using System.Collections.Generic;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public static class SixDegrees
    {
        public static IEnumerable<Steps> FindForward(IEnumerable<DVD> collection, IPerson sourcePerson, IPerson targetPerson, byte maxSearchDepth, bool considerCast = true, bool considerCrew = false)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else if (collection.Any(p => p == null))
            {
                throw new ArgumentException("Collection contains profiles that are null", nameof(collection));
            }
            else if (sourcePerson == null)
            {
                throw new ArgumentNullException(nameof(sourcePerson));
            }
            else if (targetPerson == null)
            {
                throw new ArgumentNullException(nameof(targetPerson));
            }

            var persons = (new PersonsBuilder()).Build(collection, considerCast, considerCrew);

            var result = (new ConnectionFinder(persons)).FindForward(sourcePerson, targetPerson, maxSearchDepth);

            return result;
        }
    }
}