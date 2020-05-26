using CloudStorage.DomainModels;
using System;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IPermissionService
    {
        void SetFolderPermission(Guid folderId, Guid userId, PermissionType permission);
        void SetFilePermission(Guid fileId, Guid userId, PermissionType permission);
        PermissionType GetFolderPermission(Guid folderId, Guid userId);
        PermissionType GetFilePermission(Guid fileId, Guid userId);
    }
}
