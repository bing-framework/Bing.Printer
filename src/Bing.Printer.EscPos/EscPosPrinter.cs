using System.Text;
using Bing.Printer.Factories;

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
        protected override IPrintCommand CreatePrintCommand() =>
            new PrintCommand(PrintPaperFactory.GetOrCreate(PrintPaper), Encoding.GetEncoding("GB18030"));
    }
}
