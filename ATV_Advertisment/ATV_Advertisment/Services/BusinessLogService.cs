using DataService.Model;
using DataService.Repositories;

namespace ATV_Advertisment.Services
{
    public interface IBusinessLogService
    {
        void Log(BusinessLog input);
    }

    public class BusinessLogService : IBusinessLogService
    {
        private readonly BusinessLogRepository _businessLogRepository;

        public BusinessLogService()
        {
            _businessLogRepository = new BusinessLogRepository();
        }

        public void Log(BusinessLog input)
        {
            _businessLogRepository.Add(input);
        }
    }
}
