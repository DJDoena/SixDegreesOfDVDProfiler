using System;
using System.Linq;
using System.Windows.Forms;
using DoenaSoft.DVDProfiler.DVDProfilerXML;
using mitoSoft.Math.Graphs.Dijkstra;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    internal partial class LookUpNameForm : Form
    {
        private readonly DistanceGraph _searchIn;

        internal IPerson Match { get; private set; }

        internal LookUpNameForm(IPerson searchFor, DistanceGraph searchIn)
        {
            _searchIn = searchIn;

            InitializeComponent();

            BirthYearUpDown.Maximum = ushort.MaxValue;

            FirstNameTextBox.Text = searchFor.FirstName;
            MiddleNameTextBox.Text = searchFor.MiddleName;
            LastNameTextBox.Text = searchFor.LastName;
            BirthYearUpDown.Value = searchFor.BirthYear;

            if (!string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                LookUpName();
            }
        }

        private void OnLookupNameButtonClick(object sender, EventArgs e)
        {
            Enabled = false;

            LookUpName();

            Enabled = true;
        }

        private void LookUpName()
        {
            ResultListView.Items.Clear();

            var searchFor = new SearchPerson(FirstNameTextBox.Text, MiddleNameTextBox.Text, LastNameTextBox.Text, (ushort)BirthYearUpDown.Value);

            var matches = PersonFinder.Find(searchFor, _searchIn);

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

                Match = new SearchPerson(match.FirstName, match.MiddleName, match.LastName, match.BirthYear);

                DialogResult = DialogResult.OK;

                Close();
            }
            else
            {
                MessageBox.Show("No person selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnAbortButtonClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void OnResultListViewDoubleClick(object sender, EventArgs e)
        {
            OnChooseButtonClick(this, EventArgs.Empty);
        }
    }
}