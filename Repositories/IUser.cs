using Entities;

namespace Repositories
{
    public interface IUser
    {
        bool AddUser(User user);
        User GetUserById(int id);
        bool Login(string userName, string password);
        bool UpdateUser(int id, User userToUpdate);
        int CheckPassword(string password);
    }
}