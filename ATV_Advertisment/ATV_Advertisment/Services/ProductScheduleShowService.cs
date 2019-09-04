using ATV_Advertisment.Common;
using ATV_Advertisment.ViewModel;
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
        List<ProductScheduleShowViewModel> GetAllVMForList(int contractDetailId);
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

        public List<ProductScheduleShowViewModel> GetAllVMForList(int contractDetailId)
        {
            return _ProductScheduleShowRepository.Get(c => c.ContractDetailId == contractDetailId)
                .Select(ts => new ProductScheduleShowViewModel()
                {
                    Id = ts.Id,
                    ContractDetailId = ts.ContractDetailId,
                    Quantity = ts.Quantity,
                    SessionCode = ts.SessionCode,
                    SessionName = ts.SessionName,
                    ShowDate = ts.ShowDate,
                    TimeSlot = ts.TimeSlot,
                    TimeSlotLength = ts.TimeSlotLength,
                    Cost = Utilities.DoubleMoneyToText(ts.Cost),
                    TotalCost = Utilities.DoubleMoneyToText(ts.TotalCost),
                    Discount = ts.Discount.ToString()
                })
                .ToList();
        }
    }
}
