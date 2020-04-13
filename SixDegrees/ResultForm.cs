using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using mitoSoft.Graphs;
using mitoSoft.Graphs.GraphVizInterop;
using mitoSoft.Graphs.ShortestPathAlgorithms;

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

        private void OnWhatIsGraphWizToolStripMenuItemClick(object sender, EventArgs e)
        {
            Process.Start("https://en.wikipedia.org/wiki/Graphviz");
        }

        private void OnDownloadGraphWizToolStripMenuItemClick(object sender, EventArgs e)
        {
            Process.Start("https://graphviz.gitlab.io/_pages/Download/Download_windows.html");
        }

        private void OnConfigureGraphWizToolStripMenuItemClick(object sender, EventArgs e)
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

        private void OnRunGraphWizWithResultToolStripMenuItemClick(object sender, EventArgs e)
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
                try
                {
                    var fileInfo = new FileInfo(graphWizDotExe);

                    TrySaveImage(new ImageRenderer(fileInfo.DirectoryName));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unexpected error: {ex.Message}", "GraphWiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TrySaveImage(ImageRenderer renderer)
        {
            using (var sfd = new SaveFileDialog()
            {
                CheckPathExists = true,
                Filter = "Portable Network Graphic (PNG)|*.png|Scalable Vector Graphics (SVG)|*.svg|Bitmap (BMP)|*.bmp|Tagged Image File Format (TIFF)|*.tiff|JPEG|*.jpg|Graphics Interchange Format (GIF)|*.gif",
                OverwritePrompt = true,
                RestoreDirectory = true,
                ValidateNames = true,
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    SaveImage(renderer, new FileInfo(sfd.FileName));
                }
            }
        }

        private void SaveImage(ImageRenderer renderer, FileInfo fileInfo)
        {
            foreach (var node in _resultGraph.Nodes)
            {
                if (node.Tag is PersonNode personNode)
                {
                    node.Description = PersonFormatter.GetName(personNode.Person);
                }
                else if (node.Tag is ProfileNode profileNode)
                {
                    node.Description = profileNode.Profile.Title;
                }
            }

            foreach (var edge in _resultGraph.Edges)
            {
                edge.Description = string.Empty;
            }

            var dotText = _resultGraph.ToDotText();

            switch (fileInfo.Extension.ToLower())
            {
                case ".png":
                    {
                        renderer.RenderImage(dotText, fileInfo.FullName, mitoSoft.Graphs.GraphVizInterop.Enums.LayoutEngine.dot, mitoSoft.Graphs.GraphVizInterop.Enums.ImageFormat.png);

                        break;
                    }
                case ".svg":
                    {
                        renderer.RenderImage(dotText, fileInfo.FullName, mitoSoft.Graphs.GraphVizInterop.Enums.LayoutEngine.dot, mitoSoft.Graphs.GraphVizInterop.Enums.ImageFormat.svg);

                        break;
                    }

                case ".bmp":
                    {
                        var image = renderer.RenderImage(dotText, mitoSoft.Graphs.GraphVizInterop.Enums.LayoutEngine.dot, mitoSoft.Graphs.GraphVizInterop.Enums.ImageFormat.png);

                        image.Save(fileInfo.FullName, System.Drawing.Imaging.ImageFormat.Bmp);

                        break;
                    }
                case ".tif":
                case ".tiff":
                    {
                        var image = renderer.RenderImage(dotText, mitoSoft.Graphs.GraphVizInterop.Enums.LayoutEngine.dot, mitoSoft.Graphs.GraphVizInterop.Enums.ImageFormat.png);

                        image.Save(fileInfo.FullName, System.Drawing.Imaging.ImageFormat.Tiff);

                        break;
                    }
                case ".jpg":
                case ".jpeg":
                    {
                        renderer.RenderImage(dotText, fileInfo.FullName, mitoSoft.Graphs.GraphVizInterop.Enums.LayoutEngine.dot, mitoSoft.Graphs.GraphVizInterop.Enums.ImageFormat.jpg);

                        break;
                    }
                case ".gif":
                    {
                        var image = renderer.RenderImage(dotText, mitoSoft.Graphs.GraphVizInterop.Enums.LayoutEngine.dot, mitoSoft.Graphs.GraphVizInterop.Enums.ImageFormat.png);

                        image.Save(fileInfo.FullName, System.Drawing.Imaging.ImageFormat.Gif);

                        break;
                    }
                default:
                    {
                        MessageBox.Show($"Unknown file format: {fileInfo.Extension}", "GraphWiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }
            }

            Process.Start(fileInfo.FullName);
        }
    }
}