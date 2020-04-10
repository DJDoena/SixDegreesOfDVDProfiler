using System.Diagnostics;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using mitoSoft.Graphs;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    partial class ProfileNode
    {
        [DebuggerDisplay(nameof(ProfileNodeKey) + " ({ToString()})")]
        private sealed class ProfileNodeKey : GraphNodeKeyBase
        {
            private readonly string _title;

            public ProfileNodeKey(DVD profile)
            {
                _title = BuildTitle(profile);
            }

            public override string GetKeyDisplayValue() => _title;

            public override int GetKeyHashCode() => _title.GetHashCode();

            public override bool KeysAreEqual(GraphNodeKeyBase other)
            {
                if (!(other is ProfileNodeKey pnk))
                {
                    return false;
                }
                else
                {
                    var areEqual = _title.Equals(pnk._title);

                    return areEqual;
                }
            }
        }
    }
}