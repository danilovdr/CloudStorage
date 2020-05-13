using CloudStorage.DAL.Interfaces.Context;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DAL.Interfaces.Models;

namespace CloudStorage.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<UserModel> UserRepository { get; }
        public IRepository<FolderModel> FolderRepository { get; }
        public IRepository<UserFolderModel> UserFolderRepository { get; }
        public IRepository<FileModel> FileRepository { get; }
        public IRepository<UserFileModel> UserFileRepository { get; }

        public UnitOfWork(IApplicationDbContext dbContext, IRepository<UserModel> userRepository,
            IRepository<FolderModel> folderRepository, IRepository<UserFolderModel> userFolderRepository,
            IRepository<FileModel> fileRepository, IRepository<UserFileModel> userFileRepository)
        {
            _dbContext = dbContext;
            UserRepository = userRepository;
            FolderRepository = folderRepository;
            UserFolderRepository = userFolderRepository;
            FileRepository = fileRepository;
            UserFileRepository = userFileRepository;
        }

        private IApplicationDbContext _dbContext;

        public void Save()
        {
            _dbContext.Save();
        }
    }
}
