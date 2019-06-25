using System.Linq;
using System.Text;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 打印线操作指令
    /// </summary>
    internal class PrintLineCommand:IPrintLine<string>
    {
        /// <summary>
        /// 打印纸
        /// </summary>
        private IPrintPaper _printPaper;

        /// <summary>
        /// 初始化一个<see cref="PrintLineCommand"/>类型的实例
        /// </summary>
        /// <param name="printPaper">打印纸</param>
        public PrintLineCommand(IPrintPaper printPaper)
        {
            _printPaper = printPaper;
        }

        /// <summary>
        /// 设置实线
        /// </summary>
        public string SolidLine()
        {
            var length = _printPaper.GetLineWidth() * 2;
            var sb = new StringBuilder();
            while (length>0)
            {
                sb.Append("-");
                length--;
            }
            return sb.ToString();
        }

        /// <summary>
        /// 设置空行
        /// </summary>
        public string EmptyLine()
        {
            var length = _printPaper.GetLineWidth();
            var sb = new StringBuilder();
            while (length > 0)
            {
                sb.Append("  ");
                length--;
            }
            return sb.ToString();
        }

        /// <summary>
        /// 设置虚线
        /// </summary>
        public string DottedLine()
        {
            var length = _printPaper.GetLineWidth();
            var sb = new StringBuilder();
            while (length > 0)
            {
                sb.Append("- ");
                length--;
            }
            return sb.ToString();
        }

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        public string WriteOneLine(string text1, string text2) => WriteOneLine(text1, text2, 0);

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="textSize">文字大小</param>
        public string WriteOneLine(string text1, string text2, int textSize)
        {
            var lineLength = _printPaper.GetLineStringWidth(textSize);
            var needEmpty = (lineLength -
                             (GetStringWidth(text1) + GetStringWidth(text2)) % lineLength) / 1;
            var sb = new StringBuilder();
            while (needEmpty > 0)
            {
                sb.Append(" ");
                needEmpty--;
            }

            var empty = sb.ToString();
            return $"{text1}{empty}{text2}";
        }

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="text3">文本3</param>
        public string WriteOneLine(string text1, string text2, string text3) => WriteOneLine(text1, text2, text3, 0);

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="text3">文本3</param>
        /// <param name="textSize">文字大小</param>
        public string WriteOneLine(string text1, string text2, string text3, int textSize)
        {
            var lineLength = _printPaper.GetLineStringWidth(textSize);
            var needEmpty = (lineLength -
                             (GetStringWidth(text1) + GetStringWidth(text2) + GetStringWidth(text3)) % lineLength) / 2;
            var sb = new StringBuilder();
            while (needEmpty > 0)
            {
                sb.Append(" ");
                needEmpty--;
            }

            var empty = sb.ToString();
            return $"{text1}{empty}{text2}{empty}{text3}";
        }

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="text3">文本3</param>
        /// <param name="text4">文本4</param>
        public string WriteOneLine(string text1, string text2, string text3, string text4) => WriteOneLine(text1, text2, text3, text4, 0);

        /// <summary>
        /// 写入一行输出
        /// </summary>
        /// <param name="text1">文本1</param>
        /// <param name="text2">文本2</param>
        /// <param name="text3">文本3</param>
        /// <param name="text4">文本4</param>
        /// <param name="textSize">文字大小</param>
        public string WriteOneLine(string text1, string text2, string text3, string text4, int textSize)
        {
            var lineLength = _printPaper.GetLineStringWidth(textSize);
            var needEmpty = (lineLength - (GetStringWidth(text1) + GetStringWidth(text2) + GetStringWidth(text3) +
                                           GetStringWidth(text4)) % lineLength) / 3;
            var sb = new StringBuilder();
            while (needEmpty>0)
            {
                sb.Append(" ");
                needEmpty--;
            }

            var empty = sb.ToString();
            return $"{text1}{empty}{text2}{empty}{text3}{empty}{text4}";
        }

        /// <summary>
        /// 获取字符串宽度
        /// </summary>
        /// <param name="text">文本</param>
        private static int GetStringWidth(string text) => text.ToCharArray().Sum(c => c >= 0 && c <= 128 ? 1 : 2);
    }
}
