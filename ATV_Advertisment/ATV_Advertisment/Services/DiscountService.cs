using ATV_Advertisment.Common;
using DataService.Model;
using DataService.Repositories;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface IDiscountService
    {
        Discount GetById(int id);
        List<Discount> GetAll();
        double GetDiscountByCost(double cost);
        int DeleteDiscount(int id);
        int AddDiscount(Discount input);
        int EditDiscount(Discount input);
    }

    public class DiscountService : IDiscountService
    {
        private readonly DiscountRepository _DiscountRepository;

        public DiscountService()
        {
            _DiscountRepository = new DiscountRepository();
        }

        public int AddDiscount(Discount input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                bool isExisted = _DiscountRepository.Exist(t => t.PriceRate == input.PriceRate);
                if (!isExisted)
                {
                    input.StatusId = CommonStatus.ACTIVE;
                    input.CreateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateBy = Common.Session.GetId();
                    _DiscountRepository.Add(input);
                    result = CRUDStatusCode.SUCCESS;
                }
                else
                {
                    result = CRUDStatusCode.EXISTED;
                }
            }

            return result;
        }

        public int DeleteDiscount(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var Discount = _DiscountRepository.GetById(id);
            if (Discount != null)
            {
                Discount.StatusId = CommonStatus.DELETE;
                Discount.LastUpdateDate = Utilities.GetServerDateTimeNow();
                Discount.LastUpdateBy = Common.Session.GetId();
                _DiscountRepository.Update(Discount);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditDiscount(Discount input)
        {
            int result = CRUDStatusCode.ERROR;
            var Discount = _DiscountRepository.GetById(input.Id);
            if (Discount != null)
            {
                Discount.PriceRate = input.PriceRate;
                Discount.Dicount = input.Dicount;

                Discount.LastUpdateDate = Utilities.GetServerDateTimeNow();
                Discount.LastUpdateBy = Common.Session.GetId();
                _DiscountRepository.Update(Discount);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public List<Discount> GetAll()
        {
            return _DiscountRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public Discount GetById(int id)
        {
            return _DiscountRepository.GetById(id);
        }

        public double GetDiscountByCost(double cost)
        {
            double result = 0;
            var discount = _DiscountRepository.Get(d => d.PriceRate <= cost).OrderByDescending(d => d.PriceRate).FirstOrDefault();
            if(discount != null)
            {
                result = discount.Dicount.Value;
            }
            return result;
        }
    }
}
