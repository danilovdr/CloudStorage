using CloudStorage.DAL.Interfaces.Context;
using CloudStorage.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace CloudStorage.DAL.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
