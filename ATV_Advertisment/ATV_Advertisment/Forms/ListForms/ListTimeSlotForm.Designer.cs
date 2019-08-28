namespace ATV_Advertisment.Forms.ListForms
{
    partial class ListTimeSlotForm
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
            this.adgv = new ADGV.AdvancedDataGridView();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).BeginInit();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.adgv);
            this.gbDetail.Location = new System.Drawing.Point(13, 11);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(938, 411);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Danh sách";
            // 
            // adgv
            // 
            this.adgv.AutoGenerateContextFilters = true;
            this.adgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgv.DateWithTime = false;
            this.adgv.Location = new System.Drawing.Point(7, 26);
            this.adgv.Name = "adgv";
            this.adgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgv.Size = new System.Drawing.Size(925, 379);
            this.adgv.TabIndex = 0;
            this.adgv.TimeFilter = false;
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnDelete);
            this.gbControl.Controls.Add(this.btnAdd);
            this.gbControl.Controls.Add(this.button1);
            this.gbControl.Location = new System.Drawing.Point(12, 428);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(939, 71);
            this.gbControl.TabIndex = 1;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(337, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(179, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Xem";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ListTimeSlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 511);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbDetail);
            this.Name = "ListTimeSlotForm";
            this.Text = "Danh sách thời điểm phát";
            this.gbDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).EndInit();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.GroupBox gbControl;
        private ADGV.AdvancedDataGridView adgv;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
    }
}