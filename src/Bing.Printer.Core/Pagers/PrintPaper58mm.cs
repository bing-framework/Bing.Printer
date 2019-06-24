namespace Bing.Printer.Pagers
{
    /// <summary>
    /// 58mm 打印纸
    /// </summary>
    internal class PrintPaper58mm:IPrintPaper
    {
        public int GetLineWidth() => 16;

        public int GetLineStringWidth(int textSize)
        {
            switch (textSize)
            {
                case 0:
                    return 31;
                case 1:
                    return 15;
                case 2:
                    return 60;
                default:
                    return 31;
            }
        }

        public int GetDrawableMaxWidth() => 300;
    }
}
