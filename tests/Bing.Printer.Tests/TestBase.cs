using System;
using System.Text;
using Bing.Printer.EscPos;
using Xunit;
using Xunit.Abstractions;

namespace Bing.Printer.Tests
{
    /// <summary>
    /// ���Ի���
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// ���
        /// </summary>
        protected ITestOutputHelper Output { get; }

        /// <summary>
        /// ��ӡ��
        /// </summary>
        protected IEscPosPrinter Printer { get; }

        /// <summary>
        /// ��ʼ��һ��<see cref="TestBase"/>���͵�ʵ��
        /// </summary>
        /// <param name="output">���</param>
        public TestBase(ITestOutputHelper output)
        {
            Output = output;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Printer = new EscPosPrinter();
        }

        [Fact]
        public void Test_Guid()
        {
            var guid = Guid.NewGuid();
            Output.WriteLine(guid.ToString("N"));
            var result = Guid.Parse("8c8710d3806e4973b9e871220fc4b34b");
            Output.WriteLine(result.ToString());
        }
    }
}
