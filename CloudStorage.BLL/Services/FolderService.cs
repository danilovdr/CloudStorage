using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DAL.Interfaces.Models;
using CloudStorage.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudStorage.BLL.Services
{
    public class FolderService : IFolderService
    {
        public FolderService(IUnitOfWork unitOfWork, IFileService fileService, IPermissionService permissionService)
        {
            _unitOfWork = unitOfWork;
            _permissionService = permissionService;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IPermissionService _permissionService;

        public void CreateFolder(FolderDTO folder, Guid userId)
        {
            UserModel owner = _unitOfWork.UserRepository.Get(userId);
            if (owner == null)
                throw new Exception();

            FolderModel folderModel = new FolderModel()
            {
                Name = folder.Name,
                Owner = owner
            };

            if (folder.ParentFolderId == null)
            {
                folderModel.Parent = null;
            }
            else
            {
                FolderModel parent = _unitOfWork.FolderRepository.Get((Guid)folder.ParentFolderId);
                if (parent == null)
                    throw new Exception();

                if (parent.Owner.Id != userId)
                    throw new Exception();

                folderModel.Parent = parent;
            }

            _unitOfWork.FolderRepository.Create(folderModel);
            _unitOfWork.Save();
        }

        public void DeleteFolder(Guid folderId, Guid userId)
        {
            FolderModel folderModel = _unitOfWork.FolderRepository.Get(folderId);
            if (folderModel == null)
                throw new Exception();

            if (folderModel.Owner.Id != userId)
                throw new Exception();

            List<FileModel> files = _unitOfWork.FileRepository.Find(p => p.Parent.Id == folderId).ToList();
            foreach (FileModel file in files)
                _fileService.DeleteFile(file.Id, userId);

            List<FolderModel> folders = _unitOfWork.FolderRepository.Find(p => p.Parent.Id == folderId).ToList();
            foreach (FolderModel folder in folders)
                DeleteFolder(folder.Id, userId);

            _unitOfWork.FolderRepository.Delete(folderId);
            _unitOfWork.Save();
        }

        public List<FolderDTO> GetFoldersInFolder(Guid folderId, Guid userId)
        {
            List<FolderPermissionModel> fpm = _unitOfWork.FolderPermissionRepository
                .Find(p =>
                p.Folder.Parent.Id == folderId &&
                p.User.Id == userId &&
                p.Value != PermissionType.None)
                .ToList();
            List<FolderDTO> folders = new List<FolderDTO>();

            foreach (FolderPermission folder in fpm)
            {
                FolderModel folderModel = _unitOfWork.FolderRepository.Get(folder.Id);
                FolderDTO folderDTO = new FolderDTO()
                {
                    Id = folderModel.Id,
                    Name = folderModel.Name,
                    ParentFolderId = folderModel.Parent.Id
                };
                folders.Add(folderDTO);
            }
            return folders;
        }

        public List<FileDTO> GetFilesInFolder(Guid folderId, Guid userId)
        {
            List<FilePermissionModel> fpm = _unitOfWork.FilePermissionRepository
                .Find(p =>
                p.File.Parent.Id == folderId &&
                p.User.Id == userId &&
                p.Value != PermissionType.None)
                .ToList();
            List<FileDTO> files = new List<FileDTO>();

            foreach (FilePermission file in fpm)
            {
                FileModel fileModel = _unitOfWork.FileRepository.Get(file.Id);
                FileDTO fileDTO = new FileDTO()
                {
                    Id = fileModel.Id,
                    Name = fileModel.Name,
                    Content = fileModel.Content,
                    ParentFolderId = fileModel.Parent.Id
                };
                files.Add(fileDTO);
            }
            return files;
        }
    }
}
