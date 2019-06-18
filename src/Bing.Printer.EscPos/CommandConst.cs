namespace Bing.Printer.EscPos
{
    /// <summary>
    /// 命令常量
    /// </summary>
    internal static class CommandConst
    {
        /// <summary>
        /// 操作
        /// </summary>
        public static class Operations
        {
            /// <summary>
            /// 初始化。
            /// 显示图形 : @;
            /// 二进制 : 0100 0000;
            /// 十进制 : 64;
            /// 十六进制 : 0x40;
            /// </summary>
            public const byte Initialize = 0x40;

            /// <summary>
            /// 启用禁用。
            /// 显示图形 : =;
            /// 二进制 : 0011 1101;
            /// 十进制 : 61;
            /// 十六进制 : 0x3D;
            /// </summary>
            public const byte EnableDisable = 0x3D;

            /// <summary>
            /// 切纸。
            /// 显示图形 : V;
            /// 二进制 : 0101 0110;
            /// 十进制 : 86;
            /// 十六进制 : 0x56;
            /// </summary>
            public const byte PaperCut = 0x56;
        }

        /// <summary>
        /// 字符
        /// </summary>
        public static class Chars
        {
            /// <summary>
            /// 样式模式。
            /// 显示图形 : !;
            /// 二进制 : 0010 0001;
            /// 十进制 : 33;
            /// 十六进制 : 0x21;
            /// </summary>
            public const byte StyleMode = 0x21;

            /// <summary>
            /// 对齐方式。
            /// 显示图形 : a;
            /// 二进制 : 0110 0001;
            /// 十进制 : 97;
            /// 十六进制 : 0x61;
            /// </summary>
            public const byte Alignment = 0x61;

            /// <summary>
            /// 字符间距。
            /// 显示图形 : a;
            /// 二进制 : 0110 0001;
            /// 十进制 : 97;
            /// 十六进制 : 0x61;
            /// </summary>
            public const byte RightCharacterSpacing = 0x20;
        }

        /// <summary>
        /// 空白
        /// </summary>
        public static class Whitespace
        {
            
        }

        /// <summary>
        /// 状态
        /// </summary>
        public static class Status
        {
            
        }

        /// <summary>
        /// 函数
        /// </summary>
        public static class Functions
        {
            
        }

        /// <summary>
        /// 条形码
        /// </summary>
        public static class Barcodes
        {
            /// <summary>
            /// 打印。
            /// 显示图形 : k;
            /// 二进制 : 0110 1011;
            /// 十进制 : 107;
            /// 十六进制 : 0x6B;
            /// </summary>
            public const byte Print = 0x6B;

            /// <summary>
            /// 高度。
            /// 显示图形 : h;
            /// 二进制 : 0110 1000	;
            /// 十进制 : 104;
            /// 十六进制 : 0x68;
            /// </summary>
            public const byte Height = 0x68;

            /// <summary>
            /// 宽度。
            /// 显示图形 : w;
            /// 二进制 : 0111 0111;
            /// 十进制 : 119;
            /// 十六进制 : 0x77;
            /// </summary>
            public const byte Width = 0x77;

            /// <summary>
            /// 标签显示位置。
            /// 显示图形 : H;
            /// 二进制 : 0100 1000;
            /// 十进制 : 72;
            /// 十六进制 : 0x48;
            /// </summary>
            public const byte LabelPosition = 0x48;

            /// <summary>
            /// 标签字体。
            /// 显示图形 : f;
            /// 二进制 : 0110 0110;
            /// 十进制 : 102;
            /// 十六进制 : 0x66;
            /// </summary>
            public const byte LabelFont = 0x66;
        }

        /// <summary>
        /// 二维码
        /// </summary>
        public static class QrCode
        {
            
        }

        /// <summary>
        /// 图片
        /// </summary>
        public static class Images
        {
            
        }
    }
}
