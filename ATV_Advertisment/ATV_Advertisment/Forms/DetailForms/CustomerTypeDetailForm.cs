using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using DataService.Model;
using System;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.DetailForms
{
    public partial class CustomerTypeDetailForm : CommonForm
    {
        public CustomerType model { get; set; }
        private CustomerTypeService _customerTypeService = null;

        public CustomerTypeDetailForm(CustomerType inputModel)
        {
            this.model = inputModel;
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                if (model != null)
                {
                    _customerTypeService = new CustomerTypeService();
                    model = _customerTypeService.GetById(model.Id);
                    if(model != null)
                    {
                        txtType.Text = model.Type;
                        txtDescription.Text = model.Description;
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogSystem(ex.StackTrace, SystemLogType.Exception);
                throw;
            }
            finally
            {
                _customerTypeService = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = CRUDStatusCode.ERROR;

            try
            {
                _customerTypeService = new CustomerTypeService();

                if (model == null)
                {
                    //Add
                    model = new CustomerType()
                    {
                        Type = txtType.Text,
                        Description = txtDescription.Text
                    };
                    result = _customerTypeService.AddCustomerType(model);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                    }
                }
                else
                {
                    //Edit
                    model.Type = txtType.Text;
                    model.Description = txtDescription.Text;

                    result = _customerTypeService.EditCustomerType(model);
                    if (result == CRUDStatusCode.SUCCESS)
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
                _customerTypeService = null;
            }
        }
    }
}
