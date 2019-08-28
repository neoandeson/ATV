using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using DataService.Model;
using System;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.DetailForms
{
    public partial class SessionDetailForm : CommonForm
    {
        public DataService.Model.Session model { get; set; }
        private SessionService _sessionService = null;

        public SessionDetailForm(DataService.Model.Session inputModel)
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
                    _sessionService = new SessionService();
                    model = _sessionService.GetById(model.Id);
                    if (model != null)
                    {
                        txtCode.Text = model.Code;
                        txtName.Text = model.Name;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _sessionService = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = CRUDStatusCode.ERROR;

            try
            {
                _sessionService = new SessionService();

                if (model == null)
                {
                    //Add
                    model = new DataService.Model.Session()
                    {
                        Code = txtCode.Text,
                        Name = txtName.Text
                    };
                    result = _sessionService.AddSession(model);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                    }
                }
                else
                {
                    //Edit
                    model.Code = txtCode.Text;
                    model.Name = txtName.Text;

                    result = _sessionService.EditSession(model);
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
                _sessionService = null;
            }
        }
    }
}
