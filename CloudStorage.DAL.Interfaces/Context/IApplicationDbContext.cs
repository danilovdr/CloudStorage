using CloudStorage.DAL.Interfaces.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudStorage.DAL.Interfaces.Context
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<File> Files { get; set; }
        void Save();
    }
}
