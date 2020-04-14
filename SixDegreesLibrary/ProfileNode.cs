using System.Diagnostics;
using System.Threading;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using mitoSoft.Graphs.ShortestPathAlgorithms;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [DebuggerDisplay(nameof(ProfileNode) + " ({ToString()})")]
    public sealed partial class ProfileNode : DistanceNode
    {
        public ProfileNode(DVD profile) : base(BuildNodeName(profile))
        {
            Profile = profile;

            Tag = this;
        }

        public DVD Profile { get; }

        public static string BuildNodeName(DVD profile)
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

            return $"Profile: {title.ToLower(Thread.CurrentThread.CurrentUICulture)}";
        }
    }
}