using System.Drawing;
using System.IO;

namespace Bing.Printer.Operations
{
    /// <summary>
    /// 图片操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IImage<out T>
    {
        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="imgPath">图片路径</param>
        T PrintImage(string imgPath);

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="stream">流</param>
        T PrintImage(Stream stream);

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="bytes">字节数组</param>
        T PrintImage(byte[] bytes);

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="image">图片</param>
        T PrintImage(Image image);
    }
}
