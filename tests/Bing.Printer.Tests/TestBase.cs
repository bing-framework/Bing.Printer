using System.Text;
using Bing.Printer.EscPos;
using Xunit.Abstractions;

namespace Bing.Printer.Tests
{
    /// <summary>
    /// 测试基类
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// 输出
        /// </summary>
        protected ITestOutputHelper Output { get; }

        /// <summary>
        /// 打印机
        /// </summary>
        protected IEscPosPrinter Printer { get; }

        /// <summary>
        /// 初始化一个<see cref="TestBase"/>类型的实例
        /// </summary>
        /// <param name="output">输出</param>
        public TestBase(ITestOutputHelper output)
        {
            Output = output;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Printer = new EscPosPrinter();
        }
    }
}
