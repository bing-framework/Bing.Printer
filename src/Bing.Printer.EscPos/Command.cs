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
        public static readonly byte[] InitPrinter = {Esc, AtSign};

        /// <summary>
        /// 打印并走纸一字符行。打印缓冲区内数据并走纸一字符行
        /// 格式：
        /// ASCII码    LF
        /// 十六进制码  0x0A
        /// 十进制码    10
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static readonly byte[] LF = {ASCIIControlConst.LF};

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

        #region 加粗

        /// <summary>
        /// 设置加粗模式。支持中文、英文、符号、数字
        /// 格式：
        /// ASCII码    ESC E 1
        /// 十六进制码  0x1B 0x45 0x31
        /// 十进制码    27 69 49
        /// </summary>
        public static readonly byte[] TxtBoldOn = {Esc, ASCIIShowConst.E, ASCIIShowConst.One};

        /// <summary>
        /// 取消加粗模式。支持中文、英文、符号、数字
        /// 格式：
        /// ASCII码    ESC E 0
        /// 十六进制码  0x1B 0x45 0x30
        /// 十进制码    27 69 48
        /// </summary>
        public static readonly byte[] TxtBoldOff = {Esc, ASCIIShowConst.E, ASCIIShowConst.Zero};

        #endregion

        #region 黑白反显打印

        /// <summary>
        /// 设置黑白反显打印模式。
        /// 格式：
        /// ASCII码    GS B 1
        /// 十六进制码  0x1D 0x42 0x31
        /// 十进制码    29 66 49
        /// </summary>
        public static readonly byte[] TxtBlackWhiteReverseOn = {GS, ASCIIShowConst.B, ASCIIShowConst.One};

        /// <summary>
        /// 取消黑白反显打印模式。
        /// 格式：
        /// ASCII码    GS B 0
        /// 十六进制码  0x1D 0x42 0x30
        /// 十进制码    29 66 48
        /// </summary>
        public static readonly byte[] TxtBlackWhiteReverseOff = {GS, ASCIIShowConst.B, ASCIIShowConst.Zero};

        #endregion

        #region 旋转

        /// <summary>
        /// 设置顺时针90度旋转。
        /// 格式：
        /// ASCII码    ESC V SOH
        /// 十六进制码  0x1B 0x56 0x01
        /// 十进制码    27 86 1
        /// </summary>
        public static readonly byte[] TxtRotate90On = {Esc, ASCIIShowConst.V, ASCIIControlConst.SOH};

        /// <summary>
        /// 设置顺时针180度旋转。
        /// 格式：
        /// ASCII码    ESC V STX
        /// 十六进制码  0x1B 0x56 0x02
        /// 十进制码    27 86 2
        /// </summary>
        public static readonly byte[] TxtRotate180On = {Esc, ASCIIShowConst.V, ASCIIControlConst.STX};

        /// <summary>
        /// 设置顺时针270度旋转。
        /// 格式：
        /// ASCII码    ESC V ETX
        /// 十六进制码  0x1B 0x56 0x03
        /// 十进制码    27 86 3
        /// </summary>
        public static readonly byte[] TxtRotate270On = {Esc, ASCIIShowConst.V, ASCIIControlConst.ETX};

        /// <summary>
        /// 取消顺时针旋转。
        /// 格式：
        /// ASCII码    ESC V NULL
        /// 十六进制码  0x1B 0x56 0x00
        /// 十进制码    27 86 0
        /// </summary>
        public static readonly byte[] TxtRotateOff = {Esc, ASCIIShowConst.V, ASCIIControlConst.NULL};

        #endregion

        #region 双重打印

        /// <summary>
        /// 设置双重打印模式。
        /// 格式：
        /// ASCII码    ESC G SOH
        /// 十六进制码  0x1B 0x47 0x01
        /// 十进制码    27 71 1
        /// </summary>
        public static readonly byte[] TxtDoublePrintOn = {Esc, ASCIIShowConst.G, ASCIIControlConst.SOH};

        /// <summary>
        /// 取消双重打印模式。
        /// 格式：
        /// ASCII码    ESC G NULL
        /// 十六进制码  0x1B 0x47 0x00
        /// 十进制码    27 71 0
        /// </summary>
        public static readonly byte[] TxtDoublePrintOff = {Esc, ASCIIShowConst.G, ASCIIControlConst.NULL};

        #endregion

        /// <summary>
        /// 字体大小。需要额外添加 n (0-255) 值。
        /// 格式：
        /// ASCII码    GS ! n
        /// 十六进制码  0x1D 0x21 n
        /// 十进制码    29 33 n
        /// </summary>
        public static readonly byte[] Size = {GS, ASCIIShowConst.Bang};

        /// <summary>
        /// 字符代码页。需要额外添加 n (0-50,252,253,254,255) 值。
        /// 格式：
        /// ASCII码    ESC t n
        /// 十六进制码  0x1B 0x74 n
        /// 十进制码    27 116 n
        /// </summary>
        public static readonly byte[] CharCodePage = {Esc, ASCIIShowConst.t};

        /// <summary>
        /// 国际字符。需要额外添加 n (0-13) 值。
        /// 格式：
        /// ASCII码    ESC R n
        /// 十六进制码  0x1B 0x52 n
        /// 十进制码    27 82 n
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static readonly byte[] I18nChar = {Esc, ASCIIShowConst.R};

        /// <summary>
        /// 选择字体。需要额外添加 n (0-3) 值。
        /// 格式：
        /// ASCII码    ESC M n
        /// 十六进制码  0x1B 0x4D n
        /// 十进制码    27 77 n
        /// </summary>
        public static readonly byte[] FontType = {Esc, ASCIIShowConst.M};

        #region ASCII相关操作设置

        /// <summary>
        /// ASCII
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static class ASCII
        {
            /// <summary>
            /// 重置字体大小。ASCII字体(13 x 24)、中文字体(24 x 24)，专用于取消其他打印模式
            /// 格式：
            /// ASCII码    ESC ! NULL
            /// 十六进制码  0x1B 0x21 0x00
            /// 十进制码    27 33 0
            /// </summary>
            public static readonly byte[] FontSizeReset = { Esc, ASCIIShowConst.Bang, ASCIIControlConst.NULL };

            /// <summary>
            /// 标准字体。ASCII字体(13 x 24)、中文字体(24 x 24)，专用于取消其他打印模式
            /// 格式：
            /// ASCII码    ESC ! NULL
            /// 十六进制码  0x1B 0x21 0x00
            /// 十进制码    27 33 0
            /// </summary>
            public static readonly byte[] NormalSize = {Esc, ASCIIShowConst.Bang, ASCIIControlConst.NULL};

            /// <summary>
            /// 压缩字体。ASCII字体(9 x 17)、中文字体(24 x 24)
            /// 格式：
            /// ASCII码    ESC ! SOH
            /// 十六进制码  0x1B 0x21 0x01
            /// 十进制码    27 33 1
            /// </summary>
            public static readonly byte[] CompressionSize = {Esc, ASCIIShowConst.Bang, ASCIIControlConst.SOH};

            /// <summary>
            /// 打印模式 - 设置倍宽。
            /// 格式：
            /// ASCII码    ESC ! 空格
            /// 十六进制码  0x1B 0x21 0x20
            /// 十进制码    27 33 32
            /// </summary>
            public static readonly byte[] DoubleWidth = {Esc, ASCIIShowConst.Bang, ASCIIShowConst.Space};

            /// <summary>
            /// 打印模式 - 设置倍高。
            /// 格式：
            /// ASCII码    ESC ! LF
            /// 十六进制码  0x1B 0x21 0x10
            /// 十进制码    27 33 16
            /// </summary>
            public static readonly byte[] DoubleHeight = {Esc, ASCIIShowConst.Bang, ASCIIControlConst.DLE };

            /// <summary>
            /// 打印模式 - 设置倍宽高。
            /// 格式：
            /// ASCII码    ESC ! 0
            /// 十六进制码  0x1B 0x21 0x30
            /// 十进制码    27 33 48
            /// </summary>
            public static readonly byte[] DoubleWidthHeight = {Esc, ASCIIShowConst.Bang, ASCIIShowConst.Zero};

            /// <summary>
            /// 打印模式 - 设置加粗。
            /// 格式：
            /// ASCII码    ESC ! BS
            /// 十六进制码  0x1B 0x21 0x08
            /// 十进制码    27 33 8
            /// </summary>
            public static readonly byte[] Bold = {Esc, ASCIIShowConst.Bang, ASCIIControlConst.BS};

            /// <summary>
            /// 打印模式 - 设置下划线。
            /// 格式：
            /// ASCII码    ESC ! ?
            /// 十六进制码  0x1B 0x21 0x80
            /// 十进制码    27 33 128
            /// </summary>
            public static readonly byte[] Underline = {Esc, ASCIIShowConst.Bang, 0x80};

            /// <summary>
            /// 设置1点宽下划线。
            /// 格式：
            /// ASCII码    ESC - 1
            /// 十六进制码  0x1B 0x2D 0x31
            /// 十进制码    27 45 49
            /// </summary>
            public static readonly byte[] UnderlineOn = {Esc, ASCIIShowConst.MinusSign, ASCIIShowConst.One};

            /// <summary>
            /// 设置2点宽下划线。
            /// 格式：
            /// ASCII码    ESC - 2
            /// 十六进制码  0x1B 0x2D 0x32
            /// 十进制码    27 45 50
            /// </summary>
            public static readonly byte[] Underline2On = {Esc, ASCIIShowConst.MinusSign, ASCIIShowConst.Two};

            /// <summary>
            /// 取消下划线。
            /// 格式：
            /// ASCII码    ESC - 0
            /// 十六进制码  0x1B 0x2D 0x30
            /// 十进制码    27 45 48
            /// </summary>
            public static readonly byte[] UnderlineOff = {Esc, ASCIIShowConst.MinusSign, ASCIIShowConst.Zero};
        }

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
            public static readonly byte[] Enable = {ASCIIControlConst.FS, ASCIIShowConst.And};

            /// <summary>
            /// 取消汉字字符模式。取消汉字字符模式，当取消汉字字符模式后，超过0x80的编码仍然当作ASCII字符处理，将不再打印汉字，除非再用 FS &amp; 命令选择汉字模式
            /// 格式：
            /// ASCII码    FS .
            /// 十六进制码  0x1C 0x2E
            /// 十进制码    28 46
            /// </summary>
            public static readonly byte[] Disable = {FS, ASCIIShowConst.Dot};

            /// <summary>
            /// 重置字体大小。
            /// 格式：
            /// ASCII码    FS ! NULL
            /// 十六进制码  0x1C 0x21 0x00
            /// 十进制码    28 33 0
            /// </summary>
            public static readonly byte[] FontSizeReset = {FS, ASCIIShowConst.Bang, ASCIIControlConst.NULL};

            /// <summary>
            /// 设置倍宽。
            /// 格式：
            /// ASCII码    FS ! EOT
            /// 十六进制码  0x1C 0x21 0x04
            /// 十进制码    28 33 4
            /// </summary>
            public static readonly byte[] DoubleWidthOn = {FS, ASCIIShowConst.Bang, ASCIIControlConst.EOT};

            /// <summary>
            /// 设置倍高。
            /// 格式：
            /// ASCII码    FS ! BS
            /// 十六进制码  0x1C 0x21 0x08
            /// 十进制码    28 33 8
            /// </summary>
            public static readonly byte[] DoubleHeightOn = {FS, ASCIIShowConst.Bang, ASCIIControlConst.BS};

            /// <summary>
            /// 设置倍宽高。
            /// 格式：
            /// ASCII码    FS ! FF
            /// 十六进制码  0x1C 0x21 0x0C
            /// 十进制码    28 33 12
            /// </summary>
            public static readonly byte[] DoubleWidthHeightOn = { FS, ASCIIShowConst.Bang, ASCIIControlConst.FF };

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
            public static readonly byte[] Underline2On = {FS, ASCIIShowConst.MinusSign, ASCIIShowConst.Two};

            /// <summary>
            /// 取消下划线。
            /// 格式：
            /// ASCII码    FS - 0
            /// 十六进制码  0x1C 0x2D 0x30
            /// 十进制码    28 45 48
            /// </summary>
            public static readonly byte[] UnderlineOff = {FS, ASCIIShowConst.MinusSign, ASCIIShowConst.Zero};

            /// <summary>
            /// 设置汉字字符左右间距。
            /// 格式：
            /// ASCII码    FS S n1 n2
            /// 十六进制码  0x1C 0x53 n1 n2
            /// 十进制码    28 83 n1 n2
            /// </summary>
            public static readonly byte[] SpaceingLeftRight = {FS, ASCIIShowConst.S};
        }

        #endregion

        #endregion

        #region 打印排版参数设置指令

        /// <summary>
        /// 设置绝对打印位置。需要额外添加 nL (0-255), nH (0-255) 值。
        /// 格式：
        /// ASCII码    ESC $ nL nH
        /// 十六进制码  0x1B 0x24 nL nH
        /// 十进制码    27 36 nL nH
        /// </summary>
        public static readonly byte[] StyleAbsolutePrintPosition = { Esc, ASCIIShowConst.DollarSign };

        /// <summary>
        /// 设置默认行高。
        /// 格式：
        /// ASCII码    ESC 2
        /// 十六进制码  0x1B 0x32
        /// 十进制码    27 50
        /// </summary>
        public static readonly byte[] StyleDefaultRowHeight = {Esc, ASCIIShowConst.Two};

        /// <summary>
        /// 设置行高。需要额外添加 n (0-255) 值。
        /// 格式：
        /// ASCII码    ESC 3 n
        /// 十六进制码  0x1B 0x33 n
        /// 十进制码    27 51 n
        /// </summary>
        public static readonly byte[] StyleRowHeight = {Esc, ASCIIShowConst.Three};

        /// <summary>
        /// 设置字符右间距。需要额外添加 n (0-255) 值。
        /// 格式：
        /// ASCII码    ESC SP n
        /// 十六进制码  0x1B 0x20 n
        /// 十进制码    27 32 n
        /// </summary>
        public static readonly byte[] StyleCharRightSpacing = {Esc, ASCIIShowConst.Space};

        /// <summary>
        /// 设置左对齐。
        /// 格式：
        /// ASCII码    ESC a 0
        /// 十六进制码  0x1B 0x61 0x30
        /// 十进制码    27 97 48
        /// </summary>
        public static readonly byte[] StyleLeftAlign = {Esc, ASCIIShowConst.a, ASCIIShowConst.Zero};

        /// <summary>
        /// 设置中间对齐。
        /// 格式：
        /// ASCII码    ESC a 1
        /// 十六进制码  0x1B 0x61 0x31
        /// 十进制码    27 97 49
        /// </summary>
        public static readonly byte[] StyleCenterAlign = {Esc, ASCIIShowConst.a, ASCIIShowConst.One};

        /// <summary>
        /// 设置右对齐。
        /// 格式：
        /// ASCII码    ESC a 2
        /// 十六进制码  0x1B 0x61 0x32
        /// 十进制码    27 97 50
        /// </summary>
        public static readonly byte[] StyleRightAlign = {Esc, ASCIIShowConst.a, ASCIIShowConst.Two};

        /// <summary>
        /// 设置左边距。需要额外添加 nL (0-255), nH (0-255) 值。
        /// 格式：
        /// ASCII码    GS L nL nH
        /// 十六进制码  0x1D 0x4C nL nH
        /// 十进制码    29 76 nL nH
        /// </summary>
        public static readonly byte[] StyleLeftMargin = {GS, ASCIIShowConst.L};

        /// <summary>
        /// 设置相对横向打印位置。需要额外添加 nL (0-255), nH (0-255) 值。
        /// 格式：
        /// ASCII码    ESC \ nL nH
        /// 十六进制码  0x1B 0x5C nL nH
        /// 十进制码    27 92 nL nH
        /// </summary>
        public static readonly byte[] StyleRelativeXPosition = {Esc, ASCIIShowConst.Backslash};

        /// <summary>
        /// 设置横向和纵向移动单位。需要额外添加 x (0-255), y (0-255) 值。
        /// 格式：
        /// ASCII码    GS P x y
        /// 十六进制码  0x1D 0x50 x y
        /// 十进制码    29 80 x y
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static readonly byte[] StyleXYMoveUnit = {GS, ASCIIShowConst.P};

        /// <summary>
        /// 设置打印区域宽度。需要额外添加 x (0-255), y (0-255) 值。
        /// 格式：
        /// ASCII码    GS W x y
        /// 十六进制码  0x1D 0x57 x y
        /// 十进制码    29 87 x y
        /// </summary>
        public static readonly byte[] StylePrintWidth = {GS, ASCIIShowConst.W};

        #endregion

        #region 图形/图像打印指令

        /// <summary>
        /// 设置打印密度(8点单密度)。需要额外添加 nL (0-255), nH (0-255), d1···dk (0-255) 值。
        /// 格式：
        /// ASCII码    ESC * NULL nL nH d1···dk
        /// 十六进制码  0x1B 0x2A 0x00 nL nH d1···dk
        /// 十进制码    27 47 0 nL nH d1···dk
        /// </summary>
        public static readonly byte[] ImgPrintDensity8Single = {Esc, ASCIIShowConst.Star, ASCIIControlConst.NULL};

        /// <summary>
        /// 设置打印密度(8点双密度)。需要额外添加 nL (0-255), nH (0-255), d1···dk (0-255) 值。
        /// 格式：
        /// ASCII码    ESC * SOH nL nH d1···dk
        /// 十六进制码  0x1B 0x2A 0x01 nL nH d1···dk
        /// 十进制码    27 47 1 nL nH d1···dk
        /// </summary>
        public static readonly byte[] ImgPrintDensity8Double = { Esc, ASCIIShowConst.Star, ASCIIControlConst.SOH };

        /// <summary>
        /// 设置打印密度(24点单密度)。需要额外添加 nL (0-255), nH (0-255), d1···dk (0-255) 值。
        /// 格式：
        /// ASCII码    ESC * 空格 nL nH d1···dk
        /// 十六进制码  0x1B 0x2A 0x20 nL nH d1···dk
        /// 十进制码    27 47 32 nL nH d1···dk
        /// </summary>
        public static readonly byte[] ImgPrintDensity24Single = { Esc, ASCIIShowConst.Star, ASCIIShowConst.Space };

        /// <summary>
        /// 设置打印密度(24点双密度)。需要额外添加 nL (0-255), nH (0-255), d1···dk (0-255) 值。
        /// 格式：
        /// ASCII码    ESC * ! nL nH d1···dk
        /// 十六进制码  0x1B 0x2A 0x21 nL nH d1···dk
        /// 十进制码    27 47 33 nL nH d1···dk
        /// </summary>
        public static readonly byte[] ImgPrintDensity24Double = { Esc, ASCIIShowConst.Star, ASCIIShowConst.Bang };

        #endregion

        #region 条码打印指令

        /// <summary>
        /// 设置条形码高度。需要额外添加 n (0-255) 值。
        /// 格式：
        /// ASCII码    GS h n
        /// 十六进制码  0x1D 0x68 n
        /// 十进制码    29 104 n
        /// </summary>
        public static readonly byte[] BarcodeHeight = {GS, ASCIIShowConst.h};

        /// <summary>
        /// 设置条形码宽度。需要额外添加 n (2-6) 值。
        /// 格式：
        /// ASCII码    GS w n
        /// 十六进制码  0x1D 0x77 n
        /// 十进制码    29 119 n
        /// </summary>
        public static readonly byte[] BarcodeWidth = {GS, ASCIIShowConst.w};

        /// <summary>
        /// 设置条形码标签字符的打印位置。需要额外添加 n (0-3) 值。
        /// 格式：
        /// ASCII码    GS H n
        /// 十六进制码  0x1D 0x48 n
        /// 十进制码    29 72 n
        /// </summary>
        public static readonly byte[] BarcodeLabelPosition = {GS, ASCIIShowConst.H};

        /// <summary>
        /// 设置条形码标签字符字体A。字体B(12 x 24)
        /// 格式：
        /// ASCII码    GS f NULL
        /// 十六进制码  0x1D 0x66 0x00
        /// 十进制码    29 102 0
        /// </summary>
        public static readonly byte[] BarcodeLabelFontA = {GS, ASCIIShowConst.f, ASCIIControlConst.NULL};

        /// <summary>
        /// 设置条形码标签字符字体B。字体B(9 x 17)
        /// 格式：
        /// ASCII码    GS f NULL
        /// 十六进制码  0x1D 0x66 0x00
        /// 十进制码    29 102 0
        /// </summary>
        public static readonly byte[] BarcodeLabelFontB = { GS, ASCIIShowConst.f, ASCIIControlConst.SOH };

        /// <summary>
        /// 设置 PDF417 参数。
        /// 格式：
        /// ASCII码    GS p nD
        /// 十六进制码  0x1D 0x70 nD
        /// 十进制码    29 112 m nD
        /// </summary>
        public static readonly byte[] BarcodePdf417Param = {GS, ASCIIShowConst.p};

        /// <summary>
        /// 设置二维条码纠错级别。需要额外添加 n (0-8) 值。
        /// 格式：
        /// ASCII码    GS q n
        /// 十六进制码  0x1D 0x71 n
        /// 十进制码    29 113 n
        /// </summary>
        public static readonly byte[] BarcodeQrCodeErrorLevel = {GS, ASCIIShowConst.q};

        /// <summary>
        /// 设置 QRCODE 参数。
        /// 格式：
        /// ASCII码    GS o m nA
        /// 十六进制码  0x1D 0x6F m nA
        /// 十进制码    29 111 m nA
        /// </summary>
        public static readonly byte[] BarcodeQrCodeParam = {GS, ASCIIShowConst.o};

        /// <summary>
        /// 设置条形码类型。
        /// 格式：
        /// ASCII码    GS k m nL d1···dn
        /// 十六进制码  0x1D 0x6B m nL d1···dn
        /// 十进制码    29 107 m nL d1···dn
        /// </summary>
        public static readonly byte[] BarcodeType = {GS, ASCIIShowConst.k};

        #endregion

        /// <summary>
        /// 鸣叫器。每 9 * 50ms 发出5次哔哔声
        /// </summary>
        public static readonly byte[] Beeper =
            {ASCIIControlConst.ESC, ASCIIShowConst.B, ASCIIControlConst.ENQ, ASCIIControlConst.HT};

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
        public static readonly byte[] HardwareInit = {Esc, ASCIIShowConst.AtSign};

        /// <summary>
        /// 切纸-全切纸
        /// </summary>
        public static readonly byte[] PagerFullCut = {ASCIIControlConst.GS, ASCIIShowConst.V, ASCIIControlConst.NULL};

        /// <summary>
        /// 切纸-部分切纸
        /// </summary>
        public static readonly byte[] PagerPartialCut = {ASCIIControlConst.GS, ASCIIShowConst.V, ASCIIControlConst.SOH};

        /// <summary>
        /// 文本格式-正常文本
        /// </summary>
        public static readonly byte[] TxtNormal = {ASCIIControlConst.ESC, ASCIIShowConst.Bang, ASCIIControlConst.NULL};

        /// <summary>
        /// 文本格式-双倍高度文本
        /// </summary>
        [Obsolete] public static readonly byte[] Txt2Height =
            {ASCIIControlConst.ESC, ASCIIShowConst.Bang, ASCIIControlConst.DLE};

        /// <summary>
        /// 文本格式-双倍宽度文本
        /// </summary>
        [Obsolete] public static readonly byte[] Txt2Width =
            {ASCIIControlConst.ESC, ASCIIShowConst.Bang, ASCIIShowConst.Space};

        /// <summary>
        /// 文本格式-四区域文本
        /// </summary>
        [Obsolete] public static readonly byte[] Txt4Quare =
            {ASCIIControlConst.ESC, ASCIIShowConst.Bang, ASCIIShowConst.Zero};
    }
}
