namespace BrightnessConverter.Models
{
    public class ImageProcessingResult
    {
        public required string FileName { get; set; }
        public int OriginalLowPixelCount { get; set; }
        public float OriginalLowPixelPercentage { get; set; }
        public int OriginalHighPixelCount { get; set; }
        public float OriginalHighPixelPercentage { get; set; }
        public float OriginalAverageBrightness { get; set; }
        public float BrightnessDifference { get; set; }
        public int AdjustedLowPixelCount { get; set; }
        public float AdjustedLowPixelPercentage { get; set; }
        public int AdjustedHighPixelCount { get; set; }
        public float AdjustedHighPixelPercentage { get; set; }
        public float AdjustedAverageBrightness { get; set; }
    }
}