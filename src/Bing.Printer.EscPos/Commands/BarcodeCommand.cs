using Bing.Printer.Builders;
using Bing.Printer.Enums;
using Bing.Printer.Extensions;
using Bing.Printer.Operations;
using Bing.Printer.Options;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 条形码命令
    /// </summary>
    internal class BarcodeCommand : IBarcode<byte[]>
    {
        /// <summary>
        /// 条形码生成器
        /// </summary>
        internal IBarcodeBuilder Builder { get; set; }

        /// <summary>
        /// 初始化一个<see cref="Barcode"/>类型的实例
        /// </summary>
        /// <param name="builder">条形码生成器</param>
        public BarcodeCommand(IBarcodeBuilder builder)
        {
            Builder = builder;
        }

        /// <summary>
        /// 设置 Code39 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Code39(string value)
        {
            return new byte[] { ASCIIControlConst.GS, CommandConst.Barcodes.Print, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 102, 0 }) // font hri character
                .AddBytes(new byte[] { 29, 72, 0 }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 4 })
                .AddBytes(value)
                .AddBytes(new byte[] { 0 })
                .AddLf();
        }

        /// <summary>
        /// 设置 Code128 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Code128(string value)
        {
            //return Builder.Width(BarcodeWidth.Thinnest)
            //    .Height(30)
            //    .LabelFontB(BarcodeFontType.B)
            //    .LabelPosition(BarcodePositionType.Above)
            //    .Build(BarcodeType.Code128, value);
            return new byte[] { ASCIIControlConst.GS, CommandConst.Barcodes.Print, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 102, 1 }) // font hri character
                .AddBytes(new byte[] { 29, 72, 0 }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 73 }) // printCode
                .AddBytes(new[] { (byte)(value.Length + 2) })
                .AddBytes(new[] { '{'.ToByte(), 'C'.ToByte() })
                .AddBytes(value)
                .AddLf();
        }

        /// <summary>
        /// 设置 Ean13 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Ean13(string value)
        {
            if (value.Trim().Length != 13)
                return new byte[0];

            return new byte[] { ASCIIControlConst.GS, CommandConst.Barcodes.Print, 2 } // Width
                .AddBytes(new byte[] { 29, 104, 50 }) // Height
                .AddBytes(new byte[] { 29, 72, 0 }) // If print code informed
                .AddBytes(new byte[] { 29, 107, 67, 12 })
                .AddBytes(value.Substring(0, 12))
                .AddLf();
        }

        /// <summary>
        /// 设置 Code39 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="position">标签显示位置</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="fontB">是否使用字体B</param>
        public byte[] Code39(string value, BarcodePositionType position, BarcodeWidth width, int height, bool fontB) =>
            Barcode(value, new BarcodeOptions()
            {
                Position = position,
                Width = width,
                Height = height,
                FontType = fontB ? BarcodeFontType.B : BarcodeFontType.A,
                Type = BarcodeType.Code39
            });

        /// <summary>
        /// 设置 Code128 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="position">标签显示位置</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="fontB">是否使用字体B</param>
        public byte[] Code128(string value, BarcodePositionType position, BarcodeWidth width, int height, bool fontB) =>
            Barcode(value, new BarcodeOptions()
            {
                Position = position,
                Width = width,
                Height = height,
                FontType = fontB ? BarcodeFontType.B : BarcodeFontType.A,
                Type = BarcodeType.Code128
            });

        /// <summary>
        /// 设置 Ean13 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="position">标签显示位置</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="fontB">是否使用字体B</param>
        public byte[] Ean13(string value, BarcodePositionType position, BarcodeWidth width, int height, bool fontB) =>
            Barcode(value, new BarcodeOptions()
            {
                Position = position,
                Width = width,
                Height = height,
                FontType = fontB ? BarcodeFontType.B : BarcodeFontType.A,
                Type = BarcodeType.Ean13
            });

        /// <summary>
        /// 设置条形码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="options">条形码选项</param>
        public byte[] Barcode(string value, BarcodeOptions options)
        {
            Builder.Width(options.Width ?? BarcodeWidth.Thinnest)
                .Height(options.Height ?? 50)
                .LabelPosition(options.Position ?? BarcodePositionType.None)
                .LabelFontB(options.FontType ?? BarcodeFontType.B);
            return Builder.Build(options.Type, value);
        }
    }
}
