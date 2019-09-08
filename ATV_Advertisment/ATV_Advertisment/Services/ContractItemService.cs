﻿using ATV_Advertisment.Common;
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
        ContractItem GetById(int id);
        List<ContractItem> GetAll();
        List<ContractItem> GetAllByContractCode(string contractCode);
        //List<ContractItem> GetAllForList();
        int DeleteContractDetail(int id);
        int AddContractDetail(ContractItem input);
        ContractItem CreateContractDetail(ContractItem input);
        int EditContractDetail(ContractItem input);
        ContractDetailUpdateVM UpdateContractDetailCost(int id);
    }

    public class ContractItemService : IContractDetailService
    {
        private readonly ContractItemlRepository _contractItemRepository;
        private readonly SessionRepository _sessionRepository;
        private readonly ShowTypeRepository _showTypeRepository;
        private readonly ProductScheduleShowService _productScheduleShowService;

        public ContractItemService()
        {
            _contractItemRepository = new ContractItemlRepository();
            _sessionRepository = new SessionRepository();
            _showTypeRepository = new ShowTypeRepository();
            _productScheduleShowService = new ProductScheduleShowService();
        }

        public int AddContractDetail(ContractItem input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                bool isExisted = _contractItemRepository.Exist(t => t.ContractCode == input.ContractCode &&
                                                                t.ProductName == input.ProductName);
                if (!isExisted)
                {
                    input.StatusId = CommonStatus.ACTIVE;
                    input.CreateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateBy = Common.Session.GetId();
                    _contractItemRepository.Add(input);
                    result = CRUDStatusCode.SUCCESS;
                }
                else
                {
                    result = CRUDStatusCode.EXISTED;
                }
            }

            return result;
        }

        public ContractItem CreateContractDetail(ContractItem input)
        {
            ContractItem result = null;
            if (input != null)
            {
                bool isExisted = _contractItemRepository.Exist(t => t.ContractCode == input.ContractCode &&
                                                                t.ProductName == input.ProductName);
                if (!isExisted)
                {
                    input.StatusId = CommonStatus.ACTIVE;
                    input.CreateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateBy = Common.Session.GetId();

                    result = _contractItemRepository.Create(input);
                }
                else
                {
                    //In case existed check result id = 0;
                    result = new ContractItem()
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
            var ContractItem = _contractItemRepository.GetById(id);
            if (ContractItem != null)
            {
                ContractItem.StatusId = CommonStatus.DELETE;
                ContractItem.LastUpdateDate = Utilities.GetServerDateTimeNow();
                ContractItem.LastUpdateBy = Common.Session.GetId();
                _contractItemRepository.Update(ContractItem);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditContractDetail(ContractItem input)
        {
            int result = CRUDStatusCode.ERROR;
            var ContractItem = _contractItemRepository.GetById(input.Id);
            bool isExisted = _contractItemRepository.Exist(t => t.ContractCode == input.ContractCode &&
                                                                    t.ProductName == input.ProductName &&
                                                                    t.Id != input.Id);
            if (ContractItem != null)
            {
                ContractItem.ProductName = input.ProductName;
                ContractItem.TotalCost = input.TotalCost;

                ContractItem.LastUpdateDate = Utilities.GetServerDateTimeNow();
                ContractItem.LastUpdateBy = Common.Session.GetId();
                _contractItemRepository.Update(ContractItem);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public List<ContractItem> GetAll()
        {
            return _contractItemRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public List<ContractItem> GetAllByContractCode(string contractCode)
        {
            return _contractItemRepository.Get(c => c.StatusId == CommonStatus.ACTIVE && c.ContractCode == contractCode).ToList();
        }

        public ContractItem GetById(int id)
        {
            return _contractItemRepository.GetById(id);
        }

        public ContractDetailUpdateVM UpdateContractDetailCost(int id)
        {
            ContractDetailUpdateVM result = new ContractDetailUpdateVM();

            ContractItem contractDetail = GetById(id);
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

        public List<ContractItemViewModel> GetAllVMForListByContractCode(string contractCode)
        {
            Dictionary<int, string> showTypeNames = _showTypeRepository
                .Get(c => c.StatusId == CommonStatus.ACTIVE)
                .ToDictionary(q => q.Id, q => string.Format("{0}", q.Type));
            return _contractItemRepository.Get(c => c.ContractCode == contractCode)
                .Select(ts => new ContractItemViewModel()
                {
                    Id = ts.Id,
                    ContractCode = ts.ContractCode,
                    ProductName = ts.ProductName,
                    StatusId = ts.StatusId,
                    ShowTypeId = showTypeNames.Where(s => s.Key == ts.ShowTypeId).FirstOrDefault().Value,
                    NumberOfShow = ts.NumberOfShow,
                    DurationSecond = ts.DurationSecond,
                    TotalCost = Utilities.DoubleMoneyToText(ts.TotalCost),
                    CreateDate = ts.CreateDate,
                    LastUpdateBy = ts.LastUpdateBy,
                    LastUpdateDate = ts.LastUpdateDate
                })
                .ToList();
        }
    }
}