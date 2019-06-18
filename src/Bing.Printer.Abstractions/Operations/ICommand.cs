namespace Bing.Printer.Operations
{
    /// <summary>
    /// 命令操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface ICommand<out T>
    {
        /// <summary>
        /// 设置分隔符
        /// </summary>
        T Separator();

        /// <summary>
        /// 设置自动测试内容
        /// </summary>
        T AutoTest();

        /// <summary>
        /// 设置自动打印内容
        /// </summary>
        T AutoPrinter();
    }
}
