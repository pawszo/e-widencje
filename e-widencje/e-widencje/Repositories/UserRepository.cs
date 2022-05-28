using e_widencje.Contexts;
using e_widencje.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace e_widencje.Repositories
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
