using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using DataService.Model;
using System;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.DetailForms
{
    public partial class DiscountDetailForm : CommonForm
    {
        public Discount model { get; set; }
        private DiscountService _discountService = null;

        public DiscountDetailForm(Discount inputModel)
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
                    _discountService = new DiscountService();
                    model = _discountService.GetById(model.Id);
                    if (model != null)
                    {
                        txtPriceRate.Text = Utilities.DoubleMoneyToText(model.PriceRate.Value);
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
                _discountService = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = CRUDStatusCode.ERROR;

            try
            {
                _discountService = new DiscountService();

                if (model == null)
                {
                    //Add
                    model = new Discount()
                    {
                        PriceRate = (double)txtPriceRate.MoneyValue,
                        Dicount = int.Parse(txtDiscount.Text)
                    };
                    result = _discountService.AddDiscount(model);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                    }
                }
                else
                {
                    //Edit
                    model.PriceRate = (double)txtPriceRate.MoneyValue;
                    model.Dicount = int.Parse(txtDiscount.Text);

                    result = _discountService.EditDiscount(model);
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
                _discountService = null;
            }
        }
    }
}
