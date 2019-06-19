using System.Collections.Generic;
using System.Linq;
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
        /// 设置宽度
        /// </summary>
        /// <param name="width">宽度</param>
        public IBarcodeBuilder Width(BarcodeWidth width) => Append(new[] {ASCIIControlConst.GS, CommandConst.Barcodes.Width, width.ToByte()});

        /// <summary>
        /// 设置高度
        /// </summary>
        /// <param name="height">高度</param>
        public IBarcodeBuilder Height(int height) => Append(new[] {ASCIIControlConst.GS, CommandConst.Barcodes.Height, height.ToByte()});

        /// <summary>
        /// 设置标签显示位置
        /// </summary>
        /// <param name="position">位置</param>
        public IBarcodeBuilder LabelPosition(BarcodePositionType position) => Append(new[] {ASCIIControlConst.GS, CommandConst.Barcodes.LabelPosition, position.ToByte()});

        /// <summary>
        /// 设置标签字体加粗
        /// </summary>
        /// <param name="type">类型</param>
        public IBarcodeBuilder LabelFontB(BarcodeFontType type) => Append(new[] {ASCIIControlConst.GS, CommandConst.Barcodes.LabelFont, type.ToByte()});

        /// <summary>
        /// 生成条形码
        /// </summary>
        /// <param name="type">条形码类型</param>
        /// <param name="value">值</param>
        public byte[] Build(BarcodeType type, string value)
        {
            var command = new List<byte> {ASCIIControlConst.GS, CommandConst.Barcodes.Print, type.ToByte(), (value.Length + 2).ToByte()};
            command.AddRange(value.ToCharArray().Select(x => x.ToByte()));
            Append(command.ToArray());
            //return _buffer.AddBytes(new[] { '{'.ToByte(), 'C'.ToByte() });
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
