using CloudStorage.BLL.Interfaces.Models.File;
using CloudStorage.BLL.Interfaces.ViewModels.File;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IFileService
    {
        void CreateFile(CreateFileDTO createFile);
        void UpdateFile(UpdateFileDTO updateFile);
        void DeleteFile(DeleteFileDTO deleteFile);
        bool UserHasAccess(UserHasAccessDTO userHasAccess);
        FilesByUserViewMode GetFilesByUser(FilesByUserDTO filesByUser);
    }
}
