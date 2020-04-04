using System.Collections;
using System.Collections.Generic;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public sealed class ProfileEntries : IEnumerable<ProfileEntry>
    {
        private readonly HashSet<ProfileEntry> _hashSet;

        internal ProfileEntries()
        {
            _hashSet = new HashSet<ProfileEntry>();
        }

        internal void Add(ProfileEntry item) => _hashSet.Add(item);

        IEnumerator<ProfileEntry> IEnumerable<ProfileEntry>.GetEnumerator() => _hashSet.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _hashSet.GetEnumerator();
    }
}