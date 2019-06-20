using System;
using Bing.Printer.Enums;
using Bing.Printer.Operations;

namespace Bing.Printer.EscPos.Commands
{
    internal class FontStyleCommand:IFontStyle<byte[]>
    {
        public byte[] NormalSize()
        {
            throw new NotImplementedException();
        }

        public byte[] Bold(string value)
        {
            throw new NotImplementedException();
        }

        public byte[] Bold(PrinterModeState state)
        {
            throw new NotImplementedException();
        }

        public byte[] Underline(string value)
        {
            throw new NotImplementedException();
        }

        public byte[] Underline(PrinterModeState state)
        {
            throw new NotImplementedException();
        }

        public byte[] Underline2(string value)
        {
            throw new NotImplementedException();
        }

        public byte[] Underline2(PrinterModeState state)
        {
            throw new NotImplementedException();
        }
    }
}
