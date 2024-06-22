using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.IO;

namespace Diploma.BLL;

public class Generate
{
    public Generate()
    {
    }

    public Image AddTextToImage(Image image, string textToAdd, int fontSize, int x, int y, Color color)
    {
        //Image image = Image.Load("C:\\Users\\vombe\\OneDrive\\Рабочий стол\\Лаборатория\\Diploma\\Diploma\\Diploma\\DAL\\src\\foo.png");


        FontCollection collection = new();
        FontFamily family = collection.Add("C:\\Users\\vombe\\OneDrive\\Рабочий стол\\Лаборатория\\Diploma\\Diploma\\Diploma\\DAL\\src\\Bold.ttf");
        Font font = family.CreateFont(fontSize);
        RichTextOptions options = new(font)
        {
            Origin = new PointF(x, y), 
            TabWidth = 8, 
            WrappingLength = 1200,
            HorizontalAlignment = HorizontalAlignment.Center,
            TextAlignment = TextAlignment.Center
        };

        PatternBrush brush = Brushes.Horizontal(Color.Red, Color.Blue);
        PatternPen pen = Pens.DashDot(Color.Green, 5);
        string text = "sample text";
        
        image.Mutate(x => x.DrawText(options, textToAdd, color));

        return image;
        
    }
}