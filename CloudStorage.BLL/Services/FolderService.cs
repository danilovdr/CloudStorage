using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.BLL.Interfaces.ViewModels;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DAL.Interfaces.Models;
using CloudStorage.DomainModels;
using System;
using System.Linq;

namespace CloudStorage.BLL.Services
{
    public class FolderService : IFolderService
    {
        public FolderService(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        private IUnitOfWork _unitOfWork;
        private IUserService _userService;

        public void CreateFolder(FolderDTO folder)
        {
            User user = _userService.GetUser(folder.User);

            if (user == null)
            {
                //exception
            }

            FolderModel parentFolder = _unitOfWork.FolderRepository.Get(folder.ParentFolderId);

            if (parentFolder == null)
            {
                //exception
            }

            UserFolderModel parentUserFolder = GetUserFolder(user.Id, parentFolder.Id);

            if (parentUserFolder == null && !parentUserFolder.CanChange)
            {
                //exception
            }

            FolderModel folderModel = new FolderModel()
            {
                Name = folder.Name,
                ParentFolderId = parentFolder.Id,
                ParentFolder = parentFolder,
            };

            _unitOfWork.FolderRepository.Create(folderModel);

            UserFolderModel userFolderModel = new UserFolderModel()
            {
                UserId = user.Id,
                User = (UserModel)user,
                Folder = folderModel,
                CanAccess = true,
                CanChange = true
            };

            _unitOfWork.UserFolderRepository.Create(userFolderModel);

            _unitOfWork.Save();
        }

        public FolderViewModel GetFolder(FolderDTO folder)
        {
            User user = _userService.GetUser(folder.User);

            if (user == null)
            {
                //exception
            }

            FolderModel folderModel = _unitOfWork.FolderRepository.Get(folder.ParentFolderId);

            if (folderModel == null)
            {
                //exception
            }

            UserFolderModel userFolder = _unitOfWork.UserFolderRepository.Find(p => p.UserId == user.Id && p.FolderId == folderModel.Id).FirstOrDefault();

            if (userFolder == null || !userFolder.CanAccess)
            {
                //exception
            }

            FolderViewModel viewModel = new FolderViewModel();

            foreach (FolderModel f in folderModel.Folders)
            {
                UserFolderModel uf = _unitOfWork.UserFolderRepository.Find(p => p.UserId == user.Id && p.FolderId == f.Id).FirstOrDefault();

                if (uf != null || uf.CanAccess)
                {
                    viewModel.Folders.Add(f);
                }
            }

            foreach (FileModel f in folderModel.Files)
            {
                UserFileModel uf = _unitOfWork.UserFileRepository.Find(p => p.UserId == user.Id && p.FileId == f.Id).FirstOrDefault();

                if (uf != null || uf.CanAccess)
                {
                    viewModel.Files.Add(f);
                }
            }

            return viewModel;
        }

        public void DeleteFolder(FolderDTO folder)
        {
            User user = _userService.GetUser(folder.User);

            if (user == null)
            {
                //exception
            }

            FolderModel parentFolder = _unitOfWork.FolderRepository.Get(folder.ParentFolderId);

            if (parentFolder == null)
            {
                //exception
            }

            UserFolderModel parentUserFolder = _unitOfWork.UserFolderRepository.Find(p => p.UserId == user.Id && p.FolderId == parentFolder.Id).FirstOrDefault();

            if (parentUserFolder == null && !parentUserFolder.CanChange)
            {
                //exception
            }
        }

        private UserFolderModel GetUserFolder(Guid userId, Guid folderId)
        {
            return _unitOfWork.UserFolderRepository.Find(p => p.UserId == userId && p.FolderId == folderId).FirstOrDefault();
        }
    }
}
