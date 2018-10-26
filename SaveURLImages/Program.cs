using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SaveURLImages
{
    class Program
    {
        static void Main(string[] args)
        {

            var fillbrush = Brushes.White;
            if (args.Length == 1)
            {
                var colour = args[0];
                fillbrush = new SolidBrush(Color.FromArgb(
                    Convert.ToByte(colour.Substring(1, 2), 16),
                    Convert.ToByte(colour.Substring(3, 2), 16),
                    Convert.ToByte(colour.Substring(5, 2), 16))
                );
            }

            string pathToIcon = "iconinput.png";
            string pathToLogo = "logoinput.png";

            List<CreateImage> icons = new List<CreateImage>();
            icons.Add(new CreateImage(@"android\drawable\icon.png", 72, 72, 1));
            icons.Add(new CreateImage(@"android\drawable-hdpi\icon.png", 72, 72, 1));
            icons.Add(new CreateImage(@"android\drawable-ldpi\icon.png", 36, 36, 1));
            icons.Add(new CreateImage(@"android\drawable-mdpi\icon.png", 48, 48, 1));
            icons.Add(new CreateImage(@"android\drawable-xhdpi\icon.png", 96, 96, 1));
            icons.Add(new CreateImage(@"android\drawable-xxhdpi\icon.png", 144, 144, 1));
            icons.Add(new CreateImage(@"ios\icons\512x512.png", 512, 512, 1));
            icons.Add(new CreateImage(@"ios\icons\1024x1024.png", 1024, 1024, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-40.png", 40, 40, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-40@2x.png", 80, 80, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-50.png", 50, 50, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-50@2x.png", 100, 100, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-60.png", 60, 60, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-60@2x.png", 120, 120, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-60@3x.png", 180, 180, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-72.png", 72, 72, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-72@2x.png", 144, 144, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-76.png", 76, 76, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-76@2x.png", 152, 152, 1));
            //I added START to the images that needed reconverting to work with later code - Isaac 10/25 6:23 PM
            icons.Add(new CreateImage(@"ios\icons\icon-smallSTART.png", 29, 29, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-small@2xSTART.png", 58, 58, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-small@3xSTART.png", 87, 87, 1));
            icons.Add(new CreateImage(@"ios\icons\iconSTART.png", 57, 57, 1));
            icons.Add(new CreateImage(@"ios\icons\icon@2xSTART.png", 113+1, 114, 1));
            icons.Add(new CreateImage(@"ios\icons\icon-83.5@2x.png", 167, 167, 1));

            List<CreateImage> splashScreens = new List<CreateImage>();
            //splashScreens.Add(new CreateImage(@"android\drawable-port-hdpi\screen.png", 480, 800));
            //splashScreens.Add(new CreateImage(@"android\drawable-port-ldpi\screen.png", 200, 320));
            //splashScreens.Add(new CreateImage(@"android\drawable-port-mdpi\screen.png", 320, 480));
            //splashScreens.Add(new CreateImage(@"android\drawable-port-xhdpi\screen.png", 720, 1280));
            splashScreens.Add(new CreateImage(@"android\drawable-port-hdpi\screen.png", 960, 1600, .8));
            splashScreens.Add(new CreateImage(@"android\drawable-port-ldpi\screen.png", 400, 640, .8));
            splashScreens.Add(new CreateImage(@"android\drawable-port-mdpi\screen.png", 640, 960, .8));
            splashScreens.Add(new CreateImage(@"android\drawable-port-xhdpi\screen.png", 1440, 2560, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default-568h@2x~iphone.png", 640, 1136, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default-667h.png", 750, 1334, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default-736h.png", 1242, 2208, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default-Landscape-736h.png", 1242, 2208, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default-Landscape@2x~ipad.png", 1536, 2048, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default-Landscape~ipad.png", 768, 1024, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default-Portrait@2x~ipad.png", 1536, 2048, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default-Portrait~ipad.png", 768, 1024, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default@2x~iphone.png", 640, 960, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default@~iphone.png", 320, 480, .8));

            splashScreens.Add(new CreateImage(@"ios\splash\Default@2x~iphone~anyany.png", 1334, 1334, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default@2x~iphone~comany.png", 750, 1334, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default@2x~iphone~comcom.png", 1334, 750, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default@3x~iphone~anyany.png", 2208, 2208, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default@3x~iphone~anycom.png", 2208, 1242, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default@3x~iphone~comany.png", 1242, 2208, .8));
            splashScreens.Add(new CreateImage(@"ios\splash\Default@2x~ipad~anyany.png", 2732, 2732, .5));
            splashScreens.Add(new CreateImage(@"ios\splash\Default@2x~ipad~comany.png", 1278, 2732, .5));

            for (int i = 0; i < icons.Count; i++)
            {
                if (!Directory.Exists(Path.GetDirectoryName(icons[i].filepath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(icons[i].filepath));
                }
                Resize(pathToIcon, icons[i].filepath, icons[i].height);
            }


            /*   This is the start of Isaac's Changes.
             The only pictures that had problems were ones with random odd numbers, 
             and the 32-bit Integer couldn't hold the full decimal so it sumplified to the nearest 
             pixel. I converted them twice so that they would come out as the correct pixels.
             -----Isaac 10/25 6:25 PM  */


            List<CreateImage> iconsToSize = new List<CreateImage>();
            iconsToSize.Add(new CreateImage(@"ios\icons\icon-smallSTART.png", 290, 290, 1));
            iconsToSize.Add(new CreateImage(@"ios\icons\icon-small@2xSTART.png", 58, 58, 1));
            iconsToSize.Add(new CreateImage(@"ios\icons\icon-small@3xSTART.png", 87, 87, 1));
            iconsToSize.Add(new CreateImage(@"ios\icons\iconSTART.png", 57, 57, 1));
            iconsToSize.Add(new CreateImage(@"ios\icons\icon@2xSTART.png", 228, 228, 1));

            File.Delete(@"ios\icons\icon-small.png");
            File.Delete(@"ios\icons\icon-small@2x.png");
            File.Delete(@"ios\icons\icon-small@3x.png");
            File.Delete(@"ios\icons\icon.png");
            File.Delete(@"ios\icons\icon@2x.png");
            for (int i = 0; i < 5; i++)
            {
                string newName = " ";
                int size = 1000;
                    if (!Directory.Exists(Path.GetDirectoryName(iconsToSize[i].filepath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(iconsToSize[i].filepath));
                    }

                switch(i){
                    case 0:
                        newName = @"ios\icons\icon-small.png";
                        size = 28 + 1;
                        break;
                    case 1:
                        newName = @"ios\icons\icon-small@2x.png";
                        size = 57 + 1;
                        break;
                    case 2:
                        newName = @"ios\icons\icon-small@3x.png";
                        size = 86 + 1;
                        break;
                    case 3:
                        newName = @"ios\icons\icon.png";
                        size = 56 + 1;
                        break;
                    case 4:
                        newName = @"ios\icons\icon@2x.png";
                        size = 114;
                        break;
                                 }
                    Resize(iconsToSize[i].filepath, newName, size);
                    File.Delete(iconsToSize[i].filepath);
             }
    // That is the end of Isaac's Changes

            File.Copy(pathToLogo, "logo.png");
            for (int i = 0; i < splashScreens.Count; i++)
            {
                if( !Directory.Exists(Path.GetDirectoryName(splashScreens[i].filepath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(splashScreens[i].filepath));
                }
                using (var srcImage = Image.FromFile(pathToLogo))
                {
                    double scaleFactorWidth = (double)splashScreens[i].width*splashScreens[i].logoSize / (double)srcImage.Width;
                    double scaleFactorHeight = (double)splashScreens[i].height*splashScreens[i].logoSize / (double)srcImage.Height;
                    double finalScale = scaleFactorWidth;
                    if (scaleFactorHeight < scaleFactorWidth)
                        finalScale = scaleFactorHeight;
                    var newWidth = (int)(srcImage.Width * finalScale);
                    var newHeight = (int)(srcImage.Height * finalScale);

                    Image newImage = new Bitmap(splashScreens[i].width, splashScreens[i].height, PixelFormat.Format32bppRgb);
                    using (Graphics graphics = Graphics.FromImage(newImage))
                    {
                        graphics.FillRectangle(fillbrush, 0, 0, splashScreens[i].width, splashScreens[i].height);
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphics.DrawImage(srcImage, new Rectangle((int)(((float)splashScreens[i].width / (float)2.0) - ((float)newWidth / (float)2.0)), (int)(((float)splashScreens[i].height / (float)2.0) - ((float)newHeight / (float)2.0)), newWidth, newHeight));
                        newImage.Save(splashScreens[i].filepath, ImageFormat.Png);

                    }
                }
            }

        }

        public static void Resize(string imageFile, string outputFile, double maxSize )
        {
            using (var srcImage = Image.FromFile(imageFile))
            {
                
                double scaleFactor = (double)maxSize / (double)srcImage.Width;
                if (srcImage.Width < srcImage.Height)
                    scaleFactor = (double)maxSize / (double)srcImage.Height;
                var newWidth = (int)(srcImage.Width * scaleFactor);
                var newHeight = (int)(srcImage.Height * scaleFactor);
                using (var newImage = new Bitmap(newWidth, newHeight))
                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
                    newImage.Save(outputFile, ImageFormat.Png);
                }
            }
        }

        public static void ResizeOnlyBig(string imageFile, string outputFile, double maxSize)
        {
            using (var srcImage = Image.FromFile(imageFile))
            {
                if (srcImage.Width > maxSize || srcImage.Height > maxSize)
                {
                    double scaleFactor = (double)maxSize / (double)srcImage.Width;
                    if (srcImage.Width < srcImage.Height)
                        scaleFactor = (double)maxSize / (double)srcImage.Height;
                    var newWidth = (int)(srcImage.Width * scaleFactor);
                    var newHeight = (int)(srcImage.Height * scaleFactor);
                    using (var newImage = new Bitmap(newWidth, newHeight))
                    using (var graphics = Graphics.FromImage(newImage))
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
                        newImage.Save(outputFile, ImageFormat.Png);
                    }
                }
            }
        }

        private Image MergeImages(Image backgroundImage,
                          Image overlayImage)
        {
            Image theResult = backgroundImage;
            if (null != overlayImage)
            {
                Image theOverlay = overlayImage;
                if (PixelFormat.Format32bppArgb != overlayImage.PixelFormat)
                {
                    theOverlay = new Bitmap(overlayImage.Width,
                                            overlayImage.Height,
                                            PixelFormat.Format32bppArgb);
                    using (Graphics graphics = Graphics.FromImage(theOverlay))
                    {
                        graphics.DrawImage(overlayImage,
                                           new Rectangle(0, 0, theOverlay.Width, theOverlay.Height),
                                           new Rectangle(0, 0, overlayImage.Width, overlayImage.Height),
                                           GraphicsUnit.Pixel);
                    }
                    ((Bitmap)theOverlay).MakeTransparent();
                }

                using (Graphics graphics = Graphics.FromImage(theResult))
                {
                    graphics.DrawImage(theOverlay,
                                       new Rectangle(0, 0, theResult.Width, theResult.Height),
                                       new Rectangle(0, 0, theOverlay.Width, theOverlay.Height),
                                       GraphicsUnit.Pixel);
                }
            }

            return theResult;
        }
    }

    public class CreateImage
    {
        public string filepath;
        public int width;
        public int height;
        public double logoSize;

        public CreateImage(string tempfile, int tempWidth, int tempHeight, double tempLogoSize)
        {
            this.filepath = tempfile;
            this.width = tempWidth;
            this.height = tempHeight;
            this.logoSize = tempLogoSize;
        }
    }
}
