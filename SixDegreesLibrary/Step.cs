using System.Diagnostics;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [DebuggerDisplay("{Left.Profile}: {Left.Person} - {Right.Person}")]
    public sealed class Step
    {
        public ProfileEntry Left { get; }

        public ProfileEntry Right { get; }

        internal Step(ProfileEntry left, ProfileEntry right)
        {
            Left = left;
            Right = right;
        }
    }
}