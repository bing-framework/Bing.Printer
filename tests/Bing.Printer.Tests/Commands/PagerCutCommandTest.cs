using Xunit;
using Xunit.Abstractions;

namespace Bing.Printer.Tests.Commands
{
    /// <summary>
    /// 页面截断命令测试
    /// </summary>
    public class PagerCutCommandTest : TestBase
    {
        public PagerCutCommandTest(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// 测试 - 全页切断
        /// </summary>
        [Fact]
        public void Test_Full()
        {
            Printer.Initialize();
            Printer.WriteLine("Test Full Cut");
            Printer.WriteLine("测试全页切断");

            Printer.Full();
            Printer.WriteLine("Test Full Cut");
            Printer.WriteLine("测试全页切断");
            Printer.Full();

            Printer.Initialize();
            Printer.WriteLine("Test Full Cut");
            Printer.WriteLine("测试全页切断");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }

        /// <summary>
        /// 测试 - 部分切断
        /// </summary>
        [Fact]
        public void Test_Partial()
        {
            Printer.Initialize();
            Printer.WriteLine("Test Partial Cut");
            Printer.WriteLine("测试部分切断");

            Printer.Full();
            Printer.WriteLine("Test Partial Cut");
            Printer.WriteLine("测试部分切断");
            Printer.Full();

            Printer.Initialize();
            Printer.WriteLine("Test Partial Cut");
            Printer.WriteLine("测试部分切断");

            Printer.NewLine(2);

            Output.WriteLine(Printer.ToHex());
        }
    }
}
