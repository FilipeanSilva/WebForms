using System.Collections.Generic;

namespace WebForms.Models.Users
{
    public class SQLUserRepository : IUser
    {
        private readonly AppDbContext context;
        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public User AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public void DeleteUser(int userId)
        {
            User user = context.Users.Find(userId);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users;
        }

        public string GetHashedPassword(int userId)
        {
            User user = context.Users.Find(userId);
            return user.Password;
        }

        public string GetSalt(int userId)
        {
            User user = context.Users.Find(userId);
            return user.Salt;
        }

        public User GetUserById(int userId)
        {
            User user = context.Users.Find(userId);
            if (user == null)
            {
                return null;
            }

            context.Users.Remove(user);
            context.SaveChanges();
            return user;
        }
    }
}