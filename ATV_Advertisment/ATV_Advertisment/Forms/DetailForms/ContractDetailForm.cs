using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
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
        private ContractDetail contractDetail = null;
        public Contract model { get; set; }
        private ContractService _contractService = null;
        private ContractDetailService _contractDetailService = null;
        private CustomerService _customerService = null;
        private ContractTypeService _contractTypeService = null;
        private int CustomerId = 0;

        public ContractDetailForm(Contract inputModel)
        {
            this.model = inputModel;
            InitializeComponent();
            LoadListCustomerCode();
            LoadContractType();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                if (model != null)
                {
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

                            cboContractType.SelectedValue = model.ContractTypeId;
                            dtpStartDate.Value = model.StartDate.Value;
                            dtpEndDate.Value = model.EndDate.Value;
                            txtCost.Text = String.Format("{0:0,0}", model.Cost);
                        }
                        else
                        {
                            Utilities.ShowMessage(CommonMessage.CUSTOMER_NOTFOUND);
                        }
                    }
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

        private void LoadContractType()
        {
            try
            {
                _contractTypeService = new ContractTypeService();
                Utilities.LoadComboBoxOptions(cboContractType, _contractTypeService.Getoptions());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contractTypeService = null;
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
            int result = CRUDStatusCode.ERROR;

            try
            {
                _contractService = new ContractService();

                if (model == null)
                {
                    //Add
                    model = new Contract()
                    {
                        CustomerCode = txtCustomerCode.Text,
                        ContractTypeId = (int)cboContractType.SelectedValue,
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpEndDate.Value,
                        Cost = double.Parse(txtCost.Text),
                    };
                    result = _contractService.AddContract(model);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                    }
                }
                else
                {
                    //Edit
                    model.CustomerCode = txtCustomerCode.Text;

                    model.ContractTypeId = (int)cboContractType.SelectedValue;
                    model.StartDate = dtpStartDate.Value;
                    model.EndDate = dtpEndDate.Value;
                    model.Cost = double.Parse(txtCost.Text);

                    result = _contractService.EditContract(model);
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
                _contractService = null;
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
                _contractDetailService = new ContractDetailService();
                List<ContractDetail> contractDetails = _contractDetailService.GetAll();
                SortableBindingList<ContractDetail> sbl = new SortableBindingList<ContractDetail>(contractDetails);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgv.DataSource = bs;

                adgv.Columns["Id"].Visible = false;
                adgv.Columns["StatusId"].Visible = false;
                adgv.Columns["CreateDate"].Visible = false;
                adgv.Columns["LastUpdateBy"].Visible = false;
                adgv.Columns["LastUpdateDate"].Visible = false;
                adgv.Columns["DurationSecond"].Visible = false;
                adgv.Columns["Discount"].Visible = false;
                adgv.Columns["IsApplyDiscount"].Visible = false;

                adgv.Columns["ProductName"].HeaderText = ADGVText.Code;
                adgv.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgv.Columns["TotalCost"].HeaderText = ADGVText.Name;
                adgv.Columns["TotalCost"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
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
            if (selectedRow.Cells[0].Value.ToString() != "0")
            {
                contractDetail = new ContractDetail()
                {
                    Id = int.Parse(selectedRow.Cells[0].Value.ToString())
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
            ContractDetailDetailForm contractDetailDetailForm = new ContractDetailDetailForm(contractDetail);
            contractDetailDetailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
            contractDetailDetailForm.ShowDialog();
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnViewDtail_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void DetailForm_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDGV();
        }
    }
}
