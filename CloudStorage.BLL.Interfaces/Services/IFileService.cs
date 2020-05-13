using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.DomainModels;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IFileService
    {
        void CreateFile(FileDTO file);
        void UpdateFile(FileDTO file);
        void DeleteFile(FileDTO file);
        File GetFile(FileDTO file);
    }
}
