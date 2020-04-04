using System.Collections;
using System.Collections.Generic;
using DoenaSoft.DVDProfiler.DVDProfilerXML;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public sealed class Persons : IEnumerable<PersonKey>
    {
        private readonly Dictionary<PersonKey, ProfileEntries> _dictionary;

        internal Persons()
        {
            _dictionary = new Dictionary<PersonKey, ProfileEntries>();
        }

        internal bool TryGetValue(PersonKey key, out ProfileEntries value) => _dictionary.TryGetValue(key, out value);

        internal void Add(PersonKey key, ProfileEntries value) => _dictionary.Add(key, value);

        internal ProfileEntries this[PersonKey key] => _dictionary[key];

        IEnumerator<PersonKey> IEnumerable<PersonKey>.GetEnumerator() => _dictionary.Keys.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _dictionary.Keys.GetEnumerator();
    }
}