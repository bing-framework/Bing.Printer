using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 图片操作命令
    /// </summary>
    internal class ImageCommand : IImage<byte[]>
    {
        /// <summary>
        /// 打印纸
        /// </summary>
        internal IPrintPaper PrintPaper { get; }

        /// <summary>
        /// 初始化一个<see cref="ImageCommand"/>类型的实例
        /// </summary>
        /// <param name="printPaper">打印纸</param>
        public ImageCommand(IPrintPaper printPaper)
        {
            PrintPaper = printPaper;
        }

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="imgPath">图片路径</param>
        public byte[] PrintImage(string imgPath)
        {
            using (var image= Image.FromFile(imgPath))
            {
                return PrintImage(image);
            }
        }

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="stream">流</param>
        public byte[] PrintImage(Stream stream)
        {
            using (var image = Image.FromStream(stream))
            {
                return PrintImage(image);
            }
        }

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="bytes">字节数组</param>
        public byte[] PrintImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return PrintImage(Image.FromStream(ms));
            }
        }

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="image">图片</param>
        public byte[] PrintImage(Image image)
        {
            var list = new List<byte>();
            var bmp = new Bitmap(image);
            //设置字符行间距为n点行
            //byte[] data = new byte[] { 0x1B, 0x33, 0x00 };
            string send = "" + (char)(27) + (char)(51) + (char)(0);
            byte[] data = new byte[send.Length];
            for (int i = 0; i < send.Length; i++)
            {
                data[i] = (byte)send[i];
            }

            list.AddRange(data);
            data[0] = (byte)'\x00';
            data[1] = (byte)'\x00';
            data[2] = (byte)'\x00'; // Clear to Zero.
            Color pixelColor;
            //ESC * m nL nH d1…dk   选择位图模式
            // ESC * m nL nH
            byte[] escBmp = new byte[] { 0x1B, 0x2A, 0x00, 0x00, 0x00 };
            escBmp[2] = (byte)'\x21';
            //nL, nH
            escBmp[3] = (byte)(bmp.Width % 256);
            escBmp[4] = (byte)(bmp.Width / 256);
            //循环图片像素打印图片
            //循环高
            for (int i = 0; i < (bmp.Height / 24 + 1); i++)
            {
                //设置模式为位图模式
                list.AddRange(escBmp);
                //循环宽
                for (int j = 0; j < bmp.Width; j++)
                {
                    for (int k = 0; k < 24; k++)
                    {
                        if (((i * 24) + k) < bmp.Height) // if within the BMP size
                        {
                            pixelColor = bmp.GetPixel(j, (i * 24) + k);
                            if (pixelColor.R == 0)
                            {
                                data[k / 8] += (byte)(128 >> (k % 8));

                            }
                        }
                    }

                    //一次写入一个data，24个像素
                    list.AddRange(data);

                    data[0] = (byte)'\x00';
                    data[1] = (byte)'\x00';
                    data[2] = (byte)'\x00'; // Clear to Zero.
                }

                //换行，打印第二行
                byte[] data2 = { 0xA };
                list.AddRange(data2);
            } // data

            return list.ToArray();
        }
    }
}
