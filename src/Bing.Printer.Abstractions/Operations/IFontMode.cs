using Bing.Printer.Enums;

namespace Bing.Printer.Operations
{
    /// <summary>
    /// 字体模式操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IFontMode<out T>
    {
        /// <summary>
        /// 倾斜。将文字变为斜体
        /// </summary>
        /// <param name="value">值</param>
        T Italic(string value);

        /// <summary>
        /// 倾斜。将文字变为斜体
        /// </summary>
        /// <param name="state">打印模式状态</param>
        T Italic(PrinterModeState state);

        /// <summary>
        /// 加粗。将文字加粗
        /// </summary>
        /// <param name="value">值</param>
        T Bold(string value);

        /// <summary>
        /// 加粗。将文字加粗
        /// </summary>
        /// <param name="state">打印模式状态</param>
        T Bold(PrinterModeState state);

        /// <summary>
        /// 下划线。为文字添加下划线
        /// </summary>
        /// <param name="value">值</param>
        T Underline(string value);

        /// <summary>
        /// 下划线。为文字添加下划线
        /// </summary>
        /// <param name="state">打印模式状态</param>
        T Underline(PrinterModeState state);

        /// <summary>
        /// 稀疏
        /// </summary>
        /// <param name="value">值</param>
        T Expanded(string value);

        /// <summary>
        /// 稀疏
        /// </summary>
        /// <param name="state">打印模式状态</param>
        T Expanded(PrinterModeState state);

        /// <summary>
        /// 简明
        /// </summary>
        /// <param name="value">值</param>
        T Condensed(string value);

        /// <summary>
        /// 简明
        /// </summary>
        /// <param name="state">打印模式</param>
        T Condensed(PrinterModeState state);
    }
}
