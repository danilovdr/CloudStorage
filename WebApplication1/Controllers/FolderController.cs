using CloudStorage.BLL.Interfaces.DTO;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.WEB.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CloudStorage.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FolderController : Controller
    {
        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        private readonly IFolderService _folderService;

        [Authorize]
        [HttpPut]
        public IActionResult CreateFolder(FolderViewModel folder)
        {
            Guid userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            FolderDTO folderDTO = new FolderDTO()
            {
                Name = folder.Name,
                ParentFolderId = folder.ParentFolderId
            };
            folderDTO = _folderService.CreateFolder(folderDTO, userId);
            folder = new FolderViewModel()
            {
                Id = folderDTO.Id,
                Name = folderDTO.Name,
                ParentFolderId = folderDTO.ParentFolderId
            };
            return Json(folder);
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
        [HttpGet("getUserFolders/{id}")]
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
                    ParentFolderId = folderDTO.ParentFolderId
                };
                folderViewModels.Add(viewModel);
            }
            return Json(folderViewModels);
        }

        [Authorize]
        [HttpGet("getSharedFolders/{id}")]
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
                    ParentFolderId = folderDTO.ParentFolderId
                };
                folderViewModels.Add(viewModel);
            }
            return Json(folderViewModels);
        }

        [Authorize]
        [HttpGet("getUserFiles/{id}")]
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
                    Id = fileDTO.Id,
                    Name = fileDTO.Name,
                    Content = fileDTO.Content,
                    ParentFolderId = fileDTO.ParentFolderId
                };
                folderViewModels.Add(viewModel);
            }
            return Json(folderViewModels);
        }

        [Authorize]
        [HttpGet("getSharedFiles/{id}")]
        public IActionResult GetSharedFiles(string id)
        {
            Guid folderId = Guid.Parse(id);
            Guid userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            List<FileDTO> filesDTO = _folderService.GetSharedFiles(folderId, userId);
            List<FileViewModel> folderViewModels = new List<FileViewModel>();
            foreach (FileDTO fileDTO in filesDTO)
            {
                FileViewModel viewModel = new FileViewModel()
                {
                    Id = fileDTO.Id,
                    Name = fileDTO.Name,
                    Content = fileDTO.Content,
                    ParentFolderId = fileDTO.ParentFolderId
                };
                folderViewModels.Add(viewModel);
            }
            return Json(folderViewModels);
        }
    }
}
