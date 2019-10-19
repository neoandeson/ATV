using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using DataService.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.DetailForms
{
    public partial class ProductScheduleDetailForm : CommonForm
    {
        public ProductScheduleShow model { get; set; }
        private int CompleteLoadData = 0;
        private string ProductName = "";
        private double CostRulePrice = 0;
        private int ShowTypeId = 0;
        private ProductScheduleShowService _productScheduleShowService = null;
        private TimeSlotService _timeSlotService = null;
        private CostRuleService _costRuleService = null;
        private ContractService _contractService = null;

        public ProductScheduleDetailForm(ProductScheduleShow inputModel, string contractCode)
        {
            this.model = inputModel;
            if (model != null)
            {
                ProductName = inputModel.ProductName;
                ShowTypeId = inputModel.ShowTypeId;
            }

            InitializeComponent();
            CompleteLoadData = 0;
            LoadTimeSlots();
            GetCostRule();
            LoadData();
            SetMinMaxDateMonthPicker(contractCode);
        }

        private void SetMinMaxDateMonthPicker(string contractCode)
        {
            try
            {
                _contractService = new ContractService();
                Contract contract = _contractService.GetByCode(contractCode);
                if (contract != null)
                {
                    mpShowDate.MinDate = contract.StartDate.Value;
                    mpShowDate.MaxDate = contract.EndDate.Value;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _contractService = null;
            }
        }

        public void LoadData()
        {
            try
            {
                if (model != null)
                {
                    txtTimeSlotLength.Text = model.TimeSlotLength.ToString();
                    if (model.Id != 0)
                    {
                        _productScheduleShowService = new ProductScheduleShowService();
                        model = _productScheduleShowService.GetById(model.Id);
                        if (model != null)
                        {
                            mpShowDate.Text = model.ShowDate.ToString("dd/MM/YYYY");
                            cboTimeSlot.Text = model.TimeSlot;
                            txtSumCost.Text = Utilities.DoubleMoneyToText(model.Cost);
                            //txtTotalCost.Text = Utilities.DoubleMoneyToText(model.TotalCost);
                            //txtDiscount.Text = model.Discount.ToString();
                            txtTimeSlotLength.Text = model.TimeSlotLength.ToString();
                            txtQuantity.Text = model.Quantity.ToString();
                            model.ProductName = ProductName;

                            //Load selected dates
                            var selectedDates = _productScheduleShowService.GetAllSelectedDatesByContractDetailId(model.ContractDetailId);
                            if (selectedDates != null)
                            {
                                mpShowDate.BoldedDates = selectedDates;
                                txtQuantity.Text = mpShowDate.BoldedDates.Count().ToString();
                                CalculateCost();
                            }
                        }
                    }
                    //else if(model.ContractDetailId != 0)
                    //{
                    //    _productScheduleShowService = new ProductScheduleShowService();
                    //    //Load selected dates
                    //    var selectedDates = _productScheduleShowService.GetAllSelectedDatesByContractDetailId(model.ContractDetailId);
                    //    if (selectedDates != null)
                    //    {
                    //        mpShowDate.BoldedDates = selectedDates;
                    //        txtQuantity.Text = mpShowDate.BoldedDates.Count().ToString();
                    //        CalculateCost();
                    //    }
                    //}
                    CalculateCost();
                }
            }
            catch (Exception ex)
            {
                Logging.LogSystem(ex.StackTrace, SystemLogType.Exception);
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
            catch (Exception ex)
            {
                Logging.LogSystem(ex.StackTrace, SystemLogType.Exception);
                throw;
            }
            finally
            {
                CompleteLoadData = 1;
                _timeSlotService = null;
            }
        }

        private void GetCostRule()
        {
            try
            {
                if (CompleteLoadData >= 1)
                {
                    _costRuleService = new CostRuleService();
                    var costRule = _costRuleService.GetCostRule((int)cboTimeSlot.SelectedValue, model.ShowTypeId, model.TimeSlotLength);
                    if (costRule != null)
                    {
                        CostRulePrice = costRule.Price;
                        txtCost.Text = Utilities.DoubleMoneyToText(costRule.Price);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                CompleteLoadData = 2;
                _costRuleService = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = CRUDStatusCode.ERROR;

            try
            {
                _productScheduleShowService = new ProductScheduleShowService();
                _timeSlotService = new TimeSlotService();

                if (model != null)
                {
                    //Add Edit
                    ProductScheduleShow originModel = model;
                    model.TimeSlot = cboTimeSlot.Text;
                    model.TotalCost = (double)txtSumCost.MoneyValue;
                    //model.TotalCost = (double)txtTotalCost.MoneyValue;
                    model.Cost = (double)txtCost.MoneyValue;
                    //model.TotalCost = (double)txtTotalCost.MoneyValue;
                    //model.Discount = double.Parse(txtDiscount.Text);
                    model.TimeSlotLength = int.Parse(txtTimeSlotLength.Text);
                    model.Quantity = 1;//TODO: mặc định là 1 //int.Parse(txtQuantity.Text);
                    model.ShowDate = mpShowDate.BoldedDates[0];
                    model.ProductName = ProductName;
                    model.ShowTime = _timeSlotService.GetShowTimeById((int)cboTimeSlot.SelectedValue);
                    result = AddProductSchedultShows(mpShowDate.BoldedDates, originModel);
                    Utilities.ShowReturnMessage(result, "Lưu");
                }
            }
            catch (Exception ex)
            {
                Logging.LogSystem(ex.StackTrace, SystemLogType.Exception);
                throw;
            }
            finally
            {
                _timeSlotService = null;
                _productScheduleShowService = null;
            }
        }

        private int AddProductSchedultShows(DateTime[] selectedDates, ProductScheduleShow originModel)
        {
            int result = CRUDStatusCode.ERROR;

            try
            {
                _productScheduleShowService = new ProductScheduleShowService();

                using (var context = new ATVEntities())
                {
                    using (DbContextTransaction transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var pssInDB = context.ProductScheduleShows.Where(p => p.ContractDetailId == model.ContractDetailId
                                                                                && p.ShowTime == model.ShowTime
                                                                                && p.TimeSlot == model.TimeSlot
                                                                                && p.TimeSlotLength == model.TimeSlotLength);
                            if (pssInDB != null)
                            {
                                foreach (var item in pssInDB)
                                {
                                    context.ProductScheduleShows.Remove(item);
                                }
                            }
                            ProductScheduleShow pss = null;
                            foreach (var date in selectedDates)
                            {
                                pss = originModel;
                                pss.ShowDate = date;
                                context.ProductScheduleShows.Add(pss);
                                context.SaveChanges();
                            }

                            transaction.Commit();
                            result = CRUDStatusCode.SUCCESS;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw;
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

            return result;
        }

        private void CalculateCost()
        {
            try
            {
                if (CompleteLoadData == 2)
                {

                    int quantity = Utilities.GetIntFromTextBox(txtQuantity);
                    double cost = CostRulePrice * quantity;

                    txtSumCost.Text = Utilities.DoubleMoneyToText(cost);
                    txtSumCost.Text = Utilities.DoubleMoneyToText(cost);
                }
            }
            catch (Exception ex)
            {
                Logging.LogSystem(ex.StackTrace, SystemLogType.Exception);
                throw;
            }
        }

        private void cboTimeSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CompleteLoadData >= 1)
            {
                GetCostRule();
                CalculateCost();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }

        private void ProductScheduleDetailForm_Load(object sender, EventArgs e)
        {
            GetCostRule();
        }

        private void ProductScheduleDetailForm_Shown(object sender, EventArgs e)
        {
            CalculateCost();
        }

        private void mpShowDate_MouseDown(object sender, MouseEventArgs e)
        {
            MonthCalendar.HitTestInfo info = mpShowDate.HitTest(e.Location);
            if (info.HitArea == MonthCalendar.HitArea.Date)
            {
                if (mpShowDate.BoldedDates.Contains(info.Time))
                {
                    mpShowDate.RemoveBoldedDate(info.Time);
                    txtQuantity.Text = mpShowDate.BoldedDates.Count().ToString();
                }
                else
                {
                    mpShowDate.AddBoldedDate(info.Time);
                    txtQuantity.Text = mpShowDate.BoldedDates.Count().ToString();
                }
                mpShowDate.UpdateBoldedDates();
            }
        }
    }
}
