using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    internal partial class MainForm : Form
    {
        private IEnumerable<DVD> _collection;

        private Persons _persons;

        private Persons Persons
        {
            get => _persons;
            set
            {
                _persons = value;

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

        internal MainForm()
        {
            InitializeComponent();

            Collection = null;

            Persons = null;

            LeftBirthYearUpDown.Maximum = ushort.MaxValue;
            RightBirthYearUpDown.Maximum = ushort.MaxValue;
            MaxSearchDepthUpDown.Maximum = byte.MaxValue;
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

                    Persons = null;

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

                Persons = (new PersonsBuilder()).Build(Collection, IncludeCastCheckBox.Checked, IncludeCrewCheckBox.Checked);

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

            var matches = PersonFinder.Find(searchFor, Persons).ToList();

            if (matches.Count == 1)
            {
                var matchKey = matches[0];

                var matchPerson = new SearchPerson(matchKey.FirstName, matchKey.MiddleName, matchKey.LastName, matchKey.BirthYear);

                SetMatch(matchPerson, firstNameTextBox, middleNameTextBox, lastNameTextBox, birthYearUpDown);
            }
            else
            {
                using (var lookUpForm = new LookUpNameForm(searchFor, Persons))
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
            Find((new ConnectionFinder(Persons)).FindForward);
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

            Find((new ConnectionFinder(Persons)).FindReverse);
        }

        private void Find(FindDelegate find)
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
                TryFind(find);
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

        private void TryFind(FindDelegate find)
        {
            var leftPerson = new SearchPerson(LeftFirstNameTextBox.Text, LeftMiddleNameTextBox.Text, LeftLastNameTextBox.Text, (ushort)LeftBirthYearUpDown.Value);

            var rightPerson = new SearchPerson(RightFirstNameTextBox.Text, RightMiddleNameTextBox.Text, RightLastNameTextBox.Text, (ushort)RightBirthYearUpDown.Value);

            var results = find(leftPerson, rightPerson, (byte)MaxSearchDepthUpDown.Value);

            var firstResult = results.FirstOrDefault();

            if (firstResult == null)
            {
                MessageBox.Show("No connection found.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (firstResult.Degree == 0)
            {
                MessageBox.Show("Left and right are the same person. Their degree of separation is: 0", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (var resultForm = new ResultForm(firstResult, results))
                {
                    resultForm.ShowDialog();
                }
            }
        }

        private delegate IEnumerable<Steps> FindDelegate(IPerson startPerson, IPerson targetPerson, byte maxSearchDepth);
    }
}