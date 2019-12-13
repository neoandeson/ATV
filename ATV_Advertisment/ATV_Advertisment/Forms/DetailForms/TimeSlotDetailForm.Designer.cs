using TControls;

namespace ATV_Advertisment.Forms.DetailForms
{
    partial class TimeSlotDetailForm
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
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.lblColon1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cboSession = new System.Windows.Forms.ComboBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSession = new System.Windows.Forms.Label();
            this.txtFromHour = new NumberTextBox(24);
            this.txtFromMinute = new NumberTextBox(60);
            this.lblFrom = new System.Windows.Forms.Label();
            this.cboDuration = new System.Windows.Forms.ComboBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.txtPrice = new TControls.MoneyTextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.gbCostRule = new System.Windows.Forms.GroupBox();
            this.cboShowType = new System.Windows.Forms.ComboBox();
            this.lblShowType = new System.Windows.Forms.Label();
            this.btnDeleteCostRule = new System.Windows.Forms.Button();
            this.adgv = new ADGV.AdvancedDataGridView();
            this.btnSaveCostRule = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.gbDetail.SuspendLayout();
            this.gbCostRule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).BeginInit();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.lblColon1);
            this.gbDetail.Controls.Add(this.txtCode);
            this.gbDetail.Controls.Add(this.txtName);
            this.gbDetail.Controls.Add(this.txtFromMinute);
            this.gbDetail.Controls.Add(this.cboSession);
            this.gbDetail.Controls.Add(this.lblCode);
            this.gbDetail.Controls.Add(this.txtFromHour);
            this.gbDetail.Controls.Add(this.lblName);
            this.gbDetail.Controls.Add(this.lblSession);
            this.gbDetail.Controls.Add(this.lblFrom);
            this.gbDetail.Location = new System.Drawing.Point(13, 11);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(555, 129);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Thông tin";
            // 
            // lblColon1
            // 
            this.lblColon1.AutoSize = true;
            this.lblColon1.Location = new System.Drawing.Point(468, 40);
            this.lblColon1.Name = "lblColon1";
            this.lblColon1.Size = new System.Drawing.Size(13, 20);
            this.lblColon1.TabIndex = 0;
            this.lblColon1.Text = ":";
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.Location = new System.Drawing.Point(305, 37);
            this.txtCode.MaxLength = 10;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(64, 26);
            this.txtCode.TabIndex = 2;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(78, 80);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(449, 26);
            this.txtName.TabIndex = 5;
            // 
            // txtFromMinute
            // 
            this.txtFromMinute.Location = new System.Drawing.Point(487, 37);
            this.txtFromMinute.MaxLength = 2;
            this.txtFromMinute.Name = "txtFromMinute";
            this.txtFromMinute.NumberValue = 0;
            this.txtFromMinute.Size = new System.Drawing.Size(40, 26);
            this.txtFromMinute.TabIndex = 4;
            // 
            // cboSession
            // 
            this.cboSession.FormattingEnabled = true;
            this.cboSession.Location = new System.Drawing.Point(78, 35);
            this.cboSession.Name = "cboSession";
            this.cboSession.Size = new System.Drawing.Size(164, 28);
            this.cboSession.TabIndex = 1;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(268, 38);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(31, 20);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Mã";
            // 
            // txtFromHour
            // 
            this.txtFromHour.Location = new System.Drawing.Point(425, 38);
            this.txtFromHour.MaxLength = 2;
            this.txtFromHour.Name = "txtFromHour";
            this.txtFromHour.NumberValue = 0;
            this.txtFromHour.Size = new System.Drawing.Size(40, 26);
            this.txtFromHour.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(21, 83);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(36, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Tên";
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Location = new System.Drawing.Point(21, 37);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(41, 20);
            this.lblSession.TabIndex = 0;
            this.lblSession.Text = "Buổi";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(390, 40);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(27, 20);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Từ";
            // 
            // cboDuration
            // 
            this.cboDuration.FormattingEnabled = true;
            this.cboDuration.Location = new System.Drawing.Point(122, 107);
            this.cboDuration.Name = "cboDuration";
            this.cboDuration.Size = new System.Drawing.Size(80, 28);
            this.cboDuration.TabIndex = 8;
            this.cboDuration.SelectedIndexChanged += new System.EventHandler(this.cboDuration_SelectedIndexChanged);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(280, 35);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(53, 20);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "(VNĐ)";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(122, 32);
            this.txtPrice.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(152, 26);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(21, 110);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(82, 20);
            this.lblLength.TabIndex = 0;
            this.lblLength.Text = "Thời lượng";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(21, 35);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 20);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "Giá";
            // 
            // gbCostRule
            // 
            this.gbCostRule.Controls.Add(this.cboShowType);
            this.gbCostRule.Controls.Add(this.lblShowType);
            this.gbCostRule.Controls.Add(this.btnDeleteCostRule);
            this.gbCostRule.Controls.Add(this.adgv);
            this.gbCostRule.Controls.Add(this.btnSaveCostRule);
            this.gbCostRule.Controls.Add(this.cboDuration);
            this.gbCostRule.Controls.Add(this.lblLength);
            this.gbCostRule.Controls.Add(this.lblCurrency);
            this.gbCostRule.Controls.Add(this.lblPrice);
            this.gbCostRule.Controls.Add(this.txtPrice);
            this.gbCostRule.Location = new System.Drawing.Point(13, 146);
            this.gbCostRule.Name = "gbCostRule";
            this.gbCostRule.Size = new System.Drawing.Size(555, 352);
            this.gbCostRule.TabIndex = 1;
            this.gbCostRule.TabStop = false;
            this.gbCostRule.Text = "Quy định giá tiền";
            // 
            // cboShowType
            // 
            this.cboShowType.FormattingEnabled = true;
            this.cboShowType.Location = new System.Drawing.Point(122, 67);
            this.cboShowType.Name = "cboShowType";
            this.cboShowType.Size = new System.Drawing.Size(152, 28);
            this.cboShowType.TabIndex = 7;
            // 
            // lblShowType
            // 
            this.lblShowType.AutoSize = true;
            this.lblShowType.Location = new System.Drawing.Point(21, 70);
            this.lblShowType.Name = "lblShowType";
            this.lblShowType.Size = new System.Drawing.Size(39, 20);
            this.lblShowType.TabIndex = 0;
            this.lblShowType.Text = "Loại";
            // 
            // btnDeleteCostRule
            // 
            this.btnDeleteCostRule.Location = new System.Drawing.Point(417, 65);
            this.btnDeleteCostRule.Name = "btnDeleteCostRule";
            this.btnDeleteCostRule.Size = new System.Drawing.Size(110, 30);
            this.btnDeleteCostRule.TabIndex = 10;
            this.btnDeleteCostRule.Text = "Xóa";
            this.btnDeleteCostRule.UseVisualStyleBackColor = true;
            this.btnDeleteCostRule.Click += new System.EventHandler(this.btnDeleteCostRule_Click);
            // 
            // adgv
            // 
            this.adgv.AutoGenerateContextFilters = true;
            this.adgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgv.DateWithTime = false;
            this.adgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.adgv.Location = new System.Drawing.Point(23, 149);
            this.adgv.MultiSelect = false;
            this.adgv.Name = "adgv";
            this.adgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgv.Size = new System.Drawing.Size(504, 191);
            this.adgv.TabIndex = 11;
            this.adgv.TimeFilter = false;
            this.adgv.SortStringChanged += new System.EventHandler(this.adgv_SortStringChanged);
            this.adgv.FilterStringChanged += new System.EventHandler(this.adgv_FilterStringChanged);
            this.adgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgv_CellClick);
            this.adgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.adgv_DataBindingComplete);
            // 
            // btnSaveCostRule
            // 
            this.btnSaveCostRule.Location = new System.Drawing.Point(417, 25);
            this.btnSaveCostRule.Name = "btnSaveCostRule";
            this.btnSaveCostRule.Size = new System.Drawing.Size(110, 30);
            this.btnSaveCostRule.TabIndex = 9;
            this.btnSaveCostRule.Text = "Lưu";
            this.btnSaveCostRule.UseVisualStyleBackColor = true;
            this.btnSaveCostRule.Click += new System.EventHandler(this.btnSaveCostRule_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(24, 24);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(179, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu thời điểm phát";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbControl
            // 
            this.gbControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new System.Drawing.Point(12, 504);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(556, 65);
            this.gbControl.TabIndex = 0;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // TimeSlotDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 581);
            this.Controls.Add(this.gbCostRule);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbDetail);
            this.Name = "TimeSlotDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin thời điểm phát";
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.gbCostRule.ResumeLayout(false);
            this.gbCostRule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).EndInit();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.ComboBox cboSession;
        private MoneyTextBox txtPrice;
        private NumberTextBox txtFromHour;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblColon1;
        private NumberTextBox txtFromMinute;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.ComboBox cboDuration;
        private System.Windows.Forms.GroupBox gbCostRule;
        private System.Windows.Forms.Button btnSaveCostRule;
        private ADGV.AdvancedDataGridView adgv;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnDeleteCostRule;
        private System.Windows.Forms.ComboBox cboShowType;
        private System.Windows.Forms.Label lblShowType;

        //this.txtFromHour = new NumberTextBox(24);
        //this.txtFromMinute = new NumberTextBox(60);
    }
}