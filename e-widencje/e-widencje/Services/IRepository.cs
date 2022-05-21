using e_widencje.Models;

namespace e_widencje.Services
{
    public interface IRepository
    {
        public User Auth(LoginModel login);
        public void Register(LoginModel login);
        public User Get(string email);
    }
}
