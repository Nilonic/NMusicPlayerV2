namespace NMusicPlayerV2
{
    partial class UpdateChecker
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StatusLabel = new Label();
            progressBar = new ProgressBar();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(12, 9);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(87, 20);
            StatusLabel.TabIndex = 0;
            StatusLabel.Text = "initializing...";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 32);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(451, 21);
            progressBar.TabIndex = 1;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(369, 59);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(94, 29);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // UpdateChecker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 94);
            Controls.Add(CancelButton);
            Controls.Add(progressBar);
            Controls.Add(StatusLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateChecker";
            Text = "NMusicPlayer V2 - Checking for Updates...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label StatusLabel;
        private ProgressBar progressBar;
        private Button CancelButton;
    }
}
