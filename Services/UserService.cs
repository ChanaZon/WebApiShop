using Repositories;
using Entities;
using System.Text.Json;

namespace Services
{
    public class UserService
    {
        UserRepository repository = new();
        public User GetUserById(int id)
        {
            return repository.GetUserById(id);
        }


        public User AddUser(User user)
        {
            return repository.AddUser(user);
        }

        public User Login(string userName, string password)
        {
            return repository.Login(userName, password);
        }

        public User UpdateUser(int id, User userToUpdate)
        {
                return repository.UpdateUser(id, userToUpdate);

        }
    }
}

