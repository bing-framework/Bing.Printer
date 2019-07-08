using System;

namespace Bing.Printer.Exceptions
{
    /// <summary>
    /// 打印异常
    /// </summary>
    public class PrintException : Exception
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 初始化一个<see cref="PrintException"/>类型的实例
        /// </summary>
        /// <param name="message">错误消息</param>
        public PrintException(string message) : this(message, null)
        {
        }

        /// <summary>
        /// 初始化一个<see cref="PrintException"/>类型的实例
        /// </summary>
        /// <param name="exception">异常</param>
        public PrintException(Exception exception) : this(null, null, exception)
        {
        }

        /// <summary>
        /// 初始化一个<see cref="PrintException"/>类型的实例
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误码</param>
        public PrintException(string message, string code) : this(message, code, null)
        {
        }

        /// <summary>
        /// 初始化一个<see cref="PrintException"/>类型的实例
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误码</param>
        /// <param name="exception">异常</param>
        public PrintException(string message, string code, Exception exception):base(message??"",exception)
        {
            Code = code;
        }
    }
}
