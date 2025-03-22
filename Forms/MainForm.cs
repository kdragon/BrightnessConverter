using System;
using System.IO;
using System.Windows.Forms;
using BrightnessConverter.Models;
using System.Threading.Tasks;  // <-- 필수적으로 추가

namespace BrightnessConverter.Forms
{
    public partial class MainForm : Form
    {
        
        private readonly ImageProcessor processor = new ImageProcessor();

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;

            txtLowThreshold.LostFocus += txtThreshold_LostFocus;
            txtHighThreshold.LostFocus += txtThreshold_LostFocus;
            txtTargetBrightness.LostFocus += txtThreshold_LostFocus;
        }

        private void txtThreshold_LostFocus(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            // 이전 값 읽어오기
            int prevLow = Properties.Settings.Default.LowThreshold;
            int prevHigh = Properties.Settings.Default.HighThreshold;
            float prevTarget = Properties.Settings.Default.TargetBrightness;

            // 입력값 검증 및 저장
            int lowValue = GetValidatedValue(txtLowThreshold.Text, 30, 0, 255, prevLow);
            int highValue = GetValidatedValue(txtHighThreshold.Text, 240, 0, 255, prevHigh);
            float targetValue = GetValidatedValue(txtTargetBrightness.Text, 190f, 0f, 255f, prevTarget);

            // 값 다시 표시(검증된 값으로 갱신)
            txtLowThreshold.Text = lowValue.ToString();
            txtHighThreshold.Text = highValue.ToString();
            txtTargetBrightness.Text = targetValue.ToString();

            // 설정 저장
            Properties.Settings.Default.LowThreshold = lowValue;
            Properties.Settings.Default.HighThreshold = highValue;
            Properties.Settings.Default.TargetBrightness = targetValue;

            // 변경 사항 즉시 저장
            Properties.Settings.Default.Save();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            // 폼 로드시 Properties setting 값을 TextBox에 로드하여 보여줍니다.
            txtLowThreshold.Text = Properties.Settings.Default.LowThreshold.ToString();
            txtHighThreshold.Text = Properties.Settings.Default.HighThreshold.ToString(); 
            txtTargetBrightness.Text = Properties.Settings.Default.TargetBrightness.ToString(); 
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void MainForm_Layout(object? sender, LayoutEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void btnSelectFiles_Click(object sender, EventArgs e)
        {


            using OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = true,
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string inputFolder = Path.GetDirectoryName(openFileDialog.FileNames[0]);
                string outputFolder = Path.Combine(inputFolder, "output");

                try
                {

                    if (!Directory.Exists(outputFolder))
                        Directory.CreateDirectory(outputFolder);

                    btnSelectFiles.Enabled = false;

                    await Task.Run(() =>
                    {

                        foreach (string inputFilePath in openFileDialog.FileNames)
                        {
                            processor.SaveAdjustedBrightnessImage(
                                inputFilePath,
                                outputFolder,
                                Properties.Settings.Default.TargetBrightness,
                                Properties.Settings.Default.LowThreshold,
                                Properties.Settings.Default.HighThreshold);
                        }
                    });

                    btnSelectFiles.Enabled = true;

                    MessageBox.Show("모든 파일이 밝기 조정 후 저장되었습니다.",
                                    "작업 완료",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"오류 발생: {ex.Message}",
                                    "오류",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

                finally
                {
                    btnSelectFiles.Enabled = true;
                }



            }}


        // 값 검증 및 기본값 설정 메서드 추가
        private int GetValidatedValue(string input, int defaultValue, int min, int max, int previousValue)
        {
            if (string.IsNullOrWhiteSpace(input))
                return defaultValue;

            if (!int.TryParse(input, out int value) || value < min || value > max)
                return previousValue;

            return value;
        }

        private float GetValidatedValue(string input, float defaultValue, float min, float max, float previousValue)
        {
            if (string.IsNullOrWhiteSpace(input))
                return defaultValue;

            if (!float.TryParse(input, out float value) || value < min || value > max)
                return previousValue;

            return value;

        }
    }
}
