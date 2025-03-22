using System.Text;
using System.Windows.Forms;

namespace BrightnessConverter.Models
{
    public static class ResultFormatter
    {
        public static string FormatResult(ImageProcessingResult result)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"파일명: {result.FileName}");
            sb.AppendLine("[원본 이미지]");
            sb.AppendLine($"  LowThreshold: {result.OriginalLowPixelCount} 픽셀 ({result.OriginalLowPixelPercentage}%)");
            sb.AppendLine($"  HighThreshold: {result.OriginalHighPixelCount} 픽셀 ({result.OriginalHighPixelPercentage}%)");
            sb.AppendLine($"  평균 밝기: {result.OriginalAverageBrightness}");
            sb.AppendLine($"  목표와의 차이: {result.BrightnessDifference}");
            sb.AppendLine("[변경된 이미지]");
            sb.AppendLine($"  LowThreshold: {result.AdjustedLowPixelCount} 픽셀 ({result.AdjustedLowPixelPercentage}%)");
            sb.AppendLine($"  HighThreshold: {result.AdjustedHighPixelCount} 픽셀 ({result.AdjustedHighPixelPercentage}%)");
            sb.AppendLine($"  평균 밝기: {result.AdjustedAverageBrightness}");
            return sb.ToString();
        }

        // ⭐ ListView용 별도 함수
        public static ListViewItem FormatResultForListView(ImageProcessingResult result)
        {
            ListViewItem item = new ListViewItem(result.FileName);

            item.SubItems.Add(result.OriginalAverageBrightness.ToString("F2"));
            item.SubItems.Add($"{result.OriginalLowPixelCount} ({result.OriginalLowPixelPercentage:F2}%)");
            item.SubItems.Add($"{result.OriginalHighPixelCount} ({result.OriginalHighPixelPercentage:F2}%)");

            item.SubItems.Add(result.AdjustedAverageBrightness.ToString("F2"));
            item.SubItems.Add($"{result.AdjustedLowPixelCount} ({result.AdjustedLowPixelPercentage:F2}%)");
            item.SubItems.Add($"{result.AdjustedHighPixelCount} ({result.AdjustedHighPixelPercentage:F2}%)");

            return item;
        }
    }
}