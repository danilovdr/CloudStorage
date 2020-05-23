using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DAL.Interfaces.Models;
using CloudStorage.DomainModels;
using System;

namespace CloudStorage.BLL.Services
{
    public class FileService : IFileService
    {
        public FileService(IUnitOfWork unitOfWork, IPermissionService permissionService)
        {
            _unitOfWork = unitOfWork;
            _permissionService = permissionService;
        }

        private IUnitOfWork _unitOfWork;
        private IPermissionService _permissionService;

        public void CreateFile(FileDTO file, Guid userId)
        {
            UserModel creator = _unitOfWork.UserRepository.Get(userId);
            if (creator == null)
                throw new Exception();

            FileModel fileModel = new FileModel()
            {
                Name = file.Name,
                Content = file.Content,
                Creator = creator,
            };

            if (file.ParentFolderId == null)
            {
                fileModel.Owner = creator;
                fileModel.Parent = null;
            }
            else
            {
                FolderModel parent = _unitOfWork.FolderRepository.Get((Guid)file.ParentFolderId);
                if (parent == null)
                    throw new Exception();

                if (parent.Owner.Id != userId)
                {
                    PermissionType permission = _permissionService.GetFolderPermission((Guid)file.ParentFolderId, userId);
                    if (permission == PermissionType.None)
                        throw new Exception();

                    FilePermissionModel filePermissionModel = new FilePermissionModel()
                    {
                        User = creator,
                        File = fileModel,
                        Value = PermissionType.Edit
                    };

                    _unitOfWork.FilePermissionRepository.Create(filePermissionModel);
                }

                fileModel.Parent = parent;
                fileModel.Owner = parent.Owner;
            }

            _unitOfWork.FileRepository.Create(fileModel);
            _unitOfWork.Save();
        }

        public void UpdateFile(FileDTO file, Guid userId)
        {
            FileModel fileModel = _unitOfWork.FileRepository.Get(file.Id);
            if (fileModel == null)
                throw new Exception();

            if (fileModel.Owner.Id != userId)
            {
                PermissionType permission = _permissionService.GetFilePermission(file.Id, userId);
                if (permission != PermissionType.Edit)
                    throw new Exception();
            }

            fileModel.Name = file.Name;
            fileModel.Content = file.Content;
            _unitOfWork.FileRepository.Update(fileModel);
            _unitOfWork.Save();
        }

        public void DeleteFile(Guid fileId, Guid userId)
        {
            FileModel fileModel = _unitOfWork.FileRepository.Get(fileId);
            if (fileModel == null)
                throw new Exception();

            if (fileModel.Owner.Id != userId)
            {
                PermissionType permission = _permissionService.GetFilePermission(fileId, userId);
                if (permission != PermissionType.Edit)
                    throw new Exception();
            }

            _unitOfWork.FileRepository.Delete(fileId);
            _unitOfWork.Save();
        }

        public FileDTO GetFile(Guid fileId, Guid userId)
        {
            FileModel fileModel = _unitOfWork.FileRepository.Get(fileId);
            if (fileModel == null)
                throw new Exception();

            if (fileModel.Owner.Id != userId)
            {
                PermissionType permission = _permissionService.GetFilePermission(fileId, userId);
                if (permission == PermissionType.None)
                    throw new Exception();
            }

            return new FileDTO()
            {
                Id = fileModel.Id,
                Name = fileModel.Name,
                Content = fileModel.Content,
                ParentFolderId = fileModel.Parent.Id
            };
        }
    }
}
