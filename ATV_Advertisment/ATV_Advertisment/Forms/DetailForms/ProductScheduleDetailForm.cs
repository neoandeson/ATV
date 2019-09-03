using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using DataService.Model;
using System;
using System.Collections.Generic;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.DetailForms
{
    public partial class ProductScheduleDetailForm : CommonForm
    {
        public ProductScheduleShow model { get; set; }
        private int CompleteLoadData = 0;
        private ProductScheduleShowService _productScheduleShowService = null;
        private TimeSlotService _timeSlotService = null;
        private DiscountService _discountService = null;

        public ProductScheduleDetailForm(ProductScheduleShow inputModel)
        {
            this.model = inputModel;
            InitializeComponent();
            LoadTimeSlots();
            LoadTimeSlotLengthByTimeSlot();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                if (model != null)
                {
                    cboTimeSlotLength.Text = model.TimeSlotLength.ToString();
                    if (model.Id != 0)
                    {
                        _productScheduleShowService = new ProductScheduleShowService();
                        model = _productScheduleShowService.GetById(model.Id);
                        if (model != null)
                        {
                            dtpShowDate.Text = model.ShowDate;
                            cboTimeSlot.Text = model.TimeSlot;
                            txtCost.Text = Utilities.DoubleMoneyToText(model.Cost);
                            txtTotalCost.Text = Utilities.DoubleMoneyToText(model.TotalCost);
                            txtDiscount.Text = model.Discount.ToString();
                            cboTimeSlotLength.Text = model.TimeSlotLength.ToString();
                            txtQuantity.Text = model.Quantity.ToString();
                        }
                    }
                    CalculateCost();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _productScheduleShowService = null;
            }
        }

        private void LoadTimeSlots()
        {
            try
            {
                _timeSlotService = new TimeSlotService();
                Utilities.LoadComboBoxOptions(cboTimeSlot, _timeSlotService.Getoptions());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CompleteLoadData = 1;
                _timeSlotService = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = CRUDStatusCode.ERROR;

            try
            {
                _productScheduleShowService = new ProductScheduleShowService();

                if (model != null)
                {
                    if(model.Id == 0)
                    {
                        //Add
                        model.TimeSlot = cboTimeSlot.Text;
                        model.Cost = (double)txtCost.MoneyValue;
                        model.TotalCost = (double)txtTotalCost.MoneyValue;
                        model.Discount = double.Parse(txtDiscount.Text);
                        model.TimeSlotLength = int.Parse(cboTimeSlotLength.Text);
                        model.Quantity = int.Parse(txtQuantity.Text);
                        model.ShowDate = dtpShowDate.Text;
                        result = _productScheduleShowService.AddProductScheduleShow(model);
                        if (result == CRUDStatusCode.SUCCESS)
                        {
                            Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                        } else if(result == CRUDStatusCode.EXISTED)
                        {
                            Utilities.ShowMessage(CommonMessage.EXISTED_PRODUCT_SCHEDULE);
                        }
                    }
                    else
                    {
                        //Edit
                        model.TimeSlot = cboTimeSlot.Text;
                        model.Cost = (double)txtCost.MoneyValue;
                        model.TotalCost = (double)txtTotalCost.MoneyValue;
                        model.Discount = double.Parse(txtDiscount.Text);
                        model.TimeSlotLength = int.Parse(cboTimeSlotLength.Text);
                        model.Quantity = int.Parse(txtQuantity.Text);
                        model.ShowDate = dtpShowDate.Text;

                        result = _productScheduleShowService.EditProductScheduleShow(model);
                        if (result == CRUDStatusCode.SUCCESS)
                        {
                            Utilities.ShowMessage(CommonMessage.EDIT_SUCESSFULLY);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _productScheduleShowService = null;
            }
        }

        private void CalculateCost()
        {
            try
            {
                if (CompleteLoadData == 2)
                {
                    _discountService = new DiscountService();

                    double timeSlotPrice = (double)cboTimeSlotLength.SelectedValue;
                    int quantity = Utilities.GetIntFromTextBox(txtQuantity);
                    double cost = timeSlotPrice * quantity;
                    double discount = _discountService.GetDiscountByCost(cost);
                    double totalCost = cost - (cost * discount / 100);

                    txtCost.Text = Utilities.DoubleMoneyToText(cost);
                    txtDiscount.Text = discount.ToString();
                    txtTotalCost.Text = Utilities.DoubleMoneyToText(totalCost);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _discountService = null;
            }
        }

        private void cboTimeSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTimeSlotLengthByTimeSlot();
            CalculateCost();
        }

        private void cboTimeSlotLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }

        private void LoadTimeSlotLengthByTimeSlot()
        {
            try
            {
                if(CompleteLoadData >= 1)
                {
                    _timeSlotService = new TimeSlotService();
                    //TODO Load length price
                    //Utilities.LoadComboBoxOptions(cboTimeSlotLength, _timeSlotService.GetTimeSlotLengthOptions((int)cboTimeSlot.SelectedValue));
                    CompleteLoadData = 2;
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
