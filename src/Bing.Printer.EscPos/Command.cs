using System;

namespace Bing.Printer.EscPos
{
    /// <summary>
    /// 命令
    /// </summary>
    public static class Command
    {
        #region 基本控制指令

        /// <summary>
        /// 跳出。
        /// 二进制 : 0001 1011;
        /// 十进制 : 27;
        /// 十六进制 : 0x1B;
        /// </summary>
        public const byte Esc = ASCIIControlConst.ESC;

        /// <summary>
        /// @。
        /// 显示图形 : @;
        /// 二进制 : 0100  0000;
        /// 十进制 : 64;
        /// 十六进制 : 0x40;
        /// </summary>
        public const byte AtSign = ASCIIShowConst.AtSign;

        /// <summary>
        /// 初始化打印机。清除打印缓冲区数据，打印模式被设为上电时的默认值模式
        /// 格式：
        /// ASCII码    ESC @
        /// 十六进制码  0x1B 0x40
        /// 十进制码    27 64
        /// </summary>
        public static readonly byte[] InitPrinter = {Esc, AtSign };

        /// <summary>
        /// 打印并走纸一字符行。打印缓冲区内数据并走纸一字符行
        /// 格式：
        /// ASCII码    LF
        /// 十六进制码  0x0A
        /// 十进制码    10
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static readonly byte[] LF = { ASCIIControlConst.LF };

        /// <summary>
        /// 打印并走纸。将打印缓冲区中的数据全部打印出来并走纸到左黑标处。
        /// 格式：
        /// ASCII码    FF
        /// 十六进制码  0x0C
        /// 十进制码    12
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static readonly byte[] FF = {ASCIIControlConst.FF};

        /// <summary>
        /// 打印并回车。当该指令等同于 LF 指令，既打印缓冲区内数据并走纸一字符行
        /// 格式：
        /// ASCII码    CR
        /// 十六进制码  0x0D
        /// 十进制码    13
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static readonly byte[] CR = {ASCIIControlConst.CR};

        #endregion

        #region 字符参数设置指令

        /// <summary>
        /// 文本格式-下划线关
        /// </summary>
        public static readonly byte[] TxtUnderlineOff = { ASCIIControlConst.ESC, ASCIIShowConst.MinusSign, ASCIIShowConst.Zero };

        /// <summary>
        /// 文本格式-1点宽下划线开
        /// </summary>
        public static readonly byte[] TxtUnderlineOn = { ASCIIControlConst.ESC, ASCIIShowConst.MinusSign, ASCIIShowConst.One };

        /// <summary>
        /// 文本格式-2点宽下划线开
        /// </summary>
        public static readonly byte[] TxtUnderline2On = { ASCIIControlConst.ESC, ASCIIShowConst.MinusSign, ASCIIShowConst.Two };

        #endregion

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

        
    }
}
