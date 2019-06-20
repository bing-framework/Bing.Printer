using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    /// <summary>
    /// 初始化打印操作
    /// </summary>
    internal class InitializePrintCommand : IInitializePrint<byte[]>
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public byte[] Initialize() => Command.HardwareInit;

        /// <summary>
        /// 启用
        /// </summary>
        public byte[] Enable() => new[] {ASCIIControlConst.ESC, CommandConst.Operations.EnableDisable, (byte) 1};

        /// <summary>
        /// 禁用
        /// </summary>
        public byte[] Disable() => new[] {ASCIIControlConst.ESC, CommandConst.Operations.EnableDisable, (byte) 0};
    }
}
