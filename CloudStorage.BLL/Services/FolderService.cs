using CloudStorage.BLL.Interfaces.DTO;
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
        public FolderService(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public FolderDTO CreateFolder(FolderDTO folder, Guid userId)
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
            return new FolderDTO()
            {
                Id = folderModel.Id,
                Name = folderModel.Name,
                ParentFolderId = folderModel.ParentId
            };
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

        public List<FolderDTO> GetUserFolders(Guid parentFolderId, Guid userId)
        {
            List<FolderModel> folderModels = _unitOfWork.FolderRepository
                .Find(p =>
                p.Owner.Id == userId &&
                p.Owner.Id == userId)
                .ToList();
            List<FolderDTO> folders = new List<FolderDTO>();

            foreach (FolderModel folder in folderModels)
            {
                FolderDTO folderDTO = new FolderDTO()
                {
                    Id = folder.Id,
                    Name = folder.Name,
                    ParentFolderId = folder.Parent.Id
                };
                folders.Add(folderDTO);
            }
            return folders;
        }

        public List<FolderDTO> GetSharedFolders(Guid parentFolderId, Guid userId)
        {
            List<FolderPermissionModel> fpm = _unitOfWork.FolderPermissionRepository
              .Find(p =>
              p.Folder.Parent.Id == parentFolderId &&
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

        public List<FileDTO> GetUserFiles(Guid parentFolderId, Guid userId)
        {
            List<FileModel> fileModels = _unitOfWork.FileRepository
                .Find(p =>
                p.Owner.Id == userId &&
                p.ParentId == parentFolderId)
                .ToList();
            List<FileDTO> files = new List<FileDTO>();

            foreach (FileModel file in fileModels)
            {
                FileDTO fileDTO = new FileDTO()
                {
                    Id = file.Id,
                    Name = file.Name,
                    Content = file.Content,
                    ParentFolderId = file.Parent.Id
                };
                files.Add(fileDTO);
            }
            return files;
        }

        public List<FileDTO> GetSharedFiles(Guid parentFolderId, Guid userId)
        {
            List<FilePermissionModel> fpm = _unitOfWork.FilePermissionRepository
             .Find(p =>
             p.File.Parent.Id == parentFolderId &&
             p.User.Id == userId &&
             p.Value != PermissionType.None)
             .ToList();
            List<FileDTO> files = new List<FileDTO>();

            foreach (FilePermissionModel file in fpm)
            {
                FileModel fileModel = _unitOfWork.FileRepository.Get(file.Id);
                FileDTO folderDTO = new FileDTO()
                {
                    Id = fileModel.Id,
                    Name = fileModel.Name,
                    Content = fileModel.Content,
                    ParentFolderId = fileModel.Parent.Id
                };
                files.Add(folderDTO);
            }
            return files;
        }
    }
}
