using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using mitoSoft.Graphs;
using mitoSoft.Graphs.Analysis;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    internal partial class ResultForm : Form
    {
        private readonly Graph _resultGraph;

        private readonly IEnumerable<Steps> _results;

        internal ResultForm(Graph resultGraph, DistanceNode resultGraphTargetNode)
        {
            _resultGraph = resultGraph;

            _results = GraphHelper.GetPaths(resultGraphTargetNode); ;

            InitializeComponent();

            Icon = Properties.Resource.djdsoft;

            ShowPeoplesJobInImageToolStripMenuItem.Checked = Properties.Settings.Default.ShowJobs;

            var rows = _results.Select(r => CreateRow(r)).ToArray();

            ResultListView.Items.AddRange(rows);

            if (ResultListView.Items.Count > 0)
            {
                ResultListView.Items[0].Selected = true;
            }
        }

        private static ListViewItem CreateRow(Steps result)
        {
            var degree = (result.Degree / 2).ToString();

            var firstStep = result.GetSteps().Last();

            var lastStep = result.GetSteps().First();

            var firstProfile = (ProfileNode)firstStep.Left.Tag;

            var firstTitle = firstProfile.Profile.Title;

            var lastProfile = (ProfileNode)lastStep.Right.Tag;

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
            var profile = (ProfileNode)firstStep.Left.Tag;

            var title = profile.Profile.Title;

            var leftPerson = (PersonNode)firstStep.Right.Tag;

            var leftName = PersonFormatter.GetName(leftPerson.Person);

            var leftJob = leftPerson.GetJobs(profile).First();

            var leftJobDescription = PersonFormatter.GetJob(leftJob);

            var rightPerson = (PersonNode)secondStep.Left.Tag;

            var rightName = PersonFormatter.GetName(rightPerson.Person);

            var rightJob = rightPerson.GetJobs(profile).First();

            var rightJobDescription = PersonFormatter.GetJob(rightJob);

            var subItems = new[] { title, leftName, leftJobDescription, rightName, rightJobDescription };

            var row = new ListViewItem(subItems);

            return row;
        }

        private void OnWhatIsGraphvizToolStripMenuItemClick(object sender, EventArgs e)
        {
            Process.Start("https://en.wikipedia.org/wiki/Graphviz");
        }

        private void OnDownloadGraphvizToolStripMenuItemClick(object sender, EventArgs e)
        {
            Process.Start("https://graphviz.gitlab.io/_pages/Download/Download_windows.html");
        }

        private void OnConfigureGraphvizToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog()
            {
                CheckFileExists = true,
                Filter = "dot.exe|dot.exe",
                Multiselect = false,
                Title = "Please select the 'dot.exe' in the 'bin' folder of the GraphWiz package.",
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.GraphWizDotExe = ofd.FileName;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void OnRunGraphvizWithResultToolStripMenuItemClick(object sender, EventArgs e)
        {
            var graphWizDotExe = Properties.Settings.Default.GraphWizDotExe;

            if (string.IsNullOrEmpty(graphWizDotExe))
            {
                MessageBox.Show("The path to the GraphWiz package is not configured!", "GraphWiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else if (!File.Exists(graphWizDotExe))
            {
                MessageBox.Show("The GraphWiz package cannot be found at the configured path!", "GraphWiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else
            {
                var graphvizPath = (new FileInfo(graphWizDotExe)).DirectoryName;

                var withJobs = ShowPeoplesJobInImageToolStripMenuItem.Checked;

                (new GraphvizExporter(graphvizPath)).SaveImage(_resultGraph, withJobs);
            }
        }

        private void OnShowPeoplesJobInImageToolStripMenuItemClick(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowJobs = ShowPeoplesJobInImageToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }
    }
}