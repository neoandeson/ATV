namespace ATV_Advertisment.Forms.PrintForms
{
    partial class SchedulePrintForm
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
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.lblDay = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbControl.SuspendLayout();
            this.gbContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.lblDay);
            this.gbControl.Controls.Add(this.dtpDate);
            this.gbControl.Controls.Add(this.btnPrint);
            this.gbControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbControl.Location = new System.Drawing.Point(0, 0);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(870, 54);
            this.gbControl.TabIndex = 0;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(18, 25);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(45, 20);
            this.lblDay.TabIndex = 2;
            this.lblDay.Text = "Ngày";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(79, 20);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(102, 26);
            this.dtpDate.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(196, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 25);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "In lịch";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.rptViewer);
            this.gbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gbContent.Location = new System.Drawing.Point(0, 54);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(870, 529);
            this.gbContent.TabIndex = 1;
            this.gbContent.TabStop = false;
            this.gbContent.Text = "Nội dung";
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(3, 22);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ServerReport.BearerToken = null;
            this.rptViewer.Size = new System.Drawing.Size(864, 504);
            this.rptViewer.TabIndex = 0;
            // 
            // SchedulePrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 583);
            this.Controls.Add(this.gbContent);
            this.Controls.Add(this.gbControl);
            this.Name = "SchedulePrintForm";
            this.Text = "In lịch phát sóng";
            this.Load += new System.EventHandler(this.SchedulePrintForm_Load);
            this.gbControl.ResumeLayout(false);
            this.gbControl.PerformLayout();
            this.gbContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.GroupBox gbContent;
        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
    }
}