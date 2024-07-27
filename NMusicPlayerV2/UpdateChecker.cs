using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NMusicPlayerV2
{
    public partial class UpdateChecker : Form
    {
        private readonly string _internalVersion = "0.0.0";

        public UpdateChecker()
        {
            InitializeComponent();
            CheckForUpdates();
        }

        private async void CheckForUpdates()
        {
            // first of all, are we connected to the internet?
            if (IsConnectedToInternet())
            {
                StatusLabel.Text = "Checking...";
                progressBar.Value = 10;

                const string CheckLocation = "https://raw.githubusercontent.com/Nilonic/NMusicPlayerV2/main/CurVer.txt";

                try
                {
                    // Fetch the latest version from the remote server
                    using (var httpClient = new HttpClient())
                    {
                        string remoteVersion = await httpClient.GetStringAsync(CheckLocation);
                        remoteVersion = remoteVersion.Trim(); // Trim any extraneous whitespace

                        // Compare versions
                        if (string.Compare(remoteVersion, _internalVersion) > 0)
                        {
                            StatusLabel.Text = $"Update available: {remoteVersion}";
                            // Optionally, provide a way to update
                        }
                        else
                        {
                            StatusLabel.Text = "You are using the latest version.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Error checking for updates.";
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK);
                    // Log exception or handle as needed
                }
            }
            else
            {
                StatusLabel.Text = "Not connected. Please check your internet connection.";
            }

            progressBar.Value = 100; // Update progress bar to complete
        }

        private bool IsConnectedToInternet()
        {
            try
            {
                var host = Dns.GetHostEntry("www.google.com");
                return host != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
