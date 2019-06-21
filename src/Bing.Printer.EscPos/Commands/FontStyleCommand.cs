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
        public byte[] DoubleWidthOn() => Command.Chinese.DoubleWidthOn;

        /// <summary>
        /// 倍宽-关
        /// </summary>
        public byte[] DoubleWidthOff() => Command.Chinese.DoubleWidthOff;

        /// <summary>
        /// 倍高
        /// </summary>
        /// <param name="value">值</param>
        public byte[] DoubleHeight(string value) => DoubleHeightOn().AddBytes(value).AddBytes(DoubleHeightOff()).AddLf();

        /// <summary>
        /// 倍高-开
        /// </summary>
        public byte[] DoubleHeightOn() => Command.Chinese.DoubleHeightOn;

        /// <summary>
        /// 倍高-关
        /// </summary>
        public byte[] DoubleHeightOff() => Command.Chinese.DoubleHeightOff;

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

        public byte[] FontSize(int width, int height)
        {
            throw new System.NotImplementedException();
        }
    }
}
