using CloudStorage.DAL.Interfaces.Models;

namespace CloudStorage.DAL.Interfaces.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<UserModel> UserRepository { get; }
        IRepository<FolderModel> FolderRepository { get; }
        IRepository<UserFolderModel> UserFolderRepository { get; }
        IRepository<FileModel> FileRepository { get; }
        IRepository<UserFileModel> UserFileRepository { get; }

        void Save();

    }
}
