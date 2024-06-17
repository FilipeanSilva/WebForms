using System.Collections.Generic;

namespace WebForms.Models.Users
{
    public interface IUser
    {
        User AddUser(User user);
        void DeleteUser(int userId);
        User GetUserById(int userId);
        string GetHashedPassword(int userId);
        string GetSalt(int userId);
        IEnumerable<User> GetAllUsers();
    }
}