using ATV_Advertisment.Services;
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

            EPPlusExport<TimeSlot> ePPlusExport = new EPPlusExport<TimeSlot>(exportDir, templateDir, new TimeSlotService().GetAll());
            ePPlusExport.CreateFileWithTemplate();
        }
    }
}
