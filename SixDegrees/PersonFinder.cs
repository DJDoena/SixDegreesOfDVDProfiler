using System;
using System.Collections.Generic;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerXML;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    internal static class PersonFinder
    {
        internal static IEnumerable<PersonKey> Find(IPerson searchFor, Persons searchIn)
        {
            var searchKey = new PersonKey(searchFor);

            var matches = searchIn.Where(p => IsMatch(searchKey, p));

            return matches;
        }

        private static bool IsMatch(PersonKey searchFor, PersonKey searchIn)
        {
            if (!IsMatch(searchFor.FirstName, searchIn.FirstName))
            {
                return false;
            }
            else if (!IsMatch(searchFor.MiddleName, searchIn.MiddleName))
            {
                return false;
            }
            else if (!IsMatch(searchFor.LastName, searchIn.LastName))
            {
                return false;
            }
            else
            {
                var isMatch = IsMatch(searchFor.BirthYear, searchIn.BirthYear);

                return isMatch;
            }
        }

        private static bool IsMatch(string searchFor, string searchIn)
        {
            if (string.IsNullOrWhiteSpace(searchFor))
            {
                return true;
            }
            else
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

        private static bool IsMatch(int searchFor, int searchIn)
        {
            if (searchFor == 0)
            {
                return true;
            }
            else
            {
                var isMatch = searchFor == searchIn;

                return isMatch;
            }
        }
    }
}
