using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;

namespace NMusicPlayerV2
{
    public partial class MainGui : Form
    {
        private List<string> trackList = new List<string>();
        private int currentTrackIndex = -1;
        private bool isPlaying = false;
        private bool isLooping = false;
        private bool isStopping = false; // Flag to handle stop state
        private bool isInMiddleOfTrack = false;
        private WaveOutEvent waveOut;
        private AudioFileReader audioFileReader;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer debuggerCheckTimer; // Timer for checking debugger attachment

        public MainGui()
        {
            InitializeComponent();
            throw new OutOfMemoryException();
            waveOut = new WaveOutEvent();
            waveOut.PlaybackStopped += OnPlaybackStopped;
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 1000; // Update every second
            updateTimer.Tick += UpdateTimer_Tick;

            // Initialize and start the timer to check for debugger attachment
            debuggerCheckTimer = new System.Windows.Forms.Timer();
            debuggerCheckTimer.Interval = 15000; // Check every 15 seconds
            debuggerCheckTimer.Tick += DebuggerCheckTimer_Tick;
            debuggerCheckTimer.Start();

            // Initialize the title
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            string title = "NMusic Player"; // Base title

#if DEBUG
            title += " (DEBUG)";
#endif

            if (System.Diagnostics.Debugger.IsAttached)
            {
                title += " (DEBUGGER ATTACHED)";
            }

            this.Text = title;
        }


        private void DebuggerCheckTimer_Tick(object sender, EventArgs e)
        {
            UpdateTitle(); // Update the title based on the debugger attachment status
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (audioFileReader != null)
            {
                TimeLeft.Text = $"Time Left: {(audioFileReader.TotalTime - audioFileReader.CurrentTime).ToString(@"mm\:ss")}";
            }
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (isStopping)
            {
                isStopping = false;
                return;
            }

            StopTrack();

            if (isLooping)
            {
                PlayTrack();
            }
            else
            {
                NextTrack();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Are you sure?";
            string title = "Exit";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult dialogResult = MessageBox.Show(message, title, button);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void PlayPause_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                PauseTrack();
            }
            else
            {
                PlayTrack();
            }
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (trackList.Count > 0)
            {
                currentTrackIndex = (currentTrackIndex - 1 + trackList.Count) % trackList.Count;
                PlayTrack();
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (trackList.Count > 0 && !isStopping)
            {
                currentTrackIndex = (currentTrackIndex + 1) % trackList.Count;
                PlayTrack();
            }
        }

        private void LoopButton_Click(object sender, EventArgs e)
        {
            isLooping = !isLooping;
            LoopButton.Text = isLooping ? "Looping" : "Not Looping";
        }

        private void LoadTracks_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Audio Files|*.mp3;*.wav;*.flac|All Files|*.*";
                openFileDialog.Title = "Select Tracks";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    trackList.Clear();
                    trackList.AddRange(openFileDialog.FileNames);
                    PopulateTrackListView();

                    if (trackList.Count > 0)
                    {
                        currentTrackIndex = 0;
                        PlayTrack();
                    }
                }
            }
        }

        private void PopulateTrackListView()
        {
            listView1.Items.Clear();
            foreach (var track in trackList)
            {
                listView1.Items.Add(Path.GetFileName(track));
            }
        }

        private void PlayTrack()
        {
            if (trackList.Count == 0 || currentTrackIndex < 0 || currentTrackIndex >= trackList.Count)
                return;

            // Prevent starting a new track if stopping is in progress
            if (isStopping)
            {
                return;
            }

            if (isInMiddleOfTrack)
            {
                waveOut.Play();
                isInMiddleOfTrack = false;
                isPlaying = true;
                PlayPause.Text = "Pause";
                TrackCurrentlyPlaying.Text = $"Playing: {Path.GetFileName(trackList[currentTrackIndex])}";
                updateTimer.Start();
                return;
            }

            // Stop any currently playing track
            if (isPlaying)
            {
                isStopping = true;
                StopTrack();
            }


            else
            {
                // Load and play the new track
                string trackToPlay = trackList[currentTrackIndex];
                TrackCurrentlyPlaying.Text = $"Playing: {Path.GetFileName(trackToPlay)}";

                try
                {
                    audioFileReader = new AudioFileReader(trackToPlay);
                    waveOut.Init(audioFileReader);
                    waveOut.Play();
                    isPlaying = true;
                    PlayPause.Text = "Pause";

                    // Start or restart the timer
                    updateTimer.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error playing track: {ex.Message}");
                }
            }
        }

        private void PauseTrack()
        {
            if (isPlaying)
            {
                waveOut.Pause();
                TrackCurrentlyPlaying.Text = "Paused";
                isPlaying = false;
                PlayPause.Text = "Play";
                isInMiddleOfTrack = true;

                // Stop the timer when paused
                updateTimer.Stop();
            }
        }

        private void StopTrack()
        {
            if (isPlaying)
            {
                waveOut.Stop();
                audioFileReader?.Dispose(); // Properly dispose the reader
                audioFileReader = null; // Set to null after disposing
                TrackCurrentlyPlaying.Text = "Stopped";
                isPlaying = false;
                PlayPause.Text = "Play";

                // Stop the timer when stopped
                updateTimer.Stop();
            }
        }

        private void NextTrack()
        {
            if (trackList.Count > 0)
            {
                currentTrackIndex = (currentTrackIndex + 1) % trackList.Count;
                PlayTrack();
            }
        }
    }
}
