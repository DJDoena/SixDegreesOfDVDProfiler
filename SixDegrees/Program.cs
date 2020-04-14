using System;
using System.Windows.Forms;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}