using System;
using System.Collections.Generic;
using WebForms.Data;
using WebForms.Interfaces;
using WebForms.Services;

namespace WebForms.Repository
{
    public class SQLUser : IUser
    {
        private readonly AppDbContext context;
        public SQLUser(AppDbContext context)
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
            return user.PasswordHash;
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

        public string hashPassword(string password)
        {
            var sha256 = System.Security.Cryptography.SHA256.Create();
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            var hashedPassword = sha256.ComputeHash(passwordBytes);

            return Convert.ToBase64String(hashedPassword);
        }
    }
}