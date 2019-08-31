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
            this.lblCurrency = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblColon1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtPrice = new TControls.MoneyTextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cboSession = new System.Windows.Forms.ComboBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSession = new System.Windows.Forms.Label();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbDetail.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.lblCurrency);
            this.gbDetail.Controls.Add(this.label1);
            this.gbDetail.Controls.Add(this.lblColon1);
            this.gbDetail.Controls.Add(this.txtToMinute);
            this.gbDetail.Controls.Add(this.txtFromMinute);
            this.gbDetail.Controls.Add(this.txtCode);
            this.gbDetail.Controls.Add(this.txtToHour);
            this.gbDetail.Controls.Add(this.txtPrice);
            this.gbDetail.Controls.Add(this.txtFromHour);
            this.gbDetail.Controls.Add(this.txtName);
            this.gbDetail.Controls.Add(this.cboSession);
            this.gbDetail.Controls.Add(this.lblTo);
            this.gbDetail.Controls.Add(this.lblPrice);
            this.gbDetail.Controls.Add(this.lblCode);
            this.gbDetail.Controls.Add(this.lblFrom);
            this.gbDetail.Controls.Add(this.lblName);
            this.gbDetail.Controls.Add(this.lblSession);
            this.gbDetail.Location = new System.Drawing.Point(13, 11);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(505, 262);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Thông tin";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(434, 157);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(43, 20);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "VNĐ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = ":";
            // 
            // lblColon1
            // 
            this.lblColon1.AutoSize = true;
            this.lblColon1.Location = new System.Drawing.Point(124, 157);
            this.lblColon1.Name = "lblColon1";
            this.lblColon1.Size = new System.Drawing.Size(13, 20);
            this.lblColon1.TabIndex = 0;
            this.lblColon1.Text = ":";
            // 
            // txtToMinute
            // 
            this.txtToMinute.Location = new System.Drawing.Point(143, 208);
            this.txtToMinute.MaxLength = 2;
            this.txtToMinute.Name = "txtToMinute";
            this.txtToMinute.NumberValue = 0;
            this.txtToMinute.Size = new System.Drawing.Size(40, 26);
            this.txtToMinute.TabIndex = 7;
            // 
            // txtFromMinute
            // 
            this.txtFromMinute.Location = new System.Drawing.Point(143, 154);
            this.txtFromMinute.MaxLength = 2;
            this.txtFromMinute.Name = "txtFromMinute";
            this.txtFromMinute.NumberValue = 0;
            this.txtFromMinute.Size = new System.Drawing.Size(40, 26);
            this.txtFromMinute.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(387, 37);
            this.txtCode.MaxLength = 10;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(90, 26);
            this.txtCode.TabIndex = 2;
            this.txtCode.Validated += new System.EventHandler(this.txtCode_Validated);
            // 
            // txtToHour
            // 
            this.txtToHour.Location = new System.Drawing.Point(78, 208);
            this.txtToHour.MaxLength = 2;
            this.txtToHour.Name = "txtToHour";
            this.txtToHour.NumberValue = 0;
            this.txtToHour.Size = new System.Drawing.Size(40, 26);
            this.txtToHour.TabIndex = 6;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(276, 154);
            this.txtPrice.MoneyValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(152, 26);
            this.txtPrice.TabIndex = 8;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFromHour
            // 
            this.txtFromHour.Location = new System.Drawing.Point(78, 154);
            this.txtFromHour.MaxLength = 2;
            this.txtFromHour.Name = "txtFromHour";
            this.txtFromHour.NumberValue = 0;
            this.txtFromHour.Size = new System.Drawing.Size(40, 26);
            this.txtFromHour.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(78, 94);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(399, 26);
            this.txtName.TabIndex = 3;
            // 
            // cboSession
            // 
            this.cboSession.FormattingEnabled = true;
            this.cboSession.Location = new System.Drawing.Point(78, 35);
            this.cboSession.Name = "cboSession";
            this.cboSession.Size = new System.Drawing.Size(164, 28);
            this.cboSession.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(21, 211);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(39, 20);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "Đến";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(236, 157);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 20);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "Giá";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(350, 38);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(31, 20);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Mã";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(21, 157);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(27, 20);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Từ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(21, 97);
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
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new System.Drawing.Point(13, 279);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(505, 65);
            this.gbControl.TabIndex = 0;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(24, 24);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TimeSlotDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 355);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbDetail);
            this.Name = "TimeSlotDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin thời điểm phát";
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.ComboBox cboSession;
        private NumberTextBox txtToHour;
        private MoneyTextBox txtPrice;
        private NumberTextBox txtFromHour;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblColon1;
        private NumberTextBox txtToMinute;
        private NumberTextBox txtFromMinute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCurrency;
    }
}