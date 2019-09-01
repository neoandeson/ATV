namespace ATV_Advertisment.Forms.DetailForms
{
    partial class ContractDetailDetailForm
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
            this.txtTotalCost = new TControls.MoneyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.cboDuration = new System.Windows.Forms.ComboBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbRegisterSchedule = new System.Windows.Forms.GroupBox();
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
            this.gbContractDetail.Controls.Add(this.txtTotalCost);
            this.gbContractDetail.Controls.Add(this.label3);
            this.gbContractDetail.Controls.Add(this.lblDuration);
            this.gbContractDetail.Controls.Add(this.cboDuration);
            this.gbContractDetail.Controls.Add(this.lblProductName);
            this.gbContractDetail.Controls.Add(this.txtProductName);
            this.gbContractDetail.Location = new System.Drawing.Point(12, 12);
            this.gbContractDetail.Name = "gbContractDetail";
            this.gbContractDetail.Size = new System.Drawing.Size(1011, 117);
            this.gbContractDetail.TabIndex = 0;
            this.gbContractDetail.TabStop = false;
            this.gbContractDetail.Text = "Thông tin sản phẩm";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(785, 34);
            this.txtTotalCost.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(200, 26);
            this.txtTotalCost.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(681, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Thành tiền";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(17, 78);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(82, 20);
            this.lblDuration.TabIndex = 4;
            this.lblDuration.Text = "Thời lượng";
            // 
            // cboDuration
            // 
            this.cboDuration.FormattingEnabled = true;
            this.cboDuration.Location = new System.Drawing.Point(146, 75);
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
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Tên sản phẩm";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(146, 31);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(300, 26);
            this.txtProductName.TabIndex = 1;
            // 
            // gbControl
            // 
            this.gbControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new System.Drawing.Point(12, 654);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(1011, 67);
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
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // gbRegisterSchedule
            // 
            this.gbRegisterSchedule.Controls.Add(this.btnDeleteSchedule);
            this.gbRegisterSchedule.Controls.Add(this.btnAddSchedule);
            this.gbRegisterSchedule.Controls.Add(this.adgv);
            this.gbRegisterSchedule.Location = new System.Drawing.Point(13, 135);
            this.gbRegisterSchedule.Name = "gbRegisterSchedule";
            this.gbRegisterSchedule.Size = new System.Drawing.Size(1010, 513);
            this.gbRegisterSchedule.TabIndex = 2;
            this.gbRegisterSchedule.TabStop = false;
            this.gbRegisterSchedule.Text = "Lịch đăng ký";
            // 
            // btnDeleteSchedule
            // 
            this.btnDeleteSchedule.Location = new System.Drawing.Point(876, 25);
            this.btnDeleteSchedule.Name = "btnDeleteSchedule";
            this.btnDeleteSchedule.Size = new System.Drawing.Size(110, 30);
            this.btnDeleteSchedule.TabIndex = 2;
            this.btnDeleteSchedule.Text = "Xóa lịch";
            this.btnDeleteSchedule.UseVisualStyleBackColor = true;
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Location = new System.Drawing.Point(725, 25);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(110, 30);
            this.btnAddSchedule.TabIndex = 1;
            this.btnAddSchedule.Text = "Thêm lịch";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            // 
            // adgv
            // 
            this.adgv.AutoGenerateContextFilters = true;
            this.adgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgv.DateWithTime = false;
            this.adgv.Location = new System.Drawing.Point(20, 61);
            this.adgv.Name = "adgv";
            this.adgv.Size = new System.Drawing.Size(966, 446);
            this.adgv.TabIndex = 0;
            this.adgv.TimeFilter = false;
            // 
            // ContractDetailDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 733);
            this.Controls.Add(this.gbRegisterSchedule);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbContractDetail);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "ContractDetailDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết hợp đồng";
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
        private System.Windows.Forms.Label label3;
    }
}