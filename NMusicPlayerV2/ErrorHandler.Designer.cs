namespace NMusicPlayerV2
{
    partial class ErrorHandler
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
            label1 = new Label();
            exm = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(290, 32);
            label1.TabIndex = 0;
            label1.Text = "A fatal error has occurred!";
            // 
            // exm
            // 
            exm.AutoSize = true;
            exm.Location = new Point(12, 80);
            exm.Name = "exm";
            exm.Size = new Size(37, 20);
            exm.TabIndex = 1;
            exm.Text = "exm";
            // 
            // button1
            // 
            button1.Location = new Point(390, 169);
            button1.Name = "button1";
            button1.Size = new Size(94, 32);
            button1.TabIndex = 6;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(290, 169);
            button2.Name = "button2";
            button2.Size = new Size(94, 32);
            button2.TabIndex = 7;
            button2.Text = "Open Log";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 130);
            label2.Name = "label2";
            label2.Size = new Size(239, 20);
            label2.TabIndex = 8;
            label2.Text = "Please send this to the Github repo";
            // 
            // button3
            // 
            button3.Location = new Point(12, 169);
            button3.Name = "button3";
            button3.Size = new Size(152, 32);
            button3.TabIndex = 9;
            button3.Text = "Open github issues";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ErrorHandler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 213);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(exm);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ErrorHandler";
            ShowIcon = false;
            Text = "Error!";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label exm;
        private Button button1;
        private Button button2;
        private Label label2;
        private Button button3;
    }
}