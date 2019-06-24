using Bing.Printer.Enums;

namespace Bing.Printer.Extensions
{
    /// <summary>
    /// 打印机扩展
    /// </summary>
    public static class PrinterExtensions
    {
        /// <summary>
        /// 设置 Code39 类型条码
        /// </summary>
        /// <typeparam name="TPrinter">打印机类型</typeparam>
        /// <param name="printer">打印机</param>
        /// <param name="value">值</param>
        public static TPrinter Code39<TPrinter>(this TPrinter printer, string value) where TPrinter : IPrinter<TPrinter>
        {
            return printer.Code39(value, BarcodePositionType.None, BarcodeWidth.Default, 100, true);
        }

        /// <summary>
        /// 设置 Code128 类型条码
        /// </summary>
        /// <typeparam name="TPrinter">打印机类型</typeparam>
        /// <param name="printer">打印机</param>
        /// <param name="value">值</param>
        public static TPrinter Code128<TPrinter>(this TPrinter printer,string value) where TPrinter : IPrinter<TPrinter>
        {
            return printer.Code128(value, BarcodePositionType.None, BarcodeWidth.Default, 100, true); 
        }

        /// <summary>
        /// 设置 Ean13 类型条码
        /// </summary>
        /// <typeparam name="TPrinter">打印机类型</typeparam>
        /// <param name="printer">打印机</param>
        /// <param name="value">值</param>
        public static TPrinter Ean13<TPrinter>(this TPrinter printer, string value) where TPrinter : IPrinter<TPrinter>
        {
            return printer.Ean13(value, BarcodePositionType.None, BarcodeWidth.Default, 100, true);
        }
    }
}
