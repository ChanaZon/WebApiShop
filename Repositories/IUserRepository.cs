//using Entities;
using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        User GetUserById(int id);
        User Login(string userName, string password);
        Task<User> UpdateUserAsync(int id, User userToUpdate);
    }
}