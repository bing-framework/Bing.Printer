using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 绘制器操作
    /// </summary>
    internal class Drawer : IDrawer<byte[]>
    {
        /// <summary>
        /// 打开绘制器
        /// </summary>
        public byte[] OpenDrawer() => new byte[] {27, 112, 0, 60, 120};
    }
}
