namespace Bing.Printer.Enums
{
    /// <summary>
    /// 字体类型
    /// </summary>
    public enum FontType
    {
        /// <summary>
        /// 标准 ASCII 字体(13 x 24) 中文字体(24 x 24)
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 压缩 ASCII 字体(9 x 17) 中文字体(24 x 24)
        /// </summary>
        Compress0 = 1,
        /// <summary>
        /// ASCII 字体(8 x 16) 中文字体(16 x 16)
        /// </summary>
        Compress2 = 2,
        /// <summary>
        /// ASCII 字体(9 x 17) 中文字体(16 x 16)
        /// </summary>
        Compress1 = 3
    }
}
