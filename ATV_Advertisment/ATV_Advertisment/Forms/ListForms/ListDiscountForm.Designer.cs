namespace ATV_Advertisment.Forms.ListForms
{
    partial class ListDiscountForm
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
            this.gbList = new System.Windows.Forms.GroupBox();
            this.adgv = new ADGV.AdvancedDataGridView();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.gbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).BeginInit();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.adgv);
            this.gbList.Location = new System.Drawing.Point(13, 13);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(775, 352);
            this.gbList.TabIndex = 0;
            this.gbList.TabStop = false;
            this.gbList.Text = "Danh sách";
            // 
            // adgv
            // 
            this.adgv.AutoGenerateContextFilters = true;
            this.adgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgv.DateWithTime = false;
            this.adgv.Location = new System.Drawing.Point(7, 26);
            this.adgv.Name = "adgv";
            this.adgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgv.Size = new System.Drawing.Size(762, 320);
            this.adgv.TabIndex = 0;
            this.adgv.TimeFilter = false;
            this.adgv.SortStringChanged += new System.EventHandler(this.adgv_SortStringChanged);
            this.adgv.FilterStringChanged += new System.EventHandler(this.adgv_FilterStringChanged);
            this.adgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgv_CellClick);
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnDelete);
            this.gbControl.Controls.Add(this.btnAdd);
            this.gbControl.Controls.Add(this.btnViewDetail);
            this.gbControl.Location = new System.Drawing.Point(13, 371);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(775, 67);
            this.gbControl.TabIndex = 1;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(296, 26);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(159, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(19, 26);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(100, 30);
            this.btnViewDetail.TabIndex = 0;
            this.btnViewDetail.Text = "Xem";
            this.btnViewDetail.UseVisualStyleBackColor = true;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // ListDiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbList);
            this.Name = "ListDiscountForm";
            this.Text = "Danh sách giảm giá";
            this.gbList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).EndInit();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnViewDetail;
        private ADGV.AdvancedDataGridView adgv;
    }
}