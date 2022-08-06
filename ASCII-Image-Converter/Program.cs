using System;
using J0nathan550.ASCIIImageCreator;
public class Program
{

    public static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Console.Write("Welcome to ASCII image creator! write a path to image:");
                string imagePath = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Write the output of file:");
                string savePath = Console.ReadLine();
                ASCIIImageConverter imageConverter = new ASCIIImageConverter(imagePath);
                Console.WriteLine("Done! Here is the result:");
                imageConverter.Compile(savePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);   
            }
        }

    }
}