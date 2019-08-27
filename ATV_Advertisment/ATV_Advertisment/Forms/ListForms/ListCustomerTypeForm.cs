using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Forms.DetailForms;
using ATV_Advertisment.Services;
using DataService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.ListForms
{
    public partial class ListCustomerTypeForm : CommonForm
    {
        private CustomerType customerType = null;
        private CustomerTypeService _customerTypeService = null;

        public ListCustomerTypeForm()
        {
            InitializeComponent();
            LoadDGV();
        }

        #region AdvanceDataGridView
        private BindingSource bs = null;

        private void LoadDGV()
        {
            try
            {
                _customerTypeService = new CustomerTypeService();
                List<CustomerType> customerTypes = _customerTypeService.GetAll();
                SortableBindingList<CustomerType> sbl = new SortableBindingList<CustomerType>(customerTypes);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgv.DataSource = bs;

                adgv.Columns["Id"].Visible = false;
                adgv.Columns["StatusId"].Visible = false;
                adgv.Columns["CreateDate"].Visible = false;
                adgv.Columns["Customers"].Visible = false;
                adgv.Columns["LastUpdateBy"].Visible = false;
                adgv.Columns["LastUpdateDate"].Visible = false;

                adgv.Columns["Type"].HeaderText = ADGVText.CustomerType;
                adgv.Columns["Type"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgv.Columns["Description"].HeaderText = ADGVText.Description;
                adgv.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _customerTypeService = null;
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

            //Prepare model
            customerType = new CustomerType()
            {
                Id = int.Parse(selectedRow.Cells[0].Value.ToString())
            };
        }
        #endregion

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (customerType != null)
            {
                CustomerTypeDetailForm detailForm = new CustomerTypeDetailForm(customerType);
                detailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
                detailForm.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            customerType = null;
            CustomerTypeDetailForm detailForm = new CustomerTypeDetailForm(customerType);
            detailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
            detailForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (customerType != null)
                {
                    _customerTypeService = new CustomerTypeService();
                    int result = _customerTypeService.DeleteCustomerType(customerType.Id);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        LoadDGV();
                        Utilities.ShowMessage(CommonMessage.DELETE_SUCESSFULLY);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _customerTypeService = null;
            }
        }

        private void DetailForm_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDGV();
        }
    }
}
