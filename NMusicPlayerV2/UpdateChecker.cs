using System;
using System.Net;
using System.Diagnostics;
using System.Security.Policy;

namespace NMusicPlayerV2
{
    public partial class UpdateChecker : Form
    {
        public static readonly string _internalVersion = "0.0.0";
        private readonly string _CheckLocation = "https://raw.githubusercontent.com/Nilonic/NMusicPlayerV2/main/CurVer.txt";

        public event Action UpdateCheckCompleted;

        public UpdateChecker()
        {
            InitializeComponent();
            CheckForUpdates();
        }

        private async void CheckForUpdates()
        {
            progressBar.Value += 10;
            if (IsConnectedToInternet)
            {
                StatusLabel.Text = "Checking...";
                progressBar.Value += 10;


                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        string remoteVersion = await httpClient.GetStringAsync(_CheckLocation);
                        remoteVersion = remoteVersion.Trim();

                        if (string.Compare(remoteVersion, _internalVersion) > 0)
                        {
                            StatusLabel.Text = $"Update available: {remoteVersion}";
                            var result = MessageBox.Show("Would you like to update?", "", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                string url = "https://github.com/Nilonic/NMusicPlayerV2/releases/latest";
                                Process.Start(new ProcessStartInfo
                                {
                                    FileName = url,
                                    UseShellExecute = true,
                                    WindowStyle = ProcessWindowStyle.Maximized,
                                });
                                Application.Exit();
                            }
                            else
                            {

                            }
                        }
                        else if (string.Compare(remoteVersion, _internalVersion) < 0)
                        {
                            StatusLabel.Text = $"Version Ahead! Development build?";
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
                }
            }
            else
            {
                StatusLabel.Text = "Not connected. Please check your internet connection.";
            }

            await Task.Delay(2000);
            progressBar.Value = 100;
            // Notify that the update check is complete
            UpdateCheckCompleted?.Invoke();
            this.Close();
        }

        private static bool IsConnectedToInternet
        {
            get
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }
    }
}
