using System.Text;
using Bing.Printer.EscPos;
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
    }
}
