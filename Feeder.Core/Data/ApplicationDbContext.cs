using Feeder.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Feeder.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Post> Posts { get; set; } = default!;
    }
}