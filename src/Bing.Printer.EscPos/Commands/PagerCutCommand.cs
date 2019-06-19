using Bing.Printer.Extensions;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 页面截断操作
    /// </summary>
    internal class PagerCutCommand : IPagerCut<byte[]>
    {
        /// <summary>
        /// 全页截断
        /// </summary>
        public byte[] Full() => Command.PagerFullCut;

        /// <summary>
        /// 部分截断
        /// </summary>
        public byte[] Partial() => Command.PagerPartialCut;
    }
}
