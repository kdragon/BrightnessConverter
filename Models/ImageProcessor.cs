using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BrightnessConverter.Models
{
    public class ImageProcessor
    {
        public PixelStats AnalyzeImage(Bitmap bitmap, int lowThreshold, int highThreshold)
        {
            int lowPixels = 0;
            int highPixels = 0;
            float totalBrightness = 0;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    float brightness = pixel.GetBrightness() * 255;
                    totalBrightness += brightness;

                    if (brightness <= lowThreshold) lowPixels++;
                    else if (brightness >= highThreshold) highPixels++;
                }
            }

            float avgBrightness = totalBrightness / (bitmap.Width * bitmap.Height);
            return new PixelStats(lowPixels, highPixels, avgBrightness, bitmap.Width * bitmap.Height);
        }

        public Bitmap AdjustBrightness(Bitmap bitmap, float targetBrightness, float currentBrightness)
        {
            float brightnessRatio = targetBrightness / currentBrightness;
            Bitmap adjustedImage = new Bitmap(bitmap.Width, bitmap.Height);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    int adjustedR = (int)Math.Clamp(pixel.R * brightnessRatio, 0, 255);
                    int adjustedG = (int)Math.Clamp(pixel.G * brightnessRatio, 0, 255);
                    int adjustedB = (int)Math.Clamp(pixel.B * brightnessRatio, 0, 255);

                    adjustedImage.SetPixel(x, y, Color.FromArgb(adjustedR, adjustedG, adjustedB));
                }
            }

            return adjustedImage;
        }

        // 저장기능 추가
        public void SaveAdjustedBrightnessImage(string inputFilePath, string outputFolderPath, float targetBrightness, int lowThreshold, int highThreshold)
        {
            using Bitmap originalBitmap = new Bitmap(inputFilePath);

            // 분석
            PixelStats stats = AnalyzeImage(originalBitmap, lowThreshold, highThreshold);

            // 밝기 조정
            Bitmap adjustedBitmap = AdjustBrightness(originalBitmap, targetBrightness, stats.AverageBrightness);

            // 저장경로 생성
            string fileName = Path.GetFileName(inputFilePath);
            string outputFilePath = Path.Combine(outputFolderPath, fileName);

            // 이미지 저장 (원본 이미지와 같은 포맷 유지)
            ImageFormat format = GetImageFormat(inputFilePath);
            adjustedBitmap.Save(outputFilePath, format);

            adjustedBitmap.Dispose();
        }

        private ImageFormat GetImageFormat(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();

            return ext switch
            {
                ".jpg" or ".jpeg" => ImageFormat.Jpeg,
                ".bmp" => ImageFormat.Bmp,
                ".png" => ImageFormat.Png,
                ".gif" => ImageFormat.Gif,
                _ => ImageFormat.Png,
            };
        }
    }
}