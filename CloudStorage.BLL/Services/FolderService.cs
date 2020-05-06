using CloudStorage.BLL.Interfaces.Models.Folder;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.BLL.Interfaces.ViewModels.Folder;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudStorage.BLL.Services
{
    public class FolderService : IFolderService
    {
        public void CreateFolder(CreateFolderDTO createFolder)
        {
            throw new NotImplementedException();
        }

        public void DeleteFolder(DeleteFolderDTO deleteFolder)
        {
            throw new NotImplementedException();
        }

        public FoldersByUserViewModel GetFoldersByUser(FoldersByUserDTO userHasAccess)
        {
            throw new NotImplementedException();
        }

        public bool UserHasAccess(UserHasAccessDTO userHasAccess)
        {
            throw new NotImplementedException();
        }
    }
}
