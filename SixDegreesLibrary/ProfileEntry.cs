using System;
using System.Diagnostics;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    [DebuggerDisplay("{Profile}: {Person}")]
    public sealed class ProfileEntry : IEquatable<ProfileEntry>
    {
        private readonly int _hashCode;

        public DVD Profile { get; }

        public IPerson Person { get; }

        public CastMember CastMember => Person as CastMember;

        public CrewMember CrewMember => Person as CrewMember;

        internal string ProfileId { get; }

        internal string Title { get; }

        internal PersonKey PersonKey { get; }

        internal ProfileEntries CoProfiles { get; }

        internal ProfileEntry(DVD profile, IPerson person)
        {
            Profile = profile;
            Person = person;
            CoProfiles = new ProfileEntries();
            PersonKey = new PersonKey(person);
            ProfileId = Profile.ID;
            Title = BuildTitle(Profile);
            _hashCode = ProfileId.GetHashCode() ^ PersonKey.GetHashCode();
        }

        public override int GetHashCode() => _hashCode;

        public override bool Equals(object obj) => Equals(obj as ProfileEntry);

        public bool Equals(ProfileEntry other) => ProfileId.Equals(other?.ProfileId) && PersonKey.Equals(other?.PersonKey);

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
