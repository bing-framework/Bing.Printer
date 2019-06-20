using System.Collections.Generic;
using System.Text;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 写入器命令
    /// </summary>
    internal class WriterCommand : IWriter
    {
        /// <summary>
        /// 流
        /// </summary>
        private byte[] _buffer;

        /// <summary>
        /// 字符编码
        /// </summary>
        private readonly Encoding _encoding;

        /// <summary>
        /// 初始化一个<see cref="WriterCommand"/>类型的实例
        /// </summary>
        /// <param name="encoding">字符编码</param>
        public WriterCommand(Encoding encoding)
        {
            _encoding = encoding;
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="value">字节数组</param>
        public IWriter Write(byte[] value)
        {
            if (value == null)
                return this;
            var list = new List<byte>();
            if (_buffer != null)
                list.AddRange(_buffer);
            list.AddRange(value);
            _buffer = list.ToArray();
            return this;
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="value">字符串</param>
        public IWriter Write(string value)
        {
            Write(value, false);
            return this;
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="useLf">是否换行</param>
        private void Write(string value, bool useLf)
        {
            if(string.IsNullOrEmpty(value))
                return;
            if (useLf)
                value += "\n";
            var list = new List<byte>();
            if (_buffer != null)
                list.AddRange(_buffer);
            var bytes = _encoding.GetBytes(value);
            list.AddRange(bytes);
            _buffer = list.ToArray();
        }

        /// <summary>
        /// 写入并换行
        /// </summary>
        /// <param name="value">字符串</param>
        public IWriter WriteLine(string value)
        {
            Write(value, true);
            return this;
        }

        /// <summary>
        /// 添加行
        /// </summary>
        public IWriter NewLine()
        {
            WriteLine("\r");
            return this;
        }

        /// <summary>
        /// 添加行
        /// </summary>
        /// <param name="liens">行数</param>
        public IWriter NewLine(int liens)
        {
            for (int i = 0; i < liens; i++)
            {
                NewLine();
            }
            return this;
        }

        /// <summary>
        /// 清空内容
        /// </summary>
        public IWriter Clear()
        {
            _buffer = null;
            return this;
        }

        /// <summary>
        /// 获取二进制数组
        /// </summary>
        public byte[] GetBytes() => _buffer;

        /// <summary>
        /// 转换为十六进制
        /// </summary>
        public string ToHex()
        {
            if (_buffer == null)
                return string.Empty;
            var result = new StringBuilder();
            foreach (var b in _buffer)
                result.AppendFormat("{0:x2}", b);
            return result.Replace("-", "").ToString();
        }
    }
}
