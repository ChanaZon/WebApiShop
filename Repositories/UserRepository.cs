using Entities;
using System.Runtime.InteropServices;
using System.Text.Json;
namespace Repositories

{
    public class UserRepository : IUserRepository
    {
        MyShopContext _context;
        public UserRepository(MyShopContext context)
        {
            _context = context; 
        }


        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            //var res=await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            //return res- the created user with the id
            return user;
        }

        public User Login(string userName, string password)
        {

            User user = _context.Users.FirstOrDefault(u =>  u.UserName == userName && u.Password == password );
           if(user == null) 
                return null;
            return user;

        }

        public User GetUserById(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
                return null;
            return user;
        }

        public async Task<User> UpdateUserAsync(int id, User userToUpdate)
        {

            if(userToUpdate == null)
            {
                return null;
            }
           _context.Update(userToUpdate);
            await _context.SaveChangesAsync();
            return userToUpdate;
        }
    }
}
