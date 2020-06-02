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
        [HttpPost]
        public IActionResult CreateFolder(FolderViewModel folder)
        {
            Guid userGuid = Guid.Parse(HttpContext.User.Identity.GetUserId());
            FolderDTO folderDTO = new FolderDTO
            {
                Name = folder.Name,
                ParentFolderId = folder.ParentFolderId
            };
            folderDTO = _folderService.CreateFolder(folderDTO, userGuid);
            return Json(folderDTO);
        }

        [Authorize]
        [HttpGet("my")]
        public IActionResult GetMyRootFolder()
        {
            Guid userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            List<FolderDTO> foldersDTO = _folderService.GetUserFolders(null, userId);
            List<FileDTO> filesDTO = _folderService.GetUserFiles(null, userId);
            return Json(new
            {
                Folders = foldersDTO,
                Files = filesDTO
            });
        }


        [Authorize]
        [HttpGet("my/{id}")]
        public IActionResult GetMyFolder(string id)
        {
            Guid userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            Guid folderId = Guid.Parse(id);
            List<FolderDTO> foldersDTO = _folderService.GetUserFolders(folderId, userId);
            List<FileDTO> filesDTO = _folderService.GetUserFiles(folderId, userId);
            return Json(new
            {
                Folders = foldersDTO,
                Files = filesDTO
            });
        }

        [Authorize]
        [HttpGet("shared")]
        public IActionResult GetRootSharedFolder(string id)
        {
            Guid userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            List<FolderDTO> foldersDTO = _folderService.GetSharedFolders(null, userId);
            List<FileDTO> filesDTO = _folderService.GetSharedFiles(null, userId);
            return Json(new
            {
                Folders = foldersDTO,
                Files = filesDTO
            });
        }

        [Authorize]
        [HttpGet("shared/{id}")]
        public IActionResult GetSharedFolder(string id)
        {
            Guid userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            Guid folderId = Guid.Parse(id);
            List<FolderDTO> foldersDTO = _folderService.GetSharedFolders(folderId, userId);
            List<FileDTO> filesDTO = _folderService.GetSharedFiles(folderId, userId);
            return Json(new
            {
                Folders = foldersDTO,
                Files = filesDTO
            });
        }

        [Authorize]
        [HttpDelete("{folderId}")]
        public IActionResult DeleteFolder(string folderId)
        {
            Guid userGuid = Guid.Parse(HttpContext.User.Identity.GetUserId());
            Guid folderGuid = Guid.Parse(folderId);
            _folderService.DeleteFolder(folderGuid, userGuid);
            return Ok();
        }

    }
}
