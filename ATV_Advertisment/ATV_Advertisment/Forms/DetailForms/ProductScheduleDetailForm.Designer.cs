namespace ATV_Advertisment.Forms.DetailForms
{
    partial class ProductScheduleDetailForm
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
            this.mpShowDate = new System.Windows.Forms.MonthCalendar();
            this.lblSecond = new System.Windows.Forms.Label();
            this.txtTimeSlotLength = new System.Windows.Forms.TextBox();
            this.cboTimeSlot = new System.Windows.Forms.ComboBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtTotalCost = new TControls.MoneyTextBox();
            this.txtCost = new TControls.MoneyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTimeSlot = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblShowDate = new System.Windows.Forms.Label();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.txtSumCost = new TControls.MoneyTextBox();
            this.gbDetail.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.txtSumCost);
            this.gbDetail.Controls.Add(this.lblTotalCost);
            this.gbDetail.Controls.Add(this.mpShowDate);
            this.gbDetail.Controls.Add(this.lblSecond);
            this.gbDetail.Controls.Add(this.txtTimeSlotLength);
            this.gbDetail.Controls.Add(this.cboTimeSlot);
            this.gbDetail.Controls.Add(this.txtDiscount);
            this.gbDetail.Controls.Add(this.txtQuantity);
            this.gbDetail.Controls.Add(this.txtTotalCost);
            this.gbDetail.Controls.Add(this.txtCost);
            this.gbDetail.Controls.Add(this.label1);
            this.gbDetail.Controls.Add(this.label6);
            this.gbDetail.Controls.Add(this.label5);
            this.gbDetail.Controls.Add(this.lblTimeSlot);
            this.gbDetail.Controls.Add(this.lbl);
            this.gbDetail.Controls.Add(this.label2);
            this.gbDetail.Controls.Add(this.lblShowDate);
            this.gbDetail.Location = new System.Drawing.Point(13, 13);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(737, 458);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Thông tin lịch";
            // 
            // mpShowDate
            // 
            this.mpShowDate.CalendarDimensions = new System.Drawing.Size(3, 1);
            this.mpShowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mpShowDate.Location = new System.Drawing.Point(24, 284);
            this.mpShowDate.MaxSelectionCount = 120;
            this.mpShowDate.Name = "mpShowDate";
            this.mpShowDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mpShowDate.TabIndex = 7;
            this.mpShowDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mpShowDate_MouseDown);
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(595, 42);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(27, 20);
            this.lblSecond.TabIndex = 0;
            this.lblSecond.Text = "(s)";
            // 
            // txtTimeSlotLength
            // 
            this.txtTimeSlotLength.Location = new System.Drawing.Point(517, 39);
            this.txtTimeSlotLength.Name = "txtTimeSlotLength";
            this.txtTimeSlotLength.ReadOnly = true;
            this.txtTimeSlotLength.Size = new System.Drawing.Size(72, 26);
            this.txtTimeSlotLength.TabIndex = 4;
            // 
            // cboTimeSlot
            // 
            this.cboTimeSlot.FormattingEnabled = true;
            this.cboTimeSlot.Location = new System.Drawing.Point(155, 36);
            this.cboTimeSlot.Name = "cboTimeSlot";
            this.cboTimeSlot.Size = new System.Drawing.Size(238, 28);
            this.cboTimeSlot.TabIndex = 1;
            this.cboTimeSlot.SelectedIndexChanged += new System.EventHandler(this.cboTimeSlot_SelectedIndexChanged);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(515, 175);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(74, 26);
            this.txtDiscount.TabIndex = 5;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(155, 81);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(72, 26);
            this.txtQuantity.TabIndex = 10;
            this.txtQuantity.Text = "1";
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(513, 225);
            this.txtTotalCost.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(200, 26);
            this.txtTotalCost.TabIndex = 6;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(155, 128);
            this.txtCost.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.Size = new System.Drawing.Size(238, 26);
            this.txtCost.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thành tiền";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(423, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Giảm giá";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(423, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Thời lượng";
            // 
            // lblTimeSlot
            // 
            this.lblTimeSlot.AutoSize = true;
            this.lblTimeSlot.Location = new System.Drawing.Point(21, 36);
            this.lblTimeSlot.Name = "lblTimeSlot";
            this.lblTimeSlot.Size = new System.Drawing.Size(113, 20);
            this.lblTimeSlot.TabIndex = 3;
            this.lblTimeSlot.Text = "Thời điểm phát";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(21, 131);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(122, 20);
            this.lbl.TabIndex = 2;
            this.lbl.Text = "Giá tiền 1 đơn vị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số lượng";
            // 
            // lblShowDate
            // 
            this.lblShowDate.AutoSize = true;
            this.lblShowDate.Location = new System.Drawing.Point(20, 255);
            this.lblShowDate.Name = "lblShowDate";
            this.lblShowDate.Size = new System.Drawing.Size(87, 20);
            this.lblShowDate.TabIndex = 0;
            this.lblShowDate.Text = "Ngày chiếu";
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new System.Drawing.Point(13, 477);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(738, 62);
            this.gbControl.TabIndex = 0;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(24, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(21, 178);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(75, 20);
            this.lblTotalCost.TabIndex = 11;
            this.lblTotalCost.Text = "Tổng tiền";
            // 
            // txtSumCost
            // 
            this.txtSumCost.Location = new System.Drawing.Point(155, 175);
            this.txtSumCost.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSumCost.Name = "txtSumCost";
            this.txtSumCost.Size = new System.Drawing.Size(238, 26);
            this.txtSumCost.TabIndex = 12;
            // 
            // ProductScheduleDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 551);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbDetail);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "ProductScheduleDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết lịch";
            this.Load += new System.EventHandler(this.ProductScheduleDetailForm_Load);
            this.Shown += new System.EventHandler(this.ProductScheduleDetailForm_Shown);
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTimeSlot;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblShowDate;
        private System.Windows.Forms.Label label1;
        private TControls.MoneyTextBox txtTotalCost;
        private TControls.MoneyTextBox txtCost;
        private System.Windows.Forms.ComboBox cboTimeSlot;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTimeSlotLength;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.MonthCalendar mpShowDate;
        private TControls.MoneyTextBox txtSumCost;
        private System.Windows.Forms.Label lblTotalCost;
    }
}