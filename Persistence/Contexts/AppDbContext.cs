using jobagapi.Domain.Models;
using jobagapi.Extensions;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Postulation> Postulations { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        }
    }
}