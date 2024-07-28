using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NMusicPlayerV2
{
    public partial class ErrorHandler : Form
    {
        public ErrorHandler(Exception ex)
        {
            InitializeComponent();
            exm.Text = $"Message: {ex.Message}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Specify the path to the file
            string filePath = "Errors/errorlog.md";

            // Get the directory of the file
            string directoryPath = Path.GetDirectoryName(Path.GetFullPath(filePath));

            // Open the directory in File Explorer
            Process.Start(new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = directoryPath,
                UseShellExecute = true
            });
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Nilonic/NMusicPlayerV2/issues/new",
                UseShellExecute = true
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
