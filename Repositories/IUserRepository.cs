using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserById(int id);
        User Login(string userName, string password);
        bool UpdateUser(int id, User userToUpdate);
    }
}