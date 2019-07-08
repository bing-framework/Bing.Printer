using Bing.Printer.EscPos;
using Bing.Printer.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Bing.Printer.Tests.Commands
{
    /// <summary>
    /// 打印样式命令测试
    /// </summary>
    public class PrintStyleCommandTest : TestBase
    {
        /// <summary>
        /// 初始化一个<see cref="PrintStyleCommandTest"/>类型的实例
        /// </summary>
        /// <param name="output">输出</param>
        public PrintStyleCommandTest(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// 测试 - Beep
        /// </summary>
        [Fact]
        public void Test_Beep()
        {
            Printer.Initialize();
            Printer.WriteLine("Test Print Style Beep");
            Printer.WriteLine("测试打印样式底边距");

            Printer.Write(new byte[] {Command.Esc, 0x28, 0x41, 4, 0, 48, 51, 3, 15});
            Printer.WriteLine("Test Print Style Beep");
            Printer.WriteLine("测试打印样式底边距");

            Printer.Initialize();
            Printer.WriteLine("Test Print Style Beep");
            Printer.WriteLine("测试打印样式底边距");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 设置底边距
        /// </summary>
        [Fact]
        public void Test_BottomMargin()
        {
            Printer.Initialize();
            Printer.WriteLine("Test Print Style Bottom Margin");
            Printer.WriteLine("测试打印样式底边距");

            Printer.Write(new byte[] { Command.Esc, 0x64, 0.ToByte() });
            Printer.WriteLine("Test Print Style Bottom Margin");
            Printer.WriteLine("测试打印样式底边距");
            Printer.Write(new byte[] { Command.Esc, 0x64, 1.ToByte() });
            Printer.WriteLine("Test Print Style Bottom Margin");
            Printer.WriteLine("测试打印样式底边距");
            Printer.Write(new byte[] { Command.Esc, 0x64, 10.ToByte() });
            Printer.WriteLine("Test Print Style Bottom Margin");
            Printer.WriteLine("测试打印样式底边距");
            Printer.Write(new byte[] { Command.Esc, 0x64, 20.ToByte() });
            Printer.WriteLine("Test Print Style Bottom Margin");
            Printer.WriteLine("测试打印样式底边距");
           
            Printer.Initialize();
            Printer.WriteLine("Test Print Style Bottom Margin");
            Printer.WriteLine("测试打印样式底边距");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 设置行高
        /// </summary>
        [Fact]
        public void Test_RowHeight()
        {
            Printer.Initialize();
            Printer.WriteLine("Test Print Style Row Height");
            Printer.WriteLine("测试打印样式行高");

            for (int i = 0; i < 255; i+=10)
            {
                Printer.RowHeight(i);
                Printer.WriteLine($"{i}px Test Print Style Row Height");
                Printer.WriteLine($"{i}px 测试打印样式行高");
            }

            Printer.Initialize();
            Printer.WriteLine("Test Print Style Row Height");
            Printer.WriteLine("测试打印样式行高");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }
    }
}
