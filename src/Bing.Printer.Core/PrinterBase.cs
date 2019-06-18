using System.Collections.Generic;
using System.Text;
using Bing.Printer.Enums;

namespace Bing.Printer
{
    /// <summary>
    /// 打印机基类
    /// </summary>
    /// <typeparam name="TPrinter">打印机类型</typeparam>
    public abstract class PrinterBase<TPrinter> : IPrinter<TPrinter> where TPrinter : IPrinter<TPrinter>
    {
        /// <summary>
        /// 流
        /// </summary>
        protected byte[] _buffer;

        /// <summary>
        /// 打印命令
        /// </summary>
        private IPrintCommand _command;

        /// <summary>
        /// 打印命令
        /// </summary>
        protected IPrintCommand Command => _command ?? (_command = CreatePrintCommand());

        public int ColsNomal => Command.ColsNomal;
        public int ColsCondensed => Command.ColsCondensed;
        public int ColsExpanded => Command.ColsExpanded;

        /// <summary>
        /// 转换成十六进制字符串
        /// </summary>
        public virtual string ToHex()
        {
            if (_buffer == null)
                return string.Empty;
            var result = new StringBuilder();
            foreach (var b in _buffer)
                result.AppendFormat("{0:x2}", b);
            return result.Replace("-", "").ToString();
        }

        /// <summary>
        /// 创建打印命令
        /// </summary>
        /// <returns></returns>
        protected abstract IPrintCommand CreatePrintCommand();

        /// <summary>
        /// 追加内容
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Append(string value)
        {
            AppendString(value, true);
            return This();
        }

        /// <summary>
        /// 返回自身
        /// </summary>
        private TPrinter This()
        {
            return (TPrinter)(object)this;
        }

        /// <summary>
        /// 添加字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="useLf">是否换行</param>
        private void AppendString(string value, bool useLf)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            if (useLf)
                value += "\n";
            var list = new List<byte>();
            if (_buffer != null)
                list.AddRange(_buffer);
            var bytes = GetBytes(value);
            list.AddRange(bytes);
            _buffer = list.ToArray();
        }

        /// <summary>
        /// 获取字节数组
        /// </summary>
        /// <param name="value">值</param>
        protected abstract byte[] GetBytes(string value);

        /// <summary>
        /// 追加内容
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Append(byte[] value)
        {
            if (value == null)
                return This();
            var list = new List<byte>();
            if (_buffer != null)
                list.AddRange(_buffer);
            list.AddRange(value);
            _buffer = list.ToArray();
            return This();
        }

        /// <summary>
        /// 追加内容并带有换行符
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter AppendWithoutLf(string value)
        {
            AppendString(value, false);
            return This();
        }

        /// <summary>
        /// 添加新行
        /// </summary>
        public virtual TPrinter NewLine() => Append("\r");

        /// <summary>
        /// 添加多行
        /// </summary>
        /// <param name="lines">行数</param>
        public virtual TPrinter NewLines(int lines)
        {
            for (var i = 1; i < lines; i++)
                NewLine();
            return This();
        }

        /// <summary>
        /// 清空
        /// </summary>
        public virtual TPrinter Clear()
        {
            _buffer = null;
            return This();
        }

        #region Command(命令操作)

        /// <summary>
        /// 设置分隔符
        /// </summary>
        public virtual TPrinter Separator()
        {
            Append(Command.Separator());
            return This();
        }

        /// <summary>
        /// 设置自动测试内容
        /// </summary>
        public virtual TPrinter AutoTest()
        {
            Append(Command.AutoTest());
            return This();
        }

        /// <summary>
        /// 设置自动打印内容
        /// </summary>
        public virtual TPrinter AutoPrinter()
        {
            Append("TESTE DE IMPRESSÃO NORMAL - 48 COLUNAS");
            Append("....+....1....+....2....+....3....+....4....+...");
            Separator();
            Append("Texto Normal");
            Italic("Texto Itálico");
            Bold("Texto Negrito");
            Underline("Texto Sublinhado");
            Expanded(PrinterModeState.On);
            Append("Texto Expandido");
            Append("....+....1....+....2....");
            Expanded(PrinterModeState.Off);
            Condensed(PrinterModeState.On);
            Append("Texto condensado");
            Condensed(PrinterModeState.Off);
            Separator();

            DoubleWidth2();
            Append("Largura da Fonte 2");
            DoubleWidth3();
            Append("Largura da Fonte 3");
            NormalWidth();
            Append("Largura normal");
            Separator();

            Right();
            Append("Texto alinhado à direita");
            Center();
            Append("Texto alinhado ao centro");
            Left();
            Append("Texto alinhado à esquerda");
            NewLines(5);
            Append("Final de Teste :)");
            Separator();

            return This();
        }

