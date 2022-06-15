using Ewidencje.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Ewidencje.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DbContext _context;

        public AuthRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<User> Auth(LoginModel login) => await _context.Set<User>().FirstOrDefaultAsync(p => p.Email.Equals(login.Email, StringComparison.InvariantCultureIgnoreCase) && p.Password.Equals(login.Password));

        public async Task<User> Get(string email) => await _context.Set<User>().FirstOrDefaultAsync(p => p.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));

        public async Task<bool> Register(LoginModel login)
        {
            var emailOrUserNameAlreadyRegistered = await _context.Set<User>().AnyAsync(p => p.Email.Equals(login.Email, StringComparison.InvariantCultureIgnoreCase) || p.UserName.Equals(login.UserName, StringComparison.InvariantCultureIgnoreCase));

            if (emailOrUserNameAlreadyRegistered)
                return false;

            var registeredUser = await _context.Set<User>().AddAsync(
                new User { Email = login.Email, FirstName = login.FirstName, IsActive = false, LastName = login.LastName, Password = login.Password, PersonalId = login.PersonalId, UserName = login.UserName });

            return registeredUser != null;
        }
    }
}
