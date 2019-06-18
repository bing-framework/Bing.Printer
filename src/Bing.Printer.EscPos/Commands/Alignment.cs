using Bing.Printer.Enums;
using Bing.Printer.Extensions;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 对齐方式操作
    /// </summary>
    internal class Alignment : IAlignment<byte[]>
    {
        /// <summary>
        /// 左对齐
        /// </summary>
        public byte[] Left() => new[] {ASCIIControlConst.ESC, CommandConst.Chars.Alignment, Align.Left.ToByte()};

        /// <summary>
        /// 居中
        /// </summary>
        public byte[] Center() => new[] { ASCIIControlConst.ESC, CommandConst.Chars.Alignment, Align.Center.ToByte() };

        /// <summary>
        /// 右对齐
        /// </summary>
        public byte[] Right() => new[] { ASCIIControlConst.ESC, CommandConst.Chars.Alignment, Align.Right.ToByte() };

    }
}
