using System;
using System.Linq;
using System.Text;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;

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

        public static string GetJob(IPerson person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            if (person is CastMember castMember)
            {
                var result = GetCastJob(castMember);

                return result;
            }
            else if (person is CrewMember crewMember)
            {
                var result = GetCrewJob(crewMember);

                return result;
            }
            else
            {
                return string.Empty;
            }
        }

        private static string GetCastJob(CastMember castMember)
        {
            var jobBuilder = new StringBuilder("Cast: ");

            jobBuilder.Append(castMember.Role.Trim());

            if (castMember.Voice)
            {
                jobBuilder.Append(" (voice)");
            }

            if (castMember.Uncredited)
            {
                jobBuilder.Append(" (uncredited)");
            }

            if (!string.IsNullOrWhiteSpace(castMember.CreditedAs))
            {
                jobBuilder.Append(" (as ");
                jobBuilder.Append(castMember.CreditedAs.Trim());
                jobBuilder.Append(")");
            }

            return jobBuilder.ToString();
        }

        private static string GetCrewJob(CrewMember crewMember)
        {
            var jobBuilder = new StringBuilder("Crew: ");

            if (!string.IsNullOrWhiteSpace(crewMember.CustomRole))
            {
                jobBuilder.Append(crewMember.CustomRole.Trim());
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(crewMember.CreditSubtype)
                    && crewMember.CreditSubtype != "Other")
                {
                    jobBuilder.Append(crewMember.CreditSubtype.Trim());
                }
                else
                {
                    jobBuilder.Append(crewMember.CreditType?.Trim());
                    jobBuilder.Append(" / ");
                    jobBuilder.Append(crewMember.CreditSubtype?.Trim());
                }
            }

            if (!string.IsNullOrWhiteSpace(crewMember.CreditedAs))
            {
                jobBuilder.Append(" (as ");
                jobBuilder.Append(crewMember.CreditedAs.Trim());
                jobBuilder.Append(")");
            }

            return jobBuilder.ToString();
        }
    }
}