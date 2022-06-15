using Ewidencje.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ewidencje.Infrastructure.Contexts
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
