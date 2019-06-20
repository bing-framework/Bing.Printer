using System.Text;

namespace Bing.Printer.EscPos
{
    /// <summary>
    /// Esc/Pos 打印机
    /// </summary>
    public class EscPosPrinter : PrinterBase<IEscPosPrinter>, IEscPosPrinter
    {
        /// <summary>
        /// 创建打印命令
        /// </summary>
        protected override IPrintCommand CreatePrintCommand() => new PrintCommand(Encoding.GetEncoding("GB18030"));

        /// <summary>
        /// 获取字节数组
        /// </summary>
        /// <param name="value">值</param>
        protected override byte[] GetBytes(string value) => Encoding.GetEncoding("GB18030").GetBytes(value);
    }
}
