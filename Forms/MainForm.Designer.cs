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
            resultListView = new ListView();
            panelListViewContainer = new Panel();
            label1 = new Label();
            btnClearList = new Button();
            panelListViewContainer.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectFiles
            // 
            btnSelectFiles.Location = new Point(12, 12);
            btnSelectFiles.Name = "btnSelectFiles";
            btnSelectFiles.Size = new Size(104, 36);
            btnSelectFiles.TabIndex = 0;
            btnSelectFiles.Text = "파일 선택";
            btnSelectFiles.UseVisualStyleBackColor = true;
            btnSelectFiles.Click += btnSelectFiles_Click;
            // 
            // lblLowThreshold
            // 
            lblLowThreshold.AutoSize = true;
            lblLowThreshold.Location = new Point(132, 24);
            lblLowThreshold.Name = "lblLowThreshold";
            lblLowThreshold.Size = new Size(59, 15);
            lblLowThreshold.TabIndex = 1;
            lblLowThreshold.Text = "최소 밝기";
            // 
            // lblHighThreshold
            // 
            lblHighThreshold.AutoSize = true;
            lblHighThreshold.Location = new Point(286, 23);
            lblHighThreshold.Name = "lblHighThreshold";
            lblHighThreshold.Size = new Size(59, 15);
            lblHighThreshold.TabIndex = 2;
            lblHighThreshold.Text = "최대 밝기";
            // 
            // lblTargetBrightness
            // 
            lblTargetBrightness.AutoSize = true;
            lblTargetBrightness.Location = new Point(446, 21);
            lblTargetBrightness.Name = "lblTargetBrightness";
            lblTargetBrightness.Size = new Size(59, 15);
            lblTargetBrightness.TabIndex = 3;
            lblTargetBrightness.Text = "목표 밝기";
            // 
            // txtLowThreshold
            // 
            txtLowThreshold.Location = new Point(200, 18);
            txtLowThreshold.Name = "txtLowThreshold";
            txtLowThreshold.Size = new Size(80, 23);
            txtLowThreshold.TabIndex = 4;
            txtLowThreshold.TextAlign = HorizontalAlignment.Right;
            // 
            // txtHighThreshold
            // 
            txtHighThreshold.Location = new Point(351, 16);
            txtHighThreshold.Name = "txtHighThreshold";
            txtHighThreshold.Size = new Size(80, 23);
            txtHighThreshold.TabIndex = 5;
            txtHighThreshold.TextAlign = HorizontalAlignment.Right;
            // 
            // txtTargetBrightness
            // 
            txtTargetBrightness.Location = new Point(511, 15);
            txtTargetBrightness.Name = "txtTargetBrightness";
            txtTargetBrightness.Size = new Size(80, 23);
            txtTargetBrightness.TabIndex = 6;
            txtTargetBrightness.TextAlign = HorizontalAlignment.Right;
            // 
            // resultListView
            // 
            resultListView.BackColor = SystemColors.Window;
            resultListView.Dock = DockStyle.Fill;
            resultListView.Location = new Point(0, 0);
            resultListView.Name = "resultListView";
            resultListView.Size = new Size(1008, 675);
            resultListView.TabIndex = 7;
            resultListView.UseCompatibleStateImageBehavior = false;
            // 
            // panelListViewContainer
            // 
            panelListViewContainer.Controls.Add(resultListView);
            panelListViewContainer.Dock = DockStyle.Bottom;
            panelListViewContainer.Location = new Point(0, 54);
            panelListViewContainer.Name = "panelListViewContainer";
            panelListViewContainer.Size = new Size(1008, 675);
            panelListViewContainer.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Malgun Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(614, 16);
            label1.Name = "label1";
            label1.Size = new Size(252, 21);
            label1.TabIndex = 9;
            label1.Text = "권장 : 30(실내50)~240  밝기:190";
            label1.Click += label1_Click;
            // 
            // btnClearList
            // 
            btnClearList.Location = new Point(895, 15);
            btnClearList.Name = "btnClearList";
            btnClearList.Size = new Size(75, 23);
            btnClearList.TabIndex = 10;
            btnClearList.Text = "목록초기화";
            btnClearList.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClearList.UseVisualStyleBackColor = true;
            btnClearList.Click += btnClearList_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(1008, 729);
            Controls.Add(btnClearList);
            Controls.Add(label1);
            Controls.Add(panelListViewContainer);
            Controls.Add(txtTargetBrightness);
            Controls.Add(txtHighThreshold);
            Controls.Add(txtLowThreshold);
            Controls.Add(lblTargetBrightness);
            Controls.Add(lblHighThreshold);
            Controls.Add(lblLowThreshold);
            Controls.Add(btnSelectFiles);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "텍스쳐 밝기 맞추기";
            panelListViewContainer.ResumeLayout(false);
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
        private ListView resultListView;
        private Panel panelListViewContainer;
        private Label label1;
        private Button btnClearList;
    }
}