namespace ATV_Advertisment.Forms.PrintForms
{
    partial class ShowCommitmentPrintForm
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
            this.gbCriteria = new System.Windows.Forms.GroupBox();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblContract = new System.Windows.Forms.Label();
            this.cboContractCode = new System.Windows.Forms.ComboBox();
            this.gbCriteria.SuspendLayout();
            this.gbContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCriteria
            // 
            this.gbCriteria.Controls.Add(this.cboContractCode);
            this.gbCriteria.Controls.Add(this.lblContract);
            this.gbCriteria.Controls.Add(this.btnPrint);
            this.gbCriteria.Controls.Add(this.cboProduct);
            this.gbCriteria.Controls.Add(this.lblProduct);
            this.gbCriteria.Controls.Add(this.lblMonth);
            this.gbCriteria.Controls.Add(this.dtpMonth);
            this.gbCriteria.Controls.Add(this.lblCustomer);
            this.gbCriteria.Controls.Add(this.cboCustomer);
            this.gbCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCriteria.Location = new System.Drawing.Point(0, 0);
            this.gbCriteria.Name = "gbCriteria";
            this.gbCriteria.Size = new System.Drawing.Size(964, 101);
            this.gbCriteria.TabIndex = 0;
            this.gbCriteria.TabStop = false;
            this.gbCriteria.Text = "Điều kiện";
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.rptViewer);
            this.gbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbContent.Location = new System.Drawing.Point(0, 101);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(964, 356);
            this.gbContent.TabIndex = 1;
            this.gbContent.TabStop = false;
            this.gbContent.Text = "Nội dung";
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(105, 21);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(225, 28);
            this.cboCustomer.TabIndex = 0;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(16, 26);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(57, 20);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "Mã KH";
            // 
            // dtpMonth
            // 
            this.dtpMonth.Location = new System.Drawing.Point(485, 21);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(129, 26);
            this.dtpMonth.TabIndex = 2;
            this.dtpMonth.Validated += new System.EventHandler(this.dtpMonth_Validated);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(397, 24);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(54, 20);
            this.lblMonth.TabIndex = 3;
            this.lblMonth.Text = "Tháng";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(397, 62);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(82, 20);
            this.lblProduct.TabIndex = 4;
            this.lblProduct.Text = "Sản phẩm";
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(485, 59);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(294, 28);
            this.cboProduct.TabIndex = 5;
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(3, 22);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ServerReport.BearerToken = null;
            this.rptViewer.Size = new System.Drawing.Size(958, 331);
            this.rptViewer.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(834, 62);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 25);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblContract
            // 
            this.lblContract.AutoSize = true;
            this.lblContract.Location = new System.Drawing.Point(20, 62);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(79, 20);
            this.lblContract.TabIndex = 7;
            this.lblContract.Text = "Hợp đồng";
            // 
            // cboContractCode
            // 
            this.cboContractCode.FormattingEnabled = true;
            this.cboContractCode.Location = new System.Drawing.Point(105, 59);
            this.cboContractCode.Name = "cboContractCode";
            this.cboContractCode.Size = new System.Drawing.Size(138, 28);
            this.cboContractCode.TabIndex = 8;
            this.cboContractCode.SelectedIndexChanged += new System.EventHandler(this.cboContractCode_SelectedIndexChanged);
            // 
            // ShowCommitmentPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 457);
            this.Controls.Add(this.gbContent);
            this.Controls.Add(this.gbCriteria);
            this.Name = "ShowCommitmentPrintForm";
            this.Text = "Chứng nhận phát sóng";
            this.Load += new System.EventHandler(this.ShowCommitmentPrintForm_Load);
            this.gbCriteria.ResumeLayout(false);
            this.gbCriteria.PerformLayout();
            this.gbContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCriteria;
        private System.Windows.Forms.GroupBox gbContent;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label lblProduct;
        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cboContractCode;
        private System.Windows.Forms.Label lblContract;
    }
}