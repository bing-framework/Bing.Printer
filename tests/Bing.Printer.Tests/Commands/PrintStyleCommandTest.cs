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
        /// 测试 - 设置底边距
        /// </summary>
        [Fact]
        public void Test_BottomMargin()
        {
            Printer.Initialize();
            Printer.WriteLine("Test Print Style Bottom Margin");
            Printer.WriteLine("测试打印样式底边距");

            Printer.Write(new byte[] { Command.Esc, 0x33, 0.ToByte() });
            Printer.WriteLine("Test Print Style Bottom Margin");
            Printer.Write(new byte[] { Command.Esc, 0x33, 10.ToByte() });
            Printer.WriteLine("Test Print Style Bottom Margin");
            Printer.Write(new byte[] { Command.Esc, 0x33, 20.ToByte() });
            Printer.WriteLine("测试打印样式底边距");
            Printer.Write(new byte[] { Command.Esc, 0x33, 30.ToByte() });
            Printer.WriteLine("Test Print Style Bottom Margin");
            Printer.Write(new byte[] { Command.Esc, 0x33, 40.ToByte() });
            Printer.WriteLine("测试打印样式底边距");
            Printer.Write(new byte[] { Command.Esc, 0x33, 50.ToByte() });
            Printer.WriteLine("测试打印样式底边距");
            Printer.Write(new byte[] { Command.Esc, 0x33, 60.ToByte() });
            Printer.WriteLine("测试打印样式底边距");
            Printer.Write(new byte[] { Command.Esc, 0x33, 70.ToByte() });
            Printer.WriteLine("测试打印样式底边距");
            Printer.Write(new byte[] { Command.Esc, 0x33, 80.ToByte() });
            Printer.WriteLine("测试打印样式底边距");
            Printer.Write(new byte[] { Command.Esc, 0x33, 90.ToByte() });
            Printer.WriteLine("测试打印样式底边距");
            Printer.Write(new byte[] { Command.Esc, 0x33, 100.ToByte() });
            Printer.WriteLine("测试打印样式底边距");
            Printer.Write(new byte[] { Command.Esc, 0x33, 110.ToByte() });
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
