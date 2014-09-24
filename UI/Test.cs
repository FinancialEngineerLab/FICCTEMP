using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace UI
{
    public partial class ThisAddIn
    {
        private void init()
        {
            Application.Caption = "FICC Hedge Solution";
            Excel.Workbook wb = Application.ActiveWorkbook;
            Excel.Worksheet sht = Globals.ThisAddIn.Application.ActiveSheet;
            //Excel.Range r1 = sht.get_Range("A1", missing);
            //r1.Value2 = "test";
        }
    }
}
