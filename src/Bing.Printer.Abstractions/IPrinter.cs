using Bing.Printer.Enums;
using Bing.Printer.Operations;

namespace Bing.Printer
{
    /// <summary>
    /// 打印机
    /// </summary>
    public interface IPrinter
    {
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
        , IFontStyle<TPrinter>
        , IPrintStyle<TPrinter>
        , IPagerCut<TPrinter>
        , IDrawer<TPrinter>
        , IQrCode<TPrinter>
        , IBarcode<TPrinter>
        , IStyle<TPrinter>
        , IInitializePrint<TPrinter>
        , IPrintLine<TPrinter>
        where TPrinter : IPrinter<TPrinter>
    {
    }
}
