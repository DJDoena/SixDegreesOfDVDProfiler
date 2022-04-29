using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using mitoSoft.Graphs;
using mitoSoft.Graphs.Analysis;
using mitoSoft.Graphs.Analysis.Exceptions;
using mitoSoft.Graphs.Exceptions;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler.Profile
{
    internal partial class FindForm : Form
    {
        private IEnumerable<DVD> _collection;

        private DirectedGraph _graph;

        internal FindForm()
        {
            this.InitializeComponent();

            this.Icon = Properties.Resource.djdsoft;

            this.Collection = null;

            this.Graph = null;

            MaxSearchDepthUpDown.Maximum = byte.MaxValue;
        }

        private DirectedGraph Graph
        {
            get => _graph;
            set
            {
                _graph = value;

                this.SwitchControls(value != null);
            }
        }

        private IEnumerable<DVD> Collection
        {
            get
            {
                if (_collection == null)
                {
                    return _collection;
                }
                else if (OnlyIncludeOwnedProfilesCheckBox.Checked)
                {
                    var result = _collection.Where(p => p.CollectionType?.IsPartOfOwnedCollection == true);

                    return result;
                }
                else
                {
                    return _collection;
                }
            }
            set => _collection = value;
        }

        private void SwitchControls(bool enabled)
        {
            LeftLookupTitleButton.Enabled = enabled;
            RightLookupTitleButton.Enabled = enabled;
            StartShortSearchButton.Enabled = enabled;
        }

        private void OnLoadXmlButtonClick(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog()
            {
                CheckFileExists = true,
                Filter = "Collection XML files|*.xml",
                Multiselect = false,
                RestoreDirectory = true,
                Title = "Please select your DVD Profiler collection XML file",
            })
            {
                var lastUsedFile = Properties.Settings.Default.LastUsedCollectionFile;

                if (!string.IsNullOrEmpty(lastUsedFile) && File.Exists(lastUsedFile))
                {
                    var fi = new FileInfo(lastUsedFile);

                    ofd.InitialDirectory = fi.DirectoryName;
                    ofd.FileName = fi.Name;
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.Collection = null;

                    this.Graph = null;

                    this.Enabled = false;

                    try
                    {
                        this.TryLoad(ofd.FileName);

                        Properties.Settings.Default.LastUsedCollectionFile = ofd.FileName;
                        Properties.Settings.Default.Save();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Enabled = true;
                    }
                }
            }
        }

        private void TryLoad(string fileName)
        {
            var collection = DVDProfilerSerializer<Collection>.Deserialize(fileName);

            this.Collection = collection.DVDList;

            if (this.Collection != null)
            {
                ProfilesLoadedLabel.Text = $"{collection.DVDList.Length:#,0} profiles loaded.";

                this.BuildPersons();
            }
            else
            {
                ProfilesLoadedLabel.Text = string.Empty;

                MessageBox.Show("Collection does not contain any profiles.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BuildPersons()
        {
            if (this.Collection != null)
            {
                this.Enabled = false;

                this.Graph = (new ProfileGraphBuilder()).Build(this.Collection, IncludeCastCheckBox.Checked, IncludeCrewCheckBox.Checked);

                this.Enabled = true;
            }
        }

        private void OnIncludeCastCheckBoxCheckedChanged(object sender, EventArgs e) => this.BuildPersons();

        private void OnIncludeCrewCheckBoxCheckedChanged(object sender, EventArgs e) => this.BuildPersons();

        private void OnOnlyIncludeOwnedProfilesCheckBoxCheckedChanged(object sender, EventArgs e) => this.BuildPersons();

        private void OnLeftLookupTitleButtonClick(object sender, EventArgs e) => this.LookUpTitleAndSet(LeftTitleTextBox);

        private void OnRightLookupTitleButtonClick(object sender, EventArgs e) => this.LookUpTitleAndSet(RightTitleTextBox);

        private void LookUpTitleAndSet(TextBox titleTextBox)
        {
            var profile = this.LookUpTitle(titleTextBox);

            if (profile != null)
            {
                titleTextBox.Text = profile.Title;
            }
        }

        private DVD LookUpTitle(TextBox titleTextBox)
        {
            var matches = Finder.Find(titleTextBox.Text, this.Graph).ToList();

            if (matches.Count == 1)
            {
                return matches[0];
            }
            else
            {
                using (var lookUpForm = new LookUpForm(titleTextBox.Text, this.Graph))
                {
                    if (lookUpForm.ShowDialog() == DialogResult.OK)
                    {
                        return lookUpForm.Match;
                    }
                }
            }

            return null;
        }

        private void OnStartShortSearchButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LeftTitleTextBox.Text))
            {
                MessageBox.Show("Left title is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else if (string.IsNullOrWhiteSpace(RightTitleTextBox.Text))
            {
                MessageBox.Show("Right title is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            this.Enabled = false;

            try
            {
                this.Find();
            }
            catch (NodeNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void Find()
        {
            var leftProfile = this.LookUpTitle(LeftTitleTextBox);

            var rightProfile = this.LookUpTitle(RightTitleTextBox);

            if (leftProfile == null)
            {
                MessageBox.Show("Left title could not be found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rightProfile == null)
            {
                MessageBox.Show("Right title could not be found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var leftProfileNode = _graph.GetDistanceNode(ProfileNode.BuildNodeName(leftProfile));

            var rightProfileNode = _graph.GetDistanceNode(ProfileNode.BuildNodeName(rightProfile));

            DirectedGraph resultGraph;
            try
            {
                resultGraph = (new DeepFirstAlgorithm(this.Graph, (int)(MaxSearchDepthUpDown.Value * 2))).GetShortestGraph(leftProfileNode, rightProfileNode);
            }
            catch (PathNotFoundException)
            {
                MessageBox.Show("No connection found.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (resultGraph.Nodes.Count() == 1)
            {
                MessageBox.Show("Left and right are the same title. Their degree of separation is: 0", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var resultGraphTargetNode = resultGraph.GetDistanceNode(rightProfileNode.Name);

                using (var resultForm = new ResultForm(resultGraph, resultGraphTargetNode))
                {
                    resultForm.ShowDialog();
                }
            }
        }
    }
}