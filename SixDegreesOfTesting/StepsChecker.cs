using System.Collections.Generic;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    internal static class StepsChecker
    {
        internal static void Check(IPerson sourcePerson, IPerson targetPerson, List<Step> steps)
        {
            var sourcePersonKey = new PersonKey(sourcePerson);

            var targetPersonKey = new PersonKey(targetPerson);

            CheckRightElementForSourcePerson(sourcePersonKey, steps);

            CheckAllButFirstLeftElementForSourcePerson(sourcePersonKey, steps);

            CheckAllButFirstStepForSourcePersonCoProfiled(sourcePersonKey, steps);

            CheckRightElementForTargetPerson(targetPersonKey, steps);

            CheckAllButLastRightElementForSourcePerson(targetPersonKey, steps);

            CheckAllButLastStepForTargetPersonCoProfiled(targetPersonKey, steps);

            CheckTitles(steps);
        }

        private static void CheckTitles(List<Step> steps)
        {
            var titles = new HashSet<string>();

            foreach (var step in steps)
            {
                if (!titles.Add(step.Left.Title))
                {
                    Assert.Fail("Duplicate title can be found in steps.");
                }
            }
        }

        /// <remarks>
        /// in the last element that person is always a co-profile or else it wouldn't be a step
        /// </remarks>
        private static void CheckAllButLastStepForTargetPersonCoProfiled(PersonKey targetPersonKey, List<Step> steps)
        {
            for (int stepIndex = 0; stepIndex < steps.Count - 1; stepIndex++)
            {
                var step = steps[stepIndex];

                foreach (var coProfile in step.Left.CoProfiles)
                {
                    if (IsPersonMatch(targetPersonKey, coProfile.PersonKey))
                    {
                        Assert.Fail("Target person can be found in left co-profiles.");
                    }
                }

                foreach (var coProfile in step.Right.CoProfiles)
                {
                    if (IsPersonMatch(targetPersonKey, coProfile.PersonKey))
                    {
                        Assert.Fail("Target person can be found in right co-profiles.");
                    }
                }
            }
        }

        private static void CheckAllButLastRightElementForSourcePerson(PersonKey targetPersonKey, List<Step> steps)
        {
            for (int stepIndex = 0; stepIndex < steps.Count - 1; stepIndex++)
            {
                var step = steps[stepIndex];

                var leftPersonKey = step.Right.PersonKey;

                if (IsPersonMatch(targetPersonKey, leftPersonKey))
                {
                    Assert.Fail("Target person can be found in left list.");
                }
            }
        }

        private static void CheckRightElementForTargetPerson(PersonKey targetPersonKey, List<Step> steps)
        {
            for (int stepIndex = 0; stepIndex < steps.Count; stepIndex++)
            {
                var step = steps[stepIndex];

                var rightPersonKey = step.Left.PersonKey;

                if (IsPersonMatch(targetPersonKey, rightPersonKey))
                {
                    Assert.Fail("Target person can be found in right list.");
                }
            }
        }

        /// <remarks>
        /// in the first element that person is always a co-profile or else it wouldn't be a step
        /// </remarks>
        private static void CheckAllButFirstStepForSourcePersonCoProfiled(PersonKey sourcePersonKey, List<Step> steps)
        {
            for (int stepIndex = 1; stepIndex < steps.Count; stepIndex++)
            {
                var step = steps[stepIndex];

                foreach (var coProfile in step.Left.CoProfiles)
                {
                    if (IsPersonMatch(sourcePersonKey, coProfile.PersonKey))
                    {
                        Assert.Fail("Source person can be found in left co-profiles.");
                    }
                }

                foreach (var coProfile in step.Right.CoProfiles)
                {
                    if (IsPersonMatch(sourcePersonKey, coProfile.PersonKey))
                    {
                        Assert.Fail("Source person can be found in right co-profiles.");
                    }
                }
            }
        }

        private static void CheckAllButFirstLeftElementForSourcePerson(PersonKey sourcePersonKey, List<Step> steps)
        {
            for (int stepIndex = 1; stepIndex < steps.Count; stepIndex++)
            {
                var step = steps[stepIndex];

                var leftPersonKey = step.Left.PersonKey;

                if (IsPersonMatch(sourcePersonKey, leftPersonKey))
                {
                    Assert.Fail("Source person can be found in left list.");
                }
            }
        }

        private static void CheckRightElementForSourcePerson(PersonKey sourcePersonKey, List<Step> steps)
        {
            for (int stepIndex = 0; stepIndex < steps.Count; stepIndex++)
            {
                var step = steps[stepIndex];

                var rightPersonKey = step.Right.PersonKey;

                if (IsPersonMatch(sourcePersonKey, rightPersonKey))
                {
                    Assert.Fail("Source person can be found in right list.");
                }
            }
        }

        private static bool IsPersonMatch(PersonKey left, PersonKey right)
        {
            if (left.GetHashCode() != right.GetHashCode())
            {
                return false;
            }
            else
            {
                var equals = left.Equals(right);

                return equals;
            }
        }
    }
}
