using Repositories;
using Entities;
using System.Text.Json;
using Zxcvbn;

namespace Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }


        public User AddUser(User user)
        {            //check password strength

            return _userRepository.AddUser(user);
        }

        public User Login(string userName, string password)
        {
            return _userRepository.Login(userName, password);
        }

        public Boolean UpdateUser(int id, User userToUpdate)
        {            //check password strength

            return _userRepository.UpdateUser(id, userToUpdate);

        }
        public int CheckPassword(string password)
        {
            if (password == null || password == "")
            {
                return -1;
            } 
            var result = Zxcvbn.Core.EvaluatePassword(password);

            return result.Score;
        }
    }
}

