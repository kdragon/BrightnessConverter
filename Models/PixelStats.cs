namespace BrightnessConverter.Models
{
    public class PixelStats
    {
        public int LowPixelCount { get; }
        public int HighPixelCount { get; }
        public float AverageBrightness { get; }
        public int TotalPixelCount { get; }

        public PixelStats(int lowCount, int highCount, float avgBrightness, int totalCount)
        {
            LowPixelCount = lowCount;
            HighPixelCount = highCount;
            AverageBrightness = avgBrightness;
            TotalPixelCount = totalCount;
        }

        public float LowPixelPercentage => (float)LowPixelCount / TotalPixelCount * 100f;
        public float HighPixelPercentage => (float)HighPixelCount / TotalPixelCount * 100f;
    }
}
