using ATV_Advertisment.Common;
using ATV_Advertisment.ViewModel;
using DataService.Infrastructure;
using DataService.Model;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface IContractDetailService
    {
        ContractDetail GetById(int id);
        List<ContractDetail> GetAll();
        List<ContractDetail> GetAllByContractCode(string contractCode);
        //List<ContractDetail> GetAllForList();
        int DeleteContractDetail(int id);
        int AddContractDetail(ContractDetail input);
        ContractDetail CreateContractDetail(ContractDetail input);
        int EditContractDetail(ContractDetail input);
        ContractDetailUpdateVM UpdateContractDetailCost(int id);
    }

    public class ContractDetailService : IContractDetailService
    {
        private readonly ContractDetailRepository _ContractDetailRepository;
        private readonly SessionRepository _sessionRepository;
        private readonly ProductScheduleShowService _productScheduleShowService;

        public ContractDetailService()
        {
            _ContractDetailRepository = new ContractDetailRepository();
            _sessionRepository = new SessionRepository();
            _productScheduleShowService = new ProductScheduleShowService();
        }

        public int AddContractDetail(ContractDetail input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                bool isExisted = _ContractDetailRepository.Exist(t => t.ContractCode == input.ContractCode &&
                                                                t.ProductName == input.ProductName);
                if (!isExisted)
                {
                    input.StatusId = CommonStatus.ACTIVE;
                    input.CreateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateBy = Common.Session.GetId();
                    _ContractDetailRepository.Add(input);
                    result = CRUDStatusCode.SUCCESS;
                }
                else
                {
                    result = CRUDStatusCode.EXISTED;
                }
            }

            return result;
        }

        public ContractDetail CreateContractDetail(ContractDetail input)
        {
            ContractDetail result = null;
            if (input != null)
            {
                bool isExisted = _ContractDetailRepository.Exist(t => t.ContractCode == input.ContractCode &&
                                                                t.ProductName == input.ProductName);
                if (!isExisted)
                {
                    input.StatusId = CommonStatus.ACTIVE;
                    input.CreateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateBy = Common.Session.GetId();

                    result = _ContractDetailRepository.Create(input);
                }
                else
                {
                    //In case existed check result id = 0;
                    result = new ContractDetail()
                    {
                        Id = 0
                    };
                }
            }

            return result;
        }

        public int DeleteContractDetail(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var ContractDetail = _ContractDetailRepository.GetById(id);
            if (ContractDetail != null)
            {
                ContractDetail.StatusId = CommonStatus.DELETE;
                ContractDetail.LastUpdateDate = Utilities.GetServerDateTimeNow();
                ContractDetail.LastUpdateBy = Common.Session.GetId();
                _ContractDetailRepository.Update(ContractDetail);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditContractDetail(ContractDetail input)
        {
            int result = CRUDStatusCode.ERROR;
            var ContractDetail = _ContractDetailRepository.GetById(input.Id);
            bool isExisted = _ContractDetailRepository.Exist(t => t.ContractCode == input.ContractCode &&
                                                                    t.ProductName == input.ProductName &&
                                                                    t.Id != input.Id);
            if (ContractDetail != null)
            {
                ContractDetail.ProductName = input.ProductName;
                ContractDetail.TotalCost = input.TotalCost;

                ContractDetail.LastUpdateDate = Utilities.GetServerDateTimeNow();
                ContractDetail.LastUpdateBy = Common.Session.GetId();
                _ContractDetailRepository.Update(ContractDetail);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public List<ContractDetail> GetAll()
        {
            return _ContractDetailRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public List<ContractDetail> GetAllByContractCode(string contractCode)
        {
            return _ContractDetailRepository.Get(c => c.StatusId == CommonStatus.ACTIVE && c.ContractCode == contractCode).ToList();
        }

        public ContractDetail GetById(int id)
        {
            return _ContractDetailRepository.GetById(id);
        }

        public ContractDetailUpdateVM UpdateContractDetailCost(int id)
        {
            ContractDetailUpdateVM result = new ContractDetailUpdateVM();

            ContractDetail contractDetail = GetById(id);
            if (contractDetail != null)
            {
                List<ProductScheduleShow> productScheduleShows = _productScheduleShowService.GetAllByContractDetailId(id);
                foreach (var pss in productScheduleShows)
                {
                    result.Cost += pss.TotalCost;
                    result.NumberOfShow += pss.Quantity;
                }

                contractDetail.TotalCost = result.Cost;
                contractDetail.NumberOfShow = result.NumberOfShow;
                EditContractDetail(contractDetail);
            }

            return result;
        }

        //public List<ContractDetail> GetAllForList()
        //{
        //    Dictionary<string, string> sessionCodeName = _sessionRepository
        //        .Get(c => c.StatusId == CommonStatus.ACTIVE)
        //        .ToDictionary(q => q.Code, q => string.Format("{0} {1}", q.Code, q.Name));
        //    return _ContractDetailRepository.Get(c => c.StatusId == CommonStatus.ACTIVE)
        //        .Select(ts => new ContractDetail()
        //        {
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
