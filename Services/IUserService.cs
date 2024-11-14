using Entities;

namespace Services
{
    public interface IUserService
    {
        User AddUser(User user);
        int CheckPassword(string password);
        User GetUserById(int id);
        User Login(string userName, string password);
        bool UpdateUser(int id, User userToUpdate);
    }
}