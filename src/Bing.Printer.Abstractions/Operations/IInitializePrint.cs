namespace Bing.Printer.Operations
{
    /// <summary>
    /// 初始化打印操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IInitializePrint<out T>
    {
        /// <summary>
        /// 初始化
        /// </summary>
        T Initialize();

        /// <summary>
        /// 启用
        /// </summary>
        T Enable();

        /// <summary>
        /// 禁用
        /// </summary>
        T Disable();
    }
}
