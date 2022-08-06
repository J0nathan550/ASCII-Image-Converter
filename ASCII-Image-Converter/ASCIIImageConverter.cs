using System;
using System.Drawing;
using System.IO;

namespace J0nathan550.ASCIIImageCreator
{
    public class ASCIIImageConverter
    {
        private string imagePath;

        public ASCIIImageConverter(string imagePath)
        {
            this.imagePath = imagePath;
        }

        private string pixels = " .-+*wGHM#&$%";

        public void Compile(string saveImagePath)
        {
            var image = new Bitmap(imagePath);
            using(var writer = new StreamWriter(saveImagePath))
            {
                for (var y = 0; y < image.Height; y++)
                {
                    for (var x = 0; x < image.Width; x++)
                    {
                        var color = image.GetPixel(x, y);
                        var brightness = Brightness(color);
                        var index = brightness / 255 * (pixels.Length - 1);
                        var pixel = pixels[(int)Math.Round(index)];
                        writer.Write(pixel);
                        writer.Write(pixel);
                    }
                    writer.WriteLine();
                }
                    writer.Close();
                    Console.WriteLine(File.ReadAllText(saveImagePath));
            }
        } 
        private double Brightness(Color col)
        {
            return Math.Sqrt(col.R * col.R * .246 + col.G * col.G * .691 + col.B * col.B * .068);
        }
    }
}
