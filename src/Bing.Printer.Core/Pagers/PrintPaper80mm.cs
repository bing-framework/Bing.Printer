using System;

namespace Bing.Printer.Pagers
{
    /// <summary>
    /// 80mm 打印纸
    /// </summary>
    internal class PrintPaper80mm:IPrintPaper
    {
        public int GetLineWidth() => 24;

        public int GetLineStringWidth(int textSize)
        {
            switch (textSize)
            {
                case 0:
                    return 47;
                case 1:
                    return 23;
                default:
                    return 47;
            }
        }

        public int GetDrawableMaxWidth() => 500;
    }
}
