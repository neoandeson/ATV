using ATV_Advertisment.Common;
using ATV_Advertisment.Services;
using ATV_Advertisment.ViewModel;
using DataService.Model;
using ReportService.ExportExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

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

            EPPlusExport<ProductScheduleShowRM> ePPlusExport = new EPPlusExport<ProductScheduleShowRM>(exportDir, templateDir,
                new ProductScheduleShowService().GetAllForRptByDate(dtpDate.Text));
            ePPlusExport.CreateFileWithTemplate();
            Utilities.ShowMessage(CommonMessage.EXPORT_SUCESSFULLY);
        }
    }
}
