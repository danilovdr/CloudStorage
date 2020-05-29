using CloudStorage.BLL.Interfaces.DTO;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.WEB.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace CloudStorage.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        private IFileService _fileService;

        [Authorize]
        [HttpGet]
        public IActionResult GetFile(string id)
        {
            Guid fileId = Guid.Parse(id);
            Guid userId = Guid.Parse(HttpContext.User.Identity.Name);
            FileDTO file = _fileService.GetFile(userId, fileId);
            FileViewModel viewModel = new FileViewModel()
            {
                //Id = file.Id,
                Name = file.Name,
                Content = file.Content,
                //Parent = file.ParentFolderId
            };
            return Json(viewModel);
        }

        [Authorize]
        [HttpPost("create")]
        public IActionResult CreateFile(FileViewModel file)
        {
            var claimIdentity = HttpContext.User.Identity as ClaimsIdentity;
            Guid userId = Guid.Parse(claimIdentity.GetUserId());
            FileDTO fileDTO = new FileDTO()
            {
                Name = file.Name,
                Content = file.Content,
                //ParentFolderId = file.Parent
            };
            fileDTO = _fileService.CreateFile(fileDTO, userId);
            FileViewModel viewModel = new FileViewModel()
            {
                //Id = fileDTO.Id,
                Name = fileDTO.Name,
                Content = fileDTO.Content,
                //Parent = fileDTO.ParentFolderId
            };
            return Json(viewModel);
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteFile(string id)
        {
            Guid fileId = Guid.Parse(id);
            Guid userId = Guid.Parse(HttpContext.User.Identity.Name);
            _fileService.DeleteFile(fileId, userId);
            return Ok();
        }
    }
}
