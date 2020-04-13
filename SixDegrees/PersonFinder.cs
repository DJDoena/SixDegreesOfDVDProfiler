using System;
using System.Collections.Generic;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using mitoSoft.Graphs;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    internal static class PersonFinder
    {
        internal static IEnumerable<PersonKey> Find(IPerson searchFor, Graph searchIn)
        {
            var searchKey = new PersonKey(searchFor);

            var matches = searchIn.Nodes.OfType<PersonNode>().Where(node => IsMatch(searchKey, node)).Select(node => new PersonKey(node.Person));

            return matches;
        }

        private static bool IsMatch(PersonKey searchFor, PersonNode searchIn)
        {
            var searchInPerson = searchIn.Person;

            if (!IsMatch(searchFor.FirstName, searchInPerson.FirstName))
            {
                return false;
            }
            else if (!IsMatch(searchFor.MiddleName, searchInPerson.MiddleName))
            {
                return false;
            }
            else if (!IsMatch(searchFor.LastName, searchInPerson.LastName))
            {
                return false;
            }
            else
            {
                var isMatch = IsMatch(searchFor.BirthYear, searchInPerson.BirthYear);

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