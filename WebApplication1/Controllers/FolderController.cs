using CloudStorage.BLL.Interfaces.DTO;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CloudStorage.WEB.Controllers
{
    public class FolderController : Controller
    {
        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        private readonly IFolderService _folderService;

        [Authorize]
        [HttpPost]
        public IActionResult CreateFolder(FolderViewModel folder)
        {
            Guid userId = Guid.Parse(HttpContext.User.Identity.Name);
            FolderDTO folderDTO = new FolderDTO()
            {
                Name = folder.Name,
                ParentFolderId = folder.Parent
            };
            folderDTO = _folderService.CreateFolder(folderDTO, userId);
            return Json(folderDTO);
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteFolder(string id)
        {
            Guid folderId = Guid.Parse(id);
            Guid userId = Guid.Parse(HttpContext.User.Identity.Name);
            _folderService.DeleteFolder(folderId, userId);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUserFolders(string id)
        {
            Guid folderId = Guid.Parse(id);
            Guid userId = Guid.Parse(HttpContext.User.Identity.Name);
            List<FolderDTO> foldersDTO = _folderService.GetUserFolders(folderId, userId);
            List<FolderViewModel> folderViewModels = new List<FolderViewModel>();
            foreach (FolderDTO folderDTO in foldersDTO)
            {
                FolderViewModel viewModel = new FolderViewModel()
                {
                    Id = folderDTO.Id,
                    Name = folderDTO.Name,
                    Parent = folderDTO.ParentFolderId
                };
                folderViewModels.Add(viewModel);
            }
            return Json(folderViewModels);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetSharedFolders(string id)
        {
            Guid folderId = Guid.Parse(id);
            Guid userId = Guid.Parse(HttpContext.User.Identity.Name);
            List<FolderDTO> foldersDTO = _folderService.GetSharedFolders(folderId, userId);
            List<FolderViewModel> folderViewModels = new List<FolderViewModel>();
            foreach (FolderDTO folderDTO in foldersDTO)
            {
                FolderViewModel viewModel = new FolderViewModel()
                {
                    Id = folderDTO.Id,
                    Name = folderDTO.Name,
                    Parent = folderDTO.ParentFolderId
                };
                folderViewModels.Add(viewModel);
            }
            return Json(folderViewModels);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUserFiles(string id)
        {
            Guid folderId = Guid.Parse(id);
            Guid userId = Guid.Parse(HttpContext.User.Identity.Name);
            List<FileDTO> filesDTO = _folderService.GetUserFiles(folderId, userId);
            List<FileViewModel> folderViewModels = new List<FileViewModel>();
            foreach (FileDTO fileDTO in filesDTO)
            {
                FileViewModel viewModel = new FileViewModel()
                {
                    //Id = fileDTO.Id,
                    Name = fileDTO.Name,
                    Content = fileDTO.Content,
                    //Parent = fileDTO.ParentFolderId
                };
                folderViewModels.Add(viewModel);
            }
            return Json(folderViewModels);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetSharedFiles(string id)
        {
            Guid folderId = Guid.Parse(id);
            Guid userId = Guid.Parse(HttpContext.User.Identity.Name);
            List<FileDTO> filesDTO = _folderService.GetSharedFiles(folderId, userId);
            List<FileViewModel> folderViewModels = new List<FileViewModel>();
            foreach (FileDTO fileDTO in filesDTO)
            {
                FileViewModel viewModel = new FileViewModel()
                {
                    //Id = fileDTO.Id,
                    Name = fileDTO.Name,
                    Content = fileDTO.Content,
                    //Parent = fileDTO.ParentFolderId
                };
                folderViewModels.Add(viewModel);
            }
            return Json(folderViewModels);
        }
    }
}
