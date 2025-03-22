using System;
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

            // PixelStats 객체 내부에서 퍼센티지 계산
            return new PixelStats(lowPixels, highPixels, avgBrightness, bitmap.Width * bitmap.Height);
        }

        public Bitmap AdjustBrightness(Bitmap bitmap, float targetBrightness, float currentBrightness)
        {
            float brightnessOffset = targetBrightness - currentBrightness;
            Bitmap adjustedImage = new Bitmap(bitmap.Width, bitmap.Height);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);

                    int adjustedR = (int)Math.Clamp(pixel.R + brightnessOffset, 0, 255);
                    int adjustedG = (int)Math.Clamp(pixel.G + brightnessOffset, 0, 255);
                    int adjustedB = (int)Math.Clamp(pixel.B + brightnessOffset, 0, 255);

                    adjustedImage.SetPixel(x, y, Color.FromArgb(adjustedR, adjustedG, adjustedB));
                }
            }

            return adjustedImage;
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


        public ImageProcessingResult ProcessImage(string inputFilePath, string outputFolderPath, float targetBrightness, int lowThreshold, int highThreshold)
        {
            // 원본 이미지 로드
            using Bitmap originalBitmap = new Bitmap(inputFilePath);

            // 변환 전 이미지 분석
            PixelStats originalStats = AnalyzeImage(originalBitmap, lowThreshold, highThreshold);
            float originalAvg = originalStats.AverageBrightness;
            float brightnessDifference = Math.Abs(originalAvg - targetBrightness);

            // 밝기 조정
            using Bitmap adjustedBitmap = AdjustBrightness(originalBitmap, targetBrightness, originalAvg);

            // 파일명 및 저장 경로 구성
            string fileName = Path.GetFileName(inputFilePath);
            string outputFilePath = Path.Combine(outputFolderPath, fileName);
            ImageFormat format = GetImageFormat(inputFilePath);

            // 변환된 이미지 저장
            adjustedBitmap.Save(outputFilePath, format);

            // 변환 후 이미지 분석
            PixelStats adjustedStats = AnalyzeImage(adjustedBitmap, lowThreshold, highThreshold);
            float adjustedAvg = adjustedStats.AverageBrightness;

            // adjustedBitmap.Dispose();

            // ImageProcessingResult 객체 생성 및 반환 (소수점 두자리 반올림)
            return new ImageProcessingResult
            {
                FileName = fileName,
                OriginalLowPixelCount = originalStats.LowPixelCount,
                OriginalLowPixelPercentage = (float)Math.Round(originalStats.LowPixelPercentage, 2),
                OriginalHighPixelCount = originalStats.HighPixelCount,
                OriginalHighPixelPercentage = (float)Math.Round(originalStats.HighPixelPercentage, 2),
                OriginalAverageBrightness = (float)Math.Round(originalAvg, 2),
                BrightnessDifference = (float)Math.Round(brightnessDifference, 2),
                AdjustedLowPixelCount = adjustedStats.LowPixelCount,
                AdjustedLowPixelPercentage = (float)Math.Round(adjustedStats.LowPixelPercentage, 2),
                AdjustedHighPixelCount = adjustedStats.HighPixelCount,
                AdjustedHighPixelPercentage = (float)Math.Round(adjustedStats.HighPixelPercentage, 2),
                AdjustedAverageBrightness = (float)Math.Round(adjustedAvg, 2)
            };
        }
    }
}