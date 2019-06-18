using Bing.Printer.Enums;
using Bing.Printer.Extensions;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 样式操作
    /// </summary>
    internal class Style:IStyle<byte[]>
    {
        /// <summary>
        /// 设置打印样式
        /// </summary>
        /// <param name="style">打印样式</param>
        public byte[] Styles(PrintStyle style) => new[] {ASCIIControlConst.ESC, CommandConst.Chars.StyleMode, style.ToByte()};

        /// <summary>
        /// 设置字符间距
        /// </summary>
        /// <param name="spaceCount">空格数</param>
        public byte[] RightCharacterSpacing(int spaceCount) => new[] { ASCIIControlConst.ESC, CommandConst.Chars.RightCharacterSpacing, spaceCount.ToByte() };
    }
}
