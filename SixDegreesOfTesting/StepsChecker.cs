using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitoSoft.Math.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    internal static class StepsChecker
    {
        internal static void Check(DistanceNode sourcePerson, DistanceNode targetPerson, Steps steps, double nodeDistance)
        {            
            Assert.AreEqual(nodeDistance, steps.Degree);

            var stepList = steps.GetSteps().ToList();

            Assert.AreEqual(nodeDistance, stepList.Count);

            if (stepList.Count == 0)
            {
                return;
            }

            if (!stepList[0].Left.Name.Equals(targetPerson.Name))
            {
                Assert.Fail("Chain starts incorrectly.");
            }

            if (!stepList[stepList.Count - 1].Right.Name.Equals(sourcePerson.Name))
            {
                Assert.Fail("Chain ends incorrectly.");
            }

            CheckTitles(stepList);

            CheckAllButLastElementForSourcePerson(sourcePerson, stepList);

            CheckAllButFirstElementForTargetPerson(targetPerson, stepList);

            CheckForDuplicateNodes(stepList);
        }

        internal static void Check(List<Steps> stepsList)
        {
            if (stepsList.Count == 0)
            {
                return;
            }

            var stepLists = stepsList.Select(sl => sl.GetSteps().ToList()).ToList();

            var degree = stepLists[0].Count;

            if (stepLists.Any(sl => sl.Count != degree))
            {
                Assert.Fail("Not all results have the same degree.");
            }

            var hashSet = new HashSet<StepsKey>();

            foreach (var steps in stepLists)
            {
                var key = new StepsKey(steps);

                if (!hashSet.Add(key))
                {
                    Assert.Fail("Not all results are different.");
                }
            }
        }

        private static void CheckTitles(List<Step> steps)
        {
            var profiles = new HashSet<string>();

            for (int stepIndex = 1; stepIndex < steps.Count - 1; stepIndex += 2)
            {
                var profileNode = steps[stepIndex].Left;

                if (!(profileNode is DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler.ProfileNode))
                {
                    Assert.Fail("Node is not a profile node.");
                }

                if (!profiles.Add(profileNode.Name))
                {
                    Assert.Fail("Duplicate title can be found in steps.");
                }
            }
        }

        private static void CheckAllButLastElementForSourcePerson(DistanceNode sourcePerson, List<Step> steps)
        {
            for (int stepIndex = 0; stepIndex < steps.Count - 1; stepIndex += 2)
            {
                var personNode = steps[stepIndex].Left;

                if (!(personNode is DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler.PersonNode))
                {
                    Assert.Fail("Node is not a person node.");
                }

                if (personNode.Name.Equals(sourcePerson.Name))
                {
                    Assert.Fail("Source person can be found before end.");
                }
            }
        }

        private static void CheckAllButFirstElementForTargetPerson(DistanceNode targetPerson, List<Step> steps)
        {
            for (int stepIndex = 2; stepIndex < steps.Count - 1; stepIndex += 2)
            {
                var personNode = steps[stepIndex].Left;

                if (!(personNode is DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler.PersonNode))
                {
                    Assert.Fail("Node is not a person node.");
                }

                if (personNode.Name.Equals(targetPerson.Name))
                {
                    Assert.Fail("Target person can be found after start.");
                }
            }
        }

        private static void CheckForDuplicateNodes(List<Step> steps)
        {
            if (steps.Count == 0)
            {
                return;
            }

            var ids = new HashSet<Guid>()
            {
                steps[0].Left.Id,
            };

            foreach (var step in steps)
            {
                if (!ids.Add(step.Right.Id))
                {
                    Assert.Fail("Duplicate node Id.");
                }
            }
        }

        private sealed class StepsKey
        {
            private readonly List<Step> _steps;

            private readonly int _hashCode;

            public StepsKey(List<Step> steps)
            {
                _steps = steps;

                if (steps.Count == 0)
                {
                    _hashCode = 0;
                }
                else
                {
                    var firstStep = steps[0];

                    _hashCode = firstStep.Left.Name.GetHashCode() ^ firstStep.Right.Name.GetHashCode();

                    for (var stepIndex = 1; stepIndex < steps.Count; stepIndex++)
                    {
                        var step = steps[stepIndex];

                        _hashCode ^= step.Left.Name.GetHashCode() ^ step.Right.Name.GetHashCode();
                    }
                }
            }

            public override int GetHashCode() => _hashCode;

            public override bool Equals(object obj)
            {
                if (!(obj is StepsKey other))
                {
                    return false;
                }

                if (_steps.Count != other._steps.Count)
                {
                    return false;
                }

                var areEqual = true;

                for (var stepIndex = 1; stepIndex < _steps.Count; stepIndex++)
                {
                    var thisStep = _steps[stepIndex];

                    var otherStep = other._steps[stepIndex];

                    if (!thisStep.Left.Name.Equals(otherStep.Left.Name))
                    {
                        areEqual = false;

                        break;
                    }
                    else if (!thisStep.Right.Name.Equals(otherStep.Right.Name))
                    {
                        areEqual = false;

                        break;
                    }
                }

                return areEqual;
            }
        }
    }
}