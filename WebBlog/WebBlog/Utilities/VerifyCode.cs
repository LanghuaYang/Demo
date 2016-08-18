using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebBlog.Utilities
{
    public static class Verifycode
    {
        ///// <returns>验证码图片</returns>
        //public static byte[] Create(int len, out string strCode)
        //{
        //    MemoryStream stream = new MemoryStream();
        //    byte[] buffer = null;
        //    //噪线 噪点
        //    Color[] colors = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.DarkBlue };
        //    //验证码字体
        //    string[] fonts = { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" };
        //    //验证码内容
        //    char[] charactars = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'S', 'Y', 'Z' };
        //    //生成验证码字符串
        //    StringBuilder sb = new StringBuilder();
        //    Random r = new Random();
        //    for (int i = 0; i < len; i++)
        //    {
        //        char codeChar = charactars[r.Next(0, charactars.Length)];
        //        sb.Append(codeChar);
        //    }
        //    strCode = sb.ToString();
        //    using (Bitmap bitmap = new Bitmap(len * 25, 35))
        //    {
        //        using (Graphics g = Graphics.FromImage(bitmap))
        //        {
        //            g.Clear(Color.White);
        //            for (int i = 0; i < 10; i++)
        //            {
        //                int x1 = r.Next(100);
        //                int y1 = r.Next(40);
        //                int x2 = r.Next(100);
        //                int y2 = r.Next(40);
        //                Color color = colors[r.Next(colors.Length)];
        //                g.DrawLine(new Pen(color), x1, y1, x2, y2);
        //            }
        //            //将字符串画入图片
        //            for (int i = 0; i < strCode.Length; i++)
        //            {
        //                string font = fonts[r.Next(fonts.Length)];
        //                Font fnt = new Font(font, 18);
        //                Color color = colors[r.Next(colors.Length)];
        //                g.DrawString(strCode[i].ToString(), fnt, new SolidBrush(color), (float)i * 20 + 8, (float)8);
        //            }
        //            //画噪点
        //            for (int i = 0; i < 100; i++)
        //            {
        //                int x = r.Next(bitmap.Width);
        //                int y = r.Next(bitmap.Height);
        //                Color color = colors[r.Next(colors.Length)];
        //                bitmap.SetPixel(x, y, color);
        //            }
        //        }
        //        bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        buffer = stream.ToArray();
        //    }

        //    return buffer;

        //}
        public static string CreateVerificationText(int length)
        {
            char[] _verification = new char[length];
            char[] _dictionary = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Random _random = new Random();
            for (int i = 0; i < length; i++) { _verification[i] = _dictionary[_random.Next(_dictionary.Length - 1)]; }
            return new string(_verification);
        }

        public static Bitmap CreateVerificationImage(string verificationText, int width, int height)
        {
            Pen _pen = new Pen(Color.Black);
            Font _font = new Font("Arial", 14, FontStyle.Bold);
            Brush _brush = null;
            Bitmap _bitmap = new Bitmap(width, height);
            Graphics _g = Graphics.FromImage(_bitmap);
            SizeF _totalSizeF = _g.MeasureString(verificationText, _font);
            SizeF _curCharSizeF;
            PointF _startPointF = new PointF((width - _totalSizeF.Width) / 2, (height - _totalSizeF.Height) / 2);
            //随机数产生器
            Random _random = new Random();
            _g.Clear(Color.White);
            for (int i = 0; i < verificationText.Length; i++)
            {
                _brush = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), Color.FromArgb(_random.Next(255), _random.Next(255), _random.Next(255)), Color.FromArgb(_random.Next(255), _random.Next(255), _random.Next(255)));
                _g.DrawString(verificationText[i].ToString(), _font, _brush, _startPointF);
                _curCharSizeF = _g.MeasureString(verificationText[i].ToString(), _font);
                _startPointF.X += _curCharSizeF.Width;
            }
            _g.Dispose();
            return _bitmap;
        }
    }
}