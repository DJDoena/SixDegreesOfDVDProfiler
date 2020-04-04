using System;
using System.Linq;
using DoenaSoft.DVDProfiler.DVDProfilerXML;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public static class PersonFormatter
    {
        public static string GetName(IPerson person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            var parts = new[] { person.FirstName, person.MiddleName, person.LastName };

            var relevantParts = parts.Where(p => !string.IsNullOrWhiteSpace(p)).Select(p => p.Trim()).ToArray();

            var name = string.Join(" ", relevantParts);

            if (person.BirthYear > 0)
            {
                name = $"{name} ({person.BirthYear})";
            }

            return name;
        }
    }
}