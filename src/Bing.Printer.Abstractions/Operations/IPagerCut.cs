namespace Bing.Printer.Operations
{
    /// <summary>
    /// 页面截断操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IPagerCut<out T>
    {
        /// <summary>
        /// 全页截断
        /// </summary>
        T Full();

        /// <summary>
        /// 部分截断
        /// </summary>
        T Partial();
    }
}
