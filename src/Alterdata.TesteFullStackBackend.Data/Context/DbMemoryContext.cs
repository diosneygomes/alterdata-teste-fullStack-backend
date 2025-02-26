using Alterdata.TesteFullstackBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alterdata.TesteFullStackBackend.Data.Context
{
    public sealed class DbMemoryContext : DbContext
    {
        public DbMemoryContext(DbContextOptions<DbMemoryContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbMemoryContext).Assembly);
        }
    }
}
