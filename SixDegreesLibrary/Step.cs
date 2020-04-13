using System.Diagnostics;
using mitoSoft.Graphs.ShortestPathAlgorithms;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [DebuggerDisplay(nameof(Step) + " ({ToString()})")]
    public sealed class Step
    {
        public DistanceNode Left { get; }

        public DistanceNode Right { get; }

        internal Step(DistanceNode left, DistanceNode right)
        {
            this.Left = left;

            this.Right = right;
        }

        public override string ToString() => $"{this.Left} -> {this.Right}";
    }
}
