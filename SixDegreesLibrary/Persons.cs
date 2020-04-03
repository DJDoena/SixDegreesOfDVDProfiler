using System.Collections.Generic;
using DoenaSoft.DVDProfiler.DVDProfilerXML;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public sealed class Persons : Dictionary<PersonKey, Profiles>
    {
        internal Persons() : base()
        {
        }
    }
}