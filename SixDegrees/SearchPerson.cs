using DoenaSoft.DVDProfiler.DVDProfilerXML;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    internal sealed class SearchPerson : IPerson
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int BirthYear { get; set; }

        public string CreditedAs { get; set; }

        public SearchPerson(string firstName, string middleName, string lastname, int birthYear)
        {
            FirstName = firstName?.Trim();
            MiddleName = middleName?.Trim();
            LastName = lastname?.Trim();
            BirthYear = birthYear;
        }

        public override string ToString() => PersonFormatter.GetName(this);
    }
}