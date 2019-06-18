using Bing.Printer.Enums;
using Bing.Printer.EscPos.Commands;
using Bing.Printer.Extensions;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos
{
    /// <summary>
    /// 打印命令
    /// </summary>
    internal class PrintCommand : IPrintCommand
    {
        public int ColsNomal => 48;
        public int ColsCondensed => 64;
        public int ColsExpanded => 24;

        /// <summary>
        /// 字体模式操作
        /// </summary>
        public IFontMode<byte[]> FontMode { get; set; }

        /// <summary>
        /// 字体宽度操作
        /// </summary>
        public IFontWidth<byte[]> FontWidth { get; set; }

        /// <summary>
        /// 对齐方式操作
        /// </summary>
        public IAlignment<byte[]> Alignment { get; set; }

        /// <summary>
        /// 页面截断操作
        /// </summary>
        public IPagerCut<byte[]> PagerCut { get; set; }

        /// <summary>
        /// 绘制器操作
        /// </summary>
        public IDrawer<byte[]> Drawer { get; set; }

        /// <summary>
        /// 二维码操作
        /// </summary>
        public IQrCode<byte[]> QrCode { get; set; }

        /// <summary>
        /// 条形码操作
        /// </summary>
        public IBarcode<byte[]> Barcode { get; set; }

        /// <summary>
        /// 样式操作
        /// </summary>
        public IStyle<byte[]> Style { get; set; }

        /// <summary>
        /// 初始化一个<see cref="PrintCommand"/>类型的实例
        /// </summary>
        public PrintCommand()
        {
            FontMode = new FontMode();
            FontWidth = new FontWidth();
            Alignment = new Alignment();
            PagerCut = new PagerCut();
            Drawer = new Drawer();
            QrCode = new QRCode();
            Barcode = new Barcode();
            Style = new Style();
        }

        /// <summary>
        /// 分隔符
        /// </summary>
        public byte[] Separator() => FontMode.Condensed(PrinterModeState.On)
            .AddBytes(new string('-', ColsCondensed))
            .AddBytes(FontMode.Condensed(PrinterModeState.Off))
            .AddCrLf();

        /// <summary>
        /// 自动测试
        /// </summary>
        public byte[] AutoTest() => new byte[] {29, 40, 65, 2, 0, 0, 2};
    }
}
