using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using DataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.ListForms
{
    public partial class ListCustomerForm : CommonForm
    {
        public ListCustomerForm()
        {
            InitializeComponent();
            LoadAllCustomerTypes();
            LoadDGV();
        }

        public void LoadAllCustomerTypes()
        {
            CustomerTypeService customerTypeService = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                customerTypeService = new CustomerTypeService();

                Utilities.LoadComboBoxOptions(cboCustomerType, customerTypeService.Getoptions());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                customerTypeService = null;
                Cursor.Current = Cursors.Default;
            }
        }

        private void ClearForm()
        {
            this.txtAddress.Text = "";
            this.txtCode.Text = "";
            this.txtFax.Text = "";
            this.txtName.Text = "";
            this.txtPhone1.Text = "";
            this.txtPhone2.Text = "";
            this.txtTaxCode.Text = "";
            this.cboCustomerType.SelectedIndex = 0;
        }

        #region AdvanceDataGridView
        private BindingSource bs = null;

        private void LoadDGV()
        {
            CustomerService customerService = null;
            try
            {
                customerService = new CustomerService();
                List<Customer> customers = customerService.GetAll();
                SortableBindingList<Customer> sbl = new SortableBindingList<Customer>(customers);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgv.DataSource = bs;

                adgv.Columns["Id"].Visible = false;
                adgv.Columns["Phone1"].Visible = false;
                adgv.Columns["Phone2"].Visible = false;
                adgv.Columns["Fax"].Visible = false;
                adgv.Columns["CustomerTypeId"].Visible = false;
                adgv.Columns["StatusId"].Visible = false;
                adgv.Columns["CreateDate"].Visible = false;
                adgv.Columns["LastUpdateBy"].Visible = false;
                adgv.Columns["DeleteDate"].Visible = false;
                adgv.Columns["DeleteBy"].Visible = false;
                adgv.Columns["CustomerType"].Visible = false;

                adgv.Columns["Name"].HeaderText = ADGVText.Name;
                adgv.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgv.Columns["Code"].HeaderText = ADGVText.Code;
                adgv.Columns["Code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgv.Columns["Address"].HeaderText = ADGVText.Address;
                adgv.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgv.Columns["TaxCode"].HeaderText = ADGVText.Phone;
                adgv.Columns["TaxCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                customerService = null;
            }
        }

        private void adgv_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = adgv.SortString;
        }

        private void adgv_FilterStringChanged(object sender, EventArgs e)
        {
            string tmp = adgv.FilterString;
            string pattern = @"([a-zA-Z]+)";
            MatchCollection matches = Regex.Matches(tmp, pattern);
            try
            {
                bs.Filter = adgv.FilterString;
            }
            catch (Exception ex)
            {
                Utilities.ShowError(ex.Message);
            }
        }

        private void adgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = adgv.SelectedRows[0];

            //Binding data to groupbox information
            txtCode.Text = selectedRow.Cells[1].Value.ToString();
            txtName.Text = (selectedRow.Cells[2].Value == null) ? "" : selectedRow.Cells[2].Value.ToString();
            txtAddress.Text = (selectedRow.Cells[3].Value == null) ? "" : selectedRow.Cells[3].Value.ToString();
            txtPhone1.Text = (selectedRow.Cells[4].Value == null) ? "" : selectedRow.Cells[4].Value.ToString();
            txtPhone2.Text = (selectedRow.Cells[5].Value == null) ? "" : selectedRow.Cells[5].Value.ToString();
            txtFax.Text = (selectedRow.Cells[6].Value == null) ? "" : selectedRow.Cells[6].Value.ToString();
            txtTaxCode.Text = (selectedRow.Cells[7].Value == null) ? "" : selectedRow.Cells[7].Value.ToString();
            cboCustomerType.SelectedValue = int.Parse(selectedRow.Cells[8].Value.ToString());
        }
        #endregion
    }
}
