using Bing.Printer.Operations;

namespace Bing.Printer
{
    /// <summary>
    /// 打印命令
    /// </summary>
    public interface IPrintCommand
    {
        /// <summary>
        /// 字体模式操作
        /// </summary>
        IFontMode<byte[]> FontMode { get; set; }

        /// <summary>
        /// 字体宽度操作
        /// </summary>
        IFontWidth<byte[]> FontWidth { get; set; }

        /// <summary>
        /// 页面截断操作
        /// </summary>
        IPagerCut<byte[]> PagerCut { get; set; }

        /// <summary>
        /// 绘制器操作
        /// </summary>
        IDrawer<byte[]> Drawer { get; set; }

        /// <summary>
        /// 二维码操作
        /// </summary>
        IQrCode<byte[]> QrCode { get; set; }

        /// <summary>
        /// 条形码操作
        /// </summary>
        IBarcode<byte[]> Barcode { get; set; }

        /// <summary>
        /// 样式操作
        /// </summary>
        IStyle<byte[]> Style { get; set; }

        /// <summary>
        /// 初始化打印操作
        /// </summary>
        IInitializePrint<byte[]> InitializePrint { get; set; }

        /// <summary>
        /// 打印样式操作
        /// </summary>
        IPrintStyle<byte[]> PrintStyle { get; set; }

        /// <summary>
        /// 图片操作
        /// </summary>
        IImage<byte[]> Image { get; set; }

        /// <summary>
        /// 写入操作
        /// </summary>
        IWriter Writer { get; set; }

        
    }
}
