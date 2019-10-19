using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Reports;
using ATV_Advertisment.Services;
using Microsoft.Reporting.WinForms;
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
    public partial class RevenuePrintForm : Form
    {
        private ContractService _contractService;

        public RevenuePrintForm()
        {
            InitializeComponent();

            System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
            ps.Landscape = true;
            ps.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170);
            ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
            rptViewer.SetPageSettings(ps);

            dtpFromMonth.Format = DateTimePickerFormat.Custom;
            dtpFromMonth.CustomFormat = "MM/yyyy";
            dtpFromMonth.ShowUpDown = true;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string exeFolder = Application.StartupPath;
                string reportPath = Path.Combine(exeFolder, @"Reports\RevenueRpt.rdlc");
                var reportData = GetRevenues();
                DateTime today = Utilities.GetServerDateTimeNow();
                string strToday = Utilities.DateToFormatVNDate(today);
                var totalCost = (decimal)reportData.Sum(r => r.SumCost);
                string strTotal = MoneyToText.NumberToTextVN(totalCost);

                ReportParameterCollection reportParameters = new ReportParameterCollection();
                reportParameters.Add(new ReportParameter("strMonthYear", this.dtpFromMonth.Value.Month + "/" + this.dtpFromMonth.Value.Year));
                reportParameters.Add(new ReportParameter("strReportDate", strToday));
                reportParameters.Add(new ReportParameter("strTotal", strTotal));

                rptViewer.LocalReport.ReportPath = reportPath;
                rptViewer.LocalReport.DataSources.Clear();
                rptViewer.LocalReport.SetParameters(reportParameters);
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsRevenues", reportData));
                rptViewer.RefreshReport();

                //ReportViewerForm reportViewerForm = new ReportViewerForm();
                //var reportData = GetRevenues();

                //ReportParameterCollection reportParameters = new ReportParameterCollection();
                //reportParameters.Add(new ReportParameter("strMonthYear", this.dtpFromMonth.Value.Month + "/" + this.dtpFromMonth.Value.Year));

                //reportViewerForm.reportViewer.LocalReport.ReportPath = "H:/Project/ATV2/ATV_Advertisment/ATV_Advertisment/Reports/RevenueRpt.rdlc";
                //reportViewerForm.reportViewer.LocalReport.DataSources.Clear();
                //reportViewerForm.reportViewer.LocalReport.SetParameters(reportParameters);
                //reportViewerForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("dsRevenues", reportData));
                //reportViewerForm.Refresh();

                //reportViewerForm.ShowDialog();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private List<ViewModel.RevenueRM> GetRevenues()
        {
            try
            {
                _contractService = new ContractService();
                var reportData = _contractService.GetRevenueRptByMonth(new DateTime(dtpFromMonth.Value.Year, dtpFromMonth.Value.Month, 1));
                return reportData;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _contractService = null;
            }
        }

        private void RevenuePrintForm_Load(object sender, EventArgs e)
        {

            this.rptViewer.RefreshReport();
            this.rptViewer.RefreshReport();
        }

        //private void btnPrint_Click(object sender, EventArgs e)
        //{
        //    RevenuePrintForm revenuePrintForm = new RevenuePrintForm();
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Title = "Chọn thư mục lưu";
        //    //theDialog.Filter = "TXT files|*.txt";
        //    //theDialog.InitialDirectory = @"C:\";
        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            if (!sfd.FileName.Contains("xlsx"))
        //            {
        //                sfd.FileName = sfd.FileName + ".xlsx";
        //            }

        //            FileInfo fileInfo = new FileInfo(sfd.FileName);
        //            RevenueReport revenueReport = new RevenueReport();
        //            _contractService = new ContractService();
        //            List<ViewModel.RevenueRM> models = null;
        //            models = _contractService.GetRevenueRptByMonth(new DateTime(dtpFromMonth.Value.Year, dtpFromMonth.Value.Month, 1));

        //            if (models.Count <= 0)
        //            {
        //                Utilities.ShowMessage(CommonMessage.EXPORT_FAIL);
        //            }
        //            else
        //            {
        //                revenueReport.ExportToExcel(models, fileInfo, dtpFromMonth.Value.Year, dtpFromMonth.Value.Month);
        //                Utilities.ShowMessage(CommonMessage.EXPORT_SUCESSFULLY);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            _contractService = null;
        //        }
        //    }
        //}
    }
}
