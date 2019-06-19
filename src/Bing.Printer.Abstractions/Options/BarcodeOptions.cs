using Bing.Printer.Enums;

namespace Bing.Printer.Options
{
    /// <summary>
    /// 条形码选项
    /// </summary>
    public class BarcodeOptions
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public BarcodeWidth? Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// 显示位置
        /// </summary>
        public BarcodePositionType? Position { get; set; }

        /// <summary>
        /// 字体类型
        /// </summary>
        public BarcodeFontType? FontType { get; set; }

        /// <summary>
        /// 是否包含奇偶校验
        /// </summary>
        public bool? IncludeParity { get; set; }

        /// <summary>
        /// 条码类型
        /// </summary>
        public BarcodeType Type { get; set; }
    }
}
