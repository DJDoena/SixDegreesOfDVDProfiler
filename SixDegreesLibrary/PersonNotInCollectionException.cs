using System;
using DoenaSoft.DVDProfiler.DVDProfilerXML;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public sealed class PersonNotInCollectionException : Exception
    {
        public IPerson Person { get; }

        internal PersonNotInCollectionException(IPerson person) : base($"{PersonFormatter.GetName(person)} was not found in collection.")
        {
            Person = person;
        }
    }
}