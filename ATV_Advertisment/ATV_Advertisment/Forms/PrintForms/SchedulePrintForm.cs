using ATV_Advertisment.Common;
using ATV_Advertisment.Services;
using ATV_Advertisment.ViewModel;
using System;
using System.IO;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;
using ATV_Advertisment.Reports;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;
using System.Linq;

namespace ATV_Advertisment.Forms.PrintForms
{
    public partial class SchedulePrintForm : Form
    {
        public SchedulePrintForm()
        {
            InitializeComponent();

            System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
            ps.Landscape = true;
            ps.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170);
            ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
            rptViewer.SetPageSettings(ps);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string exeFolder = Application.StartupPath;
                string reportPath = Path.Combine(exeFolder, @"Reports\ProductSchedule.rdlc");

                //
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
                {
                    SqlDataAdapter da = null;

                    try
                    {
                        string query = "SELECT	ShowDate, TimeSlot, ShowTime, ProductName, TimeSlotLength " +
                            "FROM ProductScheduleShow " +
                            "WHERE YEAR(ShowDate) = @rptYear " +
                            "AND((MONTH(ShowDate) = @rptMonth AND DAY(ShowDate) = @rptDay) " +
                                "OR (MONTH(ShowDate) = @rptMonth AND DAY(ShowDate) = @rptNextDay AND ShowTimeInt < 1000)) " +
                            "ORDER BY ShowTimeInt";
                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@rptYear", this.dtpDate.Value.Year));
                        cmd.Parameters.Add(new SqlParameter("@rptMonth", this.dtpDate.Value.Month));
                        cmd.Parameters.Add(new SqlParameter("@rptDay", this.dtpDate.Value.Day));
                        cmd.Parameters.Add(new SqlParameter("@rptNextDay", this.dtpDate.Value.Day + 1));

                        da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        List<ViewModel.ProductScheduleShowRM> reportData = Utilities.ConvertDataTable<ViewModel.ProductScheduleShowRM>(dt);

                        DateTime today = Utilities.GetServerDateTimeNow();
                        string strToday = Utilities.DateToFormatVNDate(today);
                        var totalCost = (decimal)reportData.Sum(r => r.TimeSlotLength);
                        string strTotal = MoneyToText.NumberToTextVN(totalCost);

                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("strDate", string.Format("NGÀY {0} THÁNG {1} NĂM {2}", this.dtpDate.Value.Day, this.dtpDate.Value.Month, this.dtpDate.Value.Year)));

                        rptViewer.LocalReport.ReportPath = reportPath;
                        rptViewer.LocalReport.DataSources.Clear();
                        rptViewer.LocalReport.SetParameters(reportParameters);
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsProductSchedule", dt));
                        rptViewer.RefreshReport();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    finally
                    {
                        if (da != null)
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

        private void SchedulePrintForm_Load(object sender, EventArgs e)
        {

            this.rptViewer.RefreshReport();
        }
    }
}