        #endregion

        #region FontMode(字体模式)

        /// <summary>
        /// 倾斜。将文字变为斜体
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Italic(string value) => Append(Command.FontMode.Italic(value));

        /// <summary>
        /// 倾斜。将文字变为斜体
        /// </summary>
        /// <param name="state">打印模式状态</param>
        public virtual TPrinter Italic(PrinterModeState state) => Append(Command.FontMode.Italic(state));

        /// <summary>
        /// 加粗。将文字加粗
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Bold(string value) => Append(Command.FontMode.Bold(value));

        /// <summary>
        /// 加粗。将文字加粗
        /// </summary>
        /// <param name="state">打印模式状态</param>
        public virtual TPrinter Bold(PrinterModeState state) => Append(Command.FontMode.Bold(state));

        /// <summary>
        /// 下划线。为文字添加下划线
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Underline(string value) => Append(Command.FontMode.Underline(value));

        /// <summary>
        /// 下划线。为文字添加下划线
        /// </summary>
        /// <param name="state">打印模式状态</param>
        public virtual TPrinter Underline(PrinterModeState state) => Append(Command.FontMode.Underline(state));

        /// <summary>
        /// 稀疏
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Expanded(string value) => Append(Command.FontMode.Expanded(value));

        /// <summary>
        /// 稀疏
        /// </summary>
        /// <param name="state">打印模式状态</param>
        public virtual TPrinter Expanded(PrinterModeState state) => Append(Command.FontMode.Expanded(state));

        /// <summary>
        /// 简明
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Condensed(string value) => Append(Command.FontMode.Condensed(value));

        /// <summary>
        /// 简明
        /// </summary>
        /// <param name="state">打印模式</param>
        public virtual TPrinter Condensed(PrinterModeState state) => Append(Command.FontMode.Condensed(state));

        #endregion

        #region FontWidth(字体宽度)

        /// <summary>
        /// 正常宽度
        /// </summary>
        public virtual TPrinter NormalWidth() => Append(Command.FontWidth.NormalWidth());

        /// <summary>
        /// 2倍宽度
        /// </summary>
        public virtual TPrinter DoubleWidth2() => Append(Command.FontWidth.DoubleWidth2());

        /// <summary>
        /// 3倍宽度
        /// </summary>
        public virtual TPrinter DoubleWidth3() => Append(Command.FontWidth.DoubleWidth3());

        #endregion

        #region Alignment(对齐方式)

        /// <summary>
        /// 左对齐
        /// </summary>
        public virtual TPrinter Left() => Append(Command.Alignment.Left());

        /// <summary>
        /// 右对齐
        /// </summary>
        public virtual TPrinter Right() => Append(Command.Alignment.Right());

        /// <summary>
        /// 居中
        /// </summary>
        public virtual TPrinter Center() => Append(Command.Alignment.Center());

        #endregion

        #region PagerCut(页面截断)

        /// <summary>
        /// 全页截断
        /// </summary>
        public virtual TPrinter Full() => Append(Command.PagerCut.Full());

        /// <summary>
        /// 部分截断
        /// </summary>
        public virtual TPrinter Partial() => Append(Command.PagerCut.Partial());

        #endregion

        #region Drawer(绘制器)

        /// <summary>
        /// 打开绘制器
        /// </summary>
        public virtual TPrinter OpenDrawer() => Append(Command.Drawer.OpenDrawer());

        #endregion

        #region QrCode(二维码)

        /// <summary>
        /// 设置二维码
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter QrCode(string value) => Append(Command.QrCode.QrCode(value));

        /// <summary>
        /// 设置二维码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="size">二维码大小</param>
        public virtual TPrinter QrCode(string value, QrCodeSize size) => Append(Command.QrCode.QrCode(value, size));

        #endregion

        #region Barcode(条形码)

        /// <summary>
        /// 设置 Code39 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Code39(string value) => Append(Command.Barcode.Code39(value));

        /// <summary>
        /// 设置 Code128 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        public virtual TPrinter Code128(string value) => Append(Command.Barcode.Code128(value));

        /// <summary>
        /// 设置 Ean13 类型条形码
        /// </summary>
        /// <param name="value">值</param>
        public TPrinter Ean13(string value) => Append(Command.Barcode.Ean13(value));

        #endregion

    }
}
