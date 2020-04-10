using System.Diagnostics;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using mitoSoft.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [DebuggerDisplay(nameof(ProfileNode) + " ({ToString()})")]
    public sealed partial class ProfileNode : DistanceNode
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
    }
}