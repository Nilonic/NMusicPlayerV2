using System;
using System.Windows.Forms;

namespace NMusicPlayerV2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            // Create and show the UpdateChecker form as a modal dialog
            using (var updateChecker = new UpdateChecker())
            {
                updateChecker.ShowDialog();
            }
            // After UpdateChecker closes, show the MainGui form and enable visual styles
            Application.EnableVisualStyles();
            Application.Run(new MainGui());
        }
    }
}
