using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Bing.Printer.Enums;
using Bing.Printer.EscPos;
using Bing.Printer.Extensions;
using Bing.Printer.Options;
using Xunit;
using Xunit.Abstractions;

namespace Bing.Printer.Tests
{
    public class EscPosPrinterTest : TestBase
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
        /// 测试 简单例子
        /// </summary>
        [Fact]
        public void Test_Simple()
        {
            _printer
                //.Write(new byte[]{0x1B,0x61,0x01})
                //.Write(Command.StyleCenterAlign)
                .Center()
                .WriteLine("居中字符串")
                //.Write(new byte[] { 0x1B, 0x61, 0x00 })
                //.Write(Command.StyleLeftAlign)
                .Left()
                .WriteLine("左对齐字符串")
                //.Write(new byte[] { 0x1B, 0x61, 0x02 })
                //.Write(Command.StyleRightAlign)
                .Right()
                .WriteLine("右对齐字符串")
                .Full();
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 快递单号
        /// </summary>
        [Fact]
        public void Test_DeliveryOrder()
        {
            _printer.Write(new byte[] {0x1B, 0x40});
            _printer.Center()
                .Code128("Y20190618000001")
                .NewLine()
                .WriteLine("Y20190618000001");

            _printer.Left();
            _printer.Write("订单号  \t")
                .WriteLine("Y20190618000001");

            _printer.Write("配送中心\t")
                .WriteLine("天河高志体验店");

            _printer.Write("配送时段\t")
                .WriteLine("2019-06-18 14:00-14:30");

            _printer.Write("收货人  \t")
                .WriteLine($"隔壁老王(18588777777)");

            _printer.WriteLine("收货地址")
                .WriteLine("广州市天河区黄埔大道西120号高志大厦B1层")
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
            _printer.Write(new byte[] {0x1B, 0x40});
            _printer.Center();
            _printer.WriteLine("Thinnest Width:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Width = BarcodeWidth.Thinnest
            }).NewLine();

            _printer.WriteLine("Thin Width:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Width = BarcodeWidth.Thin
            }).NewLine();

