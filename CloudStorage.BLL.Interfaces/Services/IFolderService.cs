using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.BLL.Interfaces.ViewModels;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IFolderService
    {
        void CreateFolder(FolderDTO folder);
        void DeleteFolder(FolderDTO folder);
        FolderViewModel GetFolder(FolderDTO folder);
    }
}
