namespace Bing.Printer.Operations
{
    /// <summary>
    /// 写入器操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IWriter<out T>
    {
        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="value">字节数组</param>
        T Write(byte[] value);

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="value">字符串</param>
        T Write(string value);

        /// <summary>
        /// 写入并换行
        /// </summary>
        /// <param name="value">字符串</param>
        T WriteLine(string value);

        /// <summary>
        /// 写入并换行
        /// </summary>
        /// <param name="value">字节数组</param>
        T WriteLine(byte[] value);

        /// <summary>
        /// 添加行
        /// </summary>
        T NewLine();

        /// <summary>
        /// 添加行
        /// </summary>
        /// <param name="liens">行数</param>
        T NewLine(int liens);

        /// <summary>
        /// 清空内容
        /// </summary>
        T Clear();

        /// <summary>
        /// 获取二进制数组
        /// </summary>
        byte[] GetBytes();

        /// <summary>
        /// 转换为十六进制
        /// </summary>
        string ToHex();
    }

    /// <summary>
    /// 写入器操作
    /// </summary>
    public interface IWriter : IWriter<IWriter>
    {
    }
}
