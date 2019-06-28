using Bing.Printer.Extensions;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 打印样式操作命令
    /// </summary>
    internal class PrintStyleCommand : IPrintStyle<byte[]>
    {
        /// <summary>
        /// 设置左边距
        /// </summary>
        /// <param name="value">值</param>
        public byte[] LeftMargin(int value = 0)
        {
            var nH = value >> 8;
            var nL = value - (nH << 8);
            return Command.StyleLeftMargin.AddBytes(new[] { nL.ToByte(), nH.ToByte() });
        }

        /// <summary>
        /// 设置左边距
        /// </summary>
        /// <param name="nL">边距值</param>
        /// <param name="nH">高度</param>
        public byte[] LeftMargin(int nL, int nH) => Command.StyleLeftMargin.AddBytes(new[] { nL.ToByte(), nH.ToByte() });

        /// <summary>
        /// 设置打印区域宽度
        /// </summary>
        /// <param name="nL">长度</param>
        /// <param name="nH">高度</param>
        public byte[] PrintWidth(int nL, int nH) => Command.StylePrintWidth.AddBytes(new[] {nL.ToByte(), nH.ToByte()});

        /// <summary>
        /// 设置相对横向打印位置
        /// </summary>
        /// <param name="nL">长度</param>
        /// <param name="nH">高度</param>
        public byte[] RelativeHorizontalPosition(int nL, int nH) => Command.StyleRelativeXPosition.AddBytes(new[] {nL.ToByte(), nH.ToByte()});

        /// <summary>
        /// 设置绝对打印位置
        /// </summary>
        /// <param name="nL">长度</param>
        /// <param name="nH">高度</param>
        public byte[] AbsolutePosition(int nL, int nH) => Command.StyleAbsolutePrintPosition.AddBytes(new[] { nL.ToByte(), nH.ToByte() });

        /// <summary>
        /// 左对齐
        /// </summary>
        public byte[] Left() => Command.StyleLeftAlign;

        /// <summary>
        /// 居中
        /// </summary>
        public byte[] Center() => Command.StyleCenterAlign;

        /// <summary>
        /// 右对齐
        /// </summary>
        public byte[] Right() => Command.StyleRightAlign;

        /// <summary>
        /// 设置默认行高
        /// </summary>
        public byte[] RowHeight() => Command.StyleDefaultRowHeight;

        /// <summary>
        /// 设置行高
        /// </summary>
        /// <param name="height">高度</param>
        public byte[] RowHeight(int height) => Command.StyleRowHeight.AddByte(height.ToByte());
    }
}
