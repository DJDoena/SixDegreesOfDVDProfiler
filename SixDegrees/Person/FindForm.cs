﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using DoenaSoft.ToolBox.Generics;
using mitoSoft.Graphs;
using mitoSoft.Graphs.Analysis;
using mitoSoft.Graphs.Analysis.Exceptions;
using mitoSoft.Graphs.Exceptions;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler.Person
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

            LeftBirthYearUpDown.Maximum = ushort.MaxValue;
            RightBirthYearUpDown.Maximum = ushort.MaxValue;
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
            LeftLookupButton.Enabled = enabled;
            RightLookupButton.Enabled = enabled;
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
            var collection = XmlSerializer<Collection>.Deserialize(fileName);

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

        private void OnLeftLookupButtonClick(object sender, EventArgs e) => this.LookUp(LeftFirstNameTextBox, LeftMiddleNameTextBox, LeftLastNameTextBox, LeftBirthYearUpDown);

        private void OnRightLookupButtonClick(object sender, EventArgs e) => this.LookUp(RightFirstNameTextBox, RightMiddleNameTextBox, RightLastNameTextBox, RightBirthYearUpDown);

        private bool LookUp(TextBox firstNameTextBox, TextBox middleNameTextBox, TextBox lastNameTextBox, NumericUpDown birthYearUpDown)
        {
            var searchFor = new SearchPerson(firstNameTextBox.Text, middleNameTextBox.Text, lastNameTextBox.Text, (ushort)birthYearUpDown.Value);

            var matches = Finder.Find(searchFor, this.Graph).ToList();

            if (matches.Count == 1)
            {
                var matchKey = matches[0];

                var matchPerson = new SearchPerson(matchKey.FirstName, matchKey.MiddleName, matchKey.LastName, matchKey.BirthYear);

                SetMatch(matchPerson, firstNameTextBox, middleNameTextBox, lastNameTextBox, birthYearUpDown);

                return true;
            }
            else
            {
                using (var lookUpForm = new LookUpForm(searchFor, this.Graph))
                {
                    if (lookUpForm.ShowDialog() == DialogResult.OK)
                    {
                        SetMatch(lookUpForm.Match, firstNameTextBox, middleNameTextBox, lastNameTextBox, birthYearUpDown);

                        return true;
                    }
                }
            }

            return false;
        }

        private static void SetMatch(IPerson match, TextBox firstNameTextBox, TextBox middleNameTextBox, TextBox lastNameTextBox, NumericUpDown birthYearUpDown)
        {
            firstNameTextBox.Text = match.FirstName;
            middleNameTextBox.Text = match.MiddleName;
            lastNameTextBox.Text = match.LastName;
            birthYearUpDown.Value = match.BirthYear;
        }

        private void OnStartShortSearchButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LeftFirstNameTextBox.Text))
            {
                MessageBox.Show("Left person does not have a first (given) name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else if (string.IsNullOrWhiteSpace(RightFirstNameTextBox.Text))
            {
                MessageBox.Show("Right person does not have a first (given) name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
            if (!this.LookUp(LeftFirstNameTextBox, LeftMiddleNameTextBox, LeftLastNameTextBox, LeftBirthYearUpDown))
            {
                MessageBox.Show("Left person could not be found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!this.LookUp(RightFirstNameTextBox, RightMiddleNameTextBox, RightLastNameTextBox, RightBirthYearUpDown))
            {
                MessageBox.Show("Right person could not be found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var leftPerson = new SearchPerson(LeftFirstNameTextBox.Text, LeftMiddleNameTextBox.Text, LeftLastNameTextBox.Text, (ushort)LeftBirthYearUpDown.Value);

            var rightPerson = new SearchPerson(RightFirstNameTextBox.Text, RightMiddleNameTextBox.Text, RightLastNameTextBox.Text, (ushort)RightBirthYearUpDown.Value);

            var leftNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(leftPerson));

            var rightNode = _graph.GetDistanceNode(PersonNode.BuildNodeName(rightPerson));

            DirectedGraph resultGraph;
            try
            {
                resultGraph = (new DeepFirstAlgorithm(this.Graph, (int)(MaxSearchDepthUpDown.Value * 2))).GetShortestGraph(leftNode, rightNode);
            }
            catch (PathNotFoundException)
            {
                MessageBox.Show("No connection found.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (resultGraph.Nodes.Count() == 1)
            {
                MessageBox.Show("Left and right are the same person. Their degree of separation is: 0", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var resultGraphTargetNode = resultGraph.GetDistanceNode(rightNode.Name);

                using (var resultForm = new ResultForm(resultGraph, resultGraphTargetNode))
                {
                    resultForm.ShowDialog();
                }
            }
        }

        private void OnLeftResetBirthYearCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (LeftResetBirthYearCheckBox.Checked)
            {
                LeftBirthYearUpDown.Value = 0;
            }
        }

        private void OnRightResetBirthYearCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (RightResetBirthYearCheckBox.Checked)
            {
                RightBirthYearUpDown.Value = 0;
            }
        }

        private void OnLeftBirthYearUpDownValueChanged(object sender, EventArgs e) => LeftResetBirthYearCheckBox.Checked = (LeftBirthYearUpDown.Value == 0);

        private void OnRightBirthYearUpDownValueChanged(object sender, EventArgs e) => RightResetBirthYearCheckBox.Checked = (RightBirthYearUpDown.Value == 0);
    }
}