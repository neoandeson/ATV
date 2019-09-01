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
        private ContractDetailService _contractDetailService = null;
        private DurationService _durationService = null;

        public ContractDetailDetailForm(ContractDetail inputModel)
        {
            this.model = inputModel;
            InitializeComponent();
            LoadDurationComboBox();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (model != null)
                {
                    _contractDetailService = new ContractDetailService();
                    model = _contractDetailService.GetById(model.Id);
                    if (model != null)
                    {
                        txtProductName.Text = model.ProductName;
                        txtTotalCost.Text = String.Format("{0:0,0}", model.TotalCost);
                        cboDuration.SelectedValue = model.DurationSecond;

                        LoadDGV();
                    }
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
                if (model.JSONSchedule != null)
                {
                    var productSchedules = JsonConvert.DeserializeObject<List<ProductScheduleViewModel>>(model.JSONSchedule);

                    SortableBindingList<ProductScheduleViewModel> sbl = new SortableBindingList<ProductScheduleViewModel>(productSchedules);
                    bs = new BindingSource();
                    bs.DataSource = sbl;
                    adgv.DataSource = bs;

                    adgv.Columns["ShowDate"].HeaderText = ADGVText.Code;
                    adgv.Columns["ShowDate"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                    adgv.Columns["Quantity"].HeaderText = ADGVText.Name;
                    adgv.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    adgv.Columns["Duration"].HeaderText = ADGVText.Session;
                    adgv.Columns["Duration"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                    adgv.Columns["Cost"].HeaderText = ADGVText.Session;
                    adgv.Columns["Cost"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                    adgv.Columns["Discount"].HeaderText = ADGVText.Session;
                    adgv.Columns["Discount"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                    adgv.Columns["TotalCost"].HeaderText = ADGVText.Session;
                    adgv.Columns["TotalCost"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
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
            //if (selectedRow.Cells[0].Value.ToString() != "0")
            //{
            //    contractDetail = new ContractDetail()
            //    {
            //        Id = int.Parse(selectedRow.Cells[0].Value.ToString())
            //    };
            //}
            //else
            //{
            //    contractDetail = null;
            //}
        }
        #endregion
    }
}
