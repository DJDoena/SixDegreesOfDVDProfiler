using System;
using DoenaSoft.DVDProfiler.DVDProfilerXML;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public sealed class PersonNotInCollectionException : Exception
    {
        public PersonNotInCollectionException(IPerson person) : base($"{person} was not found in collection.")
        {
        }
    }
}