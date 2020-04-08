using System.Diagnostics;

namespace mitoSoft.Math.Graphs.Dijkstra
{
    [DebuggerDisplay("{Left} - {Right}")]
    public sealed class Step
    {
        public DistanceNode Left { get; }

        public DistanceNode Right { get; }

        internal Step(DistanceNode left, DistanceNode right)
        {
            this.Left = left;

            this.Right = right;
        }
    }
}