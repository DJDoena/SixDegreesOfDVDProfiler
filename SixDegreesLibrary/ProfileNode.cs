using System.Diagnostics;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using mitoSoft.Math.Graphs;
using mitoSoft.Math.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [DebuggerDisplay("{Profile}")]
    public sealed class ProfileNode : DistanceNode
    {
        public ProfileNode(DVD profile) : base(BuildTitle(profile), new ProfileNodeKey(profile))
        {
            Profile = profile;
        }

        public DVD Profile { get; }

        private static string BuildTitle(DVD profile)
        {
            var title = profile.Title?.Trim() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(profile.OriginalTitle))
            {
                title = profile.OriginalTitle.Trim();
            }

            if (profile.ProductionYear > 0)
            {
                title = $"{title} ({profile.ProductionYear})";
            }

            return title;
        }

        private sealed class ProfileNodeKey : GraphNodeKey
        {
            private readonly string _title;

            public ProfileNodeKey(DVD profile)
            {
                _title = BuildTitle(profile);
            }

            public override string GetKeyDisplayValue() => _title;

            public override int GetKeyHashCode() => _title.GetHashCode();

            public override bool KeysAreEqual(GraphNodeKey other)
            {
                if (!(other is ProfileNodeKey pnk))
                {
                    return false;
                }

                var areEqual = _title.Equals(pnk._title);

                return areEqual;
            }
        }
    }
}
