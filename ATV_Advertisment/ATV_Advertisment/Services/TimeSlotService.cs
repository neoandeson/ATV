using ATV_Advertisment.Common;
using DataService.Model;
using DataService.Repositories;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface ITimeSlotService
    {
        TimeSlot GetById(int id);
        List<TimeSlot> GetAll();
        int DeleteTimeSlot(int id);
        int AddTimeSlot(TimeSlot input);
        int EditTimeSlot(TimeSlot input);
    }

    public class TimeSlotService : ITimeSlotService
    {
        private readonly TimeSlotRepository _TimeSlotRepository;

        public TimeSlotService()
        {
            _TimeSlotRepository = new TimeSlotRepository();
        }

        public int AddTimeSlot(TimeSlot input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                bool isExisted = _TimeSlotRepository.Exist(t => t.Code == input.Code || 
                                                                t.Name == input.Name ||
                                                                (t.FromHour == input.FromHour && 
                                                                t.ToHour == input.ToHour));
                if (!isExisted)
                {
                    input.StatusId = CommonStatus.ACTIVE;
                    input.CreateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateBy = Common.Session.GetId();
                    _TimeSlotRepository.Add(input);
                    result = CRUDStatusCode.SUCCESS;
                }
                else
                {
                    result = CRUDStatusCode.EXISTED;
                }
            }

            return result;
        }

        public int DeleteTimeSlot(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var TimeSlot = _TimeSlotRepository.GetById(id);
            if (TimeSlot != null)
            {
                TimeSlot.StatusId = CommonStatus.DELETE;
                TimeSlot.LastUpdateDate = Utilities.GetServerDateTimeNow();
                TimeSlot.LastUpdateBy = Common.Session.GetId();
                _TimeSlotRepository.Update(TimeSlot);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditTimeSlot(TimeSlot input)
        {
            int result = CRUDStatusCode.ERROR;
            var TimeSlot = _TimeSlotRepository.GetById(input.Id);
            if (TimeSlot != null)
            {
                TimeSlot.Name = input.Name;
                TimeSlot.Code = input.Code;
                TimeSlot.FromHour = input.FromHour;
                TimeSlot.ToHour = input.ToHour;
                TimeSlot.SessionCode = input.SessionCode;

                TimeSlot.LastUpdateDate = Utilities.GetServerDateTimeNow();
                TimeSlot.LastUpdateBy = Common.Session.GetId();
                _TimeSlotRepository.Update(TimeSlot);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public List<TimeSlot> GetAll()
        {
            return _TimeSlotRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public TimeSlot GetById(int id)
        {
            return _TimeSlotRepository.GetById(id);
        }
    }
}
