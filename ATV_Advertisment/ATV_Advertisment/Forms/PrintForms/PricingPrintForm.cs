using ATV_Advertisment.Common;
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

namespace ATV_Advertisment.Forms.PrintForms
{
    public partial class PricingPrintForm : Form
    {
        public PricingPrintForm()
        {
            InitializeComponent();
        }

        private void PricingPrintForm_Load(object sender, EventArgs e)
        {

            this.rptViewer.RefreshReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string exeFolder = Application.StartupPath;
                string reportPath = Path.Combine(exeFolder, @"Reports\PricingReport.rdlc");

                //
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
                {
                    SqlDataAdapter da = null;

                    try
                    {
                        //Ads
                        string queryAds = "select * " +
                            "from " +
                            "( " +
                            "SELECT  ts.SessionCode, N'Buổi ' + ss.Name as Name, ts.Code, ts.Name as TSName, ts.FromHour, 'T' + CONVERT(varchar(10), cr.Length) as TLength, cr.Price " +
                            "FROM[TimeSlot] ts " +
                            "INNER JOIN[Session] ss on ts.SessionCode = ss.Code " +
                            "INNER JOIN[CostRule] cr on ts.Id = cr.TimeSlotId " +
                            "WHERE cr.ShowTypeId = 1 " +
                            ") " +
                            "src " +
                            "pivot ( " +
                            "sum(Price) " +
                            "for TLength in ([T10], [T15], [T20], [T30]) " +
                            ") piv; ";
                        var cmdAds = new SqlCommand(queryAds, con);

                        da = new SqlDataAdapter(cmdAds);
                        DataTable dtAds = new DataTable();
                        da.Fill(dtAds);

                        //Popup
                        string queryPopup = "select * " +
                            "from " +
                            "( " +
                            "SELECT  ts.SessionCode, N'Buổi ' + ss.Name as Name, ts.Code, ts.Name as TSName, ts.FromHour, 'T' + CONVERT(varchar(10), cr.Length) as TLength, cr.Price " +
                            "FROM[TimeSlot] ts " +
                            "INNER JOIN[Session] ss on ts.SessionCode = ss.Code " +
                            "INNER JOIN[CostRule] cr on ts.Id = cr.TimeSlotId " +
                            "WHERE cr.ShowTypeId = 1 " +
                            ") " +
                            "src " +
                            "pivot ( " +
                            "sum(Price) " +
                            "for TLength in ([T10], [T15], [T20], [T30]) " +
                            ") piv; ";
                        var cmdPopup = new SqlCommand(queryPopup, con);

                        da = new SqlDataAdapter(cmdPopup);
                        DataTable dtPopup = new DataTable();
                        da.Fill(dtPopup);

                        //SelfIntro
                        string querySelfIntro = "select * " +
                            "from " +
                            "( " +
                            "SELECT  ts.SessionCode, N'Buổi ' + ss.Name as Name, ts.Code, ts.Name as TSName, ts.FromHour, 'U' + CONVERT(varchar(10), cr.Length) as TLength, cr.Price " +
                            "FROM[TimeSlot] ts " +
                            "INNER JOIN[Session] ss on ts.SessionCode = ss.Code " +
                            "INNER JOIN[CostRule] cr on ts.Id = cr.TimeSlotId " +
                            "WHERE cr.ShowTypeId = 2 " +
                            ") " +
                            "src " +
                            "pivot ( " +
                            "sum(Price) " +
                            "for TLength in ([U180], [U600]) " +
                            ") piv; ";
                        var cmdSelfIntro = new SqlCommand(querySelfIntro, con);

                        da = new SqlDataAdapter(cmdSelfIntro);
                        DataTable dtSelfIntro = new DataTable();
                        da.Fill(dtSelfIntro);

                        //Notification
                        string queryNotification = "SELECT  ts.SessionCode, N'Buổi ' + ss.Name as Name, ts.Code, ts.Name as TSName, ts.FromHour, cr.Price " +
                            "FROM[TimeSlot] ts " +
                            "INNER JOIN[Session] ss on ts.SessionCode = ss.Code " +
                            "INNER JOIN[CostRule] cr on ts.Id = cr.TimeSlotId " +
                            "WHERE cr.ShowTypeId = 4 ";
                        var cmdNotification = new SqlCommand(queryNotification, con);

                        da = new SqlDataAdapter(cmdNotification);
                        DataTable dtNotification = new DataTable();
                        da.Fill(dtNotification);

                        //FMProduct
                        string queryFMProduct = "select * " +
                            "from " +
                            "( " +
                            "SELECT  ts.SessionCode, N'Buổi ' + ss.Name as Name, ts.Code, ts.Name as TSName, ts.FromHour, 'T' + CONVERT(varchar(10), cr.Length) as TLength, cr.Price " +
                            "FROM[TimeSlot] ts " +
                            "INNER JOIN[Session] ss on ts.SessionCode = ss.Code " +
                            "INNER JOIN[CostRule] cr on ts.Id = cr.TimeSlotId " +
                            "WHERE cr.ShowTypeId = 6 " +
                            ") " +
                            "src " +
                            "pivot ( " +
                            "sum(Price) " +
                            "for TLength in ([T30], [T60]) " +
                            ") piv; ";
                        var cmdFMProduct = new SqlCommand(queryFMProduct, con);

                        da = new SqlDataAdapter(cmdFMProduct);
                        DataTable dtFMProduct = new DataTable();
                        da.Fill(dtFMProduct);

                        //FMNotification
                        string queryFMNotification = "SELECT	ts.SessionCode, N'Buổi ' + ss.Name as Name, ts.Code, ts.Name as TSName, ts.FromHour, cr.Price as T60 " +
                            "FROM[TimeSlot] ts " +
                            "INNER JOIN[Session] ss on ts.SessionCode = ss.Code " +
                            "INNER JOIN[CostRule] cr on ts.Id = cr.TimeSlotId " +
                            "WHERE cr.ShowTypeId = 7";
                        var cmdFMNotification = new SqlCommand(queryFMNotification, con);

                        da = new SqlDataAdapter(cmdFMNotification);
                        DataTable dtFMNotification = new DataTable();
                        da.Fill(dtFMNotification);

                        //Discount
                        string queryDiscount = "SELECT	Description, Percentage " +
                            "FROM DiscountApply";
                        var cmdDiscount = new SqlCommand(queryDiscount, con);

                        da = new SqlDataAdapter(cmdDiscount);
                        DataTable dtDiscount = new DataTable();
                        da.Fill(dtDiscount);

                        //List<ViewModel.PricingRM> reportData = Utilities.ConvertDataTable<ViewModel.PricingRM>(dt);

                        DateTime today = Utilities.GetServerDateTimeNow();
                        string strToday = Utilities.DateToFormatVNDate(today);

                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("strYear", txtYear.Text));
                        reportParameters.Add(new ReportParameter("strApplyDate", this.dtpApplyDate.Value.ToString("dd/mm/yyyy")));
                        reportParameters.Add(new ReportParameter("strDirectorName", txtDirectorName.Text));

                        rptViewer.LocalReport.ReportPath = reportPath;
                        rptViewer.LocalReport.DataSources.Clear();
                        rptViewer.LocalReport.SetParameters(reportParameters);
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsPricing", dtAds));
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsPopup", dtPopup));
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsSelfIntro", dtSelfIntro));
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsNotification", dtNotification));
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsFMNotification", dtFMNotification));
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsFMProduct", dtFMProduct));
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsDiscountApply", dtDiscount));
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
    }
}
