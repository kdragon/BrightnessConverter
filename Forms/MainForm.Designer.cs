namespace BrightnessConverter.Forms
{
    partial class MainForm
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
            btnSelectFiles = new Button();
            lblLowThreshold = new Label();
            lblHighThreshold = new Label();
            lblTargetBrightness = new Label();
            txtLowThreshold = new TextBox();
            txtHighThreshold = new TextBox();
            txtTargetBrightness = new TextBox();
            SuspendLayout();
            // 
            // btnSelectFiles
            // 
            btnSelectFiles.Location = new Point(12, 12);
            btnSelectFiles.Name = "btnSelectFiles";
            btnSelectFiles.Size = new Size(75, 23);
            btnSelectFiles.TabIndex = 0;
            btnSelectFiles.Text = "파일 선택";
            btnSelectFiles.UseVisualStyleBackColor = true;
            btnSelectFiles.Click += btnSelectFiles_Click;
            // 
            // lblLowThreshold
            // 
            lblLowThreshold.AutoSize = true;
            lblLowThreshold.Location = new Point(133, 18);
            lblLowThreshold.Name = "lblLowThreshold";
            lblLowThreshold.Size = new Size(59, 15);
            lblLowThreshold.TabIndex = 1;
            lblLowThreshold.Text = "최소 밝기";
            // 
            // lblHighThreshold
            // 
            lblHighThreshold.AutoSize = true;
            lblHighThreshold.Location = new Point(323, 20);
            lblHighThreshold.Name = "lblHighThreshold";
            lblHighThreshold.Size = new Size(59, 15);
            lblHighThreshold.TabIndex = 2;
            lblHighThreshold.Text = "최대 밝기";
            // 
            // lblTargetBrightness
            // 
            lblTargetBrightness.AutoSize = true;
            lblTargetBrightness.Location = new Point(577, 18);
            lblTargetBrightness.Name = "lblTargetBrightness";
            lblTargetBrightness.Size = new Size(59, 15);
            lblTargetBrightness.TabIndex = 3;
            lblTargetBrightness.Text = "목표 밝기";
            // 
            // txtLowThreshold
            // 
            txtLowThreshold.Location = new Point(207, 12);
            txtLowThreshold.Name = "txtLowThreshold";
            txtLowThreshold.Size = new Size(100, 23);
            txtLowThreshold.TabIndex = 4;
            // 
            // txtHighThreshold
            // 
            txtHighThreshold.Location = new Point(402, 12);
            txtHighThreshold.Name = "txtHighThreshold";
            txtHighThreshold.Size = new Size(100, 23);
            txtHighThreshold.TabIndex = 5;
            // 
            // txtTargetBrightness
            // 
            txtTargetBrightness.Location = new Point(652, 13);
            txtTargetBrightness.Name = "txtTargetBrightness";
            txtTargetBrightness.Size = new Size(100, 23);
            txtTargetBrightness.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtTargetBrightness);
            Controls.Add(txtHighThreshold);
            Controls.Add(txtLowThreshold);
            Controls.Add(lblTargetBrightness);
            Controls.Add(lblHighThreshold);
            Controls.Add(lblLowThreshold);
            Controls.Add(btnSelectFiles);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelectFiles;
        private Label lblLowThreshold;
        private Label lblHighThreshold;
        private Label lblTargetBrightness;
        private TextBox txtLowThreshold;
        private TextBox txtHighThreshold;
        private TextBox txtTargetBrightness;
    }
}