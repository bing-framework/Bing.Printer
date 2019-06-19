using Bing.Printer.Enums;
using Bing.Printer.Options;

namespace Bing.Printer.Operations
{
    /// <summary>
    /// 条码操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IBarcode<out T>
    {
        /// <summary>
        /// 设置 Code39 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        T Code39(string value);

        /// <summary>
        /// 设置 Code128 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        T Code128(string value);

        /// <summary>
        /// 设置 Ean13 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        T Ean13(string value);

        /// <summary>
        /// 设置条形码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="options">条形码选项</param>
        T Barcode(string value, BarcodeOptions options);
    }
}
