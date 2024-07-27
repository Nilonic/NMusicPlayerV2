namespace NMusicPlayerV2
{
    partial class MainGui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGui));
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            exitToolStripMenuItem = new ToolStripMenuItem();
            PlayPause = new Button();
            PreviousButton = new Button();
            NextButton = new Button();
            LoopButton = new Button();
            listView1 = new ListView();
            label1 = new Label();
            TrackCurrentlyPlaying = new Label();
            TimeLeft = new Label();
            LoadTracks = new Button();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(46, 24);
            toolStripDropDownButton1.Text = "File";
            toolStripDropDownButton1.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(116, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // PlayPause
            // 
            PlayPause.Location = new Point(12, 409);
            PlayPause.Name = "PlayPause";
            PlayPause.Size = new Size(94, 29);
            PlayPause.TabIndex = 2;
            PlayPause.Text = "Play";
            PlayPause.UseVisualStyleBackColor = true;
            PlayPause.Click += PlayPause_Click;
            // 
            // PreviousButton
            // 
            PreviousButton.Location = new Point(112, 409);
            PreviousButton.Name = "PreviousButton";
            PreviousButton.Size = new Size(94, 29);
            PreviousButton.TabIndex = 3;
            PreviousButton.Text = "Previous";
            PreviousButton.UseVisualStyleBackColor = true;
            PreviousButton.Click += PreviousButton_Click;
            // 
            // NextButton
            // 
            NextButton.Location = new Point(594, 409);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(94, 29);
            NextButton.TabIndex = 4;
            NextButton.Text = "Next";
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += NextButton_Click;
            // 
            // LoopButton
            // 
            LoopButton.Location = new Point(694, 409);
            LoopButton.Name = "LoopButton";
            LoopButton.Size = new Size(94, 29);
            LoopButton.TabIndex = 5;
            LoopButton.Text = "Loop (off)";
            LoopButton.UseVisualStyleBackColor = true;
            LoopButton.Click += LoopButton_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(637, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(151, 391);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 42);
            label1.Name = "label1";
            label1.Size = new Size(201, 32);
            label1.TabIndex = 8;
            label1.Text = "Currently Playing:";
            // 
            // TrackCurrentlyPlaying
            // 
            TrackCurrentlyPlaying.AutoSize = true;
            TrackCurrentlyPlaying.Font = new Font("Segoe UI", 14F);
            TrackCurrentlyPlaying.Location = new Point(12, 74);
            TrackCurrentlyPlaying.Name = "TrackCurrentlyPlaying";
            TrackCurrentlyPlaying.Size = new Size(117, 32);
            TrackCurrentlyPlaying.TabIndex = 9;
            TrackCurrentlyPlaying.Text = "Nothing...";
            // 
            // TimeLeft
            // 
            TimeLeft.AutoSize = true;
            TimeLeft.Location = new Point(12, 106);
            TimeLeft.Name = "TimeLeft";
            TimeLeft.Size = new Size(36, 20);
            TimeLeft.TabIndex = 10;
            TimeLeft.Text = "0:00";
            // 
            // LoadTracks
            // 
            LoadTracks.Location = new Point(520, 12);
            LoadTracks.Name = "LoadTracks";
            LoadTracks.Size = new Size(111, 30);
            LoadTracks.TabIndex = 13;
            LoadTracks.Text = "Choose Tracks";
            LoadTracks.UseVisualStyleBackColor = true;
            LoadTracks.Click += LoadTracks_Click;
            // 
            // MainGui
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LoadTracks);
            Controls.Add(TimeLeft);
            Controls.Add(TrackCurrentlyPlaying);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(LoopButton);
            Controls.Add(NextButton);
            Controls.Add(PreviousButton);
            Controls.Add(PlayPause);
            Controls.Add(toolStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainGui";
            Text = "NMusicPlayer V2";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Button PlayPause;
        private Button PreviousButton;
        private Button NextButton;
        private Button LoopButton;
        private ListView listView1;
        private Label label1;
        private Label TrackCurrentlyPlaying;
        private Label TimeLeft;
        private Button LoadTracks;
    }
}