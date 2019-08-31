namespace ATV_Advertisment.Forms.ListForms
{
    partial class ListCustomerTypeForm
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
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).BeginInit();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.adgv);
            this.gbList.Location = new System.Drawing.Point(12, 12);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(776, 281);
            this.gbList.TabIndex = 0;
            this.gbList.TabStop = false;
            this.gbList.Text = "Danh sách";
            // 
            // adgv
            // 
            this.adgv.AutoGenerateContextFilters = true;
            this.adgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgv.DateWithTime = false;
            this.adgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.adgv.Location = new System.Drawing.Point(7, 26);
            this.adgv.Name = "adgv";
            this.adgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.adgv.Size = new System.Drawing.Size(763, 239);
            this.adgv.TabIndex = 1;
            this.adgv.TimeFilter = false;
            this.adgv.SortStringChanged += new System.EventHandler(this.adgv_SortStringChanged);
            this.adgv.FilterStringChanged += new System.EventHandler(this.adgv_FilterStringChanged);
            this.adgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgv_CellClick);
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnViewDetail);
            this.gbControl.Controls.Add(this.btnDelete);
            this.gbControl.Controls.Add(this.btnAdd);
            this.gbControl.Location = new System.Drawing.Point(12, 300);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(776, 63);
            this.gbControl.TabIndex = 0;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Thao tác";
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(19, 23);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(110, 30);
            this.btnViewDetail.TabIndex = 2;
            this.btnViewDetail.Text = "Xem";
            this.btnViewDetail.UseVisualStyleBackColor = true;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(336, 23);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 30);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(180, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ListCustomerTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 376);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbList);
            this.Name = "ListCustomerTypeForm";
            this.Text = "ListCustomerTypeForm";
            this.gbList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adgv)).EndInit();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbList;
        private ADGV.AdvancedDataGridView adgv;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnViewDetail;
    }
}