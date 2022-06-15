using Ewidencje.Domain.Models;
using Ewidencje.Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;

namespace Ewidencje.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User, MainDbContext>
    {
        public UserRepository(MainDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public override async Task<User> Delete(int id)
        {
            var user = await Get(id);

            if (user is null) return null;

            user.IsActive = false;
            return await Update(id, user);
        }
    }
}
