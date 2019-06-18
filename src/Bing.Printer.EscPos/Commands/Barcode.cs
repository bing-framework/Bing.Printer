using Bing.Printer.Extensions;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 条码操作
    /// </summary>
    internal class Barcode : IBarcode<byte[]>
    {
        /// <summary>
        /// 设置 Code39 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Code39(string value)
        {
            return new byte[] { ASCIIControlConst.GS, CommandConst.Barcodes.Print, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 102, 0 }) // font hri character
                .AddBytes(new byte[] { 29, 72, 0 }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 4 })
                .AddBytes(value)
                .AddBytes(new byte[] { 0 })
                .AddLf();
        }

        /// <summary>
        /// 设置 Code128 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Code128(string value)
        {
            return new byte[] { ASCIIControlConst.GS, CommandConst.Barcodes.Print, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 102, 1 }) // font hri character
                .AddBytes(new byte[] { 29, 72, 0 }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 73 }) // printCode
                .AddBytes(new[] { (byte)(value.Length + 2) })
                .AddBytes(new[] { '{'.ToByte(), 'C'.ToByte() })
                .AddBytes(value)
                .AddLf();
        }

        /// <summary>
        /// 设置 Ean13 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Ean13(string value)
        {
            if (value.Trim().Length != 13)
                return new byte[0];

            return new byte[] { ASCIIControlConst.GS, CommandConst.Barcodes.Print, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 72, 0 }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 67, 12 })
                .AddBytes(value.Substring(0, 12))
                .AddLf();
        }
    }
}
