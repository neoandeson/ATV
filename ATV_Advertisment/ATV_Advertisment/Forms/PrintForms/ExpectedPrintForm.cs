﻿using ATV_Advertisment.Common;
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
    public partial class ExpectedPrintForm : Form
    {
        public ExpectedPrintForm()
        {
            InitializeComponent();

            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd/MM/yyyy";
            dtpDate.ShowUpDown = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string exeFolder = Application.StartupPath;
                string reportPath = Path.Combine(exeFolder, @"Reports\ExpectedReport.rdlc");

                //
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
                {
                    SqlDataAdapter da = null;

                    try
                    {
                        string query = "SELECT ROW_NUMBER() OVER (ORDER BY mt.TSName) AS Num, mt.*, dd.ShowTime, dd.Duration " +
                            "FROM " +
                            "(SELECT ts.Code as TSCode, ts.Name as TSName, ss.Code as SSCode, ss.Name as SSName " +
                            "FROM    TimeSlot ts " +
                                    "INNER JOIN[Session] ss on ts.SessionCode = ss.Code " +
                                    "WHERE   ts.StatusId = 1) mt " +
                            "INNER JOIN " +
                            "( " +
                            "SELECT  TimeSlotCode, ShowTime, SUM(TimeSlotLength) as Duration " +
                            "FROM    ProductScheduleShow " +
                            "WHERE   YEAR(ShowDate) = @rptYear " +
                                    "AND MONTH(ShowDate) = @rptMonth " +
                                    "AND DAY(ShowDate) = @rptDay " +
                            "GROUP BY TimeSlotCode, ShowTime " +
                            ") dd on mt.TSCode = dd.TimeSlotCode";
                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@rptDay", this.dtpDate.Value.Day));
                        cmd.Parameters.Add(new SqlParameter("@rptYear", this.dtpDate.Value.Year));
                        cmd.Parameters.Add(new SqlParameter("@rptMonth", this.dtpDate.Value.Month));

                        da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        //List<ViewModel.RevenueRM> reportData = Utilities.ConvertDataTable<ViewModel.RevenueRM>(dt);

                        ReportParameterCollection reportParameters = new ReportParameterCollection();
                        reportParameters.Add(new ReportParameter("strDate", string.Format("NGÀY {0} THÁNG {1} NĂM {2}", dtpDate.Value.Day, dtpDate.Value.Month, dtpDate.Value.Year)));

                        rptViewer.LocalReport.ReportPath = reportPath;
                        rptViewer.LocalReport.DataSources.Clear();
                        rptViewer.LocalReport.SetParameters(reportParameters);
                        rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsExpectations", dt));
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

        private void ExpectedPrintForm_Load(object sender, EventArgs e)
        {
            this.rptViewer.RefreshReport();
        }
    }
}