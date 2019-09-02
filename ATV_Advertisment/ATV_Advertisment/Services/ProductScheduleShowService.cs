using ATV_Advertisment.Common;
using DataService.Model;
using DataService.Repositories;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface IProductScheduleShowService
    {
        ProductScheduleShow GetById(int id);
        List<ProductScheduleShow> GetAllByContractDetailId(int contractDetailId);
        //List<ProductScheduleShow> GetAllForList();
        int DeleteProductScheduleShow(int id);
        int AddProductScheduleShow(ProductScheduleShow input);
        int EditProductScheduleShow(ProductScheduleShow input);
    }

    public class ProductScheduleShowService : IProductScheduleShowService
    {
        private readonly ProductScheduleShowRepository _ProductScheduleShowRepository;
        private readonly SessionRepository _sessionRepository;

        public ProductScheduleShowService()
        {
            _ProductScheduleShowRepository = new ProductScheduleShowRepository();
            _sessionRepository = new SessionRepository();
        }

        public int AddProductScheduleShow(ProductScheduleShow input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                bool isExisted = _ProductScheduleShowRepository.Exist(t => t.ContractDetailId == input.ContractDetailId && 
                                                                t.TimeSlot == input.TimeSlot &&
                                                                t.ShowDate == input.ShowDate);
                if (!isExisted)
                {
                    _ProductScheduleShowRepository.Add(input);
                    result = CRUDStatusCode.SUCCESS;
                }
                else
                {
                    result = CRUDStatusCode.EXISTED;
                }
            }

            return result;
        }

        /// <summary>
        /// Hard delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteProductScheduleShow(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var ProductScheduleShow = _ProductScheduleShowRepository.GetById(id);
            if (ProductScheduleShow != null)
            {
                _ProductScheduleShowRepository.Delete(ProductScheduleShow);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditProductScheduleShow(ProductScheduleShow input)
        {
            int result = CRUDStatusCode.ERROR;
            var ProductScheduleShow = _ProductScheduleShowRepository.GetById(input.Id);
            if (ProductScheduleShow != null)
            {
                ProductScheduleShow.ContractDetailId = input.ContractDetailId;
                ProductScheduleShow.Cost = input.Cost;
                ProductScheduleShow.Quantity = input.Quantity;
                ProductScheduleShow.TimeSlotLength = input.TimeSlotLength;
                ProductScheduleShow.ShowDate = input.ShowDate;
                ProductScheduleShow.TimeSlot = input.TimeSlot;
                ProductScheduleShow.TotalCost = input.TotalCost;
                ProductScheduleShow.Discount = input.Discount;

                bool isExisted = _ProductScheduleShowRepository.Exist(t => t.ContractDetailId == input.ContractDetailId &&
                                                                t.TimeSlot == input.TimeSlot &&
                                                                t.Quantity == input.Quantity &&
                                                                t.TimeSlotLength == input.TimeSlotLength);
                if (!isExisted)
                {
                    _ProductScheduleShowRepository.Update(ProductScheduleShow);
                    result = CRUDStatusCode.SUCCESS;
                } else
                {
                    result = CRUDStatusCode.EXISTED;
                }
            }

            return result;
        }

        public List<ProductScheduleShow> GetAllByContractDetailId(int contractDetailId)
        {
            return _ProductScheduleShowRepository.Get(c => c.ContractDetailId == contractDetailId).ToList();
        }

        public ProductScheduleShow GetById(int id)
        {
            return _ProductScheduleShowRepository.GetById(id);
        }

        //public List<ProductScheduleShow> GetAllForList()
        //{
        //    Dictionary<string, string> sessionCodeName = _sessionRepository
        //        .Get(c => c.StatusId == CommonStatus.ACTIVE)
        //        .ToDictionary(q => q.Code, q => string.Format("{0} {1}", q.Code, q.Name));
        //    return _ProductScheduleShowRepository.Get(c => c.StatusId == CommonStatus.ACTIVE)
        //        .Select(ts => new ProductScheduleShow() {
        //            Id = ts.Id,
        //            Code = ts.Code,
        //            StatusId = ts.StatusId,
        //            CreateDate = ts.CreateDate,
        //            FromHour = ts.FromHour,
        //            LastUpdateBy = ts.LastUpdateBy,
        //            LastUpdateDate = ts.LastUpdateDate,
        //            Name = ts.Name,
        //            Price = ts.Price,
        //            SessionCode = sessionCodeName.Where(s => s.Key == ts.SessionCode).FirstOrDefault().Value,
        //            ToHour = ts.ToHour
        //        })
        //        .ToList();
        //}
    }
}
