using System;
using System.Collections.Generic;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using mitoSoft.Graphs;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler.Profile
{
    internal static class Finder
    {
        internal static IEnumerable<DVD> Find(string searchFor, DirectedGraph searchIn)
        {
            var matches = searchIn.Nodes
                .OfType<ProfileNode>()
                .Where(node => IsMatch(searchFor, node))
                .Select(node => node.Profile);

            return matches;
        }

        private static bool IsMatch(string searchFor, ProfileNode searchIn)
        {
            if (IsMatch(searchFor, searchIn.Profile.Title))
            {
                return true;
            }
            else
            {
                var isMatch = IsMatch(searchFor, searchIn.Profile.OriginalTitle);

                return isMatch;
            }
        }

        private static bool IsMatch(string searchFor, string searchIn)
        {
            if (searchIn == null)
            {
                searchIn = string.Empty;
            }

            searchFor = searchFor.Trim();

            var indexOf = searchIn.IndexOf(searchFor, StringComparison.InvariantCultureIgnoreCase);

            var isMatch = indexOf >= 0;

            return isMatch;
        }
    }
}