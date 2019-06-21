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
        /// 文件分分割符。
        /// 二进制 : 0001 1100;
        /// 十进制 : 28;
        /// 十六进制 : 0x1C;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte FS = ASCIIControlConst.FS;

        /// <summary>
        /// 组群分隔符。
        /// 二进制 : 0001 1101;
        /// 十进制 : 29;
        /// 十六进制 : 0x1D;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte GS = ASCIIControlConst.GS;

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
        public static readonly byte[] InitPrinter = { Esc, AtSign };

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
        public static readonly byte[] FF = { ASCIIControlConst.FF };

        /// <summary>
        /// 打印并回车。当该指令等同于 LF 指令，既打印缓冲区内数据并走纸一字符行
        /// 格式：
        /// ASCII码    CR
        /// 十六进制码  0x0D
        /// 十进制码    13
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static readonly byte[] CR = { ASCIIControlConst.CR };

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

        /// <summary>
        /// 文本格式-加粗开
        /// </summary>
        public static readonly byte[] TxtBoldOn = {Esc, ASCIIShowConst.E, ASCIIShowConst.One};

        /// <summary>
        /// 文本格式-加粗关
        /// </summary>
        public static readonly byte[] TxtBoldOff = { Esc, ASCIIShowConst.E, ASCIIShowConst.Zero };

        /// <summary>
        /// 文本格式-黑白反显开
        /// </summary>
        public static readonly byte[] TxtBlackWhiteReverseOn = {GS, ASCIIShowConst.B, ASCIIShowConst.One};

        /// <summary>
        /// 文本格式-黑白反显关
        /// </summary>
        public static readonly byte[] TxtBlackWhiteReverseOff = { GS, ASCIIShowConst.B, ASCIIShowConst.Zero };

        /// <summary>
        /// 文本格式-顺时针90度旋转开
        /// </summary>
        public static readonly byte[] TxtRotate90On = {Esc, ASCIIShowConst.V, ASCIIControlConst.SOH };

        /// <summary>
        /// 文本格式-顺时针180度旋转开
        /// </summary>
        public static readonly byte[] TxtRotate180On = { Esc, ASCIIShowConst.V, ASCIIControlConst.STX };

        /// <summary>
        /// 文本格式-顺时针270度旋转开
        /// </summary>
        public static readonly byte[] TxtRotate270On = { Esc, ASCIIShowConst.V, ASCIIControlConst.ETX };

        /// <summary>
        /// 文本格式-顺时针旋转关
        /// </summary>
        public static readonly byte[] TxtRotateOff = { Esc, ASCIIShowConst.V, ASCIIControlConst.NULL };

        /// <summary>
        /// 文本格式-双重打印模式开
        /// </summary>
        public static readonly byte[] TxtDoublePrintOn = {Esc, ASCIIShowConst.G, ASCIIControlConst.SOH};

        /// <summary>
        /// 文本格式-双重打印模式关
        /// </summary>
        public static readonly byte[] TxtDoublePrintOff = { Esc, ASCIIShowConst.G, ASCIIControlConst.NULL };

        #endregion

        #region 打印排版参数设置指令

        /// <summary>
        /// 排版-默认行高
        /// </summary>
        public static readonly byte[] StyleDefaultRowHeight = {Esc, ASCIIShowConst.Two};

        #endregion

        #region 中文相关操作设置

        /// <summary>
        /// 中文
        /// </summary>
        public static class Chinese
        {
            /// <summary>
            /// 设定汉字字符模式。选择汉字字符模式
            /// 格式：
            /// ASCII码    FS &amp;
            /// 十六进制码  0x1C 0x26
            /// 十进制码    28 38
            /// </summary>
            public static readonly byte[] Enable = { ASCIIControlConst.FS, ASCIIShowConst.And };

            /// <summary>
            /// 取消汉字字符模式。取消汉字字符模式，当取消汉字字符模式后，超过0x80的编码仍然当作ASCII字符处理，将不再打印汉字，除非再用 FS &amp; 命令选择汉字模式
            /// 格式：
            /// ASCII码    FS .
            /// 十六进制码  0x1C 0x2E
            /// 十进制码    28 46
            /// </summary>
            public static readonly byte[] Disable = { FS, ASCIIShowConst.Dot };

            /// <summary>
            /// 设置倍宽。
            /// 格式：
            /// ASCII码    FS ! EOT
            /// 十六进制码  0x1C 0x21 0x04
            /// 十进制码    28 33 4
            /// </summary>
            public static readonly byte[] DoubleWidthOn = { FS, ASCIIShowConst.Bang, ASCIIControlConst.EOT };

            /// <summary>
            /// 取消倍宽。
            /// 格式：
            /// ASCII码    FS ! NULL
            /// 十六进制码  0x1C 0x21 0x00
            /// 十进制码    28 33 0
            /// </summary>
            public static readonly byte[] DoubleWidthOff = { FS, ASCIIShowConst.Bang, ASCIIControlConst.NULL };

            /// <summary>
            /// 设置倍高。
            /// 格式：
            /// ASCII码    FS ! BS
            /// 十六进制码  0x1C 0x21 0x08
            /// 十进制码    28 33 8
            /// </summary>
            public static readonly byte[] DoubleHeightOn = { FS, ASCIIShowConst.Bang, ASCIIControlConst.BS };

            /// <summary>
            /// 取消倍高。
            /// 格式：
            /// ASCII码    FS ! NULL
            /// 十六进制码  0x1C 0x21 0x00
            /// 十进制码    28 33 0
            /// </summary>
            public static readonly byte[] DoubleHeightOff = { FS, ASCIIShowConst.Bang, ASCIIControlConst.NULL };

            /// <summary>
            /// 设置1点宽下划线。
            /// 格式：
            /// ASCII码    FS - 1
            /// 十六进制码  0x1C 0x2D 0x31
            /// 十进制码    28 45 49
            /// </summary>
            public static readonly byte[] UnderlineOn = {FS, ASCIIShowConst.MinusSign, ASCIIShowConst.One};

            /// <summary>
            /// 设置2点宽下划线。
            /// 格式：
            /// ASCII码    FS - 2
            /// 十六进制码  0x1C 0x2D 0x32
            /// 十进制码    28 45 50
            /// </summary>
            public static readonly byte[] Underline2On = { FS, ASCIIShowConst.MinusSign, ASCIIShowConst.Two };

            /// <summary>
            /// 取消下划线。
            /// 格式：
            /// ASCII码    FS - 0
            /// 十六进制码  0x1C 0x2D 0x30
            /// 十进制码    28 45 48
            /// </summary>
            public static readonly byte[] UnderlineOff = { FS, ASCIIShowConst.MinusSign, ASCIIShowConst.Zero };
        }

        #endregion

        /// <summary>
        /// 鸣叫器。每 9 * 50ms 发出5次哔哔声
        /// </summary>
        public static readonly byte[] Beeper = { ASCIIControlConst.ESC, ASCIIShowConst.B, ASCIIControlConst.ENQ, ASCIIControlConst.HT };

        /// <summary>
        /// 行间距-24
        /// </summary>
        public static readonly byte[] LineSpace24 = { ASCIIControlConst.ESC, ASCIIShowConst.Bang, 24 };

        /// <summary>
        /// 行间距-30
        /// </summary>
        public static readonly byte[] LineSpace30 = { ASCIIControlConst.ESC, ASCIIShowConst.Bang, 30 };

        /// <summary>
        /// 选择位图像模式
        /// </summary>
        public static readonly byte[] SelectBitImageMode = { ASCIIControlConst.ESC, ASCIIShowConst.Star, 33 };

        /// <summary>
        /// 硬件初始化。在缓冲和复位模式下清除数据
        /// </summary>
        public static readonly byte[] HardwareInit = { ASCIIControlConst.ESC, ASCIIShowConst.AtSign };

        /// <summary>
        /// 切纸-全切纸
        /// </summary>
        [Obsolete]
        public static readonly byte[] PagerFullCut = { ASCIIControlConst.GS, ASCIIShowConst.V, ASCIIControlConst.NULL };

        /// <summary>
        /// 切纸-部分切纸
        /// </summary>
        [Obsolete]
        public static readonly byte[] PagerPartialCut = { ASCIIControlConst.GS, ASCIIShowConst.V, ASCIIControlConst.SOH };

        /// <summary>
        /// 文本格式-正常文本
        /// </summary>
        public static readonly byte[] TxtNormal = { ASCIIControlConst.ESC, ASCIIShowConst.Bang, ASCIIControlConst.NULL };

        /// <summary>
        /// 文本格式-双倍高度文本
        /// </summary>
        [Obsolete]
        public static readonly byte[] Txt2Height = { ASCIIControlConst.ESC, ASCIIShowConst.Bang, ASCIIControlConst.DLE };

        /// <summary>
        /// 文本格式-双倍宽度文本
        /// </summary>
        [Obsolete]
        public static readonly byte[] Txt2Width = { ASCIIControlConst.ESC, ASCIIShowConst.Bang, ASCIIShowConst.Space };

        /// <summary>
        /// 文本格式-四区域文本
        /// </summary>
        [Obsolete]
        public static readonly byte[] Txt4Quare = { ASCIIControlConst.ESC, ASCIIShowConst.Bang, ASCIIShowConst.Zero };


    }
}
