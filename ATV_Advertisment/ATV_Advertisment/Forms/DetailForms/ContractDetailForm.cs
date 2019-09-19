using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using ATV_Advertisment.ViewModel;
using DataService.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.DetailForms
{
    //Contract infomation
    public partial class ContractDetailForm : CommonForm
    {
        private ContractItem contractDetail = null;
        public Contract model { get; set; }
        private ContractService _contractService = null;
        private ContractItemService _contractItemService = null;
        private CustomerService _customerService = null;
        private SystemConfigService _systemConfigService = null;
        private int CustomerId = 0;

        public ContractDetailForm(Contract inputModel)
        {
            InitializeComponent();

            this.model = inputModel;
            if(model != null)
            {
                if(model.Code != "0")
                {
                    contractDetail = new ContractItem()
                    {
                        ContractCode = model.Code
                    };
                    LoadDGV();
                }
            }
            
            LoadListCustomerCode();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                if (model != null)
                {
                    gbContractDetail.Visible = true;

                    _contractService = new ContractService();
                    _customerService = new CustomerService();
                    model = _contractService.GetById(model.Id);
                    if (model != null)
                    {
                        var customer = _customerService.GetByCode(model.CustomerCode);
                        if (customer != null)
                        {
                            txtCustomerCode.Text = customer.Code;
                            txtCustomerName.Text = customer.Name;

                            txtCode.Text = model.Code;
                            //cboContractType.SelectedValue = model.ContractTypeId;
                            dtpStartDate.Value = model.StartDate.Value;
                            dtpEndDate.Value = model.EndDate.Value;
                            txtCost.Text = Utilities.DoubleMoneyToText(model.Cost);
                        }
                        else
                        {
                            Utilities.ShowMessage(CommonMessage.CUSTOMER_NOTFOUND);
                        }
                    }
                } else
                {
                    gbContractDetail.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _contractService = null;
                _customerService = null;
            }
        }

        private void LoadListCustomerCode()
        {
            try
            {
                _customerService = new CustomerService();
                AutoCompleteStringCollection autoCollection = new AutoCompleteStringCollection();
                foreach (var code in _customerService.GetAllCustomerCode())
                {
                    autoCollection.Add(code);
                }
                txtCustomerCode.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCustomerCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCustomerCode.AutoCompleteCustomSource = autoCollection;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Contract result = null;
                int editResult = CRUDStatusCode.ERROR;

                _contractService = new ContractService();
                _systemConfigService = new SystemConfigService();

                if (model == null)
                {
                    //Add
                    model = new Contract()
                    {
                        Code = txtCode.Text,
                        CustomerCode = txtCustomerCode.Text,
                        //ContractTypeId = (int)cboContractType.SelectedValue,
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpEndDate.Value,
                        Cost = double.Parse(txtCost.Text),
                    };
                    result = _contractService.AddContract(model);
                    if (result != null)
                    {
                        model = result;
                        gbContractDetail.Visible = true;
                        _systemConfigService.UseLastContractNumber();
                        contractDetail = new ContractItem()
                        {
                            ContractCode = model.Code
                        };
                        Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                    }
                }
                else
                {
                    //Edit
                    model.CustomerCode = txtCustomerCode.Text;

                    //model.ContractTypeId = (int)cboContractType.SelectedValue;
                    model.StartDate = dtpStartDate.Value;
                    model.EndDate = dtpEndDate.Value;
                    model.Cost = Utilities.GetDoubleFromTextBox(txtCost);

                    editResult = _contractService.EditContract(model);
                    if (editResult == CRUDStatusCode.SUCCESS)
                    {
                        gbContractDetail.Visible = true;
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
                _contractService = null;
                _systemConfigService = null;
            }
        }

        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            try
            {
                CustomerId = 0;
                _customerService = new CustomerService();
                Customer customer = _customerService.GetByCode(txtCustomerCode.Text);
                if (customer != null)
                {
                    txtCustomerName.Text = customer.Name;
                    CustomerId = customer.Id;
                    if (string.IsNullOrWhiteSpace(txtCode.Text))
                    {
                        GetLastedContractCode();
                    }
                }
                else
                {
                    Utilities.ShowMessage(CommonMessage.CUSTOMER_NOTFOUND);
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

        #region AdvanceDataGridView
        private BindingSource bs = null;

        private void LoadDGV()
        {
            try
            {
                _contractItemService = new ContractItemService();
                List<ContractItemViewModel> contractDetailVMs = _contractItemService.GetAllVMForListByContractCode(model.Code);
                SortableBindingList<ContractItemViewModel> sbl = new SortableBindingList<ContractItemViewModel>(contractDetailVMs);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgv.DataSource = bs;

                adgv.Columns["Id"].Visible = false;
                adgv.Columns["StatusId"].Visible = false;
                adgv.Columns["CreateDate"].Visible = false;
                adgv.Columns["LastUpdateBy"].Visible = false;
                adgv.Columns["LastUpdateDate"].Visible = false;
                adgv.Columns["DurationSecond"].Visible = false;

                adgv.Columns["ContractCode"].HeaderText = ADGVText.BelongToContractCode;
                adgv.Columns["ContractCode"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgv.Columns["ProductName"].HeaderText = ADGVText.Name;
                adgv.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgv.Columns["NumberOfShow"].HeaderText = ADGVText.NumberOfShow;
                adgv.Columns["NumberOfShow"].Width = ControlsAttribute.GV_WIDTH_SEEM;
                adgv.Columns["TotalCost"].HeaderText = ADGVText.Cost;
                adgv.Columns["TotalCost"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgv.Columns["ShowTypeId"].HeaderText = ADGVText.ShowType;
                adgv.Columns["ShowTypeId"].Width = ControlsAttribute.GV_WIDTH_NORMAL;

                lblNOProducts.Text = contractDetailVMs.Count + " sản phẩm";
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _contractItemService = null;
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
                contractDetail = new ContractItem()
                {
                    Id = int.Parse(selectedRow.Cells[0].Value.ToString()),
                    ProductName = selectedRow.Cells[2].Value.ToString()
                };
            }
            else
            {
                contractDetail = null;
            }
        }
        #endregion

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if(contractDetail != null)
            {
                contractDetail.Id = 0;
            }
            ContractItemDetailForm contractDetailDetailForm = new ContractItemDetailForm(contractDetail);
            contractDetailDetailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
            contractDetailDetailForm.ShowDialog();
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (contractDetail != null)
                {
                    _contractService = new ContractService();
                    int result = _contractService.DeleteContract(contractDetail.Id);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        UpdateContractCost();
                        LoadDGV();
                        Utilities.ShowMessage(CommonMessage.DELETE_SUCESSFULLY);
                    }
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

        private void btnViewDtail_Click(object sender, EventArgs e)
        {
            if (contractDetail != null)
            {
                if(contractDetail.Id != 0)
                {
                    ContractItemDetailForm detailForm = new ContractItemDetailForm(contractDetail);
                    detailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
                    detailForm.ShowDialog();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int result = CRUDStatusCode.ERROR;

            try
            {
                _contractService = new ContractService();

                if (model != null)
                {
                    //Edit
                    model.StatusId = CommonStatus.CANCEL;

                    result = _contractService.CancelContract(model.Id);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        gbContractDetail.Visible = true;
                        Utilities.ShowMessage(CommonMessage.CANCEL_SUCESSFULLY);
                    }
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

        private void DetailForm_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDGV();
            UpdateContractCost();
        }

        private string GetLastedContractCode()
        {
            string result = "";
            try
            {
                _systemConfigService = new SystemConfigService();
                txtCode.Text = _systemConfigService.GetLastContractNumberAsString();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _systemConfigService = null;
            }
        }

        private void UpdateContractCost()
        {
            try
            {
                _contractService = new ContractService();
                double result = _contractService.UpdateContractCost(model.Code);
                txtCost.Text = Utilities.DoubleMoneyToText(result);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contractService = null;
            }
        }
    }
}
