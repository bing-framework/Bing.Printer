using System.Collections.Generic;
using System.Text;
using Bing.Printer.Enums;
using Bing.Printer.Extensions;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 二维码操作
    /// </summary>
    internal class QRCode : IQrCode<byte[]>
    {
        /// <summary>
        /// 获取二维码大小二进制数组
        /// </summary>
        /// <param name="size">二维码大小</param>
        private static byte[] Size(QrCodeSize size) => new byte[] {29, 40, 107, 3, 0, 49, 67}
            .AddBytes(new[] {(size + 3).ToByte()});

        /// <summary>
        /// 模式码
        /// </summary>
        private static IEnumerable<byte> ModelQr() => new byte[] {29, 40, 107, 4, 0, 49, 65, 50, 0};

        /// <summary>
        /// 容错码
        /// </summary>
        private static IEnumerable<byte> ErrorQr() => new byte[] {29, 40, 107, 3, 0, 49, 69, 48};

        /// <summary>
        /// 存储码
        /// </summary>
        /// <param name="qrData">二维码数据</param>
        private static IEnumerable<byte> StoreQr(string qrData)
        {
            var length = qrData.Length + 3;
            var b = (byte) (length % 256);
            var b2 = (byte) (length / 256);

            return new byte[] { 29, 40, 107 }
                .AddBytes(new[] { b })
                .AddBytes(new[] { b2 })
                .AddBytes(new byte[] { 49, 80, 48 });
        }

        /// <summary>
        /// 打印码
        /// </summary>
        private static IEnumerable<byte> PrintQr() => new byte[] {29, 40, 107, 3, 0, 49, 81, 48};

        /// <summary>
        /// 设置二维码
        /// </summary>
        /// <param name="value">值</param>
        public byte[] QrCode(string value)
        {
            return QrCode(value, QrCodeSize.Size0);
        }

        /// <summary>
        /// 设置二维码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="size">二维码大小</param>
        public byte[] QrCode(string value, QrCodeSize size)
        {
            var list = new List<byte>();
            list.AddRange(ModelQr());
            list.AddRange(Size(size));
            list.AddRange(ErrorQr());
            list.AddRange(StoreQr(value));
            list.AddRange(Encoding.UTF8.GetBytes(value));
            list.AddRange(PrintQr());
            return list.ToArray();
        }
    }
}
