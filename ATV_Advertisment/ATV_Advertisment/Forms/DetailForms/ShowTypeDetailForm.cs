using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using DataService.Model;
using System;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.DetailForms
{
    public partial class ShowTypeDetailForm : CommonForm
    {
        public ShowType model { get; set; }
        private ShowTypeService _showService = null;

        public ShowTypeDetailForm(ShowType inputModel)
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
                    _showService = new ShowTypeService();
                    model = _showService.GetById(model.Id);
                    if (model != null)
                    {
                        txtType.Text = model.Type.ToString();
                        txtDescription.Text = model.Description.ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _showService = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = CRUDStatusCode.ERROR;

            try
            {
                _showService = new ShowTypeService();

                if (model == null)
                {
                    //Add
                    model = new ShowType()
                    {
                        Type = txtType.Text,
                        Description = txtDescription.Text
                    };
                    result = _showService.AddShowType(model);
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

                    result = _showService.EditShowType(model);
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
                _showService = null;
            }
        }
    }
}
