using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    internal partial class ResultForm : Form
    {
        private readonly IEnumerable<Steps> _results;

        private readonly BackgroundWorker _worker;

        internal ResultForm(Steps firstResult, IEnumerable<Steps> results)
        {
            _results = results;

            _worker = new BackgroundWorker()
            {
                WorkerSupportsCancellation = true,
            };

            InitializeComponent();

            var firstRow = CreateRow(firstResult);

            ResultListView.Items.Add(firstRow);

            firstRow.Selected = true;

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
                if (isFirstRow)
                {
                    isFirstRow = false;

                    continue;
                }

                if (_worker.CancellationPending)
                {
                    break;
                }

                var row = CreateRow(result);

                ResultListView.Invoke(new Action(() => ResultListView.Items.Add(row)));
            }
        }

        private static ListViewItem CreateRow(Steps result)
        {
            var first = result.GetSteps().First();

            var last = result.GetSteps().Last();

            var subItems = new[] { result.Degree.ToString(), first.Left.Profile.Title, last.Right.Profile.Title };

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

                var rows = steps.GetSteps().Select(GetStepRow).ToArray();

                StepsListView.Items.AddRange(rows);
            }
        }

        private static ListViewItem GetStepRow(Step step)
        {
            var subItems = new[] { step.Left.Profile.Title, PersonFormatter.GetName(step.Left.Person), GetJob(step.Left), PersonFormatter.GetName(step.Right.Person), GetJob(step.Right) };

            var row = new ListViewItem(subItems);

            return row;
        }

        private static string GetJob(ProfileEntry entry)
        {
            if (entry.CastMember != null)
            {
                var result = GetCastJob(entry.CastMember);

                return result;
            }
            else if (entry.CrewMember != null)
            {
                var result = GetCrewJob(entry.CrewMember);

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

            jobBuilder.Append(crewMember.CreditType?.Trim());
            jobBuilder.Append(" / ");
            jobBuilder.Append(crewMember.CreditSubtype?.Trim());

            if (!string.IsNullOrWhiteSpace(crewMember.CustomRole))
            {
                jobBuilder.Append(" (");
                jobBuilder.Append(crewMember.CustomRole.Trim());
                jobBuilder.Append(")");
            }

            if (!string.IsNullOrWhiteSpace(crewMember.CreditedAs))
            {
                jobBuilder.Append(" (as ");
                jobBuilder.Append(crewMember.CreditedAs.Trim());
                jobBuilder.Append(")");
            }

            return jobBuilder.ToString();
        }

        private void OnResultFormFormClosing(object sender, FormClosingEventArgs e)
        {
            _worker.CancelAsync();
        }
    }
}