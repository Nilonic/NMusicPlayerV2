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

        public event Action UpdateCheckCompleted;

        public UpdateChecker()
        {
            InitializeComponent();
            CheckForUpdates();
        }

        private async void CheckForUpdates()
        {
            if (IsConnectedToInternet())
            {
                StatusLabel.Text = "Checking...";
                progressBar.Value = 10;

                const string CheckLocation = "https://raw.githubusercontent.com/Nilonic/NMusicPlayerV2/main/CurVer.txt";

                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        string remoteVersion = await httpClient.GetStringAsync(CheckLocation);
                        remoteVersion = remoteVersion.Trim();

                        if (string.Compare(remoteVersion, _internalVersion) > 0)
                        {
                            StatusLabel.Text = $"Update available: {remoteVersion}";
                            // Optionally handle the update prompt here
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

            progressBar.Value = 100;
            await Task.Delay(2000);

            // Notify that the update check is complete
            UpdateCheckCompleted?.Invoke();
            this.Close();
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
