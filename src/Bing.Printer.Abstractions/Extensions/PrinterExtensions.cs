using System;
using System.Collections.Generic;
using System.Text;

namespace Bing.Printer.Extensions
{
    /// <summary>
    /// 打印机扩展
    /// </summary>
    public static class PrinterExtensions
    {
        /// <summary>
        /// 转换为字节
        /// </summary>
        public static byte ToByte(this char c) => (byte) c;

        /// <summary>
        /// 转换为字节
        /// </summary>
        public static byte ToByte(this Enum c) => (byte) Convert.ToInt16(c);

        /// <summary>
        /// 转换为字节
        /// </summary>
        public static byte ToByte(this short c) => (byte) c;

        /// <summary>
        /// 转换为字节
        /// </summary>
        public static byte ToByte(this int c) => (byte)c;

        /// <summary>
        /// 添加字节数组
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="addBytes">待添加的字节数组</param>
        public static byte[] AddBytes(this byte[] bytes, byte[] addBytes)
        {
            if (addBytes == null)
                return bytes;
            var list = new List<byte>();
            list.AddRange(bytes);
            list.AddRange(addBytes);
            return list.ToArray();
        }

        /// <summary>
        /// 添加字节
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="addByte">待添加的字节</param>
        public static byte[] AddByte(this byte[] bytes, byte? addByte)
        {
            if (addByte == null)
                return bytes;
            var list = new List<byte>();
            list.AddRange(bytes);
            list.Add(addByte.Value);
            return list.ToArray();
        }

        /// <summary>
        /// 添加字节数组
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="value">待添加的字符串</param>
        public static byte[] AddBytes(this byte[] bytes, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return bytes;
            var list = new List<byte>();
            list.AddRange(bytes);
            list.AddRange(Encoding.GetEncoding("GB18030").GetBytes(value));
            return list.ToArray();
        }

        /// <summary>
        /// 添加换行
        /// </summary>
        public static byte[] AddLf(this byte[] bytes) => bytes.AddBytes("\n");

        /// <summary>
        /// 添加换行
        /// </summary>
        public static byte[] AddCrLf(this byte[] bytes) => bytes.AddBytes("\r\n");
    }
}
