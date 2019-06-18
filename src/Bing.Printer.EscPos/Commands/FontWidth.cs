using Bing.Printer.Extensions;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 字体宽度操作
    /// </summary>
    internal class FontWidth : IFontWidth<byte[]>
    {
        /// <summary>
        /// 正常宽度
        /// </summary>
        public byte[] NormalWidth() => new byte[] {27, '!'.ToByte(), 0};

        /// <summary>
        /// 2倍宽度
        /// </summary>
        public byte[] DoubleWidth2() => new byte[] {27, '!'.ToByte(), 16};

        /// <summary>
        /// 3倍宽度
        /// </summary>
        public byte[] DoubleWidth3() => new byte[] { 27, '!'.ToByte(), 32 };
    }
}
