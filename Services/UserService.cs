using Repositories;
using Entities;
using System.Text.Json;

namespace Services
{
    public class UserService:IUser
    {
        IUser _userRepository;

        public UserService(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }


        public Boolean AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public Boolean Login(string userName, string password)
        {
            return _userRepository.Login(userName, password);
        }

        public Boolean UpdateUser(int id, User userToUpdate)
        {
                return _userRepository.UpdateUser(id, userToUpdate);

        }
    }
}

