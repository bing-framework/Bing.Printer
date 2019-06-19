using System.Text;
using Bing.Printer.Enums;
using Bing.Printer.EscPos;
using Bing.Printer.Extensions;
using Bing.Printer.Options;
using Xunit;
using Xunit.Abstractions;

namespace Bing.Printer.Tests
{
    public class EscPosPrinterTest:TestBase
    {
        /// <summary>
        /// 打印机
        /// </summary>
        private IEscPosPrinter _printer;

        public EscPosPrinterTest(ITestOutputHelper output) : base(output)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _printer = new EscPosPrinter();
        }

        /// <summary>
        /// 测试 自动测试
        /// </summary>
        [Fact]
        public void Test_AutoTest()
        {
            _printer.AutoTest();
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 自动打印内容
        /// </summary>
        [Fact]
        public void Test_AutoPrinter()
        {
            _printer.AutoPrinter();
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 简单例子
        /// </summary>
        [Fact]
        public void Test_Simple()
        {
            _printer.Center()
                .Append("居中字符串")
                .Left()
                .Append("左对齐字符串")
                .Right()
                .Append("右对齐字符串")
                .Full();
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 简单例子1
        /// </summary>
        [Fact]
        public void Test_Simple_1()
        {
            _printer.Append(new byte[] {0x1B, 0x40});
            _printer.Center()
                .Append("测试打印机")
                .DoubleWidth2()
                .NewLines(2);

            _printer.Left()
                .Append("这里是打印机描述")
                .NewLine();

            _printer.Left()
                .Append("\x1B\x44\x12\x19\x24\x00")
                .NewLine();

            _printer.Append("_______________________________________");
            _printer.Code39("0201902018");
            _printer.Full();

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 快递单号
        /// </summary>
        [Fact]
        public void Test_DeliveryOrder()
        {
            //_printer.Append(new byte[] { 0x1B, 0x40 });
            //_printer.Center()
            //    .Code128("Y20190618000001")
            //    .NewLine()
            //    .Append("Y20190618000001");

            _printer.Left();
            _printer.AppendWithoutLf("订单号\t")
                .Append("Y20190618000001");

            _printer.AppendWithoutLf("配送中心\t")
                .Append("天河高志体验店");

            _printer.AppendWithoutLf("配送时段\t")
                .Append("2019-06-18 14:00-14:30");

            _printer.AppendWithoutLf("收货人  \t")
                .Append($"隔壁老王(18588777777)");

            _printer.Append("收货地址")
                .Append("广州市天河区黄埔大道西120号高志大厦B1层")
                .NewLine();

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 条形码 宽度
        /// </summary>
        [Fact]
        public void Test_Barcode_Width()
        {
            _printer.Append(new byte[] {0x1B, 0x40});
            _printer.Center();
            _printer.Append("Thinnest Width:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Width = BarcodeWidth.Thinnest
            }).NewLine();

            _printer.Append("Thin Width:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Width = BarcodeWidth.Thin
            }).NewLine();

            _printer.Append("Default Width:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Width = BarcodeWidth.Default
            }).NewLine();

            _printer.Append("Thick Width:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Width = BarcodeWidth.Thick
            }).NewLine();

            _printer.Append("Thickest Width:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Width = BarcodeWidth.Thickest
            }).NewLine();

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 条形码 高度
        /// </summary>
        [Fact]
        public void Test_Barcode_Height()
        {
            _printer.Append("Short (50 dots)");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Height = 50,
                Width = BarcodeWidth.Default
            }).NewLine();

