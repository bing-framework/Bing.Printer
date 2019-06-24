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
        /// <param name="value">值</param>
        public virtual TPrinter Bold(string value) => Write(Command.FontMode.Bold(value));

        /// <summary>
        /// 加粗。将文字加粗
        /// </summary>
        /// <param name="state">打印模式状态</param>
        public virtual TPrinter Bold(PrinterModeState state) => Write(Command.FontMode.Bold(state));

        /// <summary>
        /// 下划线。为文字添加下划线
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Underline(string value) => Write(Command.FontMode.Underline(value));

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

        #region FontWidth(字体宽度)

        /// <summary>
        /// 正常宽度
        /// </summary>
        public virtual TPrinter NormalWidth() => Write(Command.FontWidth.NormalWidth());

        /// <summary>
        /// 2倍宽度
        /// </summary>
        public virtual TPrinter DoubleWidth2() => Write(Command.FontWidth.DoubleWidth2());

        /// <summary>
        /// 3倍宽度
        /// </summary>
        public virtual TPrinter DoubleWidth3() => Write(Command.FontWidth.DoubleWidth3());

        #endregion

        #region PrintStyle(打印样式)

        public virtual TPrinter LeftMargin(int value = 10) => Write(Command.PrintStyle.LeftMargin(value));

        public virtual TPrinter LeftMargin(int nL, int nH) => Write(Command.PrintStyle.LeftMargin(nL, nH));

        /// <summary>
        /// 左对齐
        /// </summary>
        public virtual TPrinter Left() => Write(Command.PrintStyle.Left());

        /// <summary>
        /// 右对齐
        /// </summary>
        public virtual TPrinter Right() => Write(Command.PrintStyle.Right());

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
        /// 设置字体大小
        /// </summary>
        /// <param name="size">字体大小</param>
        public TPrinter Size(int size) => Write(Command.Style.Size(size));

        /// <summary>
        /// 设置分隔符
        /// </summary>
        public virtual TPrinter Separator()
        {
            Condensed(PrinterModeState.On);
            Write(Command.Style.Separator());
            Condensed(PrinterModeState.Off);
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
    }
}
