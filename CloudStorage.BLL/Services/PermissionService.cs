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

        public void AddFolderPermission(Guid folderId, Guid userId, PermissionType permission)
        {
            UserModel userModel = _unitOfWork.UserRepository.Get(userId);
            if (userModel == null)
                throw new Exception();

            FolderModel folderModel = _unitOfWork.FolderRepository.Get(folderId);
            if (folderModel == null)
                throw new Exception();

            FolderPermissionModel folderPermissionModel = new FolderPermissionModel()
            {
                User = userModel,
                Folder = folderModel,
                Value = permission
            };

            _unitOfWork.FolderPermissionRepository.Create(folderPermissionModel);
            _unitOfWork.Save();
        }

        public void AddFilePermission(Guid fileId, Guid userId, PermissionType permission)
        {
            UserModel userModel = _unitOfWork.UserRepository.Get(userId);
            if (userModel == null)
                throw new Exception();

            FileModel fileModel = _unitOfWork.FileRepository.Get(fileId);
            if (fileModel == null)
                throw new Exception();

            FilePermissionModel filePermissionModel = new FilePermissionModel()
            {
                User = userModel,
                File = fileModel,
                Value = permission
            };

            _unitOfWork.FilePermissionRepository.Create(filePermissionModel);
            _unitOfWork.Save();
        }

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

        public void RemoveFolderPermission(Guid folderId, Guid userId)
        {
            FolderPermissionModel folderPermissionModel = _unitOfWork.FolderPermissionRepository
                .Find(p => p.User.Id == userId && p.Folder.Id == folderId)
                .FirstOrDefault();
            if (folderPermissionModel == null)
                throw new Exception();

            _unitOfWork.FolderPermissionRepository.Delete(folderPermissionModel.Id);
            _unitOfWork.Save();
        }

        public void RemoveFilePermission(Guid fileId, Guid userId)
        {
            FilePermissionModel filePermissionModel = _unitOfWork.FilePermissionRepository
              .Find(p => p.User.Id == userId && p.File.Id == fileId)
              .FirstOrDefault();
            if (filePermissionModel == null)
                throw new Exception();

            _unitOfWork.FilePermissionRepository.Delete(filePermissionModel.Id);
            _unitOfWork.Save();
        }
    }
}
