using DoenaSoft.DVDProfiler.DVDProfilerXML;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public sealed class SearchPerson : IPerson
    {
        private string _firstName;

        private string _middleName;

        private string _lastName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value?.Trim() ?? string.Empty;
            }
        }


        public string MiddleName
        {
            get => _middleName;
            set
            {
                _middleName = value?.Trim() ?? string.Empty;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value?.Trim() ?? string.Empty;
            }
        }

        public int BirthYear { get; set; }

        public string CreditedAs { get; set; }

        public SearchPerson(string firstName, string middleName = "", string lastName = "", int birthYear = 0)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.BirthYear = birthYear;
        }

        public override string ToString() => PersonFormatter.GetName(this);
    }
}