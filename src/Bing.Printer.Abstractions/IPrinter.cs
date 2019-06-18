using Bing.Printer.Operations;

namespace Bing.Printer
{
    /// <summary>
    /// 打印机
    /// </summary>
    public interface IPrinter
    {
        int ColsNomal { get; }

        int ColsCondensed { get; }

        int ColsExpanded { get; }

        /// <summary>
        /// 转换成十六进制字符串
        /// </summary>
        string ToHex();
    }

    /// <summary>
    /// 打印机
    /// </summary>
    /// <typeparam name="TPrinter">打印机类型</typeparam>
    public interface IPrinter<out TPrinter> : IPrinter
        , ICommand<TPrinter>
        , IFontMode<TPrinter>
        , IFontWidth<TPrinter>
        , IAlignment<TPrinter>
        , IPagerCut<TPrinter>
        , IDrawer<TPrinter>
        , IQrCode<TPrinter>
        , IBarcode<TPrinter>
        where TPrinter : IPrinter<TPrinter>
    {
        /// <summary>
        /// 追加内容
        /// </summary>
        /// <param name="value">值</param>
        TPrinter Append(string value);

        /// <summary>
        /// 追加内容
        /// </summary>
        /// <param name="value">值</param>
        TPrinter Append(byte[] value);

        /// <summary>
        /// 追加内容并带有换行符
        /// </summary>
        /// <param name="value">值</param>
        TPrinter AppendWithoutLf(string value);

        /// <summary>
        /// 添加新行
        /// </summary>
        TPrinter NewLine();

        /// <summary>
        /// 添加多行
        /// </summary>
        /// <param name="lines">行数</param>
        TPrinter NewLines(int lines);

        /// <summary>
        /// 清空
        /// </summary>
        TPrinter Clear();
    }
}
