using e_widencje.Models;
using System.Collections.Generic;
using System.Linq;

namespace e_widencje.Services
{
    public class MoqData
    {
        private List<User> users;

        private List<User> GetUsers()
        {
            return users;
        }

        private void SetUsers(List<User> value)
        {
            users = value;
        }

        public MoqData()
        {
            UserData();
        }

        private void UserData()
        {
            List<User> users = new()
            {
                new User { Id = 1, FirstName = "Amanda", LastName = "Glenn", Email = "admin@admin.com", UserName = "admin", Password = "admin", PersonalId = "111111111", IsActive = true},
                new User { Id = 2, FirstName = "Pamela", LastName = "Chambers", Email = "user@user.com", UserName = "user", Password = "user", PersonalId = "222222222", IsActive = false },
                new User { Id = 3, FirstName = "Sarah", LastName = "Lindsay", Email = "sarah@user.com", UserName = "sarah", Password = "sarah", PersonalId = "333333333", IsActive = true }
            };
            SetUsers(users);
        }

        public User Auth(LoginModel login) => GetUsers().FirstOrDefault(u => (u.Email == login.Email && u.Password == login.Password));

        public void Register(LoginModel login)
        {
            // TODO  DB Add User
        }

        public User Get(string email) => GetUsers().FirstOrDefault(u => u.Email == email || u.Email == "admin@admin.com");
    }
}
