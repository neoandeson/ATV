namespace ATV_Advertisment.Forms.DetailForms
{
    partial class ContractDetailForm
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
            this.gbCustomerInfo = new System.Windows.Forms.GroupBox();
            this.btnCustomerDetail = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblTaxCode = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtDiscount = new TControls.NumberTextBox(100);
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.gbContractDetail = new System.Windows.Forms.GroupBox();
            this.btnViewDtail = new System.Windows.Forms.Button();
            this.btnDeleteDetail = new System.Windows.Forms.Button();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.lblNOProducts = new System.Windows.Forms.Label();
            this.adgv = new ADGV.AdvancedDataGridView();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtCost = new TControls.MoneyTextBox();
            this.gbContractInfo = new System.Windows.Forms.GroupBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.txtTotalCost = new TControls.MoneyTextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblContractCode = new System.Windows.Forms.Label();
            this.lblCurrency2 = new System.Windows.Forms.Label();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbCustomerInfo.SuspendLayout();
            this.gbContractDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).BeginInit();
            this.gbContractInfo.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCustomerInfo
            // 
            this.gbCustomerInfo.Controls.Add(this.btnCustomerDetail);
            this.gbCustomerInfo.Controls.Add(this.txtCustomerName);
            this.gbCustomerInfo.Controls.Add(this.lblTaxCode);
            this.gbCustomerInfo.Controls.Add(this.txtCustomerCode);
            this.gbCustomerInfo.Controls.Add(this.lblCustomerCode);
            this.gbCustomerInfo.Location = new System.Drawing.Point(13, 13);
            this.gbCustomerInfo.Name = "gbCustomerInfo";
            this.gbCustomerInfo.Size = new System.Drawing.Size(885, 69);
            this.gbCustomerInfo.TabIndex = 0;
            this.gbCustomerInfo.TabStop = false;
            this.gbCustomerInfo.Text = "Khách hàng";
            // 
            // btnCustomerDetail
            // 
            this.btnCustomerDetail.Location = new System.Drawing.Point(317, 30);
            this.btnCustomerDetail.Name = "btnCustomerDetail";
            this.btnCustomerDetail.Size = new System.Drawing.Size(25, 25);
            this.btnCustomerDetail.TabIndex = 0;
            this.btnCustomerDetail.UseVisualStyleBackColor = true;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(404, 29);
            this.txtCustomerName.MaxLength = 10;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(459, 26);
            this.txtCustomerName.TabIndex = 2;
            // 
            // lblTaxCode
            // 
            this.lblTaxCode.AutoSize = true;
            this.lblTaxCode.Location = new System.Drawing.Point(369, 32);
            this.lblTaxCode.Name = "lblTaxCode";
            this.lblTaxCode.Size = new System.Drawing.Size(0, 20);
            this.lblTaxCode.TabIndex = 15;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCustomerCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCustomerCode.Location = new System.Drawing.Point(134, 29);
            this.txtCustomerCode.MaxLength = 20;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(177, 26);
            this.txtCustomerCode.TabIndex = 1;
            this.txtCustomerCode.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Location = new System.Drawing.Point(19, 32);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(57, 20);
            this.lblCustomerCode.TabIndex = 0;
            this.lblCustomerCode.Text = "Mã KH";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(714, 77);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(146, 26);
            this.dtpEndDate.TabIndex = 4;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(714, 33);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(146, 26);
            this.dtpStartDate.TabIndex = 3;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(602, 82);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(106, 20);
            this.lblEndDate.TabIndex = 0;
            this.lblEndDate.Text = "Ngày kết thúc";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(487, 79);
            this.txtDiscount.MaxLength = 100;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.NumberValue = 0;
            this.txtDiscount.Size = new System.Drawing.Size(56, 26);
            this.txtDiscount.TabIndex = 19;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(602, 38);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(103, 20);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Ngày bắt đầu";
            // 
            // gbContractDetail
            // 
            this.gbContractDetail.Controls.Add(this.btnViewDtail);
            this.gbContractDetail.Controls.Add(this.btnDeleteDetail);
            this.gbContractDetail.Controls.Add(this.btnAddDetail);
            this.gbContractDetail.Controls.Add(this.lblNOProducts);
            this.gbContractDetail.Controls.Add(this.adgv);
            this.gbContractDetail.Location = new System.Drawing.Point(13, 264);
            this.gbContractDetail.Name = "gbContractDetail";
            this.gbContractDetail.Size = new System.Drawing.Size(885, 281);
            this.gbContractDetail.TabIndex = 0;
            this.gbContractDetail.TabStop = false;
            this.gbContractDetail.Text = "Nội dung";
            // 
            // btnViewDtail
            // 
            this.btnViewDtail.Location = new System.Drawing.Point(477, 241);
            this.btnViewDtail.Name = "btnViewDtail";
            this.btnViewDtail.Size = new System.Drawing.Size(110, 30);
            this.btnViewDtail.TabIndex = 5;
            this.btnViewDtail.Text = "Xem";
            this.btnViewDtail.UseVisualStyleBackColor = true;
            this.btnViewDtail.Click += new System.EventHandler(this.btnViewDtail_Click);
            // 
            // btnDeleteDetail
            // 
            this.btnDeleteDetail.Location = new System.Drawing.Point(769, 241);
            this.btnDeleteDetail.Name = "btnDeleteDetail";
            this.btnDeleteDetail.Size = new System.Drawing.Size(110, 30);
            this.btnDeleteDetail.TabIndex = 7;
            this.btnDeleteDetail.Text = "Xóa";
            this.btnDeleteDetail.UseVisualStyleBackColor = true;
            this.btnDeleteDetail.Click += new System.EventHandler(this.btnDeleteDetail_Click);
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Location = new System.Drawing.Point(622, 241);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(110, 30);
            this.btnAddDetail.TabIndex = 6;
            this.btnAddDetail.Text = "Thêm";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // lblNOProducts
            // 
            this.lblNOProducts.AutoSize = true;
            this.lblNOProducts.Location = new System.Drawing.Point(776, 22);
            this.lblNOProducts.Name = "lblNOProducts";
            this.lblNOProducts.Size = new System.Drawing.Size(103, 20);
            this.lblNOProducts.TabIndex = 0;
            this.lblNOProducts.Text = "Số sản phẩm";
            // 
            // adgv
            // 
            this.adgv.AutoGenerateContextFilters = true;
            this.adgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgv.DateWithTime = false;
            this.adgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.adgv.Location = new System.Drawing.Point(6, 45);
            this.adgv.MultiSelect = false;
            this.adgv.Name = "adgv";
            this.adgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgv.Size = new System.Drawing.Size(873, 177);
            this.adgv.TabIndex = 0;
            this.adgv.TimeFilter = false;
            this.adgv.SortStringChanged += new System.EventHandler(this.adgv_SortStringChanged);
            this.adgv.FilterStringChanged += new System.EventHandler(this.adgv_FilterStringChanged);
            this.adgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgv_CellClick);
            this.adgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.adgv_DataBindingComplete);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(19, 82);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(79, 20);
            this.lblCost.TabIndex = 0;
            this.lblCost.Text = "Giá trị HĐ";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(134, 79);
            this.txtCost.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.Size = new System.Drawing.Size(179, 26);
            this.txtCost.TabIndex = 17;
            this.txtCost.Text = "0";
            // 
            // gbContractInfo
            // 
            this.gbContractInfo.Controls.Add(this.lblPercent);
            this.gbContractInfo.Controls.Add(this.lblTotalCost);
            this.gbContractInfo.Controls.Add(this.txtTotalCost);
            this.gbContractInfo.Controls.Add(this.txtDiscount);
            this.gbContractInfo.Controls.Add(this.lblDiscount);
            this.gbContractInfo.Controls.Add(this.txtCode);
            this.gbContractInfo.Controls.Add(this.lblContractCode);
            this.gbContractInfo.Controls.Add(this.lblCurrency2);
            this.gbContractInfo.Controls.Add(this.txtCost);
            this.gbContractInfo.Controls.Add(this.dtpStartDate);
            this.gbContractInfo.Controls.Add(this.lblStartDate);
            this.gbContractInfo.Controls.Add(this.lblCost);
            this.gbContractInfo.Controls.Add(this.lblEndDate);
            this.gbContractInfo.Controls.Add(this.dtpEndDate);
            this.gbContractInfo.Location = new System.Drawing.Point(13, 88);
            this.gbContractInfo.Name = "gbContractInfo";
            this.gbContractInfo.Size = new System.Drawing.Size(885, 170);
            this.gbContractInfo.TabIndex = 0;
            this.gbContractInfo.TabStop = false;
            this.gbContractInfo.Text = "Hợp đồng";
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(549, 81);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(23, 20);
            this.lblPercent.TabIndex = 22;
            this.lblPercent.Text = "%";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(19, 126);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(84, 20);
            this.lblTotalCost.TabIndex = 21;
            this.lblTotalCost.Text = "Thành tiền";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(134, 123);
            this.txtTotalCost.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(179, 26);
            this.txtTotalCost.TabIndex = 20;
            this.txtTotalCost.Text = "0";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(400, 82);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(72, 20);
            this.lblDiscount.TabIndex = 18;
            this.lblDiscount.Text = "Giảm giá";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(134, 35);
            this.txtCode.MaxLength = 8;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(108, 26);
            this.txtCode.TabIndex = 0;
            // 
            // lblContractCode
            // 
            this.lblContractCode.AutoSize = true;
            this.lblContractCode.Location = new System.Drawing.Point(19, 38);
            this.lblContractCode.Name = "lblContractCode";
            this.lblContractCode.Size = new System.Drawing.Size(59, 20);
            this.lblContractCode.TabIndex = 0;
            this.lblContractCode.Text = "Mã HĐ";
            // 
            // lblCurrency2
            // 
            this.lblCurrency2.AutoSize = true;
            this.lblCurrency2.Location = new System.Drawing.Point(319, 81);
            this.lblCurrency2.Name = "lblCurrency2";
            this.lblCurrency2.Size = new System.Drawing.Size(43, 20);
            this.lblCurrency2.TabIndex = 0;
            this.lblCurrency2.Text = "VNĐ";
            // 
            // gbControl
            // 
            this.gbControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbControl.Controls.Add(this.btnCancel);
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new System.Drawing.Point(13, 551);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(885, 70);
            this.gbControl.TabIndex = 0;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(170, 26);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(26, 26);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ContractDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 629);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbContractInfo);
            this.Controls.Add(this.gbContractDetail);
            this.Controls.Add(this.gbCustomerInfo);
            this.Name = "ContractDetailForm";
            this.Text = "Thông tin hợp đồng";
            this.gbCustomerInfo.ResumeLayout(false);
            this.gbCustomerInfo.PerformLayout();
            this.gbContractDetail.ResumeLayout(false);
            this.gbContractDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).EndInit();
            this.gbContractInfo.ResumeLayout(false);
            this.gbContractInfo.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCustomerInfo;
        private System.Windows.Forms.GroupBox gbContractDetail;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblCustomerCode;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblTaxCode;
        private System.Windows.Forms.Label lblCost;
        private TControls.MoneyTextBox txtCost;
        private System.Windows.Forms.GroupBox gbContractInfo;
        private System.Windows.Forms.Label lblCurrency2;
        private System.Windows.Forms.Button btnCustomerDetail;
        private ADGV.AdvancedDataGridView adgv;
        private System.Windows.Forms.Label lblNOProducts;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Button btnViewDtail;
        private System.Windows.Forms.Button btnDeleteDetail;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblContractCode;
        private System.Windows.Forms.Label lblTotalCost;
        private TControls.MoneyTextBox txtTotalCost;
        private TControls.NumberTextBox txtDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblPercent;
        //this.txtDiscount = new TControls.NumberTextBox(100);
    }
}