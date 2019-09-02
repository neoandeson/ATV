using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using ATV_Advertisment.ViewModel;
using DataService.Model;
using Newtonsoft.Json;
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

namespace ATV_Advertisment.Forms.DetailForms
{
    public partial class ContractDetailDetailForm : CommonForm
    {
        public ContractDetail model { get; set; }
        public ProductScheduleShow productScheduleShow = null;
        public int productScheduleShowId = 0;
        private ContractDetailService _contractDetailService = null;
        private ProductScheduleShowService _productScheduleShowService = null;
        private DurationService _durationService = null;

        public ContractDetailDetailForm(ContractDetail inputModel)
        {
            InitializeComponent();
            this.model = inputModel;
            gbRegisterSchedule.Visible = false;
            if (model != null)
            {
                if (model.Id != 0)
                {
                    gbRegisterSchedule.Visible = true;
                }
            }

            LoadDurationComboBox();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (model != null)
                {
                    if (model.Id != 0)
                    {
                        //Existed
                        _contractDetailService = new ContractDetailService();
                        model = _contractDetailService.GetById(model.Id);
                        if (model != null)
                        {
                            txtProductName.Text = model.ProductName;
                            txtTotalCost.Text = Utilities.DoubleMoneyToText(model.TotalCost);
                            cboDuration.SelectedValue = model.DurationSecond;

                            LoadDGV();
                        }
                    }
                }
                else
                {
                    gbRegisterSchedule.Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contractDetailService = null;
            }
        }

        public void LoadDurationComboBox()
        {
            try
            {
                _durationService = new DurationService();
                Utilities.LoadComboBoxOptions(cboDuration, _durationService.Getoptions());
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

        #region AdvanceDataGridView
        private BindingSource bs = null;

        private void LoadDGV()
        {
            try
            {
                if (model.Id != 0)
                {
                    var productScheduleShows = new ProductScheduleShowService().GetAllByContractDetailId(model.Id);

                    SortableBindingList<ProductScheduleShow> sbl = new SortableBindingList<ProductScheduleShow>(productScheduleShows);
                    bs = new BindingSource();
                    bs.DataSource = sbl;
                    adgv.DataSource = bs;
                    adgv.Columns["Id"].Visible = false;
                    adgv.Columns["ContractDetailId"].Visible = false;

                    adgv.Columns["ShowDate"].HeaderText = ADGVText.ShowDate;
                    adgv.Columns["ShowDate"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                    adgv.Columns["TimeSlot"].HeaderText = ADGVText.TimeSlot;
                    adgv.Columns["TimeSlot"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    adgv.Columns["Quantity"].HeaderText = ADGVText.Quantity;
                    adgv.Columns["Quantity"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                    adgv.Columns["Duration"].HeaderText = ADGVText.Duration;
                    adgv.Columns["Duration"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                    adgv.Columns["Cost"].HeaderText = ADGVText.Cost;
                    adgv.Columns["Cost"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                    adgv.Columns["Discount"].HeaderText = ADGVText.Discount;
                    adgv.Columns["Discount"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                    adgv.Columns["TotalCost"].HeaderText = ADGVText.TotalCost;
                    adgv.Columns["TotalCost"].Width = ControlsAttribute.GV_WIDTH_NORMAL;

                    productScheduleShow = new ProductScheduleShow()
                    {
                        ContractDetailId = model.Id,
                        Duration = model.DurationSecond
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            }
        }

        private void adgv_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = adgv.SortString;
        }

        private void adgv_FilterStringChanged(object sender, EventArgs e)
        {
            string tmp = adgv.FilterString;
            string pattern = @"([a-zA-Z0-9 ]+)";
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
            if (selectedRow.Cells[0].Value.ToString() != "0" && !String.IsNullOrWhiteSpace(selectedRow.Cells[0].Value.ToString()))
            {
                productScheduleShowId = int.Parse(selectedRow.Cells[0].Value.ToString());
            }
            else
            {
                productScheduleShowId = 0;
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ContractDetail result = null;
                int editResult = CRUDStatusCode.ERROR;

                _contractDetailService = new ContractDetailService();

                if (model != null)
                {
                    if (model.Id == 0)
                    {
                        //Add
                        model.ProductName = txtProductName.Text;
                        model.TotalCost = Utilities.GetDoubleFromTextBox(txtTotalCost);
                        model.DurationSecond = (int)cboDuration.SelectedValue;
                        result = _contractDetailService.CreateContractDetail(model);
                        if (result != null)
                        {
                            if (result.Id == 0)
                            {
                                Utilities.ShowMessage(CommonMessage.EXISTED_PRODUCT_IN_CONTRACT);
                            }
                            model = result;
                            gbRegisterSchedule.Visible = true;
                            productScheduleShow = new ProductScheduleShow()
                            {
                                ContractDetailId = model.Id,
                                Duration = (int)cboDuration.SelectedValue
                            };
                            Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                        }
                    }
                    else
                    {
                        //Edit
                        model.ProductName = txtProductName.Text;

                        model.TotalCost = Utilities.GetDoubleFromTextBox(txtTotalCost);
                        model.DurationSecond = (int)cboDuration.SelectedValue;

                        editResult = _contractDetailService.EditContractDetail(model);
                        if (editResult == CRUDStatusCode.SUCCESS)
                        {
                            gbRegisterSchedule.Visible = true;
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
                _contractDetailService = null;
            }
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            ProductScheduleDetailForm contractDetailDetailForm = new ProductScheduleDetailForm(productScheduleShow);
            contractDetailDetailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
            contractDetailDetailForm.ShowDialog();
        }

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                if (productScheduleShowId != 0)
                {
                    if (Utilities.ShowConfirmMessage(CommonMessage.CONFIRM_DELETE))
                    {
                        _productScheduleShowService = new ProductScheduleShowService();

                        //Completely delete from DB
                        _productScheduleShowService.DeleteProductScheduleShow(productScheduleShowId);
                    }

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

        private void DetailForm_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDGV();
            UpdateContractDetailTotalCost();
        }

        private void UpdateContractDetailTotalCost()
        {
            try
            {
                _contractDetailService = new ContractDetailService();
                double result = _contractDetailService.UpdateContractDetailCost(model.Id);
                txtTotalCost.Text = Utilities.DoubleMoneyToText(result);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contractDetailService = null;
            }
        }
    }
}
