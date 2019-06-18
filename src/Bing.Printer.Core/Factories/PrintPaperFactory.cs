using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Bing.Printer.Enums;
using Bing.Printer.Pagers;

namespace Bing.Printer.Factories
{
    /// <summary>
    /// 打印纸工厂
    /// </summary>
    public static class PrintPaperFactory
    {
        /// <summary>
        /// 打印纸字典
        /// </summary>
        private static readonly IDictionary<PrintPaperType, IPrintPaper> PrintPaperDict =
            new ConcurrentDictionary<PrintPaperType, IPrintPaper>();

        /// <summary>
        /// 创建打印纸
        /// </summary>
        /// <param name="type">打印纸类型</param>
        private static IPrintPaper Create(PrintPaperType type)
        {
            switch (type)
            {
                case PrintPaperType.Paper58:
                    return new PrintPaper58mm();
                case PrintPaperType.Paper80:
                    return new PrintPaper80mm();
                default:
                    throw new NotImplementedException($"尚未实现指定 {type} 类型的打印纸");
            }
        }

        /// <summary>
        /// 获取或创建打印纸
        /// </summary>
        /// <param name="type">打印纸类型</param>
        public static IPrintPaper GetOrCreate(PrintPaperType type)
        {
            if (PrintPaperDict.ContainsKey(type))
                return PrintPaperDict[type];
            PrintPaperDict[type] = Create(type);
            return PrintPaperDict[type];
        }
    }
}
