namespace ATV_Advertisment.Forms.DetailForms
{
    partial class DiscountDetailForm
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
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtPriceRate = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblPriceRate = new System.Windows.Forms.Label();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbDetail.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.lblCurrency);
            this.gbDetail.Controls.Add(this.txtDiscount);
            this.gbDetail.Controls.Add(this.txtPriceRate);
            this.gbDetail.Controls.Add(this.lblDiscount);
            this.gbDetail.Controls.Add(this.lblPriceRate);
            this.gbDetail.Location = new System.Drawing.Point(12, 12);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(776, 81);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Thông tin";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(398, 39);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(43, 20);
            this.lblCurrency.TabIndex = 4;
            this.lblCurrency.Text = "VNĐ";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(645, 36);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(92, 26);
            this.txtDiscount.TabIndex = 3;
            // 
            // txtPriceRate
            // 
            this.txtPriceRate.Location = new System.Drawing.Point(106, 38);
            this.txtPriceRate.Name = "txtPriceRate";
            this.txtPriceRate.Size = new System.Drawing.Size(286, 26);
            this.txtPriceRate.TabIndex = 2;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(550, 39);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(69, 20);
            this.lblDiscount.TabIndex = 1;
            this.lblDiscount.Text = "Tỷ lệ (%)";
            // 
            // lblPriceRate
            // 
            this.lblPriceRate.AutoSize = true;
            this.lblPriceRate.Location = new System.Drawing.Point(20, 39);
            this.lblPriceRate.Name = "lblPriceRate";
            this.lblPriceRate.Size = new System.Drawing.Size(64, 20);
            this.lblPriceRate.TabIndex = 0;
            this.lblPriceRate.Text = "Mức giá";
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new System.Drawing.Point(13, 99);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(775, 66);
            this.gbControl.TabIndex = 1;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(23, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DiscountDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 171);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbDetail);
            this.Name = "DiscountDetailForm";
            this.Text = "Thông tin giảm giá";
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.GroupBox gbControl;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblPriceRate;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtPriceRate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCurrency;
    }
}