using System.Text;
using Bing.Printer.EscPos;
using Xunit;
using Xunit.Abstractions;

namespace Bing.Printer.Tests
{
    public class EscPosPrinterTest:TestBase
    {
        /// <summary>
        /// 打印机
        /// </summary>
        private IEscPosPrinter _printer;

        public EscPosPrinterTest(ITestOutputHelper output) : base(output)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _printer = new EscPosPrinter();
        }

        /// <summary>
        /// 测试 自动测试
        /// </summary>
        [Fact]
        public void Test_AutoTest()
        {
            _printer.AutoTest();
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 自动打印内容
        /// </summary>
        [Fact]
        public void Test_AutoPrinter()
        {
            _printer.AutoPrinter();
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 简单例子
        /// </summary>
        [Fact]
        public void Test_Simple()
        {
            _printer.Center()
                .Append("居中字符串")
                .Left()
                .Append("左对齐字符串")
                .Right()
                .Append("右对齐字符串")
                .Full();
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 简单例子1
        /// </summary>
        [Fact]
        public void Test_Simple_1()
        {
            _printer.Append(new byte[] {0x1B, 0x40});
            _printer.Center()
                .Append("测试打印机")
                .DoubleWidth2()
                .NewLines(2);

            _printer.Left()
                .Append("这里是打印机描述")
                .NewLine();

            _printer.Left()
                .Append("\x1B\x44\x12\x19\x24\x00")
                .NewLine();

            _printer.Append("_______________________________________");
            _printer.Code39("0201902018");
            _printer.Full();

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }
    }
}
