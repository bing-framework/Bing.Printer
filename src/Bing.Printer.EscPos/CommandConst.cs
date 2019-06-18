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
