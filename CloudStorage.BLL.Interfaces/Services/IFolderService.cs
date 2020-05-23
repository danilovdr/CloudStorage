using CloudStorage.BLL.Interfaces.Models;
using System;
using System.Collections.Generic;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IFolderService
    {
        void CreateFolder(FolderDTO folder, Guid userId);
        void DeleteFolder(Guid folderId, Guid userId);
        List<FolderDTO> GetFoldersInFolder(Guid parentFolderId, Guid userId);
        List<FileDTO> GetFilesInFolder(Guid parentFolderId, Guid userId);
    }
}
