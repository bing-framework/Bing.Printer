using System;

namespace Bing.Printer.EscPos
{
    /// <summary>
    /// 命令
    /// </summary>
    public static class Command
    {
        /// <summary>
        /// 控制-换行键
        /// </summary>
        public static readonly byte[] Lf = { ASCIIControlConst.LF };

        /// <summary>
        /// 鸣叫器。每 9 * 50ms 发出5次哔哔声
        /// </summary>
        public static readonly byte[] Beeper = {ASCIIControlConst.ESC, ASCIIShowConst.B, ASCIIControlConst.ENQ, ASCIIControlConst.HT};

        /// <summary>
        /// 行间距-24
        /// </summary>
        public static readonly byte[] LineSpace24 = {ASCIIControlConst.ESC, ASCIIShowConst.Bang, 24};

        /// <summary>
        /// 行间距-30
        /// </summary>
        public static readonly byte[] LineSpace30 = {ASCIIControlConst.ESC, ASCIIShowConst.Bang, 30};

        /// <summary>
        /// 选择位图像模式
        /// </summary>
        public static readonly byte[] SelectBitImageMode = {ASCIIControlConst.ESC, ASCIIShowConst.Star, 33};

        /// <summary>
        /// 硬件初始化。在缓冲和复位模式下清除数据
        /// </summary>
        public static readonly byte[] HardwareInit = {ASCIIControlConst.ESC, ASCIIShowConst.AtSign};

        /// <summary>
        /// 切纸-全切纸
        /// </summary>
        [Obsolete]
        public static readonly byte[] PagerFullCut = {ASCIIControlConst.GS, ASCIIShowConst.V, ASCIIControlConst.NULL};

        /// <summary>
        /// 切纸-部分切纸
        /// </summary>
        [Obsolete]
        public static readonly byte[] PagerPartialCut = { ASCIIControlConst.GS, ASCIIShowConst.V, ASCIIControlConst.SOH };

        /// <summary>
        /// 文本格式-正常文本
        /// </summary>
        public static readonly byte[] TxtNormal = {ASCIIControlConst.ESC, ASCIIShowConst.Bang, ASCIIControlConst.NULL};

        /// <summary>
        /// 文本格式-双倍高度文本
        /// </summary>
        [Obsolete]
        public static readonly byte[] Txt2Height = {ASCIIControlConst.ESC, ASCIIShowConst.Bang, ASCIIControlConst.DLE};

        /// <summary>
        /// 文本格式-双倍宽度文本
        /// </summary>
        [Obsolete]
        public static readonly byte[] Txt2Width = {ASCIIControlConst.ESC, ASCIIShowConst.Bang, ASCIIShowConst.Space};

        /// <summary>
        /// 文本格式-四区域文本
        /// </summary>
        [Obsolete]
        public static readonly byte[] Txt4Quare = {ASCIIControlConst.ESC, ASCIIShowConst.Bang, ASCIIShowConst.Zero};

        /// <summary>
        /// 文本格式-下划线关
        /// </summary>
        [Obsolete]
        public static readonly byte[] TxtUnderlineOff = {ASCIIControlConst.ESC, ASCIIShowConst.MinusSign, ASCIIShowConst.Zero};

        /// <summary>
        /// 文本格式-下划线开
        /// </summary>
        [Obsolete]
        public static readonly byte[] TxtUnderlineOn = { ASCIIControlConst.ESC, ASCIIShowConst.MinusSign, ASCIIShowConst.One };
    }
}
