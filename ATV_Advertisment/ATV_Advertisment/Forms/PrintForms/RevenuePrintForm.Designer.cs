namespace ATV_Advertisment.Forms.PrintForms
{
    partial class RevenuePrintForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrint = new System.Windows.Forms.Button();
            this.dtpFromMonth = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.gbCriteria = new System.Windows.Forms.GroupBox();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbCriteria.SuspendLayout();
            this.gbContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(183, 15);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(125, 25);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Tạo báo cáo";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dtpFromMonth
            // 
            this.dtpFromMonth.Location = new System.Drawing.Point(70, 17);
            this.dtpFromMonth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFromMonth.Name = "dtpFromMonth";
            this.dtpFromMonth.Size = new System.Drawing.Size(109, 26);
            this.dtpFromMonth.TabIndex = 8;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(23, 19);
            this.lblStart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(54, 20);
            this.lblStart.TabIndex = 2;
            this.lblStart.Text = "Tháng";
            // 
            // gbCriteria
            // 
            this.gbCriteria.Controls.Add(this.lblStart);
            this.gbCriteria.Controls.Add(this.dtpFromMonth);
            this.gbCriteria.Controls.Add(this.btnPrint);
            this.gbCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCriteria.Location = new System.Drawing.Point(0, 0);
            this.gbCriteria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbCriteria.Name = "gbCriteria";
            this.gbCriteria.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbCriteria.Size = new System.Drawing.Size(858, 47);
            this.gbCriteria.TabIndex = 10;
            this.gbCriteria.TabStop = false;
            this.gbCriteria.Text = "Điều kiện";
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.rptViewer);
            this.gbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbContent.Location = new System.Drawing.Point(0, 47);
            this.gbContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbContent.Name = "gbContent";
            this.gbContent.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbContent.Size = new System.Drawing.Size(858, 465);
            this.gbContent.TabIndex = 11;
            this.gbContent.TabStop = false;
            this.gbContent.Text = "Nội dung";
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(2, 21);
            this.rptViewer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ServerReport.BearerToken = null;
            this.rptViewer.Size = new System.Drawing.Size(854, 442);
            this.rptViewer.TabIndex = 0;
            // 
            // RevenuePrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 512);
            this.Controls.Add(this.gbContent);
            this.Controls.Add(this.gbCriteria);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RevenuePrintForm";
            this.Text = "Báo cáo doanh thu";
            this.Load += new System.EventHandler(this.RevenuePrintForm_Load);
            this.gbCriteria.ResumeLayout(false);
            this.gbCriteria.PerformLayout();
            this.gbContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtpFromMonth;
        private System.Windows.Forms.GroupBox gbCriteria;
        private System.Windows.Forms.GroupBox gbContent;
        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
    }
}