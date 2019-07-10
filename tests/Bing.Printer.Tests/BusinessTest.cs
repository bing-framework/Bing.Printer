using Bing.Printer.Enums;
using Bing.Printer.EscPos;
using Bing.Printer.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Bing.Printer.Tests
{
    /// <summary>
    /// 业务测试
    /// </summary>
    public class BusinessTest:TestBase
    {
        public BusinessTest(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// 测试 - 打印物流订单
        /// </summary>
        [Fact]
        public void Test_PrintDeliveryOrder()
        {
            Printer.Initialize();
            Printer.Center();
            Printer.Code128("b0201902134", BarcodePositionType.Below, BarcodeWidth.Default, 100, true);
            Printer.NewLine();

            Printer.Initialize();
            Printer.Left();

            var order = "Y20190618000001";

            Printer.FontType(FontType.Compress2);
            Printer.FontSize(FontSize.Size1);
            Printer.LeftMargin(30);
            Printer.Write("运单号");
            Printer.LeftMargin(160);
            Printer.Write(order.Substring(0, order.Length - 4));
            Printer.FontType(FontType.Normal);
            Printer.FontSize(FontSize.Size1);
            Printer.Write(order.Substring(order.Length - 4, 4));
            Printer.RowHeight(30);
            Printer.NewLine();

            Printer.Initialize();
            Printer.Left();
            Printer.FontType(FontType.Compress2);
            Printer.FontSize(FontSize.Size1);
            Printer.RowHeight(30);
            //PrintItem(Printer, 30, 160, "运单号", "Y20190618000001");
            PrintItem(Printer, 0, 160, "配送中心", "天河高志体验店",30);
            PrintItem(Printer, 0, 160, "配送划区", "隔壁老王", 30);
            PrintItem(Printer, 0, 160, "配送时段", "2019-06-24 14:00-18:00", 30);
            PrintItem(Printer, 30, 160, "收货人", "来自隔壁老王的新手大礼包", 30);
            PrintItem(Printer, 0, 160, "联系电话", "18975927788", 30);
            var content = "广州市天河区黄埔大道广州市天河区黄埔大道广州市天河区黄埔大道广州市天河区黄埔大广州市天河区黄埔大";
            //var content = "广州市天河区黄埔大道广州市天河区黄埔大道广州市天河区黄埔大道广州市天河区黄埔大";
            //var content = "广州市天河区黄埔大道西1201号高志大厦B1层";
            //var content = "广州市天河区黄埔大道";
            PrintItem(Printer, 0, 160, "收货地址", content, 30);

            var line = GetLines(content, 26);
            Printer.Initialize();
            //Printer.DottedLine();
            //Printer.NewLine();
            //if (7 - line > 0)
            //{
            //    Printer.NewLine(7 - line);
            //}
            //Printer.DottedLine();
            //Printer.NewLine();

            switch (line)
            {
                case 1:
                    Printer.Write(new byte[] { 0x1B, 0x4A, 222.ToByte() });
                    break;
                case 2:
                    Printer.Write(new byte[] { 0x1B, 0x4A, 155.ToByte() });
                    break;
                case 3:
                    Printer.Write(new byte[] { 0x1B, 0x4A, 100.ToByte() });
                    break;
                case 4:
                    Printer.Write(new byte[] { 0x1B, 0x4A, 40.ToByte() });
                    break;
            }
            
            //Printer.DottedLine();
            //Printer.NewLine();

            var result = Printer.ToHex();
            Output.WriteLine(result);
        }

        /// <summary>
        /// 测试 - 打印物流订单详情
        /// </summary>
        [Fact]
        public void Test_PrintDeliveryOrderDetail()
        {
            //var logoPath = "D:\\utopa.tms_logo_1.png";
            //var logoPath = "D:\\utopa.tms_logo.png";
            var logoPath = "D:\\test_image4.jpg";
            //var logoPath = "D:\\utb_logo.png";
            Printer.Initialize();
            Printer.Center();
            //Printer.WriteLine("预留Logo位置");
            Printer.PrintImage(logoPath);
            Printer.NewLine();
            Printer.FontType(FontType.Compress2);
            Printer.FontSize(FontSize.Size1);
            Printer.WriteLine("联结你我 传送欢笑");
            Printer.NewLine();
            Printer.Initialize();
            Printer.Center();
            Printer.Code128("b0201902134", BarcodePositionType.Below, BarcodeWidth.Default, 100, true);
            Printer.NewLine();

            Printer.Initialize();
            Printer.Left();
            Printer.FontType(FontType.Compress2);
            Printer.FontSize(FontSize.Size1);
            PrintItem(Printer, 30, 160, "订单号", "30122019071000001741266205");
            PrintItem(Printer, 30, 160, "运单号", "Y20190618000001");
            PrintItem(Printer, 0, 160, "配送中心", "天河高志体验店");
            PrintItem(Printer, 0, 160, "配送区域", "隔壁老王");
            PrintItem(Printer, 0, 160, "配送时段", "2019-06-24 14:00-18:00");

            Printer.Initialize();
            PrintItem(Printer, 52, 160, "收货人", "来自隔壁老王的新手大礼包");
            PrintItem(Printer, 30, 160, "联系电话", "18975927788");
            PrintItem(Printer, 30, 160, "收货地址", "广州市天河区黄埔大道西120号高志大厦B1层");

            Printer.Initialize();
            Printer.DottedLine();
            Printer.NewLine();
            Printer.WriteOneLine("商品名称", "数量", "单价", "合计    ");
            Printer.NewLine();
            Printer.DottedLine();
            Printer.NewLine();

            for (int i = 0; i < 3; i++)
            {
                Printer.WriteLine($"10023332  白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜白苋菜-{i}");

                Printer.LeftMargin(180, 0);
                Printer.PrintWidth(128, 0);
                Printer.Write("1");

                Printer.LeftMargin(54, 1);
                Printer.PrintWidth(130, 0);
                Printer.Write("222.50");

                Printer.LeftMargin(190, 1);
                Printer.PrintWidth(180, 0);
                Printer.Write("6666.00");

                Printer.NewLine();
                Printer.Initialize();
            }

            Printer.DottedLine();
            Printer.NewLine();
            Printer.WriteOneLine("合计", "30", "", "2010.00");
            Printer.NewLine();
            Printer.DottedLine();
            Printer.NewLine(2);

            var result = Printer.ToHex();
            Output.WriteLine(result);
        }

        private void PrintItem(IEscPosPrinter printer, string left, string right)
        {
            printer.LeftMargin(50);
            printer.Write(left);
            printer.LeftMargin(168);
            printer.Write(right);
            printer.NewLine(1);
        }

        private void PrintItem(IEscPosPrinter printer, int leftMargin, int rightMargin, string left, string right,int rowHeigth = 15)
        {
            printer.LeftMargin(leftMargin);
            printer.Write(left);
            printer.LeftMargin(rightMargin);
            printer.Write(right);
            printer.NewLine();
            printer.RowHeight(rowHeigth);
        }

        [Fact]
        public void Test_ContentLength()
        {
            var line1 = GetLines("广州市天河区黄埔大道西1201号高志大厦B1层", 26);
            var line2 = GetLines("广州市天河区黄埔大道", 26);
            var line3 = GetLines("广州市天河区黄埔大道广州市天河区黄埔大道广州市天河区黄埔大道广州市天河区黄埔大", 26);
            var line4 = GetLines(
                "广州市天河区黄埔大道广州市天河区黄埔大道广州市天河区黄埔大道广州市天河区黄埔大道广州市天河区黄埔大道广州市天河区黄埔大道广州市天河区黄埔大道广州市天河区黄埔大道广州市天河区黄埔大道", 26);
            Output.WriteLine($"line1 : {line1}, line2 : {line2}, line3 : {line3}, line4 : {line4}");
        }

        /// <summary>
        /// 获取行数
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns></returns>
        private int GetLines(string content, int maxLength)
        {
            var line = 1;
            var currentLength = 0;
            var index = -1;
            foreach (var c in content.ToCharArray())
            {
                index++;
                // 判断是否Ascii值
                var isAscii = c >= 0 && c <= 128;
                var length = isAscii ? 1 : 2;
                if (currentLength + length == maxLength)
                {
                    currentLength = 0;
                    if (index < content.Length-1)
                    {
                        line++;
                    }
                    continue;
                }

                if (currentLength + length > maxLength)
                {
                    currentLength = 1;
                    line++;
                    continue;
                }

                currentLength += length;
            }

            return line;
        }
    }
}
