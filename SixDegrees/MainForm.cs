using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using mitoSoft.Math.Graphs;
using mitoSoft.Math.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    internal partial class MainForm : Form
    {
        private IEnumerable<DVD> _collection;

        private DistanceGraph _graph;

        internal MainForm()
        {
            InitializeComponent();

            Collection = null;

            Graph = null;

            LeftBirthYearUpDown.Maximum = ushort.MaxValue;
            RightBirthYearUpDown.Maximum = ushort.MaxValue;
            MaxSearchDepthUpDown.Maximum = byte.MaxValue;
            MaxSearchRequestsUpDown.Maximum = uint.MaxValue;
        }

        private DistanceGraph Graph
        {
            get => _graph;
            set
            {
                _graph = value;

                SwitchControls(value != null);
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
            LeftLookupNameButton.Enabled = enabled;
            RightLookupNameButton.Enabled = enabled;
            StartShortSearchButton.Enabled = enabled;
            StartLongSearchButton.Enabled = enabled;
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
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Collection = null;

                    Graph = null;

                    Enabled = false;

                    try
                    {
                        TryLoad(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Enabled = true;
                    }
                }
            }
        }

        private void TryLoad(string fileName)
        {
            var collection = DVDProfilerSerializer<Collection>.Deserialize(fileName);

            Collection = collection.DVDList;

            if (Collection != null)
            {
                BuildPersons();
            }
            else
            {
                MessageBox.Show("Collection does not contain any profiles.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BuildPersons()
        {
            if (Collection != null)
            {
                Enabled = false;

                Graph = GraphBuilder.Build(Collection, IncludeCastCheckBox.Checked, IncludeCrewCheckBox.Checked);

                Enabled = true;
            }
        }

        private void OnIncludeCastCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            BuildPersons();
        }

        private void OnIncludeCrewCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            BuildPersons();
        }

        private void OnOnlyIncludeOwnedProfilesCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            BuildPersons();
        }

        private void OnKevinBaconLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://en.wikipedia.org/wiki/Six_Degrees_of_Kevin_Bacon");
        }

        private void OnSixDegreesLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://en.wikipedia.org/wiki/Six_degrees_of_separation");
        }

        private void OnLeftLookupNameButtonClick(object sender, EventArgs e)
        {
            LookUpName(LeftFirstNameTextBox, LeftMiddleNameTextBox, LeftLastNameTextBox, LeftBirthYearUpDown);
        }

        private void OnRightLookupNameButtonClick(object sender, EventArgs e)
        {
            LookUpName(RightFirstNameTextBox, RightMiddleNameTextBox, RightLastNameTextBox, RightBirthYearUpDown);
        }

        private void LookUpName(TextBox firstNameTextBox, TextBox middleNameTextBox, TextBox lastNameTextBox, NumericUpDown birthYearUpDown)
        {
            var searchFor = new SearchPerson(firstNameTextBox.Text, middleNameTextBox.Text, lastNameTextBox.Text, (ushort)birthYearUpDown.Value);

            var matches = PersonFinder.Find(searchFor, Graph).ToList();

            if (matches.Count == 1)
            {
                var matchKey = matches[0];

                var matchPerson = new SearchPerson(matchKey.FirstName, matchKey.MiddleName, matchKey.LastName, matchKey.BirthYear);

                SetMatch(matchPerson, firstNameTextBox, middleNameTextBox, lastNameTextBox, birthYearUpDown);
            }
            else
            {
                using (var lookUpForm = new LookUpNameForm(searchFor, Graph))
                {
                    if (lookUpForm.ShowDialog() == DialogResult.OK)
                    {
                        SetMatch(lookUpForm.Match, firstNameTextBox, middleNameTextBox, lastNameTextBox, birthYearUpDown);
                    }
                }
            }
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
            Find();
        }

        private void OnStartLongSearchButtonClick(object sender, EventArgs e)
        {
            if (MaxSearchDepthUpDown.Value > 3)
            {
                if (MessageBox.Show("Reverse search may take a long time with a larger depth. Do you really wish to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            //Find((new DistanceCalculator(Graph)).FindReverse);
        }

        private void Find()
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

            Enabled = false;

            try
            {
                TryFind();
            }
            catch (NodeNotInGraphException ex)
            {
                if (ex.Node is PersonNode personNode)
                {
                    var name = PersonFormatter.GetName(personNode.Person);

                    MessageBox.Show($"{name} is not in collection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Key != null)
                {
                    MessageBox.Show($"{ex.Key.GetKeyDisplayValue()} is not in collection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enabled = true;
            }
        }

        private void TryFind()
        {
            OnLeftLookupNameButtonClick(this, EventArgs.Empty);
            OnRightLookupNameButtonClick(this, EventArgs.Empty);

            var leftPerson = new SearchPerson(LeftFirstNameTextBox.Text, LeftMiddleNameTextBox.Text, LeftLastNameTextBox.Text, (ushort)LeftBirthYearUpDown.Value);

            DistanceNode leftPersonNode = new PersonNode(leftPerson);

            var rightPerson = new SearchPerson(RightFirstNameTextBox.Text, RightMiddleNameTextBox.Text, RightLastNameTextBox.Text, (ushort)RightBirthYearUpDown.Value);

            DistanceNode rightPersonNode = new PersonNode(rightPerson);

            var calculator = new DistanceCalculator(Graph);

            var distance = calculator.CalculateDistancesByDeepFirst(ref leftPersonNode, ref rightPersonNode, (int)MaxSearchDepthUpDown.Value);

            if (double.IsPositiveInfinity(distance))
            {
                MessageBox.Show("No connection found.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (distance == 0)
            {
                MessageBox.Show("Left and right are the same person. Their degree of separation is: 0", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var results = calculator.GetShortestPath(rightPersonNode);

                using (var resultForm = new ResultForm(results))
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

        private void OnLeftBirthYearUpDownValueChanged(object sender, EventArgs e)
        {
            LeftResetBirthYearCheckBox.Checked = (LeftBirthYearUpDown.Value == 0);
        }

        private void OnRightBirthYearUpDownValueChanged(object sender, EventArgs e)
        {
            RightResetBirthYearCheckBox.Checked = (RightBirthYearUpDown.Value == 0);
        }
    }
}