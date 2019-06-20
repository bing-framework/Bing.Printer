using Bing.Printer.Enums;

namespace Bing.Printer.Operations
{
    /// <summary>
    /// 字体样式操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IFontStyle<out T>
    {
        /// <summary>
        /// 标准尺寸字体
        /// </summary>
        T NormalSize();

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
        /// 下划线(1点宽)。为文字添加下划线，仅支持英文字符数字
        /// </summary>
        /// <param name="value">值</param>
        T Underline(string value);

        /// <summary>
        /// 下划线(1点宽)。为文字添加下划线，仅支持英文字符数字
        /// </summary>
        /// <param name="state">打印模式状态</param>
        T Underline(PrinterModeState state);

        /// <summary>
        /// 下划线(2点宽)。为文字添加下划线，仅支持英文字符数字
        /// </summary>
        /// <param name="value">值</param>
        T Underline2(string value);

        /// <summary>
        /// 下划线(2点宽)。为文字添加下划线，仅支持英文字符数字
        /// </summary>
        /// <param name="state">打印模式状态</param>
        T Underline2(PrinterModeState state);
    }
}
