using System.Text;
using Bing.Printer.Builders;
using Bing.Printer.EscPos.Builders;
using Bing.Printer.EscPos.Commands;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos
{
    /// <summary>
    /// 打印命令
    /// </summary>
    internal class PrintCommand : IPrintCommand
    {
        /// <summary>
        /// 字体样式操作
        /// </summary>
        public IFontStyle<byte[]> FontStyle { get; set; }

        /// <summary>
        /// 字体模式操作
        /// </summary>
        public IFontMode<byte[]> FontMode { get; set; }

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
        /// 条形码生成器
        /// </summary>
        internal IBarcodeBuilder BarcodeBuilder { get; set; }

        /// <summary>
        /// 初始化打印操作
        /// </summary>
        public IInitializePrint<byte[]> InitializePrint { get; set; }

        /// <summary>
        /// 打印样式操作
        /// </summary>
        public IPrintStyle<byte[]> PrintStyle { get; set; }

        /// <summary>
        /// 图片操作
        /// </summary>
        public IImage<byte[]> Image { get; set; }

        /// <summary>
        /// 写入器操作
        /// </summary>
        public IWriter Writer { get; set; }

        /// <summary>
        /// 打印行操作
        /// </summary>
        public IPrintLine<string> PrintLine { get; set; }

        /// <summary>
        /// 初始化一个<see cref="PrintCommand"/>类型的实例
        /// </summary>
        /// <param name="printPaper">打印纸</param>
        /// <param name="encoding">字符编码</param>
        public PrintCommand(IPrintPaper printPaper ,Encoding encoding)
        {
            Writer = new WriterCommand(encoding);
            BarcodeBuilder = new BarcodeBuilder(encoding);

            FontStyle = new FontStyleCommand();
            FontMode = new FontModeCommand();
            PagerCut = new PagerCutCommand();
            Drawer = new DrawerCommand();
            QrCode = new QRCodeCommand();
            Barcode = new BarcodeCommand(BarcodeBuilder);
            Style = new StyleCommand(printPaper, encoding);
            InitializePrint = new InitializePrintCommand();
            PrintStyle = new PrintStyleCommand();
            Image = new ImageCommand(printPaper);
            PrintLine = new PrintLineCommand(printPaper);
        }
    }
}
