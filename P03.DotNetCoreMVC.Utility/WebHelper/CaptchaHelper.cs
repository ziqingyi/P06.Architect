using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.Utility.WebHelper
{
    public class CaptchaHelper
    {
        private static string ImagePath = @"C:\IOSerialize\Image\";
        private static string VerifyPath = @"C:\IOSerialize\Image\";
        //Bitmap is like a canvas, Graphics is like a hand, using Pen or Brush painting on the Bitmap

        static CaptchaHelper()
        {
            if (!Directory.Exists(ImagePath))
                Directory.CreateDirectory(ImagePath);
            if (!Directory.Exists(VerifyPath))
                Directory.CreateDirectory(VerifyPath);
        }


        public static void Drawing()
        {
            Bitmap bitmapobj = new Bitmap(1000, 1500);
            //create a new Graphics based on Bitmap object
            Graphics g = Graphics.FromImage(bitmapobj);
            g.Clear(Color.White);
            //create obj used for painting, like Pen or Brush
            Pen redPen = new Pen(Color.Red, 8);

            //paint graph
            g.DrawLine(redPen, 50, 20, 500, 20);
            g.DrawEllipse(Pens.Black, new Rectangle(0, 0, 200, 100));
            g.DrawArc(Pens.Aqua, new Rectangle(0, 0, 900, 500), 60, 180);
            g.DrawLine(Pens.Blue, 0, 0, 600, 100);
            g.DrawRectangle(Pens.Chartreuse, new Rectangle(0, 0, 800, 500));
            g.DrawString("this is my picture",
                new Font("Magic R", 200),
                new SolidBrush(Color.Green), new PointF(10, 10));

            bitmapobj.Save(ImagePath + "pic1.jpg", ImageFormat.Jpeg);

            //free up all obj
            bitmapobj.Dispose();
            g.Dispose();
        }
        public static void CreateCaptchaFile()
        {
            Bitmap bitmapobj = new Bitmap(200, 300);
            Graphics g = Graphics.FromImage(bitmapobj);
            g.DrawRectangle(Pens.Blue, new Rectangle(0, 0, 150, 50));
            g.FillRectangle(Brushes.White, new Rectangle(1, 1, 139, 49));
            g.DrawArc(Pens.Blue,
                new Rectangle(10, 10, 140, 10),
                150, 90);//random curve lines.
            string[] arrStr = new string[] { "A", "C", "E", "F", "X", "Z", "K", "H", "G", "O" };
            Random r = new Random();
            int i;
            for (int j = 0; j < 4; j++)
            {
                i = r.Next(10);
                g.DrawString(
                    arrStr[i],
                    new Font("", 15),
                    Brushes.Red, new PointF(j * 30, 10));
            }
            bitmapobj.Save(Path.Combine(VerifyPath, "verif.jpg"), ImageFormat.Jpeg);
            bitmapobj.Dispose();
            g.Dispose();

        }


        public static Bitmap CreateCaptchaObject(out string code)
        {
            //build Bitmap object.
            Bitmap bitmap = new Bitmap(200, 60);
            Graphics graph = Graphics.FromImage(bitmap);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, 200, 60);
            Font font = new Font(FontFamily.GenericSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel);
            Random r = new Random();
            string letters = "ABCDEFGHIJKLMNPQRSTUVWXYZ0123456789";

            StringBuilder sb = new StringBuilder();

            //add 5 letters randomly
            for (int x = 0; x < 5; x++)
            {
                string letter = letters.Substring(r.Next(0, letters.Length - 1), 1);
                sb.Append(letter);
                graph.DrawString(letter, font, new SolidBrush(Color.Black), x * 38, r.Next(0, 15));
            }
            code = sb.ToString();

            //draw back ground lines 
            Pen linePen = new Pen(new SolidBrush(Color.Black), 2);
            for (int x = 0; x < 6; x++)
                graph.DrawLine(linePen, new Point(r.Next(0, 199), r.Next(0, 59)), new Point(r.Next(0, 199), r.Next(0, 59)));
            return bitmap;
        }

        //compress picture
        public static void CompressPercent(string oldPath, string newPath, int maxWidth, int maxHeight)
        {
            Image _sourceImg = Image.FromFile(oldPath);
            double _newW = (double)maxWidth;
            double _newH = (double)maxHeight;
            double percentWidth = (double)_sourceImg.Width > maxWidth ? (double)maxWidth : (double)_sourceImg.Width;
            if ((double)_sourceImg.Height * (double)percentWidth / (double)_sourceImg.Width > (double)maxHeight)
            {
                _newH = (double)maxHeight;
                _newW = (double)maxHeight / (double)_sourceImg.Height * (double)_sourceImg.Width;
            }
            else
            {
                _newW = percentWidth;
                _newH = (percentWidth / (double)_sourceImg.Width) * (double)_sourceImg.Height;
            }

            Image bitMap = new Bitmap((int)_newW, (int)_newH);
            Graphics g = Graphics.FromImage(bitMap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(_sourceImg,
                new Rectangle(0, 0, (int)_newW, (int)_newH),
                new Rectangle(0, 0, _sourceImg.Width, _sourceImg.Height),
                GraphicsUnit.Pixel
                );
            _sourceImg.Dispose();
            bitMap.Save(newPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            bitMap.Dispose();
        }

        public static void ImageChangeBySize(string oldPath, string newPath, int newWidth, int newHeight)
        {
            Image sourceImg = Image.FromFile(oldPath);
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(bitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(sourceImg,
                new Rectangle(0, 0, newWidth, newHeight),
                new Rectangle(0, 0, sourceImg.Width, sourceImg.Height),
                GraphicsUnit.Pixel);

            sourceImg.Dispose();
            g.Dispose();
            bitmap.Save(newPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            bitmap.Dispose();
        }













    }
}
