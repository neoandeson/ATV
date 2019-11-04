using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Reports;
using ATV_Advertisment.Services;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

                //
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
                {
                    SqlDataAdapter da = null;

                    try
                    {
                        string query = "select ct.Code, ct.CustomerName, sum(pd.Cost)AS Cost, sum(pd.Cost) - (sum(pd.Cost) * ct.Discount / 100) AS TotalCost " +
                                "from ProductScheduleShow pd inner join ContractItem cti on pd.ContractDetailId = cti.Id " +
                                "inner join [Contract] ct on ct.Code = cti.ContractCode " +
                                "where YEAR(ShowDate) = @rptYear and MONTH(ShowDate) = @rptMonth group by ct.Code, ct.CustomerName, ct.Discount";
                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@rptYear", this.dtpFromMonth.Value.Year));
                        cmd.Parameters.Add(new SqlParameter("@rptMonth", this.dtpFromMonth.Value.Month));

                        da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        List<ViewModel.RevenueRM> reportData = Utilities.ConvertDataTable<ViewModel.RevenueRM>(dt);

                        DateTime today = Utilities.GetServerDateTimeNow();
                        string strToday = Utilities.DateToFormatVNDate(today);
                        var totalCost = (decimal)reportData.Sum(r => r.Cost);
                        string strTotal = MoneyToText.NumberToTextVN(totalCost);

                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("strMonthYear", this.dtpFromMonth.Value.Month + "/" + this.dtpFromMonth.Value.Year));
                        reportParameters.Add(new ReportParameter("strReportDate", strToday));
                        reportParameters.Add(new ReportParameter("strTotal", strTotal));

                        rptViewer.LocalReport.ReportPath = reportPath;
                        rptViewer.LocalReport.DataSources.Clear();
                        rptViewer.LocalReport.SetParameters(reportParameters);
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsRevenues", dt));
                        rptViewer.RefreshReport();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if(da != null)
                        {
                            da.Dispose();
                        }
                    }
                    
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //private void btnPrint_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string exeFolder = Application.StartupPath;
        //        string reportPath = Path.Combine(exeFolder, @"Reports\RevenueRpt.rdlc");
        //        var reportData = GetRevenues();
        //        DateTime today = Utilities.GetServerDateTimeNow();
        //        string strToday = Utilities.DateToFormatVNDate(today);
        //        var totalCost = (decimal)reportData.Sum(r => r.SumCost);
        //        string strTotal = MoneyToText.NumberToTextVN(totalCost);

        //        ReportParameterCollection reportParameters = new ReportParameterCollection();
        //        reportParameters.Add(new ReportParameter("strMonthYear", this.dtpFromMonth.Value.Month + "/" + this.dtpFromMonth.Value.Year));
        //        reportParameters.Add(new ReportParameter("strReportDate", strToday));
        //        reportParameters.Add(new ReportParameter("strTotal", strTotal));

        //        rptViewer.LocalReport.ReportPath = reportPath;
        //        rptViewer.LocalReport.DataSources.Clear();
        //        rptViewer.LocalReport.SetParameters(reportParameters);
        //        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsRevenues", reportData));
        //        rptViewer.RefreshReport();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

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
    }
}
