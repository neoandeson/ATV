﻿namespace ATV_Advertisment.Forms.DetailForms
{
    partial class CustomerDetailForm
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
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.txtTaxCode = new System.Windows.Forms.TextBox();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblTaxCode = new System.Windows.Forms.Label();
            this.lblFax = new System.Windows.Forms.Label();
            this.lblPhone2 = new System.Windows.Forms.Label();
            this.lblPhone1 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbCustomerInfo.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCustomerInfo
            // 
            this.gbCustomerInfo.Controls.Add(this.txtFax);
            this.gbCustomerInfo.Controls.Add(this.txtCode);
            this.gbCustomerInfo.Controls.Add(this.txtPhone2);
            this.gbCustomerInfo.Controls.Add(this.txtTaxCode);
            this.gbCustomerInfo.Controls.Add(this.txtPhone1);
            this.gbCustomerInfo.Controls.Add(this.txtAddress);
            this.gbCustomerInfo.Controls.Add(this.txtName);
            this.gbCustomerInfo.Controls.Add(this.lblCode);
            this.gbCustomerInfo.Controls.Add(this.lblTaxCode);
            this.gbCustomerInfo.Controls.Add(this.lblFax);
            this.gbCustomerInfo.Controls.Add(this.lblPhone2);
            this.gbCustomerInfo.Controls.Add(this.lblPhone1);
            this.gbCustomerInfo.Controls.Add(this.lblAddress);
            this.gbCustomerInfo.Controls.Add(this.lblName);
            this.gbCustomerInfo.Location = new System.Drawing.Point(13, 14);
            this.gbCustomerInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCustomerInfo.Name = "gbCustomerInfo";
            this.gbCustomerInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCustomerInfo.Size = new System.Drawing.Size(744, 289);
            this.gbCustomerInfo.TabIndex = 0;
            this.gbCustomerInfo.TabStop = false;
            this.gbCustomerInfo.Text = "Thông tin";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(116, 239);
            this.txtFax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFax.MaxLength = 14;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(200, 26);
            this.txtFax.TabIndex = 7;
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFax_KeyPress);
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.Location = new System.Drawing.Point(116, 39);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(200, 26);
            this.txtCode.TabIndex = 1;
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(510, 191);
            this.txtPhone2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhone2.MaxLength = 14;
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(200, 26);
            this.txtPhone2.TabIndex = 6;
            this.txtPhone2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone2_KeyPress);
            // 
            // txtTaxCode
            // 
            this.txtTaxCode.Location = new System.Drawing.Point(510, 242);
            this.txtTaxCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTaxCode.MaxLength = 10;
            this.txtTaxCode.Name = "txtTaxCode";
            this.txtTaxCode.Size = new System.Drawing.Size(163, 26);
            this.txtTaxCode.TabIndex = 8;
            this.txtTaxCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaxCode_KeyPress);
            // 
            // txtPhone1
            // 
            this.txtPhone1.Location = new System.Drawing.Point(116, 194);
            this.txtPhone1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhone1.MaxLength = 14;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(200, 26);
            this.txtPhone1.TabIndex = 5;
            this.txtPhone1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone1_KeyPress);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(116, 147);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(594, 26);
            this.txtAddress.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(116, 104);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(594, 26);
            this.txtName.TabIndex = 3;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(22, 42);
            this.lblCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(31, 20);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Mã";
            // 
            // lblTaxCode
            // 
            this.lblTaxCode.AutoSize = true;
            this.lblTaxCode.Location = new System.Drawing.Point(397, 242);
            this.lblTaxCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTaxCode.Name = "lblTaxCode";
            this.lblTaxCode.Size = new System.Drawing.Size(88, 20);
            this.lblTaxCode.TabIndex = 0;
            this.lblTaxCode.Text = "Mã số thuế";
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(22, 239);
            this.lblFax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(35, 20);
            this.lblFax.TabIndex = 0;
            this.lblFax.Text = "Fax";
            // 
            // lblPhone2
            // 
            this.lblPhone2.AutoSize = true;
            this.lblPhone2.Location = new System.Drawing.Point(397, 194);
            this.lblPhone2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone2.Name = "lblPhone2";
            this.lblPhone2.Size = new System.Drawing.Size(54, 20);
            this.lblPhone2.TabIndex = 0;
            this.lblPhone2.Text = "SĐT 2";
            // 
            // lblPhone1
            // 
            this.lblPhone1.AutoSize = true;
            this.lblPhone1.Location = new System.Drawing.Point(22, 197);
            this.lblPhone1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone1.Name = "lblPhone1";
            this.lblPhone1.Size = new System.Drawing.Size(54, 20);
            this.lblPhone1.TabIndex = 0;
            this.lblPhone1.Text = "SĐT 1";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(22, 150);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(57, 20);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Địa chỉ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(22, 104);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(36, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Tên";
            // 
            // gbControl
            // 
            this.gbControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new System.Drawing.Point(13, 311);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(750, 63);
            this.gbControl.TabIndex = 0;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(24, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CustomerDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 385);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbCustomerInfo);
            this.Name = "CustomerDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin khách hàng";
            this.gbCustomerInfo.ResumeLayout(false);
            this.gbCustomerInfo.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCustomerInfo;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.TextBox txtTaxCode;
        private System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblTaxCode;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.Label lblPhone2;
        private System.Windows.Forms.Label lblPhone1;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnSave;
    }
}