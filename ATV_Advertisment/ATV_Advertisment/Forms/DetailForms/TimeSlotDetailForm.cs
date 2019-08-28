using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
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
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.DetailForms
{
    public partial class TimeSlotDetailForm : CommonForm
    {
        public TimeSlot model { get; set; }
        private TimeSlotService _timeSlotService = null;

        public TimeSlotDetailForm(TimeSlot inputModel)
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
                    _timeSlotService = new TimeSlotService();
                    model = _timeSlotService.GetById(model.Id);
                    if (model != null)
                    {
                        txtPriceRate.Text = model.PriceRate.ToString();
                        txtDiscount.Text = model.Dicount.ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _timeSlotService = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = CRUDStatusCode.ERROR;

            try
            {
                _timeSlotService = new TimeSlotService();

                if (model == null)
                {
                    //Add
                    model = new TimeSlot()
                    {
                        PriceRate = int.Parse(txtPriceRate.Text),
                        Dicount = int.Parse(txtDiscount.Text)
                    };
                    result = _timeSlotService.AddTimeSlot(model);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                    }
                }
                else
                {
                    //Edit
                    model.PriceRate = int.Parse(txtPriceRate.Text);
                    model.Dicount = int.Parse(txtDiscount.Text);

                    result = _timeSlotService.EditTimeSlot(model);
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
                _timeSlotService = null;
            }
        }
    }
}
