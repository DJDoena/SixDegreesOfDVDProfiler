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

        internal PersonKey PersonKey { get; }

        internal Profiles CoProfiles { get; }

        internal ProfileEntry(DVD profile, IPerson person)
        {
            Profile = profile;
            Person = person;
            CoProfiles = new Profiles();
            PersonKey = new PersonKey(person);
            _hashCode = Profile.ID.GetHashCode() ^ PersonKey.GetHashCode();
        }

        public override int GetHashCode() => _hashCode;

        public override bool Equals(object obj) => Equals(obj as ProfileEntry);

        public bool Equals(ProfileEntry other) => Profile.ID.Equals(other?.Profile.ID) && PersonKey.Equals(other?.PersonKey);
    }
}
