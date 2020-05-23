using CloudStorage.DAL.Interfaces.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudStorage.DAL.Interfaces.Context
{
    public interface IApplicationDbContext
    {
        DbSet<UserModel> Users { get; set; }
        DbSet<FolderModel> Folders { get; set; }
        DbSet<FolderPermissionModel> UserFolders { get; set; }
        DbSet<FilePermissionModel> UserFolderFile { get; set; }
        DbSet<FileModel> Files { get; set; }
        void Save();
    }
}
