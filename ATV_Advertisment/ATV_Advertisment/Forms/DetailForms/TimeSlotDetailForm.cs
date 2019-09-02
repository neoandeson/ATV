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
        private SessionService _sessionService = null;

        public TimeSlotDetailForm(TimeSlot inputModel)
        {
            this.model = inputModel;
            InitializeComponent();
            LoadCboSession();
            LoadData();
        }

        public void LoadCboSession()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _sessionService = new SessionService();

                Utilities.LoadComboBoxOptions(cboSession, _sessionService.Getoptions());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sessionService = null;
                Cursor.Current = Cursors.Default;
            }
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
                        cboSession.SelectedValue = model.SessionCode;
                        txtCode.Text = model.Code;
                        txtName.Text = model.Name;
                        txtPrice.Text = Utilities.DoubleMoneyToText(model.Price);
                        txtFromHour.Text = Utilities.GetHourFromHourInt(model.FromHour).ToString();
                        txtFromMinute.Text = Utilities.GetMinuteFromHourInt(model.FromHour).ToString();
                        txtToHour.Text = Utilities.GetHourFromHourInt(model.ToHour).ToString();
                        txtToMinute.Text = Utilities.GetMinuteFromHourInt(model.ToHour).ToString();
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
                        Code = txtCode.Text,
                        Name = txtName.Text,
                        Price = double.Parse(txtPrice.Text),
                        FromHour = Utilities.GetHourFromHourString(txtFromHour.Text, txtFromMinute.Text),
                        ToHour = Utilities.GetHourFromHourString(txtToHour.Text, txtToHour.Text),
                        SessionCode = cboSession.SelectedValue.ToString()
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
                    model.Code = txtCode.Text;
                    model.Name = txtName.Text;
                    model.Price = double.Parse(txtPrice.Text);
                    model.FromHour = Utilities.GetHourFromHourString(txtFromHour.Text, txtFromMinute.Text);
                    model.ToHour = Utilities.GetHourFromHourString(txtToHour.Text, txtToMinute.Text);
                    model.SessionCode = cboSession.SelectedValue.ToString();

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

        private void txtCode_Validated(object sender, EventArgs e)
        {
            try
            {
                _timeSlotService = new TimeSlotService();
                bool result = _timeSlotService.IsExistCode(txtCode.Text);
                if (result)
                {
                    Utilities.ShowMessage(CommonMessage.USED_CODE);
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
    }
}
