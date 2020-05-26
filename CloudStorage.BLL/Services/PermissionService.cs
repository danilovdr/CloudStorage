using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DAL.Interfaces.Models;
using CloudStorage.DomainModels;
using System;
using System.Linq;

namespace CloudStorage.BLL.Services
{
    public class PermissionService : IPermissionService
    {
        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork _unitOfWork;

        public PermissionType GetFolderPermission(Guid folderId, Guid userId)
        {
            FolderPermissionModel fpm = _unitOfWork.FolderPermissionRepository
                .Find(p => p.User.Id == userId && p.Folder.Id == folderId)
                .FirstOrDefault();
            return fpm == null ? PermissionType.None : fpm.Value;
        }

        public PermissionType GetFilePermission(Guid fileId, Guid userId)
        {
            FilePermissionModel fpm = _unitOfWork.FilePermissionRepository
                .Find(p => p.User.Id == userId && p.File.Id == fileId)
                .FirstOrDefault();
            return fpm == null ? PermissionType.None : fpm.Value;
        }

        public void SetFolderPermission(Guid folderId, Guid userId, PermissionType permission)
        {
            UserModel userModel = _unitOfWork.UserRepository.Get(userId);
            if (userModel == null)
                throw new Exception();

            FolderModel folderModel = _unitOfWork.FolderRepository.Get(folderId);
            if (folderModel == null)
                throw new Exception();

            FolderPermissionModel fpm = _unitOfWork.FolderPermissionRepository
                    .Find(p => p.User.Id == userId && p.Folder.Id == folderId)
                    .FirstOrDefault();
            if (fpm == null)
            {
                if (permission != PermissionType.None)
                {
                    fpm = new FolderPermissionModel()
                    {
                        User = userModel,
                        Folder = folderModel,
                        Value = permission
                    };
                    _unitOfWork.FolderPermissionRepository.Create(fpm);
                }
            }
            else
            {
                if (permission == PermissionType.None)
                {
                    _unitOfWork.FolderPermissionRepository.Delete(fpm.Id);
                }
                else
                {
                    fpm.Value = permission;
                    _unitOfWork.FolderPermissionRepository.Update(fpm);
                }
            }
            _unitOfWork.Save();
        }

        public void SetFilePermission(Guid fileId, Guid userId, PermissionType permission)
        {
            UserModel userModel = _unitOfWork.UserRepository.Get(userId);
            if (userModel == null)
                throw new Exception();

            FileModel fileModel = _unitOfWork.FileRepository.Get(fileId);
            if (fileModel == null)
                throw new Exception();

            FilePermissionModel fpm = _unitOfWork.FilePermissionRepository
                    .Find(p => p.User.Id == userId && p.File.Id == fileId)
                    .FirstOrDefault();
            if (fpm == null)
            {
                if (permission != PermissionType.None)
                {
                    fpm = new FilePermissionModel()
                    {
                        User = userModel,
                        File = fileModel,
                        Value = permission
                    };
                    _unitOfWork.FilePermissionRepository.Create(fpm);
                }
            }
            else
            {
                if (permission == PermissionType.None)
                {
                    _unitOfWork.FilePermissionRepository.Delete(fpm.Id);
                }
                else
                {
                    fpm.Value = permission;
                    _unitOfWork.FilePermissionRepository.Update(fpm);
                }
            }
            _unitOfWork.Save();
        }
    }
}
