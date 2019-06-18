namespace Bing.Printer
{
    /// <summary>
    /// 打印纸
    /// </summary>
    public interface IPrintPaper
    {
        /// <summary>
        /// 获取行宽度
        /// </summary>
        int GetLineWidth();

        /// <summary>
        /// 获取一行字符串宽度
        /// </summary>
        /// <param name="textSize">文本大小</param>
        int GetLineStringWidth(int textSize);

        /// <summary>
        /// 获取最大绘制宽度
        /// </summary>
        int GetDrawableMaxWidth();
    }
}
