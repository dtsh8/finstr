using FinstarApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FinstarApp
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DataObject> DataObjects { get; set; }
        protected ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DataObject>(e =>
            {
                e.ToTable("DataTable");
            });
        }
    }
}