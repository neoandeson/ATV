using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using ATV_Advertisment.ViewModel;
using DataService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Advertisment.Forms.DetailForms
{
    public partial class ProductScheduleDetailForm : CommonForm
    {
        public ProductScheduleViewModel model { get; set; }
        private DurationService _durationService = null;

        public ProductScheduleDetailForm(Duration inputModel)
        {
            //this.model = inputModel;
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                if (model != null)
                {
                    _durationService = new DurationService();
                    //model = _durationService.GetById(model.Id);
                    if (model != null)
                    {
                        //txtLength.Text = model.Length.ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _durationService = null;
            }
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    int result = CRUDStatusCode.ERROR;

        //    try
        //    {
        //        _durationService = new DurationService();

        //        if (model == null)
        //        {
        //            //Add
        //            model = new Duration()
        //            {
        //                Length = int.Parse(txtLength.Text)
        //            };
        //            result = _durationService.AddDuration(model);
        //            if (result == CRUDStatusCode.SUCCESS)
        //            {
        //                Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
        //            }
        //        }
        //        else
        //        {
        //            //Edit
        //            model.Length = int.Parse(txtLength.Text);

        //            result = _durationService.EditDuration(model);
        //            if (result == CRUDStatusCode.SUCCESS)
        //            {
        //                Utilities.ShowMessage(CommonMessage.EDIT_SUCESSFULLY);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        _durationService = null;
        //    }
        //}
    }
}
