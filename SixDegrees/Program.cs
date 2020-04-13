using System;
using System.Windows.Forms;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Properties.Settings.Default.Upgrade();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}