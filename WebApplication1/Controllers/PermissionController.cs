using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DomainModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CloudStorage.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : Controller
    {
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        private readonly IPermissionService _permissionService;

        [Authorize]
        [HttpGet("file/{fileId}")]
        public IActionResult GetFilePermission(string fileId)
        {
            Guid fileGuid = Guid.Parse(fileId);
            Guid userGuid = Guid.Parse(HttpContext.User.Identity.GetUserId());
            PermissionType permission = _permissionService.GetFilePermission(fileGuid, userGuid);
            return Json(permission);
        }

        [Authorize]
        [HttpPost("file/{fileId}")]
        public IActionResult SetFilePermission(string fileId, string userId, PermissionType permission)
        {
            Guid fileGuid = Guid.Parse(fileId);
            Guid ownerGuid = Guid.Parse(HttpContext.User.Identity.GetUserId());
            Guid userGuid = Guid.Parse(userId);
            _permissionService.SetFilePermission(fileGuid, ownerGuid, userGuid, permission);
            return Ok();
        }

        [Authorize]
        [HttpGet("folder/{folderId")]
        public IActionResult GetFolderPermission(string folderId)
        {
            Guid folderGuid = Guid.Parse(folderId);
            Guid userGuid = Guid.Parse(HttpContext.User.Identity.GetUserId());
            PermissionType permission = _permissionService.GetFolderPermission(folderGuid, userGuid);
            return Json(permission);
        }

        [Authorize]
        [HttpPost("folder/{folderId}")]
        public IActionResult SetFolderPermission(string folderId, string userId, PermissionType permission)
        {
            Guid folderGuid = Guid.Parse(folderId);
            Guid ownerGuid = Guid.Parse(HttpContext.User.Identity.GetUserId());
            Guid userGuid = Guid.Parse(userId);
            _permissionService.SetFolderPermission(folderGuid, ownerGuid, userGuid, permission);
            return Ok();
        }
    }
}
