using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using mitoSoft.Math.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    internal partial class ResultForm : Form
    {
        private readonly IEnumerable<Steps> _results;

        private readonly BackgroundWorker _worker;

        internal ResultForm(IEnumerable<Steps> results)
        {
            _results = results;

            _worker = new BackgroundWorker()
            {
                WorkerSupportsCancellation = true,
            };

            InitializeComponent();

            _worker.DoWork += OnDoWork;
        }

        private void OnResultFormLoad(object sender, EventArgs e)
        {
            _worker.RunWorkerAsync();
        }

        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            var isFirstRow = true;

            foreach (var result in _results)
            {
                if (_worker.CancellationPending)
                {
                    break;
                }

                var row = CreateRow(result);

                ResultListView.Invoke(new Action(() => ResultListView.Items.Add(row)));

                if (isFirstRow)
                {
                    ResultListView.Invoke(new Action(() => row.Selected = true));

                    isFirstRow = false;
                }
            }
        }

        private static ListViewItem CreateRow(Steps result)
        {
            var degree = (result.Degree / 2).ToString();

            var firstStep = result.GetSteps().Last();

            var lastStep = result.GetSteps().First();

            var firstProfile = (ProfileNode)firstStep.Left;

            var firstTitle = firstProfile.Profile.Title;

            var lastProfile = (ProfileNode)lastStep.Right;

            var lastTitle = lastProfile.Profile.Title;

            var subItems = new[] { degree, firstTitle, lastTitle };

            var row = new ListViewItem(subItems)
            {
                Tag = result,
            };

            return row;
        }

        private void OnResultListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            StepsListView.Items.Clear();

            if (ResultListView.SelectedItems.Count > 0)
            {
                var steps = (Steps)ResultListView.SelectedItems[0].Tag;

                var rows = GetStepRows(steps).ToArray();

                StepsListView.Items.AddRange(rows);
            }
        }

        private static IEnumerable<ListViewItem> GetStepRows(Steps steps)
        {
            var stepList = steps.GetSteps().ToList();

            //the list is in reverse point of view of the target

            for (var stepIndex = stepList.Count - 1; stepIndex > 0; stepIndex -= 2)
            {
                var row = CreateRow(stepList[stepIndex], stepList[stepIndex - 1]);

                yield return row;
            }
        }

        private static ListViewItem CreateRow(Step firstStep, Step secondStep)
        {
            var profile = (ProfileNode)firstStep.Left;

            var title = profile.Profile.Title;

            var leftPerson = (PersonNode)firstStep.Right;

            var leftName = PersonFormatter.GetName(leftPerson.Person);

            var leftJob = leftPerson.GetJobs(profile).First();

            var leftJobDescription = PersonFormatter.GetJob(leftJob);

            var rightPerson = (PersonNode)secondStep.Left;

            var rightName = PersonFormatter.GetName(rightPerson.Person);

            var rightJob = rightPerson.GetJobs(profile).First();

            var rightJobDescription = PersonFormatter.GetJob(rightJob);

            var subItems = new[] { title, leftName, leftJobDescription, rightName, rightJobDescription };

            var row = new ListViewItem(subItems);

            return row;
        }

        private void OnResultFormFormClosing(object sender, FormClosingEventArgs e)
        {
            _worker.CancelAsync();
        }
    }
}