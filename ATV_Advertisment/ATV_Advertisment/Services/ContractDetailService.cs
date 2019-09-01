using ATV_Advertisment.Common;
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
        List<ContractDetail> GetAllByContractId(int contractId);
        //List<ContractDetail> GetAllForList();
        int DeleteContractDetail(int id);
        int AddContractDetail(ContractDetail input);
        int EditContractDetail(ContractDetail input);
    }

    public class ContractDetailService : IContractDetailService
    {
        private readonly ContractDetailRepository _ContractDetailRepository;
        private readonly SessionRepository _sessionRepository;

        public ContractDetailService()
        {
            _ContractDetailRepository = new ContractDetailRepository();
            _sessionRepository = new SessionRepository();
        }

        public int AddContractDetail(ContractDetail input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                bool isExisted = _ContractDetailRepository.Exist(t => t.ContractId == input.ContractId &&
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
            bool isExisted = _ContractDetailRepository.Exist(t => t.ContractId == input.ContractId &&
                                                                    t.ProductName == input.ProductName &&
                                                                    t.Id != input.Id);
            if (ContractDetail != null)
            {
                ContractDetail.ProductName = input.ProductName;
                ContractDetail.JSONSchedule = input.JSONSchedule;

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

        public List<ContractDetail> GetAllByContractId(int contractId)
        {
            return _ContractDetailRepository.Get(c => c.StatusId == CommonStatus.ACTIVE && c.ContractId == contractId).ToList();
        }

        public ContractDetail GetById(int id)
        {
            return _ContractDetailRepository.GetById(id);
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
