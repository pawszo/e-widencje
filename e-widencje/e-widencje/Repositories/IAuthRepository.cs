using e_widencje.Models;
using System.Threading.Tasks;

namespace e_widencje.Repositories
{
    public interface IAuthRepository
    {
        public Task<User> Auth(LoginModel login);
        public Task<bool> Register(LoginModel login);
        public Task<User> Get(string email);
    }
}
