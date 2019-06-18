using Bing.Printer.Extensions;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 页面截断操作
    /// </summary>
    internal class PagerCut : IPagerCut<byte[]>
    {
        /// <summary>
        /// 全页截断
        /// </summary>
        public byte[] Full() => new byte[] {29, 'V'.ToByte(), 65, 3};

        /// <summary>
        /// 部分截断
        /// </summary>
        public byte[] Partial() => new byte[] { 29, 'V'.ToByte(), 65, 3 };
    }
}
