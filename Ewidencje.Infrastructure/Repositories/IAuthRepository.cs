using Ewidencje.Domain.Models;
using System.Threading.Tasks;

namespace Ewidencje.Infrastructure.Repositories
{
    public interface IAuthRepository
    {
        public Task<User> Auth(LoginModel login);
        public Task<bool> Register(LoginModel login);
        public Task<User> Get(string email);
    }
}
