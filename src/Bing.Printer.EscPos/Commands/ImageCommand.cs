using System;
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
            return PrintImage(Image.FromFile(imgPath));
        }

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="stream">流</param>
        public byte[] PrintImage(Stream stream)
        {
            return PrintImage(Image.FromStream(stream));
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
            return null;
        }
    }
}
