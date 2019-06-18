namespace Bing.Printer.EscPos
{
    /// <summary>
    /// ASCII控制常量
    /// </summary>
    // ReSharper disable once InconsistentNaming
    internal static class ASCIIControlConst
    {
        /// <summary>
        /// 空字符(Null)。
        /// 二进制 : 0000 0000;
        /// 十进制 : 0;
        /// 十六进制 : 0x00;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte NULL = 0x00;

        /// <summary>
        /// 标题开始。
        /// 二进制 : 0000 0001;
        /// 十进制 : 1;
        /// 十六进制 : 0x01;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte SOH = 0x01;

        /// <summary>
        /// 本文开始。
        /// 二进制 : 0000 0010;
        /// 十进制 : 2;
        /// 十六进制 : 0x02;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte STX = 0x02;

        /// <summary>
        /// 本文结束。
        /// 二进制 : 0000 0011;
        /// 十进制 : 3;
        /// 十六进制 : 0x03;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte ETX = 0x03;

        /// <summary>
        /// 传输结束。
        /// 二进制 : 0000 0100;
        /// 十进制 : 4;
        /// 十六进制 : 0x04;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte EOT = 0x04;

        /// <summary>
        /// 请求。
        /// 二进制 : 0000 0101;
        /// 十进制 : 5;
        /// 十六进制 : 0x05;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte ENQ = 0x05;

        /// <summary>
        /// 确认回应。
        /// 二进制 : 0000 0110;
        /// 十进制 : 6;
        /// 十六进制 : 0x06;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte ACK = 0x06;

        /// <summary>
        /// 响铃。
        /// 二进制 : 0000 0111;
        /// 十进制 : 7;
        /// 十六进制 : 0x07;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte BEL = 0x07;

        /// <summary>
        /// 退格。
        /// 二进制 : 0000 1000;
        /// 十进制 : 8;
        /// 十六进制 : 0x08;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte BS = 0x08;

        /// <summary>
        /// 水平定位符号。
        /// 二进制 : 0000 1001;
        /// 十进制 : 9;
        /// 十六进制 : 0x09;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte HT = 0x09;

        /// <summary>
        /// 换行键。
        /// 二进制 : 0000 1010;
        /// 十进制 : 10;
        /// 十六进制 : 0x0A;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte LF = 0x0A;

        /// <summary>
        /// 垂直定位符号。
        /// 二进制 : 0000 1011;
        /// 十进制 : 11;
        /// 十六进制 : 0x0B;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte VT = 0x0B;

        /// <summary>
        /// 换页键。
        /// 二进制 : 0000 1100;
        /// 十进制 : 12;
        /// 十六进制 : 0x0C;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte FF = 0x0C;

        /// <summary>
        /// 归位键。
        /// 二进制 : 0000 1101;
        /// 十进制 : 13;
        /// 十六进制 : 0x0D;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte CR = 0x0D;

        /// <summary>
        /// 取消变换(Shift out)。
        /// 二进制 : 0000 1110;
        /// 十进制 : 14;
        /// 十六进制 : 0x0E;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte SO = 0x0E;

        /// <summary>
        /// 启用变换(Shift In)。
        /// 二进制 : 0000 1111;
        /// 十进制 : 15;
        /// 十六进制 : 0x0F;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte SI = 0x0F;

        /// <summary>
        /// 跳出数据通讯。
        /// 二进制 : 0001 0000;
        /// 十进制 : 16;
        /// 十六进制 : 0x10;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte DLE = 0x10;

        /// <summary>
        /// 设备控制一(XON 启用软件速度控制)。
        /// 二进制 : 0001 0001;
        /// 十进制 : 17;
        /// 十六进制 : 0x11;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte DC1 = 0x11;

        /// <summary>
        /// 设备控制二。
        /// 二进制 : 0001 0010;
        /// 十进制 : 18;
        /// 十六进制 : 0x12;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte DC2 = 0x12;

        /// <summary>
        /// 设备控制三(XOFF 停用软件速度控制)。
        /// 二进制 : 0001 0011;
        /// 十进制 : 19;
        /// 十六进制 : 0x13;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte DC3 = 0x13;

        /// <summary>
        /// 设备控制四。
        /// 二进制 : 0001 0100;
        /// 十进制 : 20;
        /// 十六进制 : 0x14;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte DC4 = 0x14;

        /// <summary>
        /// 确认失败回应。
        /// 二进制 : 0001 0101;
        /// 十进制 : 21;
        /// 十六进制 : 0x15;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte NAK = 0x15;

        /// <summary>
        /// 同步用暂停。
        /// 二进制 : 0001 0110;
        /// 十进制 : 22;
        /// 十六进制 : 0x16;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte SYN = 0x16;

        /// <summary>
        /// 区块传输结束。
        /// 二进制 : 0001 0111;
        /// 十进制 : 23;
        /// 十六进制 : 0x17;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte ETB = 0x17;

        /// <summary>
        /// 取消。
        /// 二进制 : 0001 1000;
        /// 十进制 : 24;
        /// 十六进制 : 0x18;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte CAN = 0x18;

        /// <summary>
        /// 连接介质中断。
        /// 二进制 : 0001 1001;
        /// 十进制 : 25;
        /// 十六进制 : 0x19;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte EM = 0x19;

        /// <summary>
        /// 替换。
        /// 二进制 : 0001 1010;
        /// 十进制 : 26;
        /// 十六进制 : 0x1A;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte SUB = 0x1A;

        /// <summary>
        /// 跳出。
        /// 二进制 : 0001 1011;
        /// 十进制 : 27;
        /// 十六进制 : 0x1B;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte ESC = 0x1B;

        /// <summary>
        /// 文件分分割符。
        /// 二进制 : 0001 1100;
        /// 十进制 : 28;
        /// 十六进制 : 0x1C;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte FS = 0x1C;

        /// <summary>
        /// 组群分隔符。
        /// 二进制 : 0001 1101;
        /// 十进制 : 29;
        /// 十六进制 : 0x1D;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte GS = 0x1D;

        /// <summary>
        /// 记录分隔符。
        /// 二进制 : 0001 1110;
        /// 十进制 : 30;
        /// 十六进制 : 0x1E;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte RS = 0x1E;

        /// <summary>
        /// 单元分隔符。
        /// 二进制 : 0001 1111;
        /// 十进制 : 31;
        /// 十六进制 : 0x1F;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte US = 0x1F;

        /// <summary>
        /// 删除。
        /// 二进制 : 0111 1111;
        /// 十进制 : 127;
        /// 十六进制 : 0x7F;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte DEL = 0x7F;

    }
}
