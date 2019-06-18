namespace Bing.Printer.Operations
{
    /// <summary>
    /// 对齐方式操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IAlignment<out T>
    {
        /// <summary>
        /// 左对齐
        /// </summary>
        T Left();

        /// <summary>
        /// 右对齐
        /// </summary>
        T Right();

        /// <summary>
        /// 居中
        /// </summary>
        T Center();
    }
}
