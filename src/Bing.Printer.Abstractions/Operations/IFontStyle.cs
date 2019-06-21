namespace Bing.Printer.Operations
{
    /// <summary>
    /// 字体样式操作
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IFontStyle<out T>
    {
        /// <summary>
        /// 加粗。将文字加粗
        /// </summary>
        /// <param name="value">值</param>
        T Bold(string value);

        /// <summary>
        /// 加粗-开。将文字加粗
        /// </summary>
        T BoldOn();

        /// <summary>
        /// 加粗-关。将文字加粗
        /// </summary>
        T BoldOff();

        /// <summary>
        /// 倍宽
        /// </summary>
        /// <param name="value">值</param>
        T DoubleWidth(string value);

        /// <summary>
        /// 倍宽-开
        /// </summary>
        T DoubleWidthOn();

        /// <summary>
        /// 倍宽-关
        /// </summary>
        T DoubleWidthOff();

        /// <summary>
        /// 倍高
        /// </summary>
        /// <param name="value">值</param>
        T DoubleHeight(string value);

        /// <summary>
        /// 倍高-开
        /// </summary>
        T DoubleHeightOn();

        /// <summary>
        /// 倍高-关
        /// </summary>
        T DoubleHeightOff();
        
        /// <summary>
        /// 下划线(1点宽)。为文字添加下划线
        /// </summary>
        /// <param name="value">值</param>
        T Underline(string value);

        /// <summary>
        /// 下划线(2点宽)。为文字添加下划线
        /// </summary>
        /// <param name="value">值</param>
        T Underline2(string value);

        /// <summary>
        /// 下划线(1点宽)。为文字添加下划线
        /// </summary>
        T UnderlineOn();

        /// <summary>
        /// 下划线(2点宽)。为文字添加下划线
        /// </summary>
        T Underline2On();

        /// <summary>
        /// 下划线。为文字添加下划线
        /// </summary>
        T UnderlineOff();

        /// <summary>
        /// 黑白反显
        /// </summary>
        /// <param name="value">值</param>
        T BlackWhite(string value);

        /// <summary>
        /// 黑白反显-开
        /// </summary>
        T BlackWhiteOn();

        /// <summary>
        /// 黑白反显-关
        /// </summary>
        T BlackWhiteOff();

        /// <summary>
        /// 顺时针90度旋转
        /// </summary>
        /// <param name="value">值</param>
        T Rotate90(string value);

        /// <summary>
        /// 顺时针180度旋转
        /// </summary>
        /// <param name="value">值</param>
        T Rotate180(string value);

        /// <summary>
        /// 顺时针270度旋转
        /// </summary>
        /// <param name="value">值</param>
        T Rotate270(string value);

        /// <summary>
        /// 顺时针90度旋转-开
        /// </summary>
        T Rotate90On();

        /// <summary>
        /// 顺时针180度旋转-开
        /// </summary>
        T Rotate180On();

        /// <summary>
        /// 顺时针270度旋转-开
        /// </summary>
        T Rotate270On();

        /// <summary>
        /// 顺时针旋转-关
        /// </summary>
        T RotateOff();
    }
}
