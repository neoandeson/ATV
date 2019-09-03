﻿using ATV_Advertisment.Common;
using ATV_Advertisment.ViewModel;
using DataService.Model;
using DataService.Repositories;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface ICostRuleService
    {
        CostRule GetById(int id);
        List<CostRule> GetAll();
        List<CostRuleViewModel> GetAllForList(int timeSlotId);
        Dictionary<double, int> Getoptions(int timeSlotID);
        List<KeyValuePair<double, int>> GetCostRuleLengthOptions(int CostRuleId);
        int DeleteCostRule(int id);
        int AddCostRule(CostRule input);
        int EditCostRule(CostRule input);
    }

    public class CostRuleService : ICostRuleService
    {
        private readonly CostRuleRepository _CostRuleRepository;
        private readonly SessionRepository _sessionRepository;

        public CostRuleService()
        {
            _CostRuleRepository = new CostRuleRepository();
            _sessionRepository = new SessionRepository();
        }

        public int AddCostRule(CostRule input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                bool isExisted = _CostRuleRepository.Exist(t => t.TimeSlotId == input.TimeSlotId && 
                                                                t.Length == input.Length);
                if (!isExisted)
                {
                    _CostRuleRepository.Add(input);
                    result = CRUDStatusCode.SUCCESS;
                }
                else
                {
                    result = CRUDStatusCode.EXISTED;
                }
            }

            return result;
        }

        public bool IsExistLengthAndTimeSlotId(int timeSlotId, int length)
        {
            bool result = false;
            CostRule CostRule = _CostRuleRepository.Get(q => q.TimeSlotId == timeSlotId && q.Length == length).FirstOrDefault();
            if( CostRule != null )
            {
                result = true;
            }

            return result;
        }

        public int DeleteCostRule(int id)
        {
            //Hard delete
            int result = CRUDStatusCode.ERROR;
            var CostRule = _CostRuleRepository.GetById(id);
            if (CostRule != null)
            {
                _CostRuleRepository.Delete(CostRule);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditCostRule(CostRule input)
        {
            int result = CRUDStatusCode.ERROR;
            var CostRule = _CostRuleRepository.GetById(input.Id);
            if (CostRule != null)
            {
                CostRule.Length = input.Length;
                CostRule.Price = input.Price;

                _CostRuleRepository.Update(CostRule);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public List<CostRule> GetAll()
        {
            return _CostRuleRepository.GetAll().ToList();
        }

        public CostRule GetById(int id)
        {
            return _CostRuleRepository.GetById(id);
        }

        public List<CostRuleViewModel> GetAllForList(int timeSlotId)
        {
            return _CostRuleRepository.Get(c => c.TimeSlotId == timeSlotId)
                .OrderBy(c => c.Length)
                .Select(ts => new CostRuleViewModel() {
                    Id = ts.Id,
                    Length = ts.Length,
                    Price = Utilities.DoubleMoneyToText(ts.Price)
                })
                .ToList();
        }


        public Dictionary<double, int> Getoptions(int timeSlotID)
        {
            var options = _CostRuleRepository.Get(t => t.TimeSlotId == timeSlotID).ToDictionary(x => x.Price, x => x.Length);
            
            return options;
        }

        public List<KeyValuePair<double, int>> GetCostRuleLengthOptions(int CostRuleId)
        {
            List<KeyValuePair<double, int>> result = new List<KeyValuePair<double, int>>();
            KeyValuePair<double, int> op = new KeyValuePair<double, int>();
            var options = _CostRuleRepository.Get(t => t.Id == CostRuleId);
            foreach (var option in options)
            {
                op = new KeyValuePair<double, int>(option.Price, option.Length);
                result.Add(op);
            }
            return result;
        }
    }
}
