using ATV_Advertisment.Common;
using ATV_Advertisment.Services;
using ATV_Advertisment.ViewModel;
using System;
using System.IO;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;
using ATV_Advertisment.Reports;

namespace ATV_Advertisment.Forms.PrintForms
{
    public partial class SchedulePrintForm : Form
    {
        public SchedulePrintForm()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var exportDir = Path.GetFullPath(@"LichChieu.xlsx");
            var templateDir = Path.GetFullPath(@"Schedule.xlsx");

            //EPPlusExport<ProductScheduleShowRM> ePPlusExport = new EPPlusExport<ProductScheduleShowRM>(exportDir, templateDir,
            //    new ProductScheduleShowService().GetAllForRptByDate(dtpDate.Text));
            //ePPlusExport.CreateFileWithTemplate();

            ProductScheduleShowRpt productScheduleShowRpt = new ProductScheduleShowRpt();
            FileInfo newFile = new FileInfo(exportDir);
            productScheduleShowRpt.ExportToExcel(new ProductScheduleShowService().GetAllForRptByDate(dtpDate.Value), newFile);
            Utilities.ShowMessage(CommonMessage.EXPORT_SUCESSFULLY);
        }
    }
}
