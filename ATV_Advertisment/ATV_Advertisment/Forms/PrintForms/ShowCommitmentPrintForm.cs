using ATV_Advertisment.Common;
using ATV_Advertisment.Services;
using DataService.Model;
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
    public partial class ShowCommitmentPrintForm : Form
    {
        public ShowCommitmentPrintForm()
        {
            InitializeComponent();
            LoadCboCustomerCode();

            System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
            ps.Landscape = true;
            ps.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170);
            ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
            rptViewer.SetPageSettings(ps);

            dtpMonth.Format = DateTimePickerFormat.Custom;
            dtpMonth.CustomFormat = "MM/yyyy";
            dtpMonth.ShowUpDown = true;
        }

        private void LoadCboCustomerCode()
        {
            try
            {
                Utilities.LoadComboBoxOptions(cboCustomer, new CustomerService().GetOptions());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadCboContractCode()
        {
            try
            {
                string customerCode = cboCustomer.SelectedValue + "";
                var options = new ContractService().GetOptionsByCustomerCodeAndMonth(customerCode, dtpMonth.Value, dtpMonth.Value);
                if(options.Count > 0)
                {
                    Utilities.LoadComboBoxOptions(cboContractCode, options);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void LoadCboProductCode()
        {
            try
            {
                string contracCode = cboContractCode.SelectedValue + "";
                var options = new ContractItemService().GetOptionsByContractCode(contracCode.Trim());
                if(options.Count > 0)
                {
                    Utilities.LoadComboBoxOptions(cboProduct, options);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string contracCode = cboContractCode.SelectedValue.ToString();
                string productName = cboProduct.SelectedValue.ToString();
                if(!string.IsNullOrWhiteSpace(contracCode) && !string.IsNullOrWhiteSpace(productName))
                {
                    ContractItem contractItem = new ContractItemService().GetByContractCodeAndProductName(contracCode, productName);
                    if(contractItem != null)
                    {
                        int contractDetailId = contractItem.Id;
                        string cdProductName = contractItem.FileName;

                        string exeFolder = Application.StartupPath;
                        string reportPath = Path.Combine(exeFolder, @"Reports\ShowCommitmentReport.rdlc");

                        //
                        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
                        {
                            SqlDataAdapter da = null;

                            try
                            {
                                string query = "SELECT ProductName, TimeSlot, ShowTime, TimeSlotCode, [1] as D1,[2] as D2,[3] as D3,[4] as D4,[5] as D5," +
                                    "[6] as D6,[7] as D7,[8] as D8,[9] as D9,[10] as D10, [11] as D11,[12] as D12,[13] as D13,[14] as D14,[15] as D15," +
                                    "[16] as D16,[17] as D17,[18] as D18,[19] as D19,[20] as D20,[21] as D21,[22] as D22,[23] as D23,[24] as D24, [25] as D25, " +
                                    "[26] as D26, [27] as D27, [28] as D28, [29] as D29, [30] as D30, [31] as D31, Qty " +
                                    "FROM" +
                                    "(" +
                                        "SELECT ProductName, TimeSlot, ShowTime, TimeSlotCode, " +
                                                "CAST(DAY(ShowDate) AS VARCHAR(4)) AS ShowDay, Quantity " +
                                        "FROM dbo.ProductScheduleShow p1 " +
                                        "WHERE   p1.ProductName = @productName " +
                                                "AND YEAR(p1.ShowDate) = @rptYear " +
                                                "AND MONTH(p1.ShowDate) = @rptMonth " +
                                                "AND ContractDetailId = @contractDetailId" +
                                    ") AS ts LEFT JOIN( " +
                                        "SELECT ProductName as ProductName1, TimeSlotCode as TimeSlotCode1, SUM(Quantity) as Qty " +
                                        "FROM  dbo.ProductScheduleShow p1 " +
                                        "WHERE p1.ProductName = @productName " +
                                                "AND YEAR(p1.ShowDate) = @rptYear " +
                                                "AND MONTH(p1.ShowDate) = @rptMonth " +
                                                "AND ContractDetailId = @contractDetailId " +
                                        "GROUP BY ProductName, Quantity, ShowTime, TimeSlotCode) as nu on ts.ProductName = nu.ProductName1 AND ts.TimeSlotCode = nu.TimeSlotCode1 " +
                                    "PIVOT " +
                                    "( " +
                                    "count(Quantity) " +
                                    "FOR ShowDay IN ( [1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20],[21],[22],[23],[24], [25], [26], [27], [28], [29], [30], [31]) " +
                                    ") AS pvt";
                                var cmd = new SqlCommand(query, con);
                                cmd.Parameters.Add(new SqlParameter("@rptYear", this.dtpMonth.Value.Year));
                                cmd.Parameters.Add(new SqlParameter("@rptMonth", this.dtpMonth.Value.Month));
                                cmd.Parameters.Add(new SqlParameter("@contractDetailId", contractDetailId));
                                cmd.Parameters.Add(new SqlParameter("@productName", cdProductName));

                                da = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                var firstDayOfMonth = new DateTime(this.dtpMonth.Value.Year, this.dtpMonth.Value.Month, 1);
                                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                                List<ViewModel.LiabilitiesRM> reportData = Utilities.ConvertDataTable<ViewModel.LiabilitiesRM>(dt);

                                ReportParameterCollection reportParameters = new ReportParameterCollection();
                                reportParameters.Add(new ReportParameter("strDate", this.dtpMonth.Value.Month + "/" + this.dtpMonth.Value.Year));
                                reportParameters.Add(new ReportParameter("strProductName", contractItem.ProductName));
                                reportParameters.Add(new ReportParameter("strFileName", contractItem.FileName));
                                reportParameters.Add(new ReportParameter("strLength", contractItem.DurationSecond + " giây"));
                                reportParameters.Add(new ReportParameter("strFromToDate", string.Format("{0} đến {1}", firstDayOfMonth.ToShortDateString(), lastDayOfMonth.ToShortDateString())));

                                rptViewer.LocalReport.ReportPath = reportPath;
                                rptViewer.LocalReport.DataSources.Clear();
                                rptViewer.LocalReport.SetParameters(reportParameters);
                                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsShowCommitment", dt));
                                rptViewer.RefreshReport();
                            }
                            catch (Exception)
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
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void ShowCommitmentPrintForm_Load(object sender, EventArgs e)
        {

            this.rptViewer.RefreshReport();
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCboContractCode();
        }

        private void dtpMonth_Validated(object sender, EventArgs e)
        {
            LoadCboContractCode();
        }

        private void cboContractCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboContractCode.Items.Count > 0)
            {
                LoadCboProductCode();
            } else
            {
                cboProduct.Items.Clear();
            }
        }
    }
}
