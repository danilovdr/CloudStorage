using CloudStorage.BLL.Interfaces.Models.Folder;
using CloudStorage.BLL.Interfaces.ViewModels.Folder;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IFolderService
    {
        void CreateFolder(CreateFolderDTO createFolder);
        void DeleteFolder(DeleteFolderDTO deleteFolder);
        bool UserHasAccess(UserHasAccessDTO userHasAccess);
        FoldersByUserViewModel GetFoldersByUser(FoldersByUserDTO userHasAccess);
    }
}
