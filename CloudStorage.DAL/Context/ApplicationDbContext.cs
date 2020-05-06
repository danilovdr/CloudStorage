using CloudStorage.DAL.Interfaces.Context;
using CloudStorage.DAL.Interfaces.Models;
using CloudStorage.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace CloudStorage.DAL.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<FolderModel> Folders { get; set; }
        public DbSet<UserFolderModel> UserFolders { get; set; }
        public DbSet<UserFolderFileModel> UserFolderFile { get; set; }
        public DbSet<FileModel> Files { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFolderFileModel>()
                .ToTable("UserFolderFile")
                .HasKey(p => new { p.UserId, p.FolderId, p.FileId });

            modelBuilder.Entity<UserFolderFileModel>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserFolderFile)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<UserFolderFileModel>()
                .HasOne(p => p.Folder)
                .WithMany(p => p.UserFolderFile)
                .HasForeignKey(p => p.FolderId);

            modelBuilder.Entity<UserFolderFileModel>()
                .HasOne(p => p.File)
                .WithMany(p => p.UserFolderFile)
                .HasForeignKey(p => p.FileId);

            modelBuilder.Entity<UserFolderModel>()
                .ToTable("UserFolder")
                .HasKey(p => new { p.UserId, p.FolderId });

            modelBuilder.Entity<UserFolderModel>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserFolder)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<UserFolderModel>()
                .HasOne(p => p.Folder)
                .WithMany(p => p.UserFolder)
                .HasForeignKey(p => p.FolderId);

            modelBuilder.Entity<UserModel>()
                .ToTable("User")
                .HasKey(p => p.Id);

            modelBuilder.Entity<FolderModel>()
                .ToTable("Folder")
                .HasKey(p => p.Id);

            modelBuilder.Entity<File>()
                .ToTable("File")
                .HasKey(p => p.Id);
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
