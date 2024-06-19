using System.Collections.Generic;
using WebForms.Data;

namespace WebForms.Interfaces
{
    public interface IUser
    {
        User AddUser(User user);
        void DeleteUser(int userId);
        User GetUserById(int userId);
        string GetHashedPassword(int userId);
        string GetSalt(int userId);
        IEnumerable<User> GetAllUsers();
        string hashPassword(string password);
    }
}