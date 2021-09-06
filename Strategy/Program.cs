using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 策略
            //// Three contexts following different strategies
            //Context c = new Context(new ConcreteStrategyA());
            //c.ContextInterface();

            //Context d = new Context(new ConcreteStrategyB());
            //d.ContextInterface();

            //Context e = new Context(new ConcreteStrategyC());
            //e.ContextInterface(); 
            #endregion

            var workbook = new Aspose.Cells.Workbook();

            // add a new worksheet to the Excel object
            int sheetIndex = workbook.Worksheets.Add();

            // obtain the reference of the newly added worksheet by passing its sheet index
            Worksheet worksheet = workbook.Worksheets[sheetIndex];

            // add sample values to cells
            worksheet.Cells["A1"].PutValue(50);
            worksheet.Cells["A2"].PutValue(100);
            worksheet.Cells["A3"].PutValue(150);
            worksheet.Cells["B1"].PutValue(4);
            worksheet.Cells["B2"].PutValue(20);
            worksheet.Cells["B3"].PutValue(50);

            // add a chart to the worksheet
            int chartIndex = worksheet.Charts.Add(Aspose.Cells.Charts.ChartType.Pyramid, 5, 0, 15, 5);

            // access the instance of the newly added chart
            var chart = worksheet.Charts[chartIndex];

            // add chart data source from "A1" to "B3"
            chart.NSeries.Add("A1:B3", true);

            // save the Excel file
            // workbook.Save("‪output.xls", SaveFormat.Xlsx);
           // var docStream = new MemoryStream();
            workbook. Save("D:\\output.xlsx", SaveFormat.Xlsx);

            Console.ReadKey();
        }
    }
}
