using System.Drawing;
using System.IO;
using Bing.Printer.Enums;
using Bing.Printer.Options;

namespace Bing.Printer
{
    /// <summary>
    /// 打印机基类
    /// </summary>
    /// <typeparam name="TPrinter">打印机类型</typeparam>
    public abstract class PrinterBase<TPrinter> : IPrinter<TPrinter> where TPrinter : IPrinter<TPrinter>
    {
        /// <summary>
        /// 打印命令
        /// </summary>
        private IPrintCommand _command;

        /// <summary>
        /// 打印命令
        /// </summary>
        protected IPrintCommand Command => _command ?? (_command = CreatePrintCommand());

        /// <summary>
        /// 打印纸类型
        /// </summary>
        public PrintPaperType PrintPaper { get; set; } = PrintPaperType.Paper80;

        #region Writer(写入器操作)

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="value">字节数组</param>
        public virtual TPrinter Write(byte[] value)
        {
            Command.Writer.Write(value);
            return This();
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="value">字符串</param>
        public virtual TPrinter Write(string value)
        {
            Command.Writer.Write(value);
            return This();
        }

        /// <summary>
        /// 写入并换行
        /// </summary>
        /// <param name="value">字符串</param>
        public TPrinter WriteLine(string value)
        {
            Command.Writer.WriteLine(value);
            return This();
        }

        /// <summary>
        /// 写入并换行
        /// </summary>
        /// <param name="value">字节数组</param>
        public TPrinter WriteLine(byte[] value)
        {
            Command.Writer.WriteLine(value);
            return This();
        }

        /// <summary>
        /// 添加行
        /// </summary>
        public virtual TPrinter NewLine()
        {
            Command.Writer.NewLine();
            return This();
        }

        /// <summary>
        /// 添加行
        /// </summary>
        /// <param name="liens">行数</param>
        public virtual TPrinter NewLine(int liens)
        {
            Command.Writer.NewLine(liens);
            return This();
        }

        /// <summary>
        /// 清空
        /// </summary>
        public virtual TPrinter Clear()
        {
            Command.Writer.Clear();
            return This();
        }

        /// <summary>
        /// 获取二进制数组
        /// </summary>
        public virtual byte[] GetBytes() => Command.Writer.GetBytes();

        /// <summary>
        /// 转换成十六进制字符串
        /// </summary>
        public virtual string ToHex() => Command.Writer.ToHex();

        /// <summary>
        /// 创建打印命令
        /// </summary>
        /// <returns></returns>
        protected abstract IPrintCommand CreatePrintCommand();

        /// <summary>
        /// 返回自身
        /// </summary>
        private TPrinter This() => (TPrinter)(object)this;

        #endregion

        #region FontStyle(字体样式)

        /// <summary>
        /// 加粗。将文字加粗
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Bold(string value) => Write(Command.FontStyle.Bold(value));

        /// <summary>
        /// 加粗-开。将文字加粗
        /// </summary>
        public virtual TPrinter BoldOn() => Write(Command.FontStyle.BoldOn());

        /// <summary>
        /// 加粗-关。将文字加粗
        /// </summary>
        public virtual TPrinter BoldOff() => Write(Command.FontStyle.BoldOff());

        /// <summary>
        /// 倍宽
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter DoubleWidth(string value) => Write(Command.FontStyle.DoubleWidth(value));

        /// <summary>
        /// 倍宽-开
        /// </summary>
        public virtual TPrinter DoubleWidthOn() => Write(Command.FontStyle.DoubleWidthOn());

        /// <summary>
        /// 倍宽-关
        /// </summary>
        public virtual TPrinter DoubleWidthOff() => Write(Command.FontStyle.DoubleWidthOff());

        /// <summary>
        /// 倍高
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter DoubleHeight(string value) => Write(Command.FontStyle.DoubleHeight(value));

        /// <summary>
        /// 倍高-开
        /// </summary>
        public virtual TPrinter DoubleHeightOn() => Write(Command.FontStyle.DoubleHeightOn());

        /// <summary>
        /// 倍高-关
        /// </summary>
        public virtual TPrinter DoubleHeightOff() => Write(Command.FontStyle.DoubleHeightOff());

        /// <summary>
        /// 下划线(1点宽)。为文字添加下划线
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Underline(string value) => Write(Command.FontStyle.Underline(value));

        /// <summary>
        /// 下划线(2点宽)。为文字添加下划线
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Underline2(string value) => Write(Command.FontStyle.Underline2(value));

        /// <summary>
        /// 下划线(1点宽)。为文字添加下划线
        /// </summary>
        public virtual TPrinter UnderlineOn() => Write(Command.FontStyle.UnderlineOn());

        /// <summary>
        /// 下划线(2点宽)。为文字添加下划线
        /// </summary>
        public virtual TPrinter Underline2On() => Write(Command.FontStyle.Underline2On());

        /// <summary>
        /// 下划线。为文字添加下划线
        /// </summary>
        public virtual TPrinter UnderlineOff() => Write(Command.FontStyle.UnderlineOff());

        /// <summary>
        /// 黑白反显
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter BlackWhite(string value) => Write(Command.FontStyle.BlackWhite(value));

        /// <summary>
        /// 黑白反显-开
        /// </summary>
        public virtual TPrinter BlackWhiteOn() => Write(Command.FontStyle.BlackWhiteOn());

        /// <summary>
        /// 黑白反显-关
        /// </summary>
        public virtual TPrinter BlackWhiteOff() => Write(Command.FontStyle.BlackWhiteOff());

        /// <summary>
        /// 顺时针90度旋转
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Rotate90(string value) => Write(Command.FontStyle.Rotate90(value));

        /// <summary>
        /// 顺时针180度旋转
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Rotate180(string value) => Write(Command.FontStyle.Rotate180(value));

        /// <summary>
        /// 顺时针270度旋转
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Rotate270(string value) => Write(Command.FontStyle.Rotate270(value));

        /// <summary>
        /// 顺时针90度旋转-开
        /// </summary>
        public virtual TPrinter Rotate90On() => Write(Command.FontStyle.Rotate90On());

        /// <summary>
        /// 顺时针180度旋转-开
        /// </summary>
        public virtual TPrinter Rotate180On() => Write(Command.FontStyle.Rotate180On());

        /// <summary>
        /// 顺时针270度旋转-开
        /// </summary>
        public virtual TPrinter Rotate270On() => Write(Command.FontStyle.Rotate270On());

        /// <summary>
        /// 顺时针旋转-关
        /// </summary>
        public virtual TPrinter RotateOff() => Write(Command.FontStyle.RotateOff());

        /// <summary>
        /// 设置字体大小
        /// </summary>
        /// <param name="size">字体大小</param>
        public virtual TPrinter FontSize(FontSize size) => Write(Command.FontStyle.FontSize(size));

        /// <summary>
        /// 设置字体大小
        /// </summary>
        /// <param name="size">字体大小</param>
        public virtual TPrinter FontSize(int size) => Write(Command.FontStyle.FontSize(size));

        /// <summary>
        /// 设置字体大小
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public virtual TPrinter FontSize(int width, int height) => Write(Command.FontStyle.FontSize(width, height));

        /// <summary>
        /// 设置字体类型
        /// </summary>
        /// <param name="type">字体类型</param>
        public virtual TPrinter FontType(FontType type) => Write(Command.FontStyle.FontType(type));

        /// <summary>
        /// 设置倍宽。仅支持4个级别
        /// </summary>
        /// <param name="size">字体大小</param>
        public virtual TPrinter DoubleWidth(FontSize size) => Write(Command.FontStyle.DoubleWidth(size));

        /// <summary>
        /// 设置倍高。仅支持4个级别
        /// </summary>
        /// <param name="size">字体大小</param>
        public virtual TPrinter DoubleHeight(FontSize size) => Write(Command.FontStyle.DoubleHeight(size));

        #endregion

        #region FontMode(字体模式)

        /// <summary>
        /// 倾斜。将文字变为斜体
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Italic(string value) => Write(Command.FontMode.Italic(value));

        /// <summary>
        /// 倾斜。将文字变为斜体
        /// </summary>
        /// <param name="state">打印模式状态</param>
        public virtual TPrinter Italic(PrinterModeState state) => Write(Command.FontMode.Italic(state));

        /// <summary>
        /// 加粗。将文字加粗
        /// </summary>
        /// <param name="state">打印模式状态</param>
        public virtual TPrinter Bold(PrinterModeState state) => Write(Command.FontMode.Bold(state));

        /// <summary>
        /// 下划线。为文字添加下划线
        /// </summary>
        /// <param name="state">打印模式状态</param>
        public virtual TPrinter Underline(PrinterModeState state) => Write(Command.FontMode.Underline(state));

        /// <summary>
        /// 稀疏
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Expanded(string value) => Write(Command.FontMode.Expanded(value));

        /// <summary>
        /// 稀疏
        /// </summary>
        /// <param name="state">打印模式状态</param>
        public virtual TPrinter Expanded(PrinterModeState state) => Write(Command.FontMode.Expanded(state));

        /// <summary>
        /// 简明
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Condensed(string value) => Write(Command.FontMode.Condensed(value));

        /// <summary>
        /// 简明
        /// </summary>
        /// <param name="state">打印模式</param>
        public virtual TPrinter Condensed(PrinterModeState state) => Write(Command.FontMode.Condensed(state));

        #endregion

        #region PrintStyle(打印样式)

        /// <summary>
        /// 设置左边距
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter LeftMargin(int value = 0) => Write(Command.PrintStyle.LeftMargin(value));

        /// <summary>
        /// 设置左边距
        /// </summary>
        /// <param name="nL">边距值</param>
        /// <param name="nH">高度</param>
        public virtual TPrinter LeftMargin(int nL, int nH) => Write(Command.PrintStyle.LeftMargin(nL, nH));

        /// <summary>
        /// 设置打印区域宽度
        /// </summary>
        /// <param name="nL">长度</param>
        /// <param name="nH">高度</param>
        public TPrinter PrintWidth(int nL, int nH) => Write(Command.PrintStyle.PrintWidth(nL, nH));

        /// <summary>
        /// 设置相对横向打印位置
        /// </summary>
        /// <param name="nL">长度</param>
        /// <param name="nH">高度</param>
        public TPrinter RelativeHorizontalPosition(int nL, int nH) => Write(Command.PrintStyle.PrintWidth(nL, nH));

        /// <summary>
        /// 设置绝对打印位置
        /// </summary>
        /// <param name="nL">长度</param>
        /// <param name="nH">高度</param>
        public TPrinter AbsolutePosition(int nL, int nH) => Write(Command.PrintStyle.PrintWidth(nL, nH));

        /// <summary>
        /// 左对齐
        /// </summary>
        public virtual TPrinter Left() => Write(Command.PrintStyle.Left());

        /// <summary>
        /// 右对齐
        /// </summary>
        public virtual TPrinter Right() => Write(Command.PrintStyle.Right());

        /// <summary>
        /// 设置默认行高
        /// </summary>
        public virtual TPrinter RowHeight() => Write(Command.PrintStyle.RowHeight());

        /// <summary>
        /// 设置行高
        /// </summary>
        /// <param name="height">高度</param>
        public virtual TPrinter RowHeight(int height) => Write(Command.PrintStyle.RowHeight(height));

        /// <summary>
        /// 居中
        /// </summary>
        public virtual TPrinter Center() => Write(Command.PrintStyle.Center());

        #endregion

        #region PagerCut(页面截断)

        /// <summary>
        /// 全页截断
        /// </summary>
        public virtual TPrinter Full() => Write(Command.PagerCut.Full());

        /// <summary>
        /// 部分截断
        /// </summary>
        public virtual TPrinter Partial() => Write(Command.PagerCut.Partial());

        #endregion

        #region Drawer(绘制器)

        /// <summary>
        /// 打开绘制器
        /// </summary>
        public virtual TPrinter OpenDrawer() => Write(Command.Drawer.OpenDrawer());

        #endregion

        #region QrCode(二维码)

        /// <summary>
        /// 设置二维码
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter QrCode(string value) => Write(Command.QrCode.QrCode(value));

        /// <summary>
        /// 设置二维码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="size">二维码大小</param>
        public virtual TPrinter QrCode(string value, QrCodeSize size) => Write(Command.QrCode.QrCode(value, size));

        #endregion

        #region Barcode(条形码)

        /// <summary>
        /// 设置 Code39 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="position">标签显示位置</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="fontB">是否使用字体B</param>
        public TPrinter
            Code39(string value, BarcodePositionType position, BarcodeWidth width, int height, bool fontB) =>
            Write(Command.Barcode.Code39(value, position, width, height, fontB));

        /// <summary>
        /// 设置 Code128 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="position">标签显示位置</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="fontB">是否使用字体B</param>
        public TPrinter Code128(string value, BarcodePositionType position, BarcodeWidth width, int height,
            bool fontB) =>
            Write(Command.Barcode.Code128(value, position, width, height, fontB));

        /// <summary>
        /// 设置 Ean13 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="position">标签显示位置</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="fontB">是否使用字体B</param>
        public TPrinter Ean13(string value, BarcodePositionType position, BarcodeWidth width, int height, bool fontB) =>
            Write(Command.Barcode.Ean13(value, position, width, height, fontB));

        /// <summary>
        /// 设置条形码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="options">条形码选项</param>
        public TPrinter Barcode(string value, BarcodeOptions options) => Write(Command.Barcode.Barcode(value, options));

        #endregion

        #region Style(样式)

        /// <summary>
        /// 设置打印样式
        /// </summary>
        /// <param name="style">打印样式</param>
        public TPrinter Styles(PrintStyle style) => Write(Command.Style.Styles(style));

        /// <summary>
        /// 设置字符间距
        /// </summary>
        /// <param name="spaceCount">空格数</param>
        public TPrinter RightCharacterSpacing(int spaceCount) => Write(Command.Style.RightCharacterSpacing(spaceCount));

        /// <summary>
        /// 设置分隔符
        /// </summary>
        public virtual TPrinter Separator()
        {
            Condensed(PrinterModeState.On);
            Write(Command.Style.Separator());
            Condensed(PrinterModeState.Off);
            NewLine();
            return This();
        }

        #endregion

        #region InitializePrint(初始化打印)

        /// <summary>
        /// 初始化
        /// </summary>
        public TPrinter Initialize() => Write(Command.InitializePrint.Initialize());

        /// <summary>
        /// 启用
        /// </summary>
        public TPrinter Enable() => Write(Command.InitializePrint.Enable());

        /// <summary>
        /// 禁用
        /// </summary>
        public TPrinter Disable() => Write(Command.InitializePrint.Disable());

        #endregion

        #region PrintLine(打印行)

        /// <summary>
        /// 设置实线
        /// </summary>
        public virtual TPrinter SolidLine() => Write(Command.PrintLine.SolidLine());

        /// <summary>
        /// 设置空行
        /// </summary>
        public virtual TPrinter EmptyLine() => Write(Command.PrintLine.EmptyLine());

        /// <summary>
        /// 设置虚线
        /// </summary>
        public virtual TPrinter DottedLine() => Write(Command.PrintLine.DottedLine());

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        public virtual TPrinter WriteOneLine(string text1, string text2) => Write(Command.PrintLine.WriteOneLine(text1, text2));

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="textSize">文字大小</param>
        public virtual TPrinter WriteOneLine(string text1, string text2, int textSize) => Write(Command.PrintLine.WriteOneLine(text1, text2, textSize));

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="text3">文本3</param>
        public virtual TPrinter WriteOneLine(string text1, string text2, string text3) => Write(Command.PrintLine.WriteOneLine(text1, text2, text3));

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="text3">文本3</param>
        /// <param name="textSize">文字大小</param>
        public virtual TPrinter WriteOneLine(string text1, string text2, string text3, int textSize) => Write(Command.PrintLine.WriteOneLine(text1, text2, text3, textSize));

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="text3">文本3</param>
        /// <param name="text4">文本4</param>
        public virtual TPrinter WriteOneLine(string text1, string text2, string text3, string text4) => Write(Command.PrintLine.WriteOneLine(text1, text2, text3, text4));

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="text3">文本3</param>
        /// <param name="text4">文本4</param>
        /// <param name="textSize">文字大小</param>
        public virtual TPrinter WriteOneLine(string text1, string text2, string text3, string text4, int textSize) => Write(Command.PrintLine.WriteOneLine(text1, text2, text3, text4, textSize));

        #endregion

        #region Image(图片)

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="imgPath">图片路径</param>
        public virtual TPrinter PrintImage(string imgPath) => Write(Command.Image.PrintImage(imgPath));

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="stream">流</param>
        public virtual TPrinter PrintImage(Stream stream) => Write(Command.Image.PrintImage(stream));

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="bytes">字节数组</param>
        public virtual TPrinter PrintImage(byte[] bytes) => Write(Command.Image.PrintImage(bytes));

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="image">图片</param>
        public virtual TPrinter PrintImage(Image image) => Write(Command.Image.PrintImage(image));

        #endregion

    }
}
