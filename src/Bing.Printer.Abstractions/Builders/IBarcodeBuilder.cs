using Bing.Printer.Enums;

namespace Bing.Printer.Builders
{
    /// <summary>
    /// 条形码生成器
    /// </summary>
    public interface IBarcodeBuilder
    {
        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="width">宽度</param>
        IBarcodeBuilder Width(BarcodeWidth width);

        /// <summary>
        /// 设置高度
        /// </summary>
        /// <param name="height">高度</param>
        IBarcodeBuilder Height(int height);

        /// <summary>
        /// 设置标签显示位置
        /// </summary>
        /// <param name="position">位置</param>
        IBarcodeBuilder LabelPosition(BarcodePositionType position);

        /// <summary>
        /// 设置标签字体
        /// </summary>
        /// <param name="type">类型</param>
        IBarcodeBuilder LabelFontB(BarcodeFontType type);

        /// <summary>
        /// 生成条形码
        /// </summary>
        /// <param name="type">条形码类型</param>
        /// <param name="value">值</param>
        byte[] Build(BarcodeType type, string value);
    }
}
