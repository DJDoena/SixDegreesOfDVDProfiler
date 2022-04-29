using System;
using System.Linq;
using System.Windows.Forms;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using mitoSoft.Graphs;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler.Person
{
    internal partial class LookUpForm : Form
    {
        private readonly DirectedGraph _searchIn;

        internal LookUpForm(IPerson searchFor, DirectedGraph searchIn)
        {
            _searchIn = searchIn ?? throw new ArgumentNullException(nameof(searchIn));

            this.InitializeComponent();

            this.Icon = Properties.Resource.djdsoft;

            BirthYearUpDown.Maximum = ushort.MaxValue;

            FirstNameTextBox.Text = searchFor.FirstName;
            MiddleNameTextBox.Text = searchFor.MiddleName;
            LastNameTextBox.Text = searchFor.LastName;
            BirthYearUpDown.Value = searchFor.BirthYear;

            if (!string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                this.LookUpName();
            }
        }

        internal IPerson Match { get; private set; }

        private void OnLookupNameButtonClick(object sender, EventArgs e)
        {
            this.Enabled = false;

            this.LookUpName();

            this.Enabled = true;
        }

        private void LookUpName()
        {
            ResultListView.Items.Clear();

            var searchFor = new SearchPerson(FirstNameTextBox.Text, MiddleNameTextBox.Text, LastNameTextBox.Text, (ushort)BirthYearUpDown.Value);

            var matches = Finder.Find(searchFor, _searchIn);

            var rows = matches.Select(CreateRow).ToArray();

            ResultListView.Items.AddRange(rows);

            if (ResultListView.Items.Count > 0)
            {
                ResultListView.Items[0].Selected = true;
            }
        }

        private static ListViewItem CreateRow(PersonKey match)
        {
            var cells = new[] { match.FirstName, match.MiddleName, match.LastName, match.BirthYear.ToString().TrimStart('0') };

            var row = new ListViewItem(cells)
            {
                Tag = match,
            };

            return row;
        }

        private void OnChooseButtonClick(object sender, EventArgs e)
        {
            if (ResultListView.SelectedIndices.Count == 1)
            {
                var match = (PersonKey)ResultListView.SelectedItems[0].Tag;

                this.Match = new SearchPerson(match.FirstName, match.MiddleName, match.LastName, match.BirthYear);

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            else
            {
                MessageBox.Show("No person selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnAbortButtonClick(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void OnResultListViewDoubleClick(object sender, EventArgs e)
        {
            this.OnChooseButtonClick(this, EventArgs.Empty);
        }

        private void OnResetBirthYearCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (ResetBirthYearCheckBox.Checked)
            {
                BirthYearUpDown.Value = 0;
            }
        }

        private void OnBirthYearUpDownValueChanged(object sender, EventArgs e)
        {
            ResetBirthYearCheckBox.Checked = (BirthYearUpDown.Value == 0);
        }
    }
}