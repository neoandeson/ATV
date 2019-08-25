using DataService.Infrastructure;
using DataService.Model;
using DataService.Repositories;
using System;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface IUserService
    {
        User GetLogin(string username, string password);
        void UpdateLastLogin(string username);
    }

    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public User GetLogin(string username, string password)
        {
            HashHelper hashHelper = new HashHelper();
            return _userRepository.GetAll()
                .Where(u => u.Username == username &&
                            u.StatusId == CommonStatus.ACTIVE &&
                            hashHelper.VerifyHashedPassword(u.Password, password))
                .FirstOrDefault();
        }

        public void UpdateLastLogin(string username)
        {
            _userRepository.Get(u => u.Username == username).FirstOrDefault()
                .LastLoginTime = DateTime.Now;
        }
    }
}
