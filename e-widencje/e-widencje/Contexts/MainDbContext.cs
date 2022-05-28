using e_widencje.Models;
using Microsoft.EntityFrameworkCore;

namespace e_widencje.Contexts
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<ExciseEvidence> ExciseEvidences { get; set; }
    }
}
