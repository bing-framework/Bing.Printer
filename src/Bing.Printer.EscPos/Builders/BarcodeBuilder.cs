using System.Collections.Generic;
using System.Text;
using Bing.Printer.Builders;
using Bing.Printer.Enums;
using Bing.Printer.Extensions;

namespace Bing.Printer.EscPos.Builders
{
    /// <summary>
    /// 条码生成器
    /// </summary>
    internal class BarcodeBuilder : IBarcodeBuilder
    {
        /// <summary>
        /// 缓存流
        /// </summary>
        private byte[] _buffer;

        /// <summary>
        /// 字符编码
        /// </summary>
        private Encoding _encoding;

        /// <summary>
        /// 初始化一个<see cref="BarcodeBuilder"/>类型的实例
        /// </summary>
        /// <param name="encoding">字符编码</param>
        public BarcodeBuilder(Encoding encoding)
        {
            _encoding = encoding;
        }

        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="width">宽度</param>
        public IBarcodeBuilder Width(BarcodeWidth width) =>
            Append(Command.BarcodeWidth.AddBytes(new[] {width.ToByte()}));

        /// <summary>
        /// 设置高度
        /// </summary>
        /// <param name="height">高度</param>
        public IBarcodeBuilder Height(int height) => Append(Command.BarcodeHeight.AddBytes(new[] {height.ToByte()}));

        /// <summary>
        /// 设置标签显示位置
        /// </summary>
        /// <param name="position">位置</param>
        public IBarcodeBuilder LabelPosition(BarcodePositionType position) =>
            Append(Command.BarcodeLabelPosition.AddBytes(new[] {position.ToByte()}));

        /// <summary>
        /// 设置标签字体
        /// </summary>
        /// <param name="type">类型</param>
        public IBarcodeBuilder LabelFontB(BarcodeFontType type) => Append(type == BarcodeFontType.B ? Command.BarcodeLabelFontB : Command.BarcodeLabelFontA);

        /// <summary>
        /// 生成条形码
        /// </summary>
        /// <param name="type">条形码类型</param>
        /// <param name="value">值</param>
        public byte[] Build(BarcodeType type, string value)
        {
            // 设置条形码类型
            Append(Command.BarcodeType.AddBytes(new[] {type.ToByte()}));
            Append(new[] {(byte) (value.Length + 2)});
            Append(_encoding.GetBytes(value));
            Append(new byte[] {0});
            return _buffer;
        }

        /// <summary>
        /// 追加内容
        /// </summary>
        /// <param name="value">二进制数组</param>
        private IBarcodeBuilder Append(byte[] value)
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
    }
}
