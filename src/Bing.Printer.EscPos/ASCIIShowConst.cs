namespace Bing.Printer.EscPos
{
    /// <summary>
    /// ASCII可显示字符常量
    /// </summary>
    // ReSharper disable once InconsistentNaming
    internal static class ASCIIShowConst
    {
        /// <summary>
        /// 空格。
        /// 显示图形 : " ";
        /// 二进制 : 0010 0000;
        /// 十进制 : 32;
        /// 十六进制 : 0x20;
        /// </summary>
        public const byte Space = 0x20;

        /// <summary>
        /// 叹号。
        /// 显示图形 : !;
        /// 二进制 : 0010 0001;
        /// 十进制 : 33;
        /// 十六进制 : 0x21;
        /// </summary>
        public const byte Bang = 0x21;

        /// <summary>
        /// 双引号。
        /// 显示图形 : ";
        /// 二进制 : 0010 0010;
        /// 十进制 : 34;
        /// 十六进制 : 0x22;
        /// </summary>
        public const byte DoubleQuote = 0x22;

        /// <summary>
        /// 井号。
        /// 显示图形 : #;
        /// 二进制 : 0010 0011;
        /// 十进制 : 35;
        /// 十六进制 : 0x23;
        /// </summary>
        public const byte Sharp = 0x23;

        /// <summary>
        /// 美元符号。
        /// 显示图形 : $;
        /// 二进制 : 0010 0100;
        /// 十进制 : 36;
        /// 十六进制 : 0x24;
        /// </summary>
        public const byte DollarSign = 0x24;

        /// <summary>
        /// 百分号。
        /// 显示图形 : %;
        /// 二进制 : 0010 0101;
        /// 十进制 : 37;
        /// 十六进制 : 0x25;
        /// </summary>
        public const byte Mod = 0x25;

        /// <summary>
        /// 和。
        /// 显示图形 : &amp;;
        /// 二进制 : 0010 0110;
        /// 十进制 : 38;
        /// 十六进制 : 0x26;
        /// </summary>
        public const byte And = 0x26;

        /// <summary>
        /// 单引号。
        /// 显示图形 : ';
        /// 二进制 : 0010 0111;
        /// 十进制 : 39;
        /// 十六进制 : 0x27;
        /// </summary>
        public const byte SingleQuote= 0x27;

        /// <summary>
        /// 左小括号。
        /// 显示图形 : (;
        /// 二进制 : 0010 1000;
        /// 十进制 : 40;
        /// 十六进制 : 0x28;
        /// </summary>
        public const byte LeftParentheses = 0x28;

        /// <summary>
        /// 右小括号。
        /// 显示图形 : );
        /// 二进制 : 0010 1001;
        /// 十进制 : 41;
        /// 十六进制 : 0x29;
        /// </summary>
        public const byte RightParentheses = 0x29;

        /// <summary>
        /// 星号。
        /// 显示图形 : *;
        /// 二进制 : 0010 1010;
        /// 十进制 : 42;
        /// 十六进制 : 0x2A;
        /// </summary>
        public const byte Star = 0x2A;

        /// <summary>
        /// 加号。
        /// 显示图形 : +;
        /// 二进制 : 0010 1011;
        /// 十进制 : 43;
        /// 十六进制 : 0x2B;
        /// </summary>
        public const byte PlusSign = 0x2B;

        /// <summary>
        /// 逗号。
        /// 显示图形 : ,;
        /// 二进制 : 0010 1100;
        /// 十进制 : 44;
        /// 十六进制 : 0x2C;
        /// </summary>
        public const byte Comma = 0x2C;

        /// <summary>
        /// 减号。
        /// 显示图形 : -;
        /// 二进制 : 0010 1101;
        /// 十进制 : 45;
        /// 十六进制 : 0x2D;
        /// </summary>
        public const byte MinusSign = 0x2D;

        /// <summary>
        /// 点号。
        /// 显示图形 : .;
        /// 二进制 : 0010 1110;
        /// 十进制 : 46;
        /// 十六进制 : 0x2E;
        /// </summary>
        public const byte Dot = 0x2E;

        /// <summary>
        /// 斜线。
        /// 显示图形 : /;
        /// 二进制 : 0010 1111;
        /// 十进制 : 47;
        /// 十六进制 : 0x2F;
        /// </summary>
        public const byte Slash = 0x2F;

        /// <summary>
        /// 0。
        /// 显示图形 : 0;
        /// 二进制 : 0011 0000;
        /// 十进制 : 48;
        /// 十六进制 : 0x30;
        /// </summary>
        public const byte Zero = 0x30;

        /// <summary>
        /// 1。
        /// 显示图形 : 1;
        /// 二进制 : 0011 0001;
        /// 十进制 : 49;
        /// 十六进制 : 0x31;
        /// </summary>
        public const byte One = 0x31;

        /// <summary>
        /// 2。
        /// 显示图形 : 2;
        /// 二进制 : 0011 0010;
        /// 十进制 : 50;
        /// 十六进制 : 0x32;
        /// </summary>
        public const byte Two = 0x32;

        /// <summary>
        /// 3。
        /// 显示图形 : 3;
        /// 二进制 : 0011 0011;
        /// 十进制 : 51;
        /// 十六进制 : 0x33;
        /// </summary>
        public const byte Three = 0x33;

        /// <summary>
        /// 4。
        /// 显示图形 : 4;
        /// 二进制 : 0011 0100;
        /// 十进制 : 52;
        /// 十六进制 : 0x34;
        /// </summary>
        public const byte Four = 0x34;

        /// <summary>
        /// 5。
        /// 显示图形 : 5;
        /// 二进制 : 0011 0101;
        /// 十进制 : 53;
        /// 十六进制 : 0x35;
        /// </summary>
        public const byte Five = 0x35;

        /// <summary>
        /// 6。
        /// 显示图形 : 6;
        /// 二进制 : 0011 0110;
        /// 十进制 : 54;
        /// 十六进制 : 0x36;
        /// </summary>
        public const byte Six = 0x36;

        /// <summary>
        /// 7。
        /// 显示图形 : 7;
        /// 二进制 : 0011 0111;
        /// 十进制 : 55;
        /// 十六进制 : 0x37;
        /// </summary>
        public const byte Seven = 0x37;

        /// <summary>
        /// 8。
        /// 显示图形 : 8;
        /// 二进制 : 0011 1000;
        /// 十进制 : 56;
        /// 十六进制 : 0x38;
        /// </summary>
        public const byte Eight= 0x38;

        /// <summary>
        /// 9。
        /// 显示图形 : 9;
        /// 二进制 : 0011 1001;
        /// 十进制 : 57;
        /// 十六进制 : 0x39;
        /// </summary>
        public const byte Nine = 0x39;

        /// <summary>
        /// 冒号。
        /// 显示图形 : :;
        /// 二进制 : 0011 1010;
        /// 十进制 : 58;
        /// 十六进制 : 0x3A;
        /// </summary>
        public const byte Colon = 0x3A;

        /// <summary>
        /// 分号。
        /// 显示图形 : ;;
        /// 二进制 : 0011 1011;
        /// 十进制 : 59;
        /// 十六进制 : 0x3B;
        /// </summary>
        public const byte Semicolon = 0x3B;

        /// <summary>
        /// 小于号。
        /// 显示图形 : &lt;;
        /// 二进制 : 0011 1100;
        /// 十进制 : 60;
        /// 十六进制 : 0x3C;
        /// </summary>
        public const byte LessThan = 0x3C;

        /// <summary>
        /// 等号。
        /// 显示图形 : =;
        /// 二进制 : 0011 1101;
        /// 十进制 : 61;
        /// 十六进制 : 0x3D;
        /// </summary>
        public const byte EqualSign = 0x3D;

        /// <summary>
        /// 大于号。
        /// 显示图形 : &gt;;
        /// 二进制 : 0011 1110;
        /// 十进制 : 62;
        /// 十六进制 : 0x3E;
        /// </summary>
        public const byte GreaterThan = 0x3E;

        /// <summary>
        /// 问号。
        /// 显示图形 : ?;
        /// 二进制 : 0011 1111;
        /// 十进制 : 63;
        /// 十六进制 : 0x3F;
        /// </summary>
        public const byte QuestionMark = 0x3F;

        /// <summary>
        /// @。
        /// 显示图形 : @;
        /// 二进制 : 0100  0000;
        /// 十进制 : 64;
        /// 十六进制 : 0x40;
        /// </summary>
        public const byte AtSign = 0x40;

        /// <summary>
        /// A。
        /// 显示图形 : A;
        /// 二进制 : 0100  0001;
        /// 十进制 : 65;
        /// 十六进制 : 0x41;
        /// </summary>
        public const byte A = 0x41;

        /// <summary>
        /// B。
        /// 显示图形 : B;
        /// 二进制 : 0100  0010;
        /// 十进制 : 66;
        /// 十六进制 : 0x42;
        /// </summary>
        public const byte B = 0x42;

        /// <summary>
        /// C。
        /// 显示图形 : C;
        /// 二进制 : 0100  0011;
        /// 十进制 : 67;
        /// 十六进制 : 0x43;
        /// </summary>
        public const byte C = 0x43;

        /// <summary>
        /// E。
        /// 显示图形 : E;
        /// 二进制 : 0100 0101;
        /// 十进制 : 69;
        /// 十六进制 : 0x45;
        /// </summary>
        public const byte E = 0x45;

        /// <summary>
        /// G。
        /// 显示图形 : G;
        /// 二进制 : 0100 0111;
        /// 十进制 : 71;
        /// 十六进制 : 0x47;
        /// </summary>
        public const byte G = 0x47;

        /// <summary>
        /// H。
        /// 显示图形 : H;
        /// 二进制 : 0100 1000;
        /// 十进制 : 72;
        /// 十六进制 : 0x48;
        /// </summary>
        public const byte H = 0x48;

        /// <summary>
        /// L。
        /// 显示图形 : L;
        /// 二进制 : 0100 1100;
        /// 十进制 : 76;
        /// 十六进制 : 0x4C;
        /// </summary>
        public const byte L = 0x4C;

        /// <summary>
        /// M。
        /// 显示图形 : M;
        /// 二进制 : 0100 1101;
        /// 十进制 : 77;
        /// 十六进制 : 0x4D;
        /// </summary>
        public const byte M = 0x4D;

        /// <summary>
        /// P。
        /// 显示图形 : P;
        /// 二进制 : 0101 0000;
        /// 十进制 : 80;
        /// 十六进制 : 0x50;
        /// </summary>
        public const byte P = 0x50;

        /// <summary>
        /// R。
        /// 显示图形 : R;
        /// 二进制 : 0101 0010;
        /// 十进制 : 82;
        /// 十六进制 : 0x52;
        /// </summary>
        public const byte R = 0x52;

        /// <summary>
        /// V。
        /// 显示图形 : V;
        /// 二进制 : 0101 0110;
        /// 十进制 : 86;
        /// 十六进制 : 0x56;
        /// </summary>
        public const byte V = 0x56;

        /// <summary>
        /// w。
        /// 显示图形 : w;
        /// 二进制 : 0101 0111;
        /// 十进制 : 87;
        /// 十六进制 : 0x57;
        /// </summary>
        public const byte W = 0x57;

        /// <summary>
        /// 反斜线。
        /// 显示图形 : \;
        /// 二进制 : 0101 1100;
        /// 十进制 : 92;
        /// 十六进制 : 0x5C;
        /// </summary>
        public const byte Backslash = 0x5C;

        /// <summary>
        /// a。
        /// 显示图形 : a;
        /// 二进制 : 0110 0001;
        /// 十进制 : 97;
        /// 十六进制 : 0x61;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte a = 0x61;

        /// <summary>
        /// f。
        /// 显示图形 : f;
        /// 二进制 : 0110 0110;
        /// 十进制 : 102;
        /// 十六进制 : 0x66;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte f = 0x66;

        /// <summary>
        /// h。
        /// 显示图形 : h;
        /// 二进制 : 0110 1000;
        /// 十进制 : 104;
        /// 十六进制 : 0x68;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte h = 0x68;

        /// <summary>
        /// k。
        /// 显示图形 : k;
        /// 二进制 : 0110 1011;
        /// 十进制 : 107;
        /// 十六进制 : 0x6B;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte k = 0x6B;

        /// <summary>
        /// o。
        /// 显示图形 : o;
        /// 二进制 : 0111 1111;
        /// 十进制 : 111;
        /// 十六进制 : 0x6F;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte o = 0x6F;

        /// <summary>
        /// p。
        /// 显示图形 : p;
        /// 二进制 : 0111 0000;
        /// 十进制 : 112;
        /// 十六进制 : 0x70;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte p = 0x70;

        /// <summary>
        /// q。
        /// 显示图形 : q;
        /// 二进制 : 0111 0001;
        /// 十进制 : 113;
        /// 十六进制 : 0x71;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte q = 0x71;

        /// <summary>
        /// t。
        /// 显示图形 : t;
        /// 二进制 : 0111 0100;
        /// 十进制 : 116;
        /// 十六进制 : 0x74;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte t = 0x74;

        /// <summary>
        /// w。
        /// 显示图形 : w;
        /// 二进制 : 0111 0111;
        /// 十进制 : 119;
        /// 十六进制 : 0x77;
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const byte w = 0x77;
    }
}
