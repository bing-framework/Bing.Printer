using Bing.Printer.Enums;
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
        /// 打印纸类型
        /// </summary>
        PrintPaperType PrintPaper { get; set; }
    }

    /// <summary>
    /// 打印机
    /// </summary>
    /// <typeparam name="TPrinter">打印机类型</typeparam>
    public interface IPrinter<out TPrinter> : IPrinter
        , IWriter<TPrinter>
        , ICommand<TPrinter>
        , IFontMode<TPrinter>
        , IFontWidth<TPrinter>
        , IAlignment<TPrinter>
        , IPagerCut<TPrinter>
        , IDrawer<TPrinter>
        , IQrCode<TPrinter>
        , IBarcode<TPrinter>
        , IStyle<TPrinter>
        , IInitializePrint<TPrinter>
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
    }
}
