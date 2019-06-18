namespace Bing.Printer.Operations
{
    /// <summary>
    /// 绘制器操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IDrawer<out T>
    {
        /// <summary>
        /// 打开绘制器
        /// </summary>
        T OpenDrawer();
    }
}
