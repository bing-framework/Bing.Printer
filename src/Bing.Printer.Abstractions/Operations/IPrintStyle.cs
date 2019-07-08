namespace Bing.Printer.Operations
{
    /// <summary>
    /// 打印样式操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IPrintStyle<out T>
    {
        /// <summary>
        /// 设置左边距
        /// </summary>
        /// <param name="value">值</param>
        T LeftMargin(int value = 0);

        /// <summary>
        /// 设置左边距
        /// </summary>
        /// <param name="nL">边距值</param>
        /// <param name="nH">高度</param>
        T LeftMargin(int nL, int nH);

        /// <summary>
        /// 设置打印区域宽度
        /// </summary>
        /// <param name="nL">长度</param>
        /// <param name="nH">高度</param>
        T PrintWidth(int nL, int nH);

        /// <summary>
        /// 设置相对横向打印位置
        /// </summary>
        /// <param name="nL">长度</param>
        /// <param name="nH">高度</param>
        T RelativeHorizontalPosition(int nL, int nH);

        /// <summary>
        /// 设置绝对打印位置
        /// </summary>
        /// <param name="nL">长度</param>
        /// <param name="nH">高度</param>
        T AbsolutePosition(int nL, int nH);

        /// <summary>
        /// 左对齐
        /// </summary>
        T Left();

        /// <summary>
        /// 居中
        /// </summary>
        T Center();

        /// <summary>
        /// 右对齐
        /// </summary>
        /// <returns></returns>
        T Right();

        /// <summary>
        /// 设置默认行高
        /// </summary>
        T RowHeight();

        /// <summary>
        /// 设置行高
        /// </summary>
        /// <param name="height">高度</param>
        T RowHeight(int height);

        /// <summary>
        /// 设置中文字符间距
        /// </summary>
        /// <param name="left">左间距</param>
        /// <param name="right">右间距</param>
        // ReSharper disable once InconsistentNaming
        T SpacingCN(int left = 0, int right = 0);
    }
}
