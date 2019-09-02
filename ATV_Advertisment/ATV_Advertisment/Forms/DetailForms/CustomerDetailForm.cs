using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using DataService.Model;
using System;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.DetailForms
{
    public partial class CustomerDetailForm : CommonForm
    {
        private CustomerService _customerService;

        public Customer model { get; set; }

        public CustomerDetailForm(Customer inputModel)
        {
            this.model = inputModel;

            InitializeComponent();
            LoadAllCustomerTypes();
            LoadData();
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

        public void LoadData()
        {
            if (model != null)
            {
                txtCode.Text = model.Code;
                txtName.Text = model.Name;
                txtAddress.Text = model.Address;
                txtPhone1.Text = model.Phone1;
                txtPhone2.Text = model.Phone2;
                txtFax.Text = model.Fax;
                txtTaxCode.Text = model.TaxCode;
                cboCustomerType.SelectedValue = model.CustomerTypeId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerService customerService = null;
            bool result = false;

            try
            {
                customerService = new CustomerService();

                if (model == null)
                {
                    //Add
                    model = new Customer()
                    {
                        Code = txtCode.Text,
                        Name = txtName.Text,
                        Address = txtAddress.Text,
                        Phone1 = txtPhone1.Text,
                        Phone2 = txtPhone2.Text,
                        Fax = txtFax.Text,
                        TaxCode = txtTaxCode.Text,
                        CustomerTypeId = (int)cboCustomerType.SelectedValue
                    };
                    result = customerService.AddCustomer(model);
                    if (result)
                    {
                        Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                    }
                }
                else
                {
                    //Edit
                    model.Code = txtCode.Text;
                    model.Name = txtName.Text;
                    model.Address = txtAddress.Text;
                    model.Phone1 = txtPhone1.Text;
                    model.Phone2 = txtPhone2.Text;
                    model.Fax = txtFax.Text;
                    model.TaxCode = txtTaxCode.Text;
                    model.CustomerTypeId = (int)cboCustomerType.SelectedValue;

                    result = customerService.EditCustomer(model);
                    if (result)
                    {
                        Utilities.ShowMessage(CommonMessage.EDIT_SUCESSFULLY);
                    }
                }
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

        private void txtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPhone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTaxCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            try
            {
                _customerService = new CustomerService();
                var isExistCode = _customerService.IsExistCode(txtCode.Text);
                if(isExistCode)
                {
                    Utilities.ShowMessage(CommonMessage.USED_CODE);
                    txtCode.Focus();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _customerService = null;
            }
        }
    }
}
