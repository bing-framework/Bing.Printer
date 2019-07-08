using Bing.Printer.Enums;
using Bing.Printer.Exceptions;
using Bing.Printer.Extensions;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 字体样式命令
    /// </summary>
    internal class FontStyleCommand : IFontStyle<byte[]>
    {
        /// <summary>
        /// 加粗。将文字加粗
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Bold(string value) => BoldOn().AddBytes(value).AddBytes(BoldOff()).AddLf();

        /// <summary>
        /// 加粗-开。将文字加粗
        /// </summary>
        public byte[] BoldOn() => Command.TxtBoldOn;

        /// <summary>
        /// 加粗-关。将文字加粗
        /// </summary>
        public byte[] BoldOff() => Command.TxtBoldOff;

        /// <summary>
        /// 倍宽
        /// </summary>
        /// <param name="value">值</param>
        public byte[] DoubleWidth(string value) => DoubleWidthOn().AddBytes(value).AddBytes(DoubleWidthOff()).AddLf();

        /// <summary>
        /// 倍宽-开
        /// </summary>
        public byte[] DoubleWidthOn() => Command.Chinese.DoubleWidthOn.AddBytes(Command.ASCII.DoubleWidth);

        /// <summary>
        /// 倍宽-关
        /// </summary>
        public byte[] DoubleWidthOff() => Command.Chinese.FontSizeReset.AddBytes(Command.ASCII.FontSizeReset);

        /// <summary>
        /// 倍高
        /// </summary>
        /// <param name="value">值</param>
        public byte[] DoubleHeight(string value) => DoubleHeightOn().AddBytes(value).AddBytes(DoubleHeightOff()).AddLf();

        /// <summary>
        /// 倍高-开
        /// </summary>
        public byte[] DoubleHeightOn() => Command.Chinese.DoubleHeightOn.AddBytes(Command.ASCII.DoubleHeight);

        /// <summary>
        /// 倍高-关
        /// </summary>
        public byte[] DoubleHeightOff() => Command.Chinese.FontSizeReset.AddBytes(Command.ASCII.FontSizeReset);

        /// <summary>
        /// 倍宽高
        /// </summary>
        /// <param name="value">值</param>
        public byte[] DoubleWidthHeight(string value) => DoubleWidthHeightOn().AddBytes(value).AddBytes(DoubleWidthHeightOff()).AddLf();

        /// <summary>
        /// 倍宽高-开
        /// </summary>
        public byte[] DoubleWidthHeightOn() => Command.Chinese.DoubleWidthHeightOn.AddBytes(Command.ASCII.DoubleWidthHeight);

        /// <summary>
        /// 倍宽高-关
        /// </summary>
        public byte[] DoubleWidthHeightOff() => Command.Chinese.FontSizeReset.AddBytes(Command.ASCII.FontSizeReset);

        /// <summary>
        /// 下划线(1点宽)。为文字添加下划线
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Underline(string value) => UnderlineOn().AddBytes(value).AddBytes(UnderlineOff()).AddLf();

        /// <summary>
        /// 下划线(2点宽)。为文字添加下划线
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Underline2(string value) => Underline2On().AddBytes(value).AddBytes(UnderlineOff()).AddLf();

        /// <summary>
        /// 下划线(1点宽)。为文字添加下划线
        /// </summary>
        public byte[] UnderlineOn() => Command.Chinese.UnderlineOn.AddBytes(Command.ASCII.UnderlineOn);

        /// <summary>
        /// 下划线(2点宽)。为文字添加下划线
        /// </summary>
        public byte[] Underline2On() => Command.Chinese.Underline2On.AddBytes(Command.ASCII.Underline2On);

        /// <summary>
        /// 下划线。为文字添加下划线
        /// </summary>
        public byte[] UnderlineOff() => Command.Chinese.UnderlineOff.AddBytes(Command.ASCII.UnderlineOff);

        /// <summary>
        /// 黑白反显
        /// </summary>
        /// <param name="value">值</param>
        public byte[] BlackWhite(string value) => BlackWhiteOn().AddBytes(value).AddBytes(BlackWhiteOff()).AddLf();

        /// <summary>
        /// 黑白反显-开
        /// </summary>
        public byte[] BlackWhiteOn() => Command.TxtBlackWhiteReverseOn;

        /// <summary>
        /// 黑白反显-关
        /// </summary>
        public byte[] BlackWhiteOff() => Command.TxtBlackWhiteReverseOff;

        /// <summary>
        /// 顺时针90度旋转
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Rotate90(string value) => Rotate90On().AddBytes(value).AddBytes(RotateOff()).AddLf();

        /// <summary>
        /// 顺时针180度旋转
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Rotate180(string value) => Rotate180On().AddBytes(value).AddBytes(RotateOff()).AddLf();

        /// <summary>
        /// 顺时针270度旋转
        /// </summary>
        /// <param name="value">值</param>
        public byte[] Rotate270(string value) => Rotate270On().AddBytes(value).AddBytes(RotateOff()).AddLf();

        /// <summary>
        /// 顺时针90度旋转-开
        /// </summary>
        public byte[] Rotate90On() => Command.TxtRotate90On;

        /// <summary>
        /// 顺时针180度旋转-开
        /// </summary>
        public byte[] Rotate180On() => Command.TxtRotate180On;

        /// <summary>
        /// 顺时针270度旋转-开
        /// </summary>
        public byte[] Rotate270On() => Command.TxtRotate270On;

        /// <summary>
        /// 顺时针旋转-关
        /// </summary>
        public byte[] RotateOff() => Command.TxtRotateOff;

        /// <summary>
        /// 设置字体大小
        /// </summary>
        /// <param name="size">字体大小</param>
        public byte[] FontSize(FontSize size)
        {
            byte realSize = 0;
            switch (size)
            {
                case Enums.FontSize.Size0:
                    realSize = 0;
                    break;
                case Enums.FontSize.Size1:
                    realSize = 17;
                    break;
                case Enums.FontSize.Size2:
                    realSize = 34;
                    break;
                case Enums.FontSize.Size3:
                    realSize = 51;
                    break;
                case Enums.FontSize.Size4:
                    realSize = 68;
                    break;
                case Enums.FontSize.Size5:
                    realSize = 85;
                    break;
                case Enums.FontSize.Size6:
                    realSize = 102;
                    break;
                case Enums.FontSize.Size7:
                    realSize = 119;
                    break;
            }

            return Command.Size.AddByte(realSize);
        }

        /// <summary>
        /// 设置字体大小
        /// </summary>
        /// <param name="size">字体大小</param>
        public byte[] FontSize(int size)
        {
            return Command.Size.AddByte(size.ToByte());
        }

        /// <summary>
        /// 设置字体大小
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public byte[] FontSize(int width, int height)
        {
            var widthSize = (width - 1) * 16;
            var heightSize = (height - 1);
            var size = widthSize + heightSize;
            return Command.Size.AddByte(size.ToByte());
        }

        /// <summary>
        /// 设置字体类型
        /// </summary>
        /// <param name="type">字体类型</param>
        public byte[] FontType(FontType type) => Command.FontType.AddByte(type.ToByte());

        /// <summary>
        /// 设置倍宽。仅支持4个级别
        /// </summary>
        /// <param name="size">字体大小</param>
        public byte[] DoubleWidth(FontSize size)
        {
            byte realSize = 0;
            switch (size)
            {
                case Enums.FontSize.Size0:
                    realSize = 0;
                    break;
                case Enums.FontSize.Size1:
                    realSize = 16;
                    break;
                case Enums.FontSize.Size2:
                    realSize = 32;
                    break;
                case Enums.FontSize.Size3:
                    realSize = 48;
                    break;
                default:
                    throw new PrintException("仅支持 FontSize0 - FontSize3 倍宽");
            }
            return Command.Size.AddByte(realSize);
        }

        /// <summary>
        /// 设置倍高。仅支持4个级别
        /// </summary>
        /// <param name="size">字体大小</param>
        public byte[] DoubleHeight(FontSize size)
        {
            byte realSize = 0;
            switch (size)
            {
                case Enums.FontSize.Size0:
                    realSize = 0;
                    break;
                case Enums.FontSize.Size1:
                    realSize = 1;
                    break;
                case Enums.FontSize.Size2:
                    realSize = 2;
                    break;
                case Enums.FontSize.Size3:
                    realSize = 3;
                    break;
                default:
                    throw new PrintException("仅支持 FontSize0 - FontSize3 倍高");
            }
            return Command.Size.AddByte(realSize);
        }
    }
}
