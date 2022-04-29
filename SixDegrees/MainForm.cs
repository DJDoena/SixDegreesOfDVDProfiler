using System;
using System.Diagnostics;
using System.Windows.Forms;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    internal partial class MainForm : Form
    {
        internal MainForm()
        {
            this.InitializeComponent();

            this.Icon = Properties.Resource.djdsoft;
        }

        private void OnKevinBaconLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://en.wikipedia.org/wiki/Six_Degrees_of_Kevin_Bacon");

        private void OnSixDegreesLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://en.wikipedia.org/wiki/Six_degrees_of_separation");

        private void OnSearchByPersonButtonClick(object sender, EventArgs e)
        {
            using (var form = new Person.FindForm())
            {
                form.ShowDialog();
            }
        }

        private void OnByTitleButtonClick(object sender, EventArgs e)
        {
            using (var form = new Profile.FindForm())
            {
                form.ShowDialog();
            }
        }

        private void OnExitToolStripMenuItemClick(object sender, EventArgs e) => this.Close();

        private void OnCheckForUpdatesToolStripMenuItemClick(object sender, EventArgs e) => OnlineAccess.CheckForNewVersion("http://doena-soft.de/dvdprofiler/3.9.0/versions.xml", new WindowHandle(), "Six Degrees of DVD Profiler", this.GetType().Assembly);

        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (var aboutBox = new AboutBox(this.GetType().Assembly))
            {
                aboutBox.ShowDialog();
            }
        }
    }
}