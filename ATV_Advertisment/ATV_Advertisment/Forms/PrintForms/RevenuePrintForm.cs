using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Reports;
using ATV_Advertisment.Services;
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
    public partial class RevenuePrintForm : CommonForm
    {
        private ContractService _contractService;

        public RevenuePrintForm()
        {
            InitializeComponent();

            dtpFromMonth.Format = DateTimePickerFormat.Custom;
            dtpFromMonth.CustomFormat = "MM/yyyy";
            dtpFromMonth.ShowUpDown = true;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RevenuePrintForm revenuePrintForm = new RevenuePrintForm();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Chọn thư mục lưu";
            //theDialog.Filter = "TXT files|*.txt";
            //theDialog.InitialDirectory = @"C:\";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (!sfd.FileName.Contains("xlsx"))
                    {
                        sfd.FileName = sfd.FileName + ".xlsx";
                    }

                    FileInfo fileInfo = new FileInfo(sfd.FileName);
                    RevenueReport revenueReport = new RevenueReport();
                    _contractService = new ContractService();
                    List<ViewModel.RevenueRM> models = null;
                    models = _contractService.GetRevenueRptByMonth(new DateTime(dtpFromMonth.Value.Year, dtpFromMonth.Value.Month, 1));

                    if (models.Count <= 0)
                    {
                        Utilities.ShowMessage(CommonMessage.EXPORT_FAIL);
                    }
                    else
                    {
                        revenueReport.ExportToExcel(models, fileInfo, dtpFromMonth.Value.Year, dtpFromMonth.Value.Month);
                        Utilities.ShowMessage(CommonMessage.EXPORT_SUCESSFULLY);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _contractService = null;
                }
            }
        }
    }
}
