using System;
using System.Linq;

namespace WebForms.Models.Users
{
    public class UserRepository
    {
        private readonly AppDbContext context;
        private readonly SQLUserRepository sqlUserRepository;
        public UserRepository()
        {
            context = new AppDbContext();
            sqlUserRepository = new SQLUserRepository(context);
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var matchingUser = sqlUserRepository.GetAllUsers().ToList()
                .FirstOrDefault(user => user.Username == username && sqlUserRepository.hashPassword($"{password}{user.Salt}") == user.PasswordHash);

            return matchingUser;
        }

        public User Register(User newUser)
        {
            if (newUser == null)
            {
                return null;
            }


            var matchingUser = sqlUserRepository.GetAllUsers().ToList()
                .FirstOrDefault(user => user.Username == newUser.Username);

            if (matchingUser != null)
            {
                return null;
            }

            Random rand = new Random();
            int salt = rand.Next();
            string saltedPw = $"{newUser.PasswordHash}{salt}";
            string hashedPassword = sqlUserRepository.hashPassword($"{newUser.PasswordHash}{salt}");

            newUser.PasswordHash = hashedPassword;
            newUser.Salt = salt.ToString();

            sqlUserRepository.AddUser(newUser);
            return newUser;
        }
    }
}