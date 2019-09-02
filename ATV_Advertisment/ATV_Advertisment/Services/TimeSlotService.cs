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
        List<TimeSlot> GetAllForList();
        Dictionary<int, string> Getoptions();
        List<KeyValuePair<double, int>> GetTimeSlotLengthOptions(int timeSlotId);
        bool IsExistCodeAndLength(string code, int length);
        int DeleteTimeSlot(int id);
        int AddTimeSlot(TimeSlot input);
        int EditTimeSlot(TimeSlot input);
    }

    public class TimeSlotService : ITimeSlotService
    {
        private readonly TimeSlotRepository _TimeSlotRepository;
        private readonly SessionRepository _sessionRepository;

        public TimeSlotService()
        {
            _TimeSlotRepository = new TimeSlotRepository();
            _sessionRepository = new SessionRepository();
        }

        public int AddTimeSlot(TimeSlot input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                bool isExisted = _TimeSlotRepository.Exist(t => t.Code == input.Code && 
                                                                t.Name == input.Name &&
                                                                t.FromHour == input.FromHour && 
                                                                t.Length == input.Length);
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

        public bool IsExistCodeAndLength(string code, int length)
        {
            bool result = false;
            TimeSlot timeSlot = _TimeSlotRepository.Get(q => q.Code == code && q.Length == length).FirstOrDefault();
            if( timeSlot != null )
            {
                result = true;
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
                TimeSlot.Length = input.Length;
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

        public List<TimeSlot> GetAllForList()
        {
            Dictionary<string, string> sessionCodeName = _sessionRepository
                .Get(c => c.StatusId == CommonStatus.ACTIVE)
                .ToDictionary(q => q.Code, q => string.Format("{0} {1}", q.Code, q.Name));
            return _TimeSlotRepository.Get(c => c.StatusId == CommonStatus.ACTIVE)
                .OrderBy(c => c.SessionCode).ThenBy(c => c.Name)
                .Select(ts => new TimeSlot() {
                    Id = ts.Id,
                    Code = ts.Code,
                    StatusId = ts.StatusId,
                    CreateDate = ts.CreateDate,
                    FromHour = ts.FromHour,
                    LastUpdateBy = ts.LastUpdateBy,
                    LastUpdateDate = ts.LastUpdateDate,
                    Name = ts.Name,
                    Price = ts.Price,
                    SessionCode = sessionCodeName.Where(s => s.Key == ts.SessionCode).FirstOrDefault().Value,
                    Length = ts.Length
                })
                .ToList();
        }

        public Dictionary<int, string> Getoptions()
        {
            var options = _TimeSlotRepository.Get(t => t.StatusId == CommonStatus.ACTIVE).ToDictionary(x => x.Id, x => x.Name);
            
            return options;
        }

        public List<KeyValuePair<double, int>> GetTimeSlotLengthOptions(int timeSlotId)
        {
            List<KeyValuePair<double, int>> result = new List<KeyValuePair<double, int>>();
            KeyValuePair<double, int> op = new KeyValuePair<double, int>();
            var options = _TimeSlotRepository.Get(t => t.Id == timeSlotId);
            foreach (var option in options)
            {
                op = new KeyValuePair<double, int>(option.Price, option.Length);
                result.Add(op);
            }
            return result;
        }
    }
}
