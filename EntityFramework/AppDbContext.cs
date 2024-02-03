using Domain.LinkInfo;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Link> Links { get; set; }
    }
}
