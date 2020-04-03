using System.Collections.Generic;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public sealed class Profiles : HashSet<ProfileEntry>
    {
        internal Profiles() : base()
        {
        }

        internal Profiles(IEnumerable<ProfileEntry> collection) : base(collection)
        {
        }
    }
}