namespace ATV_Advertisment.Forms.DetailForms
{
    partial class ContractItemDetailForm
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
            this.gbContractDetail = new System.Windows.Forms.GroupBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.cboShowType = new System.Windows.Forms.ComboBox();
            this.lblShowType = new System.Windows.Forms.Label();
            this.txtNumberOfShow = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtTotalCost = new TControls.MoneyTextBox();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.cboDuration = new System.Windows.Forms.ComboBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbRegisterSchedule = new System.Windows.Forms.GroupBox();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDeleteSchedule = new System.Windows.Forms.Button();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.adgv = new ADGV.AdvancedDataGridView();
            this.gbContractDetail.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.gbRegisterSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).BeginInit();
            this.SuspendLayout();
            // 
            // gbContractDetail
            // 
            this.gbContractDetail.Controls.Add(this.txtFileName);
            this.gbContractDetail.Controls.Add(this.labelFileName);
            this.gbContractDetail.Controls.Add(this.cboShowType);
            this.gbContractDetail.Controls.Add(this.lblShowType);
            this.gbContractDetail.Controls.Add(this.txtNumberOfShow);
            this.gbContractDetail.Controls.Add(this.lblQuantity);
            this.gbContractDetail.Controls.Add(this.txtTotalCost);
            this.gbContractDetail.Controls.Add(this.lblTotalCost);
            this.gbContractDetail.Controls.Add(this.lblDuration);
            this.gbContractDetail.Controls.Add(this.cboDuration);
            this.gbContractDetail.Controls.Add(this.lblProductName);
            this.gbContractDetail.Controls.Add(this.txtProductName);
            this.gbContractDetail.Location = new System.Drawing.Point(12, 12);
            this.gbContractDetail.Name = "gbContractDetail";
            this.gbContractDetail.Size = new System.Drawing.Size(1273, 117);
            this.gbContractDetail.TabIndex = 0;
            this.gbContractDetail.TabStop = false;
            this.gbContractDetail.Text = "Thông tin sản phẩm";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(146, 69);
            this.txtFileName.MaxLength = 200;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(345, 26);
            this.txtFileName.TabIndex = 5;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(20, 72);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(94, 20);
            this.labelFileName.TabIndex = 4;
            this.labelFileName.Text = "Mô tả Video";
            // 
            // cboShowType
            // 
            this.cboShowType.FormattingEnabled = true;
            this.cboShowType.Location = new System.Drawing.Point(664, 31);
            this.cboShowType.Name = "cboShowType";
            this.cboShowType.Size = new System.Drawing.Size(150, 28);
            this.cboShowType.TabIndex = 2;
            this.cboShowType.SelectedIndexChanged += new System.EventHandler(this.cboShowType_SelectedIndexChanged);
            // 
            // lblShowType
            // 
            this.lblShowType.AutoSize = true;
            this.lblShowType.Location = new System.Drawing.Point(551, 34);
            this.lblShowType.Name = "lblShowType";
            this.lblShowType.Size = new System.Drawing.Size(75, 20);
            this.lblShowType.TabIndex = 0;
            this.lblShowType.Text = "Loại phát";
            // 
            // txtNumberOfShow
            // 
            this.txtNumberOfShow.Location = new System.Drawing.Point(1055, 72);
            this.txtNumberOfShow.Name = "txtNumberOfShow";
            this.txtNumberOfShow.ReadOnly = true;
            this.txtNumberOfShow.Size = new System.Drawing.Size(46, 26);
            this.txtNumberOfShow.TabIndex = 0;
            this.txtNumberOfShow.Text = "0";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(929, 75);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(108, 20);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Số lượng phát";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(1055, 34);
            this.txtTotalCost.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(200, 26);
            this.txtTotalCost.TabIndex = 0;
            this.txtTotalCost.Text = "0";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(929, 34);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(75, 20);
            this.lblTotalCost.TabIndex = 0;
            this.lblTotalCost.Text = "Tổng tiền";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(551, 72);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(96, 20);
            this.lblDuration.TabIndex = 0;
            this.lblDuration.Text = "Độ dài video";
            // 
            // cboDuration
            // 
            this.cboDuration.FormattingEnabled = true;
            this.cboDuration.Location = new System.Drawing.Point(664, 65);
            this.cboDuration.Name = "cboDuration";
            this.cboDuration.Size = new System.Drawing.Size(80, 28);
            this.cboDuration.TabIndex = 3;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(17, 34);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(110, 20);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Tên sản phẩm";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(146, 31);
            this.txtProductName.MaxLength = 80;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(345, 26);
            this.txtProductName.TabIndex = 1;
            // 
            // gbControl
            // 
            this.gbControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new System.Drawing.Point(12, 654);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(1273, 67);
            this.gbControl.TabIndex = 1;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(20, 26);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbRegisterSchedule
            // 
            this.gbRegisterSchedule.Controls.Add(this.btnViewDetail);
            this.gbRegisterSchedule.Controls.Add(this.button1);
            this.gbRegisterSchedule.Controls.Add(this.btnDeleteSchedule);
            this.gbRegisterSchedule.Controls.Add(this.btnAddSchedule);
            this.gbRegisterSchedule.Controls.Add(this.adgv);
            this.gbRegisterSchedule.Location = new System.Drawing.Point(13, 135);
            this.gbRegisterSchedule.Name = "gbRegisterSchedule";
            this.gbRegisterSchedule.Size = new System.Drawing.Size(1272, 513);
            this.gbRegisterSchedule.TabIndex = 0;
            this.gbRegisterSchedule.TabStop = false;
            this.gbRegisterSchedule.Text = "Lịch đăng ký";
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(999, 25);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(110, 30);
            this.btnViewDetail.TabIndex = 4;
            this.btnViewDetail.Text = "Xem";
            this.btnViewDetail.UseVisualStyleBackColor = true;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(847, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Xóa lịch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btnDeleteSchedule_Click);
            // 
            // btnDeleteSchedule
            // 
            this.btnDeleteSchedule.Location = new System.Drawing.Point(726, 25);
            this.btnDeleteSchedule.Name = "btnDeleteSchedule";
            this.btnDeleteSchedule.Size = new System.Drawing.Size(110, 30);
            this.btnDeleteSchedule.TabIndex = 6;
            this.btnDeleteSchedule.Text = "Xóa lịch";
            this.btnDeleteSchedule.UseVisualStyleBackColor = true;
            this.btnDeleteSchedule.Visible = false;
            this.btnDeleteSchedule.Click += new System.EventHandler(this.btnDeleteSchedule_Click);
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Location = new System.Drawing.Point(1144, 25);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(110, 30);
            this.btnAddSchedule.TabIndex = 5;
            this.btnAddSchedule.Text = "Thêm lịch";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // adgv
            // 
            this.adgv.AutoGenerateContextFilters = true;
            this.adgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgv.DateWithTime = false;
            this.adgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.adgv.Location = new System.Drawing.Point(20, 61);
            this.adgv.MultiSelect = false;
            this.adgv.Name = "adgv";
            this.adgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgv.Size = new System.Drawing.Size(1234, 446);
            this.adgv.TabIndex = 0;
            this.adgv.TimeFilter = false;
            this.adgv.SortStringChanged += new System.EventHandler(this.adgv_SortStringChanged);
            this.adgv.FilterStringChanged += new System.EventHandler(this.adgv_FilterStringChanged);
            this.adgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgv_CellClick);
            this.adgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.adgv_DataBindingComplete);
            // 
            // ContractItemDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 733);
            this.Controls.Add(this.gbRegisterSchedule);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbContractDetail);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "ContractItemDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết sản phẩm";
            this.gbContractDetail.ResumeLayout(false);
            this.gbContractDetail.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.gbRegisterSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbContractDetail;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.ComboBox cboDuration;
        private System.Windows.Forms.GroupBox gbRegisterSchedule;
        private ADGV.AdvancedDataGridView adgv;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnDeleteSchedule;
        private System.Windows.Forms.Button btnSave;
        private TControls.MoneyTextBox txtTotalCost;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtNumberOfShow;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.ComboBox cboShowType;
        private System.Windows.Forms.Label lblShowType;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button button1;
    }
}