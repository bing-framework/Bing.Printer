namespace Bing.Printer.Operations
{
    /// <summary>
    /// 打印线操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IPrintLine<out T>
    {
        /// <summary>
        /// 设置实线
        /// </summary>
        T SolidLine();

        /// <summary>
        /// 设置空行
        /// </summary>
        T EmptyLine();

        /// <summary>
        /// 设置虚线
        /// </summary>
        T DottedLine();

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        T WriteOneLine(string text1, string text2);

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="textSize">文字大小</param>
        T WriteOneLine(string text1, string text2, int textSize);

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="text3">文本3</param>
        T WriteOneLine(string text1, string text2, string text3);

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="text3">文本3</param>
        /// <param name="textSize">文字大小</param>
        T WriteOneLine(string text1, string text2, string text3, int textSize);

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="text3">文本3</param>
        /// <param name="text4">文本4</param>
        T WriteOneLine(string text1, string text2, string text3, string text4);

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="text3">文本3</param>
        /// <param name="text4">文本4</param>
        /// <param name="textSize">文字大小</param>
        T WriteOneLine(string text1, string text2, string text3, string text4, int textSize);
    }
}
