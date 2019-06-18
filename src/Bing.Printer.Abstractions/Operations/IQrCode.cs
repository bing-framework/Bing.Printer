using Bing.Printer.Enums;

namespace Bing.Printer.Operations
{
    /// <summary>
    /// 二维码操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IQrCode<out T>
    {
        /// <summary>
        /// 设置二维码
        /// </summary>
        /// <param name="value">值</param>
        T QrCode(string value);

        /// <summary>
        /// 设置二维码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="size">二维码大小</param>
        T QrCode(string value, QrCodeSize size);
    }
}
