using System;

namespace Bing.Printer.Enums
{
    /// <summary>
    /// 打印样式
    /// </summary>
    [Flags]
    public enum PrintStyle
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 0,
        /// <summary>
        /// 加粗
        /// </summary>
        FontB = 1,
        /// <summary>
        /// 粗体
        /// </summary>
        Bold = 1 << 3,
        /// <summary>
        /// 双倍高度
        /// </summary>
        DoubleHeight = 1 << 4,
        /// <summary>
        /// 双倍宽度
        /// </summary>
        DoubleWidth = 1 << 5,
        /// <summary>
        /// 下划线
        /// </summary>
        Underline = 1 << 7
    }
}
