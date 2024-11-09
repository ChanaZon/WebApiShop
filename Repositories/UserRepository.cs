using Entities;
using System.Runtime.InteropServices;
using System.Text.Json;
namespace Repositories

{
    public class UserRepository
    {
        string filePath = "E:\\web api\\Web Api\\MyShop\\MyShop\\users.txt";
        public User GetUserById(int id)
            {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        return user;
                }
            }
            User u = new();
            return u;
        }


        public User AddUser( User user)
            {
                int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
                user.UserId = numberOfUsers + 1;
                string userJson = JsonSerializer.Serialize(user);
                System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
            }

            public User Login(string userName, string password)
            {
                using (StreamReader reader = System.IO.File.OpenText(filePath))
                {
                    string? currentUserInFile;
                    while ((currentUserInFile = reader.ReadLine()) != null)
                    {
                        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                        if (user.UserName == userName && user.Password == password)

                            return user;
                    }
                }
            User u = new();

            return u;

            }

            public User UpdateUser(int id, User userToUpdate)
            {

                string textToReplace = string.Empty;
                using (StreamReader reader = System.IO.File.OpenText(filePath))
                {
                    string currentUserInFile;
                    while ((currentUserInFile = reader.ReadLine()) != null)
                    {

                        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                        if (user.UserId == id)
                            textToReplace = currentUserInFile;
                    }
                }

                if (textToReplace != string.Empty)
                {
                    string text = System.IO.File.ReadAllText(filePath);
                    text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                    System.IO.File.WriteAllText(filePath, text);
                    return userToUpdate;
                }
                else
                {
                    return userToUpdate;
                }

            }
        }
}
