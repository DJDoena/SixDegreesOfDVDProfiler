using System;
using System.Linq;
using System.Windows.Forms;
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using mitoSoft.Graphs;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler.Profile
{
    internal partial class LookUpForm : Form
    {
        private readonly DirectedGraph _searchIn;

        internal LookUpForm(string searchFor, DirectedGraph searchIn)
        {
            _searchIn = searchIn ?? throw new ArgumentNullException(nameof(searchIn));

            this.InitializeComponent();

            this.Icon = Properties.Resource.djdsoft;

            TitleTextBox.Text = searchFor;

            if (!string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                this.LookUpTitle();
            }
        }

        internal DVD Match { get; private set; }

        private void OnLookupNameButtonClick(object sender, EventArgs e)
        {
            this.Enabled = false;

            this.LookUpTitle();

            this.Enabled = true;
        }

        private void LookUpTitle()
        {
            ResultListView.Items.Clear();

            var matches = Finder.Find(TitleTextBox.Text, _searchIn);

            var rows = matches.Select(CreateRow).ToArray();

            ResultListView.Items.AddRange(rows);

            if (ResultListView.Items.Count > 0)
            {
                ResultListView.Items[0].Selected = true;
            }
        }

        private static ListViewItem CreateRow(DVD match)
        {
            var cells = new[] { match.Title, match.OriginalTitle, match.ProductionYear.ToString().TrimStart('0') };

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
                this.Match = (DVD)ResultListView.SelectedItems[0].Tag;

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
    }
}