            _printer.WriteLine("Default Width:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Width = BarcodeWidth.Default
            }).NewLine();

            _printer.WriteLine("Thick Width:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Width = BarcodeWidth.Thick
            }).NewLine();

            _printer.WriteLine("Thickest Width:");
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
            _printer.WriteLine("Short (50 dots)");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Height = 50,
                Width = BarcodeWidth.Default
            }).NewLine();

            _printer.WriteLine("Tall (255 dots)");
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
            _printer.WriteLine("Label Above:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Height = 50,
                Position = BarcodePositionType.Above
            }).NewLine();

            _printer.WriteLine("Label Below:");
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
            _printer.WriteLine("Font A Label Below:");
            _printer.Barcode("Y20190618000001", new BarcodeOptions()
            {
                Type = BarcodeType.Code128,
                Height = 50,
                Position = BarcodePositionType.Below,
                FontType = BarcodeFontType.A
            }).NewLine();

            _printer.WriteLine("Font B Label Below:");
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
            _printer.WriteLine("Y20190618000001")
                .Code128("Y20190618000001");

            _printer.WriteLine("Y20190618000002")
                .Code128("Y20190618000002");

            _printer.WriteLine("Y20190618000003")
                .Code128("Y20190618000003");

            _printer.WriteLine("Y20190618000004")
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
            _printer.WriteLine("Test Pager Full Cut");
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
            _printer.WriteLine("Test Pager Partial Cut");
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
            _printer.Write(Command.HardwareInit);
            _printer.WriteLine("准备加粗字体测试1");
            _printer.WriteLine("Ready Test Txt Format Bold");

            _printer.Write(Command.TxtBoldOn);
            _printer.WriteLine("加粗字体测试2");
            _printer.WriteLine("Test Txt Format Bold");

            _printer.Write(Command.TxtBoldOff);
            _printer.WriteLine("取消加粗字体测试3");
            _printer.WriteLine("Cancel Test Txt Format Bold");

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试文本格式-下划线
        /// </summary>
        [Fact]
        public void Test_TxtFormat_Underline()
        {
            _printer.Initialize();
            _printer.WriteLine("测试下划线字符串");
            _printer.WriteLine("Test Txt Format Underline");

            _printer.Write(Command.Chinese.Underline2On);
            _printer.Write(Command.ASCII.Underline2On);
            _printer.WriteLine("测试下划线字符串");
            _printer.WriteLine("Test Txt Format Underline");

            _printer.Write(Command.Chinese.UnderlineOff);
            _printer.Write(Command.ASCII.UnderlineOff);
            _printer.WriteLine("测试下划线字符串");
            _printer.WriteLine("Test Txt Format Underline");

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试文本格式-双倍宽度
        /// </summary>
        [Fact]
        public void Test_TxtFormat_DoubleWidth()
        {
            _printer.Initialize();
            _printer.WriteLine("Test Double Width");
            _printer.WriteLine("正常文本大小");
            _printer.Write(new byte[] {0x1C, 0x21, 0x04});
            _printer.Write(new byte[] {0x1B, 0x21, 0x20});
            _printer.WriteLine("Test Double Width");
            _printer.WriteLine("选择倍宽文本大小");
            _printer.Write(new byte[] {0x1C, 0x21, 0x00});
            _printer.Write(new byte[] {0x1B, 0x21, 0x00});
            _printer.WriteLine("Test Double Width");
            _printer.WriteLine("取消倍宽文本大小");

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试文本格式-旋转
        /// </summary>
        [Fact]
        public void Test_TxtFormat_Rotate()
        {
            _printer.Initialize();
            _printer.WriteLine("正常文本");
            _printer.Write(Command.TxtRotate90On);
            _printer.WriteLine("旋转90度文本");
            _printer.Write(Command.TxtRotate180On);
            _printer.WriteLine("旋转180度文本");
            _printer.Write(Command.TxtRotate270On);
            _printer.WriteLine("旋转270度文本");
            _printer.Write(Command.TxtRotateOff);
            _printer.WriteLine("取消旋转文本");

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试文本格式-双重打印
        /// </summary>
        [Fact]
        public void Test_TxtFormat_DoublePrint()
        {
            _printer.Initialize();
            _printer.WriteLine("正常文本");
            _printer.Write(new byte[] {0x1B, 0x47, 0x01});
            _printer.WriteLine("双重打印文本");
            _printer.Write(new byte[] {0x1B, 0x47, 0x00});
            _printer.WriteLine("取消双重打印文本");

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }


        /// <summary>
        /// 测试文本格式-宽度
        /// </summary>
        [Fact]
        public void Test_TxtFormt_Width()
        {
            _printer.Write(Command.HardwareInit);
            _printer.Write(new byte[] {0x1D, 0x21, 16, 16});
            _printer
                //.NormalWidth()
                .WriteLine("普通宽度中文")
                .WriteLine("Normal Width Word");

            _printer.Write(new byte[] {0x1D, 0x21, 32, 32});
            _printer
                //.DoubleWidth2()
                .WriteLine("双倍宽度中文")
                .WriteLine("Double Width Word");

            _printer.Write(new byte[] {0x1D, 0x21, 48, 48});
            _printer
                //.DoubleWidth3()
                .WriteLine("三倍宽度中文")
                .WriteLine("Three Width Word");

            _printer.Write(new byte[] {0x1D, 0x21, 32, 32});
            _printer
                //.DoubleWidth2()
                .WriteLine("双倍宽度中文 1")
                .WriteLine("Double Width Word 1");

            _printer.Write(new byte[] {0x1D, 0x21, 16, 16});
            _printer
                //.NormalWidth()
                .WriteLine("普通宽度中文 1")
                .WriteLine("Normal Width Word 1");

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试文本格式-大小
        /// </summary>
        [Fact]
        public void Test_TxtFormat_Size()
        {
            _printer.WriteLine("普通文本")
                .WriteLine("Normal Size Text")
                .NewLine();

            _printer.FontSize(FontSize.Size0)
                .WriteLine("0 级文本")
                .WriteLine("0 Level Size Text")
                .NewLine();

            _printer.FontSize(FontSize.Size1)
                .WriteLine("1 级文本")
                .WriteLine("1 Level Size Text")
                .NewLine();

            _printer.FontSize(FontSize.Size2)
                .WriteLine("2 级文本")
                .WriteLine("2 Level Size Text")
                .NewLine();

            _printer.FontSize(FontSize.Size3)
                .WriteLine("3 级文本")
                .WriteLine("3 Level Size Text")
                .NewLine();

            _printer.FontSize(FontSize.Size4)
                .WriteLine("4 级文本")
                .WriteLine("4 Level Size Text")
                .NewLine();

            _printer.FontSize(FontSize.Size5)
                .WriteLine("5 级文本")
                .WriteLine("5 Level Size Text")
                .NewLine();

            _printer.FontSize(FontSize.Size6)
                .WriteLine("6 级文本")
                .WriteLine("6 Level Size Text")
                .NewLine();

            _printer.FontSize(FontSize.Size7)
                .WriteLine("7 级文本")
                .WriteLine("7 Level Size Text")
                .NewLine();

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试文本格式-大小
        /// </summary>
        [Fact]
        public void Test_TxtFormat_Size_1()
        {
            _printer.Initialize();
            for (int i = 0; i <= 255; i++)
            {
                _printer.Write(new byte[] {0x1D, 0x21, (byte) i});
                _printer.WriteLine($"{i} 级字体");
            }

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试-打印1
        /// </summary>
        [Fact]
        public void Test_Print_1()
        {
            // 打印机复位
            _printer.Initialize();
            _printer.NewLine();
            _printer.WriteLine("012345678901234567890123456789012");
            _printer.WriteLine("	       交通违章罚款决定书");
            _printer.WriteLine("            NO.10012001091023009");
            _printer.WriteLine("姓名:林秀芳 ____________________");
            _printer.WriteLine("身份证:21021119580822291X ______");
            _printer.WriteLine("年龄:39 ________________________");
            _printer.WriteLine("地址:大连市玉山一街68-1-25号____");
            _printer.WriteLine("车型:普通大客车  车号:辽B.11045");
            _printer.WriteLine("违章时间:2001年11月22日09时24分");
            _printer.WriteLine("处罚地点:辽宁省大连市沙河口玉山");
            _printer.WriteLine("         街路口");
            _printer.WriteLine("违章事实:酒后驾车无证驾驶闯红灯");
            _printer.WriteLine("         骂人打架");
            _printer.WriteLine("根据《中华人民共和国道路交通管理");
            _printer.WriteLine("条例》12条23款，《中华人民共和国");
            _printer.WriteLine("高速公路管理办法》32条34款，");
            _printer.WriteLine("《辽宁省道路交通管理实施办法》45");
            _printer.WriteLine("条44款之规定。决定给予罚款1500元");
            _printer.WriteLine("的处罚。");
            _printer.WriteLine("    如你（单位）不服本处罚决定，");
            _printer.WriteLine("可在收到决定书之日起二个月内向上");
            _printer.WriteLine("一级公安交通管理机关申请复议或依");
            _printer.WriteLine("法向人民法院起诉。");
            _printer.WriteLine("                值勤民警：郭泗东");
            _printer.WriteLine("                2001年11月22日");
            _printer.WriteLine("                当事人：________");
            _printer.NewLine(4);

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试-打印2
        /// </summary>
        [Fact]
        public void Test_Print_2()
        {
            _printer.Write(new byte[] {0x1B, 0x40}); // 打印机复位
            _printer.NewLine();
            _printer.WriteLine("原始打印例子");
            _printer.Write(new byte[] {0x1B, 0x61, 0x01}); // 居中
            _printer.WriteLine("*****华丽的分割线*****");
            _printer.Write(new byte[] {0x1B, 0x61, 0x00}); // 左对齐
            _printer.WriteLine("测试开始");

            _printer.WriteLine("(1、标题，居中，3倍大小，下划线，粗体)");
            _printer.Write(new byte[] {0x1B, 0x61, 0x01}); // 居中
            _printer.Write(new byte[] {0x1D, 0x21, 0x22}); // 3倍字体大小
            _printer.Write(new byte[] {0x1B, 0x45, 0x01}); // 粗体
            _printer.Write(new byte[] {0x1B, 0x2D, 0x32}); // 2点粗下划线
            _printer.WriteLine("标题");

            _printer.Write(new byte[] {0x1B, 0x61, 0x00}); // 左对齐
            _printer.Write(new byte[] {0x1B, 0x21, 0x00}); // 还原默认字体，取消下划线，取消粗体模式
            _printer.Write(new byte[] {0x1D, 0x21, 0x00}); // 还原默认字体，取消下划线，取消粗体模式
            _printer.WriteLine("(2、条码：左对齐）");
            _printer.Write(new byte[]
                {
                    0x1D, 0x6B, 0x45, 0x0D, 0x31, 0x39, 0x41, 0x54, 0x5A, 0x2D, 0x2E, 0x20, 0x24, 0x2F, 0x2B, 0x25, 0x44
                })
                .NewLine(); // code39 条码：19ATZ-. $/+%D

            _printer.WriteLine("（3、正文1，默认打印模式，绝对打印位置5mm）");
            _printer.Write(new byte[] {0x1B, 0x24, 0x28, (byte) 0x80}); // 设置绝对位置5mm,80代表00
            _printer.WriteLine(
                "1、0123456789-ABCD-9876543210芝柯无敌。2、0123456789-ABCD-9876543210芝柯无敌。3、0123456789-ABCD-9876543210芝柯无敌。");

            _printer.WriteLine("（4、继续条码，居中）");
            _printer.Write(new byte[] {0x1B, 0x61, 0x01}); // 居中
            _printer.Write(new byte[]
                {
                    0x1D, 0x6B, 0x45, 0x0D, 0x31, 0x39, 0x41, 0x54, 0x5A, 0x2D, 0x2E, 0x20, 0x24, 0x2F, 0x2B, 0x25, 0x44
                })
                .NewLine(); // code39 条码：19ATZ-. $/+%D

            _printer.Write(new byte[] {0x1B, 0x61, 0x00}); // 左对齐
            _printer.WriteLine("（5、左对齐 0x3F点行间距）");
            _printer.Write(new byte[] {0x1B, 0x33, 0x1E}); // 设置行间距为：3.75mm
            _printer.WriteLine("以下是校长高震东在国内的讲演：");

            _printer.Write(new byte[] {0x1B, 0x32}); // 设置默认行间距：1mm
            _printer.WriteLine("（6、默认行间距）");
            _printer.Write(new byte[] {0x1B, 0x24, 0x28, (byte) 0x80}); // 设置绝对位置5mm,80代表00
            _printer.WriteLine(
                "1、0123456789-ABCD-9876543210芝柯无敌。2、0123456789-ABCD-9876543210芝柯无敌。3、0123456789-ABCD-9876543210芝柯无敌。");

            _printer.WriteLine("（7 、条码）");
            _printer.Write(new byte[]
                {0x1D, 0x6B, 0x02, 0x30, 0x31, 0x37, 0x31, 0x32, 0x33, 0x034, 0x35, 0x00}); // EAN8：01712345
            _printer.NewLine();

            _printer.WriteLine("（8、0行间距）");
            _printer.Write(new byte[] {0x1B, 0x33, 0x00}); // 设置行间距为：0mm
            _printer.Write(new byte[] {0x1B, 0x24, 0x28, (byte) 0x80}); // 设置绝对位置5mm,80代表00
            _printer.WriteLine(
                "1、0123456789-ABCD-9876543210芝柯无敌。2、0123456789-ABCD-9876543210芝柯无敌。3、0123456789-ABCD-9876543210芝柯无敌。");

            _printer.WriteLine("（9 、条码）");
            _printer.Write(new byte[]
            {
                0x1D, 0x6B, 0x03, 0x30, 0x31, 0x37, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x35, 0x00
            }); // EAN13：0171234567895
            _printer.NewLine();

            _printer.WriteLine("（10、3个预存储图章）");
            _printer.Write(new byte[] {0x1C, 0x50, 0x01}); // 打印编号为01的预存储图片
            _printer.Write(new byte[] {0x1C, 0x50, 0x02}); // 打印编号为01的预存储图片
            _printer.Write(new byte[] {0x1C, 0x50, 0x03}); // 打印编号为01的预存储图片
            _printer.NewLine();

            _printer.WriteLine("（11、16点阵字符）");
            _printer.Write(new byte[] {0x1B, 0x40}); // 打印机复位
            _printer.Write(new byte[] {0x1B, 0x4D, 0x01}); // 选择16点阵字体
            _printer.WriteLine(
                "1、0123456789-ABCD-9876543210芝柯无敌。2、0123456789-ABCD-9876543210芝柯无敌。3、0123456789-ABCD-9876543210芝柯无敌。");

            _printer.Write(new byte[] {0x1B, 0x4D, 0x00}); // 选择24点阵字体
            _printer.WriteLine("（12、还原默认字符大小，二维条码PDF417）");
            _printer.Write(new byte[] {0x1D, 0x77, 0x04}); // 条码宽度4倍
            _printer.Write(new byte[] {0x1D, 0x5A, 0x00}); // 选择PDF417条码
            _printer.Write(new byte[]
            {
                0x1B, 0x5A, 0x02, 0x02, 0x03, 0x39, 0x00, (byte) 0xC9, (byte) 0xCF, (byte) 0xBA, (byte) 0xA3,
                (byte) 0xD6, (byte) 0xA5,
                (byte) 0xBF, (byte) 0xC2, (byte) 0xB4, (byte) 0xF2, (byte) 0xD3, (byte) 0xA1, (byte) 0xBC, (byte) 0xBC,
                (byte) 0xCA,
                (byte) 0xF5, (byte) 0xD3, (byte) 0xD0, (byte) 0xCF, (byte) 0xDE, (byte) 0xB9, (byte) 0xAB, (byte) 0xCB,
                (byte) 0xBE,
                0x20, 0x20, (byte) 0xB5, (byte) 0xD8, (byte) 0xD6, (byte) 0xB7, (byte) 0xA3, (byte) 0xBA, (byte) 0xC9,
                (byte) 0xCF,
                (byte) 0xBA, (byte) 0xA3, (byte) 0xC6, (byte) 0xD6, (byte) 0xB6, (byte) 0xAB, (byte) 0xD0, (byte) 0xE3,
                (byte) 0xC6,
                (byte) 0xCC, (byte) 0xC2, (byte) 0xB7, 0x33, 0x39, 0x39, 0x39, (byte) 0xBA, (byte) 0xC5, 0x36,
                (byte) 0xBA, (byte) 0xC5,
                (byte) 0xC2, (byte) 0xA5
            }); // 打印PDF417条码
            _printer.NewLine();

            _printer.WriteLine("（13、反白打印）");
            _printer.Write(new byte[] {0x1B, 0x40}); // 打印机复位
            _printer.Write(new byte[] {0x1D, 0x42, 0x01}); // 选择反白打印模式
            _printer.WriteLine("1、0123456789-ABCD-9876543210芝柯无敌。");

            _printer.Write(new byte[] {0x1B, 0x40}); // 打印机复位
            _printer.Write(new byte[] {0x1D, 0x42, 0x00}); // 取消反白打印模式
            _printer.WriteLine("(14、条码.10点高度条码)");
            _printer.Write(new byte[] {0x1D, 0x68, 0x0A}); // 设置条码打印高度为10点：1.25mm
            _printer.Write(new byte[]
                {0x1D, 0x6B, 0x04, 0x2A, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x2A, 0x00}); // 打印code39码：*123456*
            _printer.NewLine();

            _printer.WriteLine("（16、条码，18点高度条码）");
            _printer.Write(new byte[] {0x1D, 0x68, 0x12}); // 设置条码打印高度为18点：2.25mm
            _printer.Write(new byte[]
                {0x1D, 0x6B, 0x04, 0x2A, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x2A, 0x00}); // 打印code39码：*123456*
            _printer.NewLine();

            _printer.WriteLine("（17、8个水平制表位）");
            _printer.Write(new byte[]
            {
                0x1B, 0x44, 0x04, 0x09, 0x0F, 0x14, 0x19, 0x1F, 0x24, 0x29, 0x2F, 0x34, 0x39, 0x3F, (byte) 0xff
            }); // 设置12点水平制表位，因为最大为8，所以后面4个无效
            _printer.Write(new byte[] {0x09}); // 第1个制表位打印
            _printer.Write("第一");
            _printer.Write(new byte[] {0x09}); // 第2个制表位打印
            _printer.Write("第二");
            _printer.Write(new byte[] {0x09}); // 第3个制表位打印
            _printer.Write("第三");
            _printer.Write(new byte[] {0x09}); // 第4个制表位打印
            _printer.Write("第四");
            _printer.Write(new byte[] {0x09}); // 第5个制表位打印
            _printer.Write("第五");
            _printer.Write(new byte[] {0x09}); // 第6个制表位打印
            _printer.Write("第六");
            _printer.Write(new byte[] {0x09}); // 第7个制表位打印
            _printer.Write("第七");
            _printer.Write(new byte[] {0x09}); // 第8个制表位打印
            _printer.Write("第八");
            _printer.Write(new byte[] {0x09}); // 第9个制表位打印
            _printer.Write("第九个应该没有");
            _printer.NewLine();

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试-打印3
        /// </summary>
        [Fact]
        public void Test_Print_3()
        {
            _printer.Write(new byte[] {0x1B, 0x40}); // 打印机复位
            _printer.NewLine();
            _printer.WriteLine("原始打印例子");
            _printer.WriteLine("（18、条码）");
            _printer.Write(new byte[]
                {0x1D, 0x6B, 0x01, 0x30, 0x31, 0x39, 0x37, 0x37, 0x31, 0x31, 0x30, 0x00}); // 打印UPC-E码：01977110
            _printer.NewLine();

            _printer.WriteLine("（19、0X30点的字符间距）");
            _printer.Write(new byte[] {0x1B, 0x20, 0x30}); // 设置字符间距0x30个点
            _printer.WriteLine("1、0123456789-ABCD-9876543210芝柯无敌。");

            _printer.Write(new byte[] {0x1B, 0x20, 0x00}); // 设置字符间距0x00个点
            _printer.WriteLine("（20、粗体，下划线，2倍大小）");
            _printer.Write(new byte[] {0x1b, 0x21, (byte) 0xfe}); // 设置字体为粗体，下划线，2倍大小的24点阵
            _printer.WriteLine("1、0123456789-ABCD-9876543210芝柯无敌。");

            _printer.Write(new byte[] {0x1B, 0x40}); // 打印机复位
            _printer.WriteLine("（21、条码）");
            _printer.Write(new byte[]
                {0x1D, 0x6B, 0x01, 0x30, 0x31, 0x39, 0x37, 0x37, 0x31, 0x31, 0x30, 0x00}); // 打印UPC-E码：01977110
            _printer.NewLine();

            _printer.WriteLine("（22、左边距0x2F）");
            _printer.Write(new byte[] {0x1D, 0x4C, 0x2F, 0x00}); // 设置左边距0x2F
            _printer.WriteLine(
                "1、0123456789-ABCD-9876543210芝柯无敌。2、0123456789-ABCD-9876543210芝柯无敌。3、0123456789-ABCD-9876543210芝柯无敌。4、0123456789-ABCD-9876543210芝柯无敌。");

            _printer.WriteLine("（23、竖直条码）");

            _printer.WriteLine("(24、条码) ");
            _printer.Write(new byte[]
                {0x1D, 0x6B, 0x01, 0x30, 0x31, 0x39, 0x37, 0x37, 0x31, 0x31, 0x30, 0x00}); // 打印UPC-E码：01977110
            _printer.NewLine();

            _printer.WriteLine("(25、旋转90度) ");
            _printer.Write(new byte[] {0x1B, 0x40}); // 打印机复位
            _printer.Write(new byte[] {0x1B, 0x56, 0x01}); // 设置顺时针旋转90度
            _printer.WriteLine("1、0123456789-ABCD-9876543210芝柯无敌。 ");

            _printer.Write(new byte[] {0x1B, 0x56, 0x00}); // 设置为不旋转
            _printer.WriteLine("(26、条码) ");
            _printer.Write(new byte[]
                {0x1D, 0x6B, 0x01, 0x30, 0x31, 0x39, 0x37, 0x37, 0x31, 0x31, 0x30, 0x00}); // 打印UPC-E码：01977110
            _printer.NewLine();

            _printer.WriteLine("(27、旋转180度)");
            _printer.Write(new byte[] {0x1B, 0x56, 0x02}); // 设置顺时针旋转180度
            _printer.WriteLine("1、0123456789-ABCD-9876543210芝柯无敌。 ");

            _printer.Write(new byte[] {0x1B, 0x56, 0x00}); // 设置为不旋转
            _printer.WriteLine("(28、二维条码DataMatrix)");
            _printer.Write(new byte[] {0x1D, 0x77, 0x04}); // 条码宽度4倍
            _printer.Write(new byte[] {0x1D, 0x5A, 0x01}); // 选择DataMatrix条码
            _printer.Write(new byte[]
            {
                0x1B, 0x5A, 0x00, 0x00, 0x00, 0x39, 0x00, (byte) 0xC9, (byte) 0xCF, (byte) 0xBA, (byte) 0xA3,
                (byte) 0xD6, (byte) 0xA5, (byte) 0xBF, (byte) 0xC2, (byte) 0xB4, (byte) 0xF2, (byte) 0xD3,
                (byte) 0xA1, (byte) 0xBC, (byte) 0xBC, (byte) 0xCA, (byte) 0xF5, (byte) 0xD3, (byte) 0xD0,
                (byte) 0xCF, (byte) 0xDE, (byte) 0xB9, (byte) 0xAB, (byte) 0xCB, (byte) 0xBE, 0x20, 0x20,
                (byte) 0xB5, (byte) 0xD8, (byte) 0xD6, (byte) 0xB7, (byte) 0xA3, (byte) 0xBA, (byte) 0xC9,
                (byte) 0xCF, (byte) 0xBA, (byte) 0xA3, (byte) 0xC6, (byte) 0xD6, (byte) 0xB6, (byte) 0xAB,
                (byte) 0xD0, (byte) 0xE3, (byte) 0xC6, (byte) 0xCC, (byte) 0xC2, (byte) 0xB7, 0x33, 0x39,
                0x39, 0x39, (byte) 0xBA, (byte) 0xC5, 0x36, (byte) 0xBA, (byte) 0xC5, (byte) 0xC2, (byte) 0xA5
            }); // 打印DataMatrix条码
            _printer.NewLine();

            _printer.WriteLine("(29、旋转270度)");
            _printer.Write(new byte[] {0x1B, 0x56, 0x03}); // 设置顺时针旋转270度
            _printer.WriteLine("1、0123456789-ABCD-9876543210芝柯无敌。 ");

            _printer.Write(new byte[] {0x1B, 0x56, 0x00}); // 设置为不旋转
            _printer.WriteLine("(30、二维条码QR-CODE 曲线，曲线上打印文字)");
            _printer.Write(new byte[] {0x1D, 0x77, 0x04}); // 条码宽度4倍
            _printer.Write(new byte[] {0x1D, 0x5A, 0x02}); // 选择QR-CODE条码
            _printer.Write(new byte[]
            {
                0x1B, 0x5A, 0x00, 0x01, 0x00, 0x39, 0x00, (byte) 0xC9, (byte) 0xCF, (byte) 0xBA, (byte) 0xA3,
                (byte) 0xD6, (byte) 0xA5, (byte) 0xBF, (byte) 0xC2, (byte) 0xB4, (byte) 0xF2, (byte) 0xD3,
                (byte) 0xA1, (byte) 0xBC, (byte) 0xBC, (byte) 0xCA, (byte) 0xF5, (byte) 0xD3, (byte) 0xD0,
                (byte) 0xCF, (byte) 0xDE, (byte) 0xB9, (byte) 0xAB, (byte) 0xCB, (byte) 0xBE, 0x20, 0x20,
                (byte) 0xB5, (byte) 0xD8, (byte) 0xD6, (byte) 0xB7, (byte) 0xA3, (byte) 0xBA, (byte) 0xC9,
                (byte) 0xCF, (byte) 0xBA, (byte) 0xA3, (byte) 0xC6, (byte) 0xD6, (byte) 0xB6, (byte) 0xAB,
                (byte) 0xD0, (byte) 0xE3, (byte) 0xC6, (byte) 0xCC, (byte) 0xC2, (byte) 0xB7, 0x33, 0x39,
                0x39, 0x39, (byte) 0xBA, (byte) 0xC5, 0x36, (byte) 0xBA, (byte) 0xC5, (byte) 0xC2, (byte) 0xA5
            }); // 打印DataMatrix条码
            _printer.NewLine();

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试-打印4
        /// </summary>
        [Fact]
        public void Test_Print_4()
        {
            _printer.Write(new byte[] {0x1B, 0x40}); // 打印机复位
            _printer.NewLine();
            _printer.WriteLine("原始打印例子");

            _printer.Write(new byte[] {0x1D, 0x27, 0x01, 0x1A, 0x00, 0x3F, 0x02}); //打印第1行线段
            _printer.Write(new byte[] {0x1D, 0x22, 0x00, 0x00, 0x00, (byte) 0xCE, (byte) 0xD2, 0x00}); //2行线段上打印第1个字符
            _printer.Write(new byte[] {0x1D, 0x22, 0x01, 0x27, 0x02, (byte) 0xB5, (byte) 0xC4, 0x00}); //2行线段上打印第2个字符
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x1B, 0x00, 0x1C, 0x00}); //打印第2行2节线段		
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x1E, 0x00, 0x1F, 0x00}); //打印第3行2节线段
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x20, 0x00, 0x21, 0x00}); //打印第4行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x22, 0x00, 0x23, 0x00}); //打印第5行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x24, 0x00, 0x25, 0x00}); //打印第6行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x26, 0x00, 0x27, 0x00}); //打印第7行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x28, 0x00, 0x29, 0x00}); //打印第8行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x2A, 0x00, 0x2B, 0x00}); //打印第9行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x2C, 0x00, 0x2D, 0x00}); //打印第10行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x2E, 0x00, 0x2F, 0x00}); //打印第11行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x30, 0x00, 0x31, 0x00}); //打印第12行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x32, 0x00, 0x33, 0x00}); //打印第13行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x34, 0x00, 0x35, 0x00}); //打印第14行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x36, 0x00, 0x37, 0x00}); //打印第15行2节线段	
            _printer.Write(new byte[]
                {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x38, 0x00, 0x39, 0x00}); //打印第16行2节线段						
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x3A, 0x00, 0x3B, 0x00}); //打印第17行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x3C, 0x00, 0x3D, 0x00}); //打印第18行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x3E, 0x00, 0x3F, 0x00}); //打印第19行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x40, 0x00, 0x41, 0x00}); //打印第20行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x42, 0x00, 0x43, 0x00}); //打印第21行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x44, 0x00, 0x45, 0x00}); //打印第22行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x46, 0x00, 0x47, 0x00}); //打印第23行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x48, 0x00, 0x49, 0x00}); //打印第24行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x4A, 0x00, 0x4B, 0x00}); //打印第25行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x4C, 0x00, 0x4D, 0x00}); //打印第26行2节线段	
            _printer.Write(new byte[] {0x1D, 0x22, 0x00, 0x00, 0x00, 0x41, 0x00}); //27行线段上打印第1个字符
            _printer.Write(new byte[] {0x1D, 0x22, 0x01, 0x4C, 0x00, 0x42, 0x00}); //27行线段上打印第2个字符		
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x4E, 0x00, 0x4F, 0x00}); //打印第27行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x50, 0x00, 0x51, 0x00}); //打印第28行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x52, 0x00, 0x53, 0x00}); //打印第29行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x54, 0x00, 0x55, 0x00}); //打印第30行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x56, 0x00, 0x57, 0x00}); //打印第31行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x58, 0x00, 0x59, 0x00}); //打印第32行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x5A, 0x00, 0x5B, 0x00}); //打印第33行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x5C, 0x00, 0x5D, 0x00}); //打印第34行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x5E, 0x00, 0x5F, 0x00}); //打印第35行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x60, 0x00, 0x61, 0x00}); //打印第36行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x62, 0x00, 0x63, 0x00}); //打印第37行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x64, 0x00, 0x65, 0x00}); //打印第38行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x66, 0x00, 0x67, 0x00}); //打印第39行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x68, 0x00, 0x69, 0x00}); //打印第40行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x6A, 0x00, 0x6B, 0x00}); //打印第41行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x6C, 0x00, 0x6D, 0x00}); //打印第42行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x6E, 0x00, 0x6F, 0x00}); //打印第43行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x70, 0x00, 0x71, 0x00}); //打印第44行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x72, 0x00, 0x73, 0x00}); //打印第45行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x74, 0x00, 0x75, 0x00}); //打印第46行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x76, 0x00, 0x77, 0x00}); //打印第47行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x78, 0x00, 0x79, 0x00}); //打印第48行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x7A, 0x00, 0x7B, 0x00}); //打印第49行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x7C, 0x00, 0x7D, 0x00}); //打印第50行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x02, 0x1A, 0x00, 0x1A, 0x00, 0x7E, 0x00, 0x7F, 0x00}); //打印第51行2节线段	
            _printer.Write(new byte[] {0x1D, 0x27, 0x01, 0x1A, 0x00, 0x3F, 0x02});
            _printer.NewLine(2);

            _printer.Write(new byte[] {0x1B, 0x40}); // 打印机复位
            _printer.Write(new byte[] {0x1B, 0x61, 0x01}); // 居中
            _printer.WriteLine("===================================== ");
            _printer.NewLine(2);
            _printer.WriteLine("******** 测试结束 ******** ");
            _printer.NewLine(2);

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试-打印5
        /// </summary>
        [Fact]
        public void Test_Print_5()
        {
            _printer.Write(new byte[] {0x1B, 0x40}); // 打印机复位
            _printer.NewLine();
            _printer.WriteLine("原始打印例子");
            _printer.Write(new byte[] {0x1B, 0x40}); //打印机复位
            _printer.Write(new byte[] {0x1B, 0x33, 0x00}); //设置行间距为0
            _printer.NewLine();
            _printer.Write(new byte[] {0x1B, 0x61, 0x00}); //设置不居中
            _printer.Write(new byte[] {0x1d, 0x21, 0x01}); //设置倍高
            _printer.WriteLine("    苏驰物流");
            _printer.Write(new byte[] {0x1d, 0x48, 0x02}); //设置条码内容打印在条码下方
            _printer.Write(new byte[] {0x1d, 0x77, 0x03}); //设置条码宽度0.375
            _printer.Write(new byte[] {0x1d, 0x68, 0x40}); //设置条码高度64
            //打印code128条码
            _printer.Write(new byte[] {0x1D, 0x6B, 0x18});
            _printer.WriteLine("1234567890\0");
            _printer.NewLine();
            _printer.Write(new byte[] {0x1d, 0x21, 0x00}); //设置不倍高
            _printer.WriteLine("┏━━┳━━━━━━━┳━━┳━━━━━━━━┓");
            _printer.Write(new byte[] {0x1d, 0x21, 0x01}); //设置倍高
            _printer.WriteLine("┃发站┃杭州┃到站┃宝应┃");
            _printer.Write(new byte[] {0x1d, 0x21, 0x00}); //设置不倍高
            _printer.WriteLine("┣━━╋━━━━━━━╋━━╋━━━━━━━━┫");
            _printer.Write(new byte[] {0x1d, 0x21, 0x01}); //设置倍高
            _printer.WriteLine("┃件数┃1/222┃单号┃55555555┃");
            _printer.Write(new byte[] {0x1d, 0x21, 0x00}); //设置不倍高
            _printer.WriteLine("┣━━┻┳━━━━━━┻━━┻━━━━━━━━┫");
            _printer.Write(new byte[] {0x1d, 0x21, 0x01}); //设置倍高
            _printer.WriteLine("┃收件人┃【送】孙俊/宁新富┃");
            _printer.Write(new byte[] {0x1d, 0x21, 0x00}); //设置不倍高
            _printer.WriteLine("┣━━━╋━━━━━━┳━━┳━━━━━━━━┫");
            _printer.Write(new byte[] {0x1d, 0x21, 0x01}); //设置倍高
            _printer.WriteLine("┃业务员┃测试┃名称┃杭州┃");
            _printer.Write(new byte[] {0x1d, 0x21, 0x00}); //设置不倍高
            _printer.WriteLine("┗━━━┻━━━━━━┻━━┻━━━━━━━━┛");

            _printer.Write(new byte[] {0x1b, 0x61, 0x01}); //设置居中
            _printer.Write(new byte[] {0x1d, 0x21, 0x01}); //设置倍高
            _printer.WriteLine("日期：2011-05-16");

            _printer.NewLine(5);

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试字体格式-位置
        /// </summary>
        [Fact]
        public void Test_TxtFormat_Position()
        {
            _printer.Initialize();
            _printer.NewLine();
            _printer.WriteLine("封装组件打印例子");
            // 居中
            _printer.Center();
            _printer.WriteLine("*****华丽的分割线*****");
            // 左对齐
            _printer.Left();
            _printer.WriteLine("测试开始");
            _printer.WriteLine("(1、标题，居中，3倍大小，下划线，粗体)");
        }

        /// <summary>
        /// 测试字体格式-黑白反显打印模式
        /// </summary>
        [Fact]
        public void Test_TxtFormat_BlackWhiteReverse()
        {
            _printer.Initialize();
            _printer.NewLine();
            _printer.WriteLine("准备测试黑白反显打印模式");
            _printer.WriteLine("Ready Test Black White Reverse");

            _printer.Write(Command.TxtBlackWhiteReverseOn);
            _printer.WriteLine("测试黑白反显打印模式");
            _printer.WriteLine("Test Black White Reverse");

            _printer.Write(Command.TxtBlackWhiteReverseOff);
            _printer.WriteLine("取消测试黑白反显打印模式");
            _printer.WriteLine("Cancel Test Black White Reverse");

            _printer.NewLine(2);

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试打印样式-左边距
        /// </summary>
        [Fact]
        public void Test_PrintStyle_MarginLeft()
        {
            _printer.Initialize();
            _printer.NewLine();
            _printer.WriteLine("正常字体位置");
            _printer.WriteLine("Margin Left Font Position");
            var oldLeft = 10;
            var oldnH = oldLeft >> 8;
            var oldnL = oldLeft - (oldnH << 8);

            int left = 30;
            var nH = left >> 8;
            var nL = left - (nH << 8);

            _printer.Write(new byte[] {0x1D, 0x4C, nL.ToByte(), nH.ToByte()});
            _printer.WriteLine("设置 30 左边距的字体位置");
            _printer.WriteLine("Set 30 Margin Left Font Position");

            _printer.Write(new byte[] {0x1D, 0x4C, oldnL.ToByte(), oldnH.ToByte()});
            _printer.WriteLine("恢复 左边距的字体位置");
            _printer.WriteLine("Return Margin Left Font Position");

            _printer.Write(new byte[] {0x1D, 0x4C, nL.ToByte(), nH.ToByte()});
            _printer.WriteLine("设置 30 nL 10 nH 左边距的字体位置");
            _printer.WriteLine("Set 30 nL 10 nH Margin Left Font Position");

            _printer.Write(new byte[] {0x1D, 0x4C, oldnL.ToByte(), oldnH.ToByte()});
            _printer.WriteLine("恢复 左边距的字体位置");
            _printer.WriteLine("Return Margin Left Font Position");

            _printer.NewLine(2);

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试打印-列模式
        /// </summary>
        [Fact]
        public void Test_Print_Columns_3()
        {
            _printer.Initialize();
            _printer.NewLine();

            _printer.Left()
                .Write("货号/品号/数量")
                .Right()
                .WriteLine("金额");

            _printer.Left()
                .WriteLine("412117");

            _printer.Left()
                .WriteLine("鲜甜豆浆500ml/瓶");

            _printer.Left()
                .Write("x 1")
                .Right()
                .WriteLine("￥1.46");

            _printer.Write(new byte[] {0x1B, 0x61, 0x32})
                .Write("测试右侧对齐")
                .NewLine();

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试打印-列模式
        /// </summary>
        [Fact]
        public void Test_Print_Columns_4()
        {
            _printer.Initialize();
            _printer.NewLine();

            _printer.Left()
                .WriteLine(PrintInOneLine("货号/品号/数量", "金额"));

            _printer.Left()
                .WriteLine("412117");

            _printer.Left()
                .WriteLine("鲜甜豆浆500ml/瓶");

            _printer.Left()
                .WriteLine(PrintInOneLine("x 1", "￥1.46"));

            _printer.NewLine(2);

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 打印在一行
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        private string PrintInOneLine(string text1, string text2)
        {
            var lineLength = 48;//48,23
            var needEmpty = lineLength - (GetStringWidth(text1) + GetStringWidth(text2)) % lineLength;
            StringBuilder sb = new StringBuilder();
            while (needEmpty>0)
            {
                sb.Append(" ");
                needEmpty--;
            }

            return $"{text1}{sb.ToString()}{text2}";
        }

        private int GetStringWidth(string text)
        {
            var width = 0;
            foreach (char c in text.ToCharArray())
            {
                width += IsAscii(c) ? 1 : 2;
            }

            return width;
        }

        private bool IsAscii(char c)
        {
            return (int) c >= 0 && (int) c <= 128;
        }

        /// <summary>
        /// 测试打印-列模式
        /// </summary>
        [Fact]
        public void Test_Print_Columns_2()
        {
            _printer.Initialize();
            _printer.NewLine();

            var pageWidth = 23;
            var weights = new[] {15, 5};
            var aligins = new[] {0, 2};
            foreach (var item in PrintColumns(new[] {"货号/品号/数量", "金额"}, weights, aligins, pageWidth))
            {
                _printer.Write(item);
            }

            _printer.WriteLine("412117");
            _printer.WriteLine("鲜甜豆浆500ml/瓶");
            foreach (var item in PrintColumns(new[] {"x 1", "￥1.46"}, weights, aligins, pageWidth))
            {
                _printer.Write(item);
            }

            _printer.NewLine(2);

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试打印-列模式
        /// </summary>
        [Fact]
        public void Test_Print_Columns()
        {
            _printer.Initialize();
            _printer.NewLine();

            var pageWidth = 23;
            var weights = new[] {20, 5, 5, 5};
            var aligins = new[] {0, 1, 1, 1};

            //for (int i = 0; i < pageWidth; i++)
            //{
            //    _printer.Write("测");
            //}

            //_printer.NewLine();

            //foreach (var item in PrintColumns(new []{"商品","单价","数量","小计"}, weights, aligins, pageWidth))
            //{
            //    _printer.Write(item);
            //}

            //_printer.NewLine();

            foreach (var item in PrintColumns(new[] {"可口可乐可口可乐", "2.5", "4", "10"}, weights, aligins, pageWidth))
            {
                _printer.Write(item);
            }

            _printer.NewLine();

            //foreach (var item in PrintColumns(new[] { "可口可乐可口可乐11111111111111111111111111111111", "2.5", "4", "10" }, weights, aligins, pageWidth))
            //{
            //    _printer.Write(item);
            //}
            //_printer.NewLine();

            //foreach (var item in PrintColumns(new[] { "可口可乐可口可乐2222222222222222222222222222", "2.5", "4", "10" }, weights, aligins, pageWidth))
            //{
            //    _printer.Write(item);
            //}
            //_printer.NewLine();
            //foreach (var item in PrintColumns(new[] { "可口可乐可口可乐33333333333333333333333", "2.5", "4", "10" }, weights, aligins, pageWidth))
            //{
            //    _printer.Write(item);
            //}

            _printer.NewLine(2);

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 打印一行多列
        /// </summary>
        /// <param name="texts">文本内容</param>
        /// <param name="weights">每个字段权重</param>
        /// <param name="aligins">对齐方式</param>
        /// <param name="pageWidth">页面可容纳的字符长度</param>
        /// <param name="zoom">是否缩放</param>
        /// <returns></returns>
        private List<string> PrintColumns(string[] texts, int[] weights, int[] aligins, int pageWidth, bool zoom = true)
        {
            var total = weights.Sum();
            var maxOfRows = 1;
            List<List<string>> list = new List<List<string>>();
            for (var i = 0; i < texts.Length; i++)
            {
                var text = texts[i];

                var width = (decimal) (((double) weights[i] / (double) total) * (double) pageWidth);
                var columnRowLength = (int) Math.Ceiling(width);
                var align = aligins[i];
                // 因为一个单元格无法容纳这么多字符串 ，将自动列换行
                var columnRowArray = MultiText(text, (int) columnRowLength, align, zoom);
                var rowCount = columnRowArray.Count;
                if (rowCount > maxOfRows)
                {
                    maxOfRows = rowCount;
                }

                list.Add(columnRowArray);
            }

            var index = 0;
            string[] result = new string[texts.Length];
            list.ForEach(item =>
            {
                var sb = new StringBuilder();
                item.ForEach(x =>
                {
                    // 将每一列溢出的行 自动换到下一行打印
                    var currentRow = !string.IsNullOrEmpty(x)
                        ? x
                        : new string(' ', (int) Math.Ceiling((decimal) ((weights[index] / total) * pageWidth)));
                    if (currentRow.Length == pageWidth && 0 == currentRow.Trim().Length)
                    {
                        return;
                    }

                    result[index] = (result[index] != null ? result[index] + currentRow : currentRow);
                });
                index += 1;
            });

            return result.ToList();
        }


        private List<string> MultiText(string text, int lineMax, int aliginType, bool zoom)
        {
            var length = text.Length;
            var containCount = Math.Ceiling(zoom ? lineMax * 0.8 : lineMax);
            List<string> list = new List<string>();
            do
            {
                var content = ColumnText(text, lineMax, containCount, aliginType);
                if (!string.IsNullOrEmpty(content))
                {
                    list.Add(content);
                }

                content = content.Trim();
                text = text.Substring(content.Length, text.Length - content.Length);
                length = text.Length;
                if (length < containCount)
                {
                    list.Add(ColumnText(text, lineMax, containCount, aliginType));
                }

            } while (length >= containCount);

            return list;
        }

        private string ColumnText(string text, int lineMax, double containCount, int aliginType)
        {
            var length = GetLength(text) > containCount ? containCount : GetLength(text);
            var tempLength = 0;
            List<char> chars = new List<char>();
            for (int i = 0; i < text.Length; i++)
            {
                var charCode = (int) text[i];
                tempLength += (charCode >= 0 && charCode <= 128 ? 1 : 2);
                if (tempLength > length)
                {
                    break;
                }

                chars.Add((char) charCode);
            }

            var result = new string(chars.ToArray());
            result = result.Replace("�", "");
            var t1 = lineMax - length;
            var empty = " ";
            while (t1 > 0)
            {
                switch (aliginType)
                {
                    case 0:
                        result = result + empty;
                        break;
                    case 1:
                        result = (t1 % 2 == 0 ? empty + result : result + empty);
                        break;
                    case 2:
                        result = empty + result;
                        break;
                    default:
                        result = empty + result;
                        break;
                }

                --t1;
            }

            return result;
        }

        /// <summary>
        /// 获取文本长度
        /// </summary>
        /// <param name="text">文本</param>
        private int GetLength(string text)
        {
            var realLength = 0;
            var charCode = -1;
            for (var i = 0; i < text.Length; i++)
            {
                charCode = text[i];
                realLength += charCode >= 0 && charCode <= 128 ? 1 : 2;
            }

            return realLength;
        }

        /// <summary>
        /// 测试打印图片
        /// </summary>
        [Fact]
        public void Test_PrintImage()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            Output.WriteLine(basePath);

            _printer.Initialize();
            _printer.Center();
            _printer.WriteLine("Test PNG images with widths 100 - 600 px at native resolution");

            _printer.WriteLine("-- pd-logo-100.png --");
            _printer.Write(PrintImage($"{basePath}images\\pd-logo-100.png"));
            _printer.NewLine(1);

            _printer.WriteLine("-- pd-logo-200.png --");
            _printer.Write(PrintImage($"{basePath}images\\pd-logo-200.png"));
            _printer.NewLine(1);

            //_printer.WriteLine("-- pd-logo-300.png --");
            //_printer.Write(PrintImage($"{basePath}images\\pd-logo-300.png"));
            //_printer.NewLine(1);

            //_printer.WriteLine("-- pd-logo-400.png --");
            //_printer.Write(PrintImage($"{basePath}images\\pd-logo-400.png"));
            //_printer.NewLine(1);

            //_printer.WriteLine("-- pd-logo-500.png --");
            //_printer.Write(PrintImage($"{basePath}images\\pd-logo-500.png"));
            //_printer.NewLine(1);

            //_printer.WriteLine("-- pd-logo-600.png --");
            //_printer.Write(PrintImage($"{basePath}images\\pd-logo-600.png"));
            //_printer.NewLine(1);

            _printer.NewLine(2);
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        private byte[] PrintImage(string filePath)
        {
            var list = new List<byte>();
            using (var image = Image.FromFile(filePath))
            {
                var bmp = new Bitmap(image);
                //设置字符行间距为n点行
                //byte[] data = new byte[] { 0x1B, 0x33, 0x00 };
                string send = "" + (char) (27) + (char) (51) + (char) (0);
                byte[] data = new byte[send.Length];
                for (int i = 0; i < send.Length; i++)
                {
                    data[i] = (byte) send[i];
                }

                list.AddRange(data);
                data[0] = (byte) '\x00';
                data[1] = (byte) '\x00';
                data[2] = (byte) '\x00'; // Clear to Zero.
                Color pixelColor;
                //ESC * m nL nH d1…dk   选择位图模式
                // ESC * m nL nH
                byte[] escBmp = new byte[] {0x1B, 0x2A, 0x00, 0x00, 0x00};
                escBmp[2] = (byte) '\x21';
                //nL, nH
                escBmp[3] = (byte) (bmp.Width % 256);
                escBmp[4] = (byte) (bmp.Width / 256);
                //循环图片像素打印图片
                //循环高
                for (int i = 0; i < (bmp.Height / 24 + 1); i++)
                {
                    //设置模式为位图模式
                    list.AddRange(escBmp);
                    //循环宽
                    for (int j = 0; j < bmp.Width; j++)
                    {
                        for (int k = 0; k < 24; k++)
                        {
                            if (((i * 24) + k) < bmp.Height) // if within the BMP size
                            {
                                pixelColor = bmp.GetPixel(j, (i * 24) + k);
                                if (pixelColor.R == 0)
                                {
                                    data[k / 8] += (byte) (128 >> (k % 8));

                                }
                            }
                        }

                        //一次写入一个data，24个像素
                        list.AddRange(data);

                        data[0] = (byte) '\x00';
                        data[1] = (byte) '\x00';
                        data[2] = (byte) '\x00'; // Clear to Zero.
                    }

                    //换行，打印第二行
                    byte[] data2 = {0xA};
                    list.AddRange(data2);
                } // data
            }

            return list.ToArray();
        }

        private byte[] GetImageData(string bmpFileName)
        {
            if (!File.Exists(bmpFileName))
            {
                return null;
            }

            var data = GetBitmapData(bmpFileName);
            var dots = data.Dots;
            var width = BitConverter.GetBytes(data.Width);

            var offset = 0;
            var ms = new MemoryStream();
            var bw = new BinaryWriter(ms);

            bw.Write((char) 0x1B);
            bw.Write('@');

            bw.Write((char) 0x1B);
            bw.Write('3');
            bw.Write((byte) 24);

            while (offset < data.Height)
            {
                bw.Write((char) 0x1B);
                bw.Write('*'); // bit-image mode
                bw.Write((byte) 33); // 24-dot double-density
                bw.Write(width[0]); // width low byte
                bw.Write(width[1]); // width high byte

                for (int x = 0; x < data.Width; ++x)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        byte slice = 0;
                        for (int b = 0; b < 8; ++b)
                        {
                            int y = (((offset / 8) + k) * 8) + b;
                            // Calculate the location of the pixel we want in the bit array.
                            // It'll be at (y * width) + x.
                            int i = (y * data.Width) + x;

                            // If the image is shorter than 24 dots, pad with zero.
                            bool v = false;
                            if (i < dots.Length)
                            {
                                v = dots[i];
                            }

                            slice |= (byte) ((v ? 1 : 0) << (7 - b));
                        }

                        bw.Write(slice);
                    }
                }

                offset += 24;
                bw.Write((char) 0x0A);
            }

            // Restore the line spacing to the default of 30 dots.
            bw.Write((char) 0x1B);
            bw.Write('3');
            bw.Write((byte) 30);

            bw.Flush();
            byte[] bytes = ms.ToArray();
            bw.Dispose();
            ms.Dispose();
            return bytes;
        }

        private BitmapData GetBitmapData(string bmpFileName)
        {
            using (var bitmap = (Bitmap) Bitmap.FromFile(bmpFileName))
            {
                var threshold = 127;
                var index = 0;
                double multiplier = 500;
                double scale = (double) (multiplier / (double) bitmap.Width);
                var xHeight = (int) (bitmap.Height * scale);
                var xWidth = (int) (bitmap.Width * scale);
                var dimensions = xWidth * xHeight;
                var dots = new BitArray(dimensions);
                for (var y = 0; y < xHeight; y++)
                {
                    for (var x = 0; x < xWidth; x++)
                    {
                        var _x = (int) (x / scale);
                        var _y = (int) (y / scale);
                        var color = bitmap.GetPixel(_x, _y);
                        var luminance = (int) (color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        dots[index] = (luminance < threshold);
                        index++;
                    }
                }

                return new BitmapData()
                {
                    Dots = dots,
                    Height = (int) (bitmap.Height * scale),
                    Width = (int) (bitmap.Width * scale)
                };
            }
        }

        /// <summary>
        /// 位图数据
        /// </summary>
        private class BitmapData
        {
            /// <summary>
            /// 点
            /// </summary>
            public BitArray Dots { get; set; }

            /// <summary>
            /// 高度
            /// </summary>
            public int Height { get; set; }

            /// <summary>
            /// 宽度
            /// </summary>
            public int Width { get; set; }
        }

        /// <summary>
        /// 测试打印订单
        /// </summary>
        [Fact]
        public void Test_PrintOrder()
        {
            var logoPath = "D:\\utb_logo.png";
            _printer.Initialize();
            _printer.NewLine();
            _printer.Center();
            _printer.WriteLine("预留Logo位置");
            //_printer.Write(PrintImage(logoPath));
            _printer.Code128("0201902134", BarcodePositionType.Above, BarcodeWidth.Default, 100, true);
            _printer.NewLine();
            _printer.SolidLine();
            _printer.NewLine();

            _printer.Left();
            _printer.FontType(FontType.Compress2);
            _printer.FontSize(FontSize.Size1);
            PrintItem(_printer,26,168,"运单号", "Y20190618000001");
            PrintItem(_printer,0,168,"配送中心", "天河高志体验店");
            PrintItem(_printer,0,168,"配送时段", "2019-06-24 14:00-18:00");
            _printer.Initialize();
            PrintItem(_printer,52,168,"收货人", "来自隔壁老王的新手大礼包");
            PrintItem(_printer,26,168,"联系电话", "18975927788");
            PrintItem(_printer,26,168,"收货地址", "广州市天河区黄埔大道西120号高志大厦B1层");

            _printer.Initialize();
            _printer.SolidLine();
            _printer.NewLine();
            PrintItem(_printer,"订单号", "lbz53968504");

            _printer.Initialize();
            _printer.DottedLine();
            _printer.NewLine();
            _printer.WriteOneLine("商品名称", "数量", "单价", "合计    ");
            _printer.NewLine();
            _printer.DottedLine();
            _printer.NewLine(2);

            for (int i = 0; i < 3; i++)
            {
                _printer.WriteLine($"10023332  白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜-{i}");
                _printer.NewLine();

                _printer.LeftMargin(180, 0);
                _printer.PrintWidth(128, 0);
                _printer.Write("1000000000");

                _printer.LeftMargin(54, 1);
                _printer.PrintWidth(130, 0);
                _printer.Write("9999999.50");

                _printer.LeftMargin(190, 1);
                _printer.PrintWidth(180, 0);
                _printer.Write("999999950000000.00");

                _printer.NewLine();
                _printer.Initialize();
                _printer.NewLine();
            }

            _printer.DottedLine();
            _printer.NewLine();
            _printer.Right();
            _printer.WriteLine("商品件数：3件 ");
            _printer.Left();
            _printer.NewLine();
            _printer.DottedLine();
            _printer.NewLine(2);

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试打印-条码
        /// </summary>
        [Fact]
        public void Test_Print_Barcode()
        {
            _printer.Initialize();
            for (var i = 2; i <= 6; i++)
            {
                _printer.Write(Code128(i, 100, "0201902134", 1, true));
                _printer.NewLine();
            }
            _printer.NewLine(2);

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        private byte[] Code128(int width, int height, string content, int showContentPosition, bool fontB)
        {
            var list = new List<byte>();
            // 设置宽度
            list.AddRange(Command.BarcodeWidth);
            list.Add((byte) width);

            // 设置高度
            list.AddRange(Command.BarcodeHeight);
            list.Add((byte) height);

            // 设置条码打印位置
            list.AddRange(Command.BarcodeLabelPosition);
            switch (showContentPosition)
            {
                case 1:
                    list.Add(0x01);
                    break;
                case 2:
                    list.Add(0x02);
                    break;
                case 3:
                    list.Add(0x01);
                    list.AddRange(Command.BarcodeLabelPosition);
                    list.Add(0x02);
                    break;
                default:
                    list.Add(0x00);
                    break;
            }

            // 设置条码识读字符字体
            list.AddRange(fontB ? Command.BarcodeLabelFontB : Command.BarcodeLabelFontA);

            // 设置打印条码
            list.AddRange(new byte[] {0x1D, 0X6B, 0x49});
            list.Add((byte) (content.Length + 2));
            list.AddRange(Encoding.GetEncoding("GB18030").GetBytes(content));
            list.Add(0);
            return list.ToArray();
        }

        /// <summary>
        /// 测试打印分隔符
        /// </summary>
        [Fact]
        public void Test_Print_Separator()
        {
            _printer.Initialize();
            _printer.NewLine();
            int length = 72;
            //_printer.Bold(PrinterModeState.On);
            //_printer.WriteLine(new string('-', length - 24));// 48个字符
            //_printer.WriteLine($"开始内容 {length}");
            
            //_printer.Condensed(new string('-', length));
            //_printer.Bold(PrinterModeState.Off);
            //_printer.NewLine();

            _printer.WriteLine($"结束内容 {length}");
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试打印-分隔符 设置左边距
        /// </summary>
        [Fact]
        public void Test_Print_Separator_LeftMargin()
        {
            _printer.Initialize();
            _printer.NewLine();
            _printer.WriteLine("开始内容");
            _printer.Separator();
            _printer.LeftMargin(30);
            _printer.WriteLine("设置左边距内容");
            _printer.Separator();
            _printer.LeftMargin();
            _printer.WriteLine("恢复左边距内容");
            _printer.Separator();

            _printer.NewLine(2);
            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试权重
        /// </summary>
        [Fact]
        public void Test_Weights()
        {
            //_printer.Initialize();
            //for (var i = 0; i < 48; i++)
            //{
            //    _printer.Write("1");
            //}

            //_printer.NewLine();

            //var result = _printer.ToHex();
            //Output.WriteLine(result);

            var result = WeightsHandler(new string[] {"等于最大长度，需要切割字符串", "这是一首歌的时间66666666666666", "感觉凉凉的说", "有一句凉凉不知道改改说"},
                new int[] {7, 5, 5, 5}, 48);
            foreach (var item in result)
            {
                Output.WriteLine(new string('-', 48));
                Output.WriteLine(item);
            }
        }

        /// <summary>
        /// 权重处理
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="proportion">比例</param>
        /// <param name="maxWidth">最大宽度</param>
        private List<string> WeightsHandler(string[] source, int[] proportion,int maxWidth)
        {
            var sum = proportion.Sum();
            List<List<string>> list = new List<List<string>>();
            int[] width = new int[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                width[i]= GetWidth(proportion[i], sum, maxWidth);
                list.Add(CutString(source[i], width[i]));
            }

            var maxLine = list.Max(x => x.Count);
            var result = new string[maxLine];
            var index = 0;
            foreach (var item in list)
            {
                for (int i = 0; i < maxLine; i++)
                {
                    if (i < item.Count)
                    {
                        result[i] = result[i] == null ? item[i] : result[i] + item[i];
                    }
                    else
                    {
                        result[i] += new string(' ', width[index]);
                    }
                }

                index++;
            }

            return result.ToList();
        }

        /// <summary>
        /// 切割字符串
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxLength"></param>
        private List<string> CutString(string text, int maxLength)
        {
            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            var length = 0;
            var index = -1;
            foreach (var c in text.ToCharArray())
            {
                index++;
                var cLength = IsAscii(c) ? 1 : 2;
                // 等于最大长度，需要切割字符串
                if (length + cLength == maxLength)
                {
                    length = 0;
                    sb.Append(c);
                    sb.Append(" ");
                    list.Add(sb.ToString());
                    sb.Clear();
                    continue;
                }

                // 大于最大长度，需要切割字符串，当前字符填充到下面
                if (length + cLength > maxLength && index != text.Length - 1)
                {
                    length = cLength;
                    sb.Append(" ");
                    list.Add(sb.ToString());
                    sb.Clear();
                    sb.Append(c);
                    continue;
                }

                if (length + cLength < maxLength)
                {
                    length += cLength;
                    sb.Append(c);
                }

                // 如果为最后字符，则需要填充空格
                if (index == text.Length - 1)
                {
                    sb.Append(new string(' ', maxLength - length));
                    list.Add(sb.ToString());
                }
            }

            return list;
        }

        /// <summary>
        /// 获取文本宽度
        /// </summary>
        /// <param name="source">权重</param>
        /// <param name="total">总比例</param>
        /// <param name="maxWidth">最大长度</param>
        private int GetWidth(int source, int total, int maxWidth)
        {
            return (int) Math.Ceiling((double) source / (double) total * (double) maxWidth);
        }

        /// <summary>
        /// 测试打印-物流订单详情
        /// </summary>
        [Fact]
        public void Test_Print_DeliveryOrderDetail()
        {
            _printer.Initialize();
            _printer.Center();
            // 箱子抬头 logo
            var logoPath = "D:\\utb_logo.png";
            _printer.Write(PrintImage(logoPath));
            _printer.NewLine();
            // 左对齐
            _printer.Left();
            // 设置字体 ASCII 字体（8×16）+ 中文字体（16×16）
            _printer.FontType(FontType.Compress2);
            // 字符大小，设置为放大2倍
            _printer.FontSize(FontSize.Size1);
            PrintItem(_printer,0,168,"配送站点", "高德置地广场D座19楼");
            PrintItem(_printer, 0, 168, "配送时间", "2019-06-04 15:00-16:00");
            // 重置排版
            _printer.Initialize();
            PrintItem(_printer, "订单数", "10");
            PrintItem(_printer,"箱子数", "第1个/共2个（7件商品）");
            // 重置排版
            _printer.Initialize();
            // 实线
            _printer.SolidLine();

            // 订单信息
            _printer.NewLine(2);
            _printer.Center();
            //_printer.Write(PrintImage(logoPath));
            _printer.NewLine(2);
            _printer.Left();
            PrintItem(_printer,"订单号", "DD8070600015");
            PrintItem(_printer,"收件人","盛茂");
            PrintItem(_printer,26,168,"联系电话", "134149**358");
            PrintItem(_printer,26,168,"收货地址", "广州市天河区珠江西路8号高德置地广场D座19楼");

            // 重置排版
            _printer.Initialize();
            // 虚线
            _printer.DottedLine();
            _printer.NewLine();
            _printer.WriteOneLine("商品名称", "数量", "单价", "合计    ");
            _printer.NewLine();
            _printer.DottedLine();
            _printer.NewLine(2);

            for (int i = 0; i < 3; i++)
            {
                _printer.WriteLine($"10023332  白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜-{i}");
                _printer.NewLine();

                _printer.LeftMargin(180, 0);
                _printer.PrintWidth(128, 0);
                _printer.Write("1000000000");

                _printer.LeftMargin(54, 1);
                _printer.PrintWidth(130, 0);
                _printer.Write("9999999.50");

                _printer.LeftMargin(190, 1);
                _printer.PrintWidth(180, 0);
                _printer.Write("999999950000000.00");

                _printer.NewLine();
                _printer.Initialize();
                _printer.NewLine();
            }

            _printer.DottedLine();
            _printer.NewLine();
            _printer.Right();
            _printer.WriteLine("商品件数：3件 ");
            _printer.Left();
            _printer.NewLine();
            _printer.DottedLine();
            _printer.NewLine(2);

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }

        private void PrintItem(IEscPosPrinter printer, string left, string right)
        {
            printer.LeftMargin(50);
            printer.Write(left);
            printer.LeftMargin(168);
            printer.Write(right);
            printer.NewLine(2);
        }

        private void PrintItem(IEscPosPrinter printer, int leftMargin, int rightMargin, string left, string right)
        {
            printer.LeftMargin(leftMargin);
            printer.Write(left);
            printer.LeftMargin(rightMargin);
            printer.Write(right);
            printer.NewLine(2);
        }

        /// <summary>
        /// 测试打印-图片
        /// </summary>
        [Fact]
        public void Test_Print_Image10()
        {
            var logoPath = "D:\\utb_logo.png";
            _printer.Write(PrintImage(logoPath));
            _printer.NewLine(2);

            var result = _printer.ToHex();
            Output.WriteLine(result);
        }
    }
}