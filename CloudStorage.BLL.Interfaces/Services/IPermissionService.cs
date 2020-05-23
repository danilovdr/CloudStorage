using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.DomainModels;
using System;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IPermissionService
    {
        void AddFolderPermission(Guid folderId, Guid userId, PermissionType permission);
        void AddFilePermission(Guid fileId, Guid userId, PermissionType permission);
        PermissionType GetFolderPermission(Guid folderId, Guid userId);
        PermissionType GetFilePermission(Guid fileId, Guid userId);
        void RemoveFolderPermission(Guid folderId, Guid userId);
        void RemoveFilePermission(Guid fileId, Guid userId);
    }
}
