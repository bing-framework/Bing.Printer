namespace Bing.Printer.Operations
{
    /// <summary>
    /// 字体宽度操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IFontWidth<out T>
    {
        /// <summary>
        /// 正常宽度
        /// </summary>
        T NormalWidth();

        /// <summary>
        /// 2倍宽度
        /// </summary>
        T DoubleWidth2();

        /// <summary>
        /// 3倍宽度
        /// </summary>
        T DoubleWidth3();
    }
}
