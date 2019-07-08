using Bing.Printer.Enums;
using Xunit;
using Xunit.Abstractions;

namespace Bing.Printer.Tests.Commands
{
    /// <summary>
    /// 字体样式命令测试
    /// </summary>
    public class FontStyleCommandTest : TestBase
    {
        /// <summary>
        /// 初始化一个<see cref="FontStyleCommandTest"/>类型的实例
        /// </summary>
        /// <param name="output">输出</param>
        public FontStyleCommandTest(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// 测试 - 加粗
        /// </summary>
        [Fact]
        public void Test_Bold()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World Bold");
            Printer.WriteLine("测试中文加粗");

            Printer.Bold("Test World Bold");
            Printer.NewLine();
            Printer.Bold("测试中文加粗");
            Printer.NewLine();

            Printer.WriteLine("Test World Bold");
            Printer.WriteLine("测试中文加粗");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 加粗开关
        /// </summary>
        [Fact]
        public void Test_Bold_On_Off()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World Bold");
            Printer.WriteLine("测试中文加粗");

            Printer.BoldOn();
            Printer.WriteLine("Test World Bold");
            Printer.WriteLine("测试中文加粗");
            Printer.BoldOff();

            Printer.WriteLine("Test World Bold");
            Printer.WriteLine("测试中文加粗");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 倍宽
        /// </summary>
        [Fact]
        public void Test_DoubleWidth()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World DoubleWidth");
            Printer.WriteLine("测试中文倍宽");

            Printer.DoubleWidth("Test World DoubleWidth");
            Printer.NewLine();
            Printer.DoubleWidth("测试中文倍宽");
            Printer.NewLine();

            Printer.WriteLine("Test World DoubleWidth");
            Printer.WriteLine("测试中文倍宽");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 倍宽开关
        /// </summary>
        [Fact]
        public void Test_DoubleWidth_On_Off()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World DoubleWidth");
            Printer.WriteLine("测试中文倍宽");

            Printer.DoubleWidthOn();
            Printer.WriteLine("Test World DoubleWidth");
            Printer.WriteLine("测试中文倍宽");
            Printer.DoubleWidthOff();

            Printer.WriteLine("Test World DoubleWidth");
            Printer.WriteLine("测试中文倍宽");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 倍高
        /// </summary>
        [Fact]
        public void Test_DoubleHeight()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World DoubleHeight");
            Printer.WriteLine("测试中文倍高");

            Printer.DoubleHeight("Test World DoubleHeight");
            Printer.NewLine();
            Printer.DoubleHeight("测试中文倍高");
            Printer.NewLine();

            Printer.WriteLine("Test World DoubleHeight");
            Printer.WriteLine("测试中文倍高");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 倍高开关
        /// </summary>
        [Fact]
        public void Test_DoubleHeight_On_Off()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World DoubleHeight");
            Printer.WriteLine("测试中文倍高");

            Printer.DoubleHeightOn();
            Printer.WriteLine("Test World DoubleHeight");
            Printer.WriteLine("测试中文倍高");
            Printer.DoubleHeightOff();

            Printer.WriteLine("Test World DoubleHeight");
            Printer.WriteLine("测试中文倍高");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 下划线(1点宽)
        /// </summary>
        [Fact]
        public void Test_Underline()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World Underline");
            Printer.WriteLine("测试中文下划线");

            Printer.Underline("Test World Underline");
            Printer.NewLine();
            Printer.Underline("测试中文下划线");
            Printer.NewLine();

            Printer.WriteLine("Test World Underline");
            Printer.WriteLine("测试中文下划线");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 下划线(1点宽)开关
        /// </summary>
        [Fact]
        public void Test_Underline_On_Off()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World Underline");
            Printer.WriteLine("测试中文下划线");

            Printer.UnderlineOn();
            Printer.WriteLine("Test World Underline");
            Printer.WriteLine("测试中文下划线");
            Printer.UnderlineOff();

            Printer.WriteLine("Test World Underline");
            Printer.WriteLine("测试中文下划线");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 下划线(2点宽)
        /// </summary>
        [Fact]
        public void Test_Underline2()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World Underline");
            Printer.WriteLine("测试中文下划线");

            Printer.Underline2("Test World Underline");
            Printer.NewLine();
            Printer.Underline2("测试中文下划线");
            Printer.NewLine();

            Printer.WriteLine("Test World Underline");
            Printer.WriteLine("测试中文下划线");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 下划线(2点宽)开关
        /// </summary>
        [Fact]
        public void Test_Underline2_On_Off()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World Underline");
            Printer.WriteLine("测试中文下划线");

            Printer.Underline2On();
            Printer.WriteLine("Test World Underline");
            Printer.WriteLine("测试中文下划线");
            Printer.UnderlineOff();

            Printer.WriteLine("Test World Underline");
            Printer.WriteLine("测试中文下划线");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 黑白反显
        /// </summary>
        [Fact]
        public void Test_BlackWhite()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World BlackWhite");
            Printer.WriteLine("测试中文黑白反显");

            Printer.BlackWhite("Test World BlackWhite");
            Printer.NewLine();
            Printer.BlackWhite("测试中文黑白反显");
            Printer.NewLine();

            Printer.WriteLine("Test World BlackWhite");
            Printer.WriteLine("测试中文黑白反显");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 黑白反显开关
        /// </summary>
        [Fact]
        public void Test_BlackWhite_On_Off()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World BlackWhite");
            Printer.WriteLine("测试中文黑白反显");

            Printer.BlackWhiteOn();
            Printer.WriteLine("Test World BlackWhite");
            Printer.WriteLine("测试中文黑白反显");
            Printer.BlackWhiteOff();

            Printer.WriteLine("Test World BlackWhite");
            Printer.WriteLine("测试中文黑白反显");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 顺时针90度旋转
        /// </summary>
        [Fact]
        public void Test_Rotate90()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World Rotate90");
            Printer.WriteLine("测试中文顺时针90度旋转");

            Printer.Rotate90("Test World Rotate90");
            Printer.NewLine();
            Printer.Rotate90("测试中文顺时针90度旋转");
            Printer.NewLine();

            Printer.WriteLine("Test World Rotate90");
            Printer.WriteLine("测试中文顺时针90度旋转");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 顺时针90度旋转开关
        /// </summary>
        [Fact]
        public void Test_Rotate90_On_Off()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World Rotate90");
            Printer.WriteLine("测试中文顺时针90度旋转");

            Printer.Rotate90On();
            Printer.WriteLine("Test World Rotate90");
            Printer.WriteLine("测试中文顺时针90度旋转");
            Printer.RotateOff();

            Printer.WriteLine("Test World Rotate90");
            Printer.WriteLine("测试中文顺时针90度旋转");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 顺时针180度旋转
        /// </summary>
        [Fact]
        public void Test_Rotate180()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World Rotate180");
            Printer.WriteLine("测试中文顺时针180度旋转");

            Printer.Rotate180("Test World Rotate180");
            Printer.NewLine();
            Printer.Rotate180("测试中文顺时针180度旋转");
            Printer.NewLine();

            Printer.WriteLine("Test World Rotate180");
            Printer.WriteLine("测试中文顺时针180度旋转");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 顺时针180度旋转开关
        /// </summary>
        [Fact]
        public void Test_Rotate180_On_Off()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World Rotate180");
            Printer.WriteLine("测试中文顺时针180度旋转");

            Printer.Rotate180On();
            Printer.WriteLine("Test World Rotate180");
            Printer.WriteLine("测试中文顺时针180度旋转");
            Printer.RotateOff();

            Printer.WriteLine("Test World Rotate180");
            Printer.WriteLine("测试中文顺时针180度旋转");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 顺时针270度旋转
        /// </summary>
        [Fact]
        public void Test_Rotate270()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World Rotate270");
            Printer.WriteLine("测试中文顺时针270度旋转");

            Printer.Rotate270("Test World Rotate270");
            Printer.NewLine();
            Printer.Rotate270("测试中文顺时针270度旋转");
            Printer.NewLine();

            Printer.WriteLine("Test World Rotate270");
            Printer.WriteLine("测试中文顺时针270度旋转");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 顺时针270度旋转开关
        /// </summary>
        [Fact]
        public void Test_Rotate270_On_Off()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World Rotate270");
            Printer.WriteLine("测试中文顺时针270度旋转");

            Printer.Rotate270On();
            Printer.WriteLine("Test World Rotate270");
            Printer.WriteLine("测试中文顺时针270度旋转");
            Printer.RotateOff();

            Printer.WriteLine("Test World Rotate270");
            Printer.WriteLine("测试中文顺时针270度旋转");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 设置字体大小 - 固定字体尺寸
        /// </summary>
        [Fact]
        public void Test_FontSize_1()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World FontSize");
            Printer.WriteLine("测试中文设置字体大小");

            Printer.FontSize(FontSize.Size0);
            Printer.WriteLine("0 级字体大小");
            Printer.WriteLine("0 Level Font Size");

            Printer.FontSize(FontSize.Size1);
            Printer.WriteLine("1 级字体大小");
            Printer.WriteLine("1 Level Font Size");

            Printer.FontSize(FontSize.Size2);
            Printer.WriteLine("2 级字体大小");
            Printer.WriteLine("2 Level Font Size");

            Printer.FontSize(FontSize.Size3);
            Printer.WriteLine("3 级字体大小");
            Printer.WriteLine("3 Level Font Size");

            Printer.FontSize(FontSize.Size4);
            Printer.WriteLine("4 级字体大小");
            Printer.WriteLine("4 Level Font Size");

            Printer.FontSize(FontSize.Size5);
            Printer.WriteLine("5 级字体大小");
            Printer.WriteLine("5 Level Font Size");

            Printer.FontSize(FontSize.Size6);
            Printer.WriteLine("6 级字体大小");
            Printer.WriteLine("6 Level Font Size");

            Printer.FontSize(FontSize.Size7);
            Printer.WriteLine("7 级字体大小");
            Printer.WriteLine("7 Level Font Size");

            Printer.Initialize();
            Printer.WriteLine("Test World FontSize");
            Printer.WriteLine("测试中文设置字体大小");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 设置字体大小 - 自定义尺寸
        /// </summary>
        [Fact]
        public void Test_FontSize_2()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World FontSize");
            Printer.WriteLine("测试中文设置字体大小");

            Printer.FontSize(0);
            Printer.WriteLine("0 级字体大小");
            Printer.WriteLine("0 Level Font Size");

            Printer.FontSize(17);
            Printer.WriteLine("1 级字体大小");
            Printer.WriteLine("1 Level Font Size");

            Printer.FontSize(34);
            Printer.WriteLine("2 级字体大小");
            Printer.WriteLine("2 Level Font Size");

            Printer.FontSize(51);
            Printer.WriteLine("3 级字体大小");
            Printer.WriteLine("3 Level Font Size");

            Printer.FontSize(68);
            Printer.WriteLine("4 级字体大小");
            Printer.WriteLine("4 Level Font Size");

            Printer.FontSize(85);
            Printer.WriteLine("5 级字体大小");
            Printer.WriteLine("5 Level Font Size");

            Printer.FontSize(102);
            Printer.WriteLine("6 级字体大小");
            Printer.WriteLine("6 Level Font Size");

            Printer.FontSize(119);
            Printer.WriteLine("7 级字体大小");
            Printer.WriteLine("7 Level Font Size");

            Printer.Initialize();
            Printer.WriteLine("Test World FontSize");
            Printer.WriteLine("测试中文设置字体大小");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 设置字体大小 - 自定义宽高
        /// </summary>
        [Fact]
        public void Test_FontSize_3()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World FontSize");
            Printer.WriteLine("测试中文设置字体大小");

            Printer.FontSize(10, 20);
            Printer.WriteLine("10 px, 20 px 字体大小");
            Printer.WriteLine("10 px, 20 px FontSize");

            Printer.FontSize(20, 20);
            Printer.WriteLine("20 px, 20 px 字体大小");
            Printer.WriteLine("20 px, 20 px FontSize");

            Printer.FontSize(30, 30);
            Printer.WriteLine("30 px, 30 px 字体大小");
            Printer.WriteLine("30 px, 30 px FontSize");

            Printer.FontSize(40, 40);
            Printer.WriteLine("40 px, 40 px 字体大小");
            Printer.WriteLine("40 px, 40 px FontSize");

            Printer.Initialize();
            Printer.WriteLine("Test World FontSize");
            Printer.WriteLine("测试中文设置字体大小");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 设置字体类型
        /// </summary>
        [Fact]
        public void Test_FonntType()
        {
            Printer.Initialize();
            Printer.WriteLine("Test World FontSize");
            Printer.WriteLine("测试中文设置字体类型");

            Printer.FontType(FontType.Normal);
            Printer.WriteLine("正常字体类型");
            Printer.WriteLine("Test Normal Font Type");

            Printer.FontType(FontType.Compress0);
            Printer.WriteLine("压缩字体类型");
            Printer.WriteLine("Test Compress0 Font Type");

            Printer.FontType(FontType.Compress1);
            Printer.WriteLine("压缩字体1类型");
            Printer.WriteLine("Test Compress1 Font Type");

            Printer.FontType(FontType.Compress2);
            Printer.WriteLine("压缩字体2类型");
            Printer.WriteLine("Test Compress2 Font Type");

            Printer.Initialize();
            Printer.WriteLine("Test World FontSize");
            Printer.WriteLine("测试中文设置字体类型");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }
    }
}
