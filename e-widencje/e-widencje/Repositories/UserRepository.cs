using e_widencje.Contexts;
using e_widencje.Models;
using System.Threading.Tasks;

namespace e_widencje.Repositories
{
    public class UserRepository : RepositoryBase<User, MainDbContext>
    {
        public UserRepository(MainDbContext context) : base(context)
        {
        }

        public override async Task<User> Delete(int id)
        {
            var user = await Get(id);

            if (user is null) return null;

            user.IsActive = false;
            return await Update(user);
        }
    }
}
