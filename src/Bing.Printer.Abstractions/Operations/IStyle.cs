using Bing.Printer.Enums;

namespace Bing.Printer.Operations
{
    /// <summary>
    /// 样式操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IStyle<out T>
    {
        /// <summary>
        /// 设置打印样式
        /// </summary>
        /// <param name="style">打印样式</param>
        T Styles(PrintStyle style);

        /// <summary>
        /// 设置字符间距
        /// </summary>
        /// <param name="spaceCount">空格数</param>
        T RightCharacterSpacing(int spaceCount);

        /// <summary>
        /// 设置字体大小
        /// </summary>
        /// <param name="size">字体大小</param>
        T Size(int size);
    }
}
