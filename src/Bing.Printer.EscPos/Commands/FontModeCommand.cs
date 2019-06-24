using Bing.Printer.Enums;
using Bing.Printer.Extensions;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 字体模式操作
    /// </summary>
    internal class FontModeCommand : IFontMode<byte[]>
    {
        /// <summary>
        /// 倾斜。将文字变为斜体
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Italic(string value) => Italic(PrinterModeState.On)
            .AddBytes(value)
            .AddBytes(Italic(PrinterModeState.Off))
            .AddLf();

        /// <summary>
        /// 倾斜。将文字变为斜体
        /// </summary>
        /// <param name="state">打印模式状态</param>
        public byte[] Italic(PrinterModeState state) => state == PrinterModeState.On
            ? new byte[] {27, '4'.ToByte()}
            : new byte[] {27, '5'.ToByte()};

        /// <summary>
        /// 加粗。将文字加粗
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Bold(string value) => Bold(PrinterModeState.On)
            .AddBytes(value)
            .AddBytes(Bold(PrinterModeState.Off))
            .AddLf();

        /// <summary>
        /// 加粗。将文字加粗
        /// </summary>
        /// <param name="state">打印模式状态</param>
        public byte[] Bold(PrinterModeState state) => state == PrinterModeState.On
            ? new byte[] {27, 'E'.ToByte(), 1}
            : new byte[] {27, 'E'.ToByte(), 0};

        /// <summary>
        /// 下划线。为文字添加下划线
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Underline(string value) => Underline(PrinterModeState.On)
            .AddBytes(value)
            .AddBytes(Underline(PrinterModeState.Off))
            .AddLf();

        /// <summary>
        /// 下划线。为文字添加下划线
        /// </summary>
        /// <param name="state">打印模式状态</param>
        public byte[] Underline(PrinterModeState state) => state == PrinterModeState.On
            ? new byte[] {27, '-'.ToByte(), 1}
            : new byte[] {27, '-'.ToByte(), 0};

        /// <summary>
        /// 稀疏
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Expanded(string value) => Expanded(PrinterModeState.On)
            .AddBytes(value)
            .AddBytes(Expanded(PrinterModeState.Off))
            .AddLf();

        /// <summary>
        /// 稀疏
        /// </summary>
        /// <param name="state">打印模式状态</param>
        public byte[] Expanded(PrinterModeState state) => state == PrinterModeState.On
            ? new byte[] {29, '!'.ToByte(), 16}
            : new byte[] {29, '!'.ToByte(), 0};

        /// <summary>
        /// 简明
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Condensed(string value) => Condensed(PrinterModeState.On)
            .AddBytes(value)
            .AddBytes(Condensed(PrinterModeState.Off))
            .AddLf();

        /// <summary>
        /// 简明
        /// </summary>
        /// <param name="state">打印模式</param>
        public byte[] Condensed(PrinterModeState state) => state == PrinterModeState.On
            ? Command.ASCII.CompressionSize
            : Command.ASCII.NormalSize.AddBytes(Command.Chinese.FontSizeReset);
    }
}