            _printer.Append("Tall (255 dots)");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Height = 255,
            }).NewLine();

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 条形码 标签位置
        /// </summary>
        [Fact]
        public void Test_Barcode_Label_Position()
        {
            _printer.Append("Label Above:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Height = 50,
                Position = BarcodePositionType.Above
            }).NewLine();

            _printer.Append("Label Above and Below:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Height = 50,
                Position = BarcodePositionType.Both
            }).NewLine();

            _printer.Append("Label Below:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Height = 50,
                Position = BarcodePositionType.Below
            }).NewLine();

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 条形码 标签字体
        /// </summary>
        [Fact]
        public void Test_Barcode_Label_Font()
        {
            _printer.Append("Font A Label Below:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Height = 50,
                Position = BarcodePositionType.Below,
                FontType = BarcodeFontType.A
            }).NewLine();

            _printer.Append("Font B Label Below:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Height = 50,
                Position = BarcodePositionType.Below,
                FontType = BarcodeFontType.B
            }).NewLine();

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        [Fact]
        public void Test_Barcode_Code128()
        {
            _printer.Append("Y20190618000001")
                .Code128("Y20190618000001");

            _printer.Append("Y20190618000002")
                .Code128("Y20190618000002");

            _printer.Append("Y20190618000003")
                .Code128("Y20190618000003");

            _printer.Append("Y20190618000004")
                .Code128("Y20190618000004");

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 切纸-全切纸
        /// </summary>
        [Fact]
        public void Test_Pager_FullCut()
        {
            _printer.Append("Test Pager Full Cut");
            _printer.Full();
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 切纸-部分切纸
        /// </summary>
        [Fact]
        public void Test_Pager_PartialCut()
        {
            _printer.Append("Test Pager Partial Cut");
            _printer.Partial();
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试文本格式-加粗
        /// </summary>
        [Fact]
        public void Test_TxtFormat_Bold()
        {
            _printer.Append(Command.HardwareInit);
            _printer.Bold("加粗格式字体")
                .NewLine();
            _printer.Bold("Test Txt Format Bold")
                .NewLine();
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试文本格式-倾斜
        /// </summary>
        [Fact]
        public void Test_TxtFormat_Italic()
        {
            _printer.Append(Command.HardwareInit);
            _printer.Italic("倾斜格式字体")
                .NewLine();
            _printer.Bold("Test Txt Format Italic")
                .NewLine();
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试文本格式-宽度
        /// </summary>
        [Fact]
        public void Test_TxtFormt_Width()
        {
            _printer.Append(Command.HardwareInit);
            _printer.Append(new byte[] { 0x1D, 0x21, 16,16 });
            _printer
                //.NormalWidth()
                .Append("普通宽度中文")
                .Append("Normal Width Word");

            _printer.Append(new byte[] { 0x1D, 0x21, 32,32 });
            _printer
                //.DoubleWidth2()
                .Append("双倍宽度中文")
                .Append("Double Width Word");

            _printer.Append(new byte[] { 0x1D, 0x21, 48,48 });
            _printer
                //.DoubleWidth3()
                .Append("三倍宽度中文")
                .Append("Three Width Word");

            _printer.Append(new byte[] { 0x1D, 0x21, 32,32 });
            _printer
                //.DoubleWidth2()
                .Append("双倍宽度中文 1")
                .Append("Double Width Word 1");

            _printer.Append(new byte[] { 0x1D, 0x21, 16,16 });
            _printer
                //.NormalWidth()
                .Append("普通宽度中文 1")
                .Append("Normal Width Word 1");

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }


        [Fact]
        public void Test_Demo()
        {
            _printer.Append(Command.HardwareInit);

            _printer.Left();
            _printer.Append(Command.TxtNormal);
            _printer.Append("正常格式文本");

            _printer.Append(Command.Txt2Height);
            _printer.Append("双倍高度格式文本");

            _printer.Append(Command.Txt2Width);
            _printer.Append("双倍宽度格式文本");

            _printer.Append(Command.Txt4Quare);
            _printer.Append("四区域格式文本");

            _printer.Append(Command.TxtUnderlineOn);
            _printer.Append("下划线格式文本");
            _printer.Append(Command.TxtUnderlineOff);

            _printer
                .Underline("下划线文本测试")
                .NewLine();

            _printer
                .Underline("test under line")
                .NewLine();

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }
    }
}
