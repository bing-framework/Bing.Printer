using Xunit.Abstractions;

namespace Bing.Printer.Tests.Commands
{
    /// <summary>
    /// 写入器命令测试
    /// </summary>
    public class WriterCommandTest:TestBase
    {
        /// <summary>
        /// 初始化一个<see cref="WriterCommandTest"/>类型的实例
        /// </summary>
        /// <param name="output">输出</param>
        public WriterCommandTest(ITestOutputHelper output) : base(output)
        {
        }
    }
}
