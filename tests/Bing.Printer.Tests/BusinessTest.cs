using Bing.Printer.Enums;
using Bing.Printer.EscPos;
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
            Printer.NewLine();
            Printer.Center();
            //Printer.WriteLine("预留Logo位置");
            Printer.PrintImage(logoPath);
            Printer.NewLine();
            Printer.FontType(FontType.Compress2);
            Printer.FontSize(FontSize.Size1);
            Printer.WriteLine("联结你我 传送欢笑");
            Printer.Initialize();
            Printer.Center();
            Printer.NewLine();
            Printer.Code128("b0201902134", BarcodePositionType.Below, BarcodeWidth.Default, 100, true);
            Printer.NewLine();
            //Printer.SolidLine();
            //Printer.NewLine();

            Printer.Left();
            Printer.Initialize();
            Printer.FontType(FontType.Compress2);
            Printer.FontSize(FontSize.Size1);
            PrintItem(Printer, 30, 168, "订单号", "lbz53968504");
            PrintItem(Printer, 30, 168, "运单号", "Y20190618000001");
            PrintItem(Printer, 0, 168, "配送中心", "天河高志体验店");
            PrintItem(Printer, 0, 168, "配送区域", "隔壁老王");
            PrintItem(Printer, 0, 168, "配送时段", "2019-06-24 14:00-18:00");

            Printer.Initialize();
            PrintItem(Printer, 52, 168, "收货人", "来自隔壁老王的新手大礼包");
            PrintItem(Printer, 30, 168, "联系电话", "18975927788");
            PrintItem(Printer, 30, 168, "收货地址", "广州市天河区黄埔大道西120号高志大厦B1层");

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

        private void PrintItem(IEscPosPrinter printer, int leftMargin, int rightMargin, string left, string right)
        {
            printer.LeftMargin(leftMargin);
            printer.Write(left);
            printer.LeftMargin(rightMargin);
            printer.Write(right);
            printer.NewLine();
            printer.RowHeight(15);
        }
    }
}
