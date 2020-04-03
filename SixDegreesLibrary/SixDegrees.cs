using System;
using System.Collections.Generic;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public static class SixDegrees
    {
        public static Steps Find(IEnumerable<DVD> collection, IPerson startPerson, IPerson targetPerson, byte maxSearchDepth, bool considerCast = true, bool considerCrew = false)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else if (startPerson == null)
            {
                throw new ArgumentNullException(nameof(startPerson));
            }
            else if (targetPerson == null)
            {
                throw new ArgumentNullException(nameof(targetPerson));
            }

            var persons = (new GraphBuilder()).Build(collection, considerCast, considerCrew);

            var result = (new Finder(persons)).Find(startPerson, targetPerson, maxSearchDepth);

            return result;
        }
    }
}