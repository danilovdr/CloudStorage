using CloudStorage.BLL.Interfaces.DTO;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.WEB.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpPut]
        public IActionResult CreateFile(FileViewModel file)
        {
            Guid userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            FileDTO fileDTO = new FileDTO()
            {
                Name = file.Name,
                Content = file.Content,
                ParentFolderId = file.ParentFolderId
            };
            fileDTO = _fileService.CreateFile(fileDTO, userId);
            file = new FileViewModel()
            {
                Id = fileDTO.Id,
                Name = fileDTO.Name,
                Content = fileDTO.Content,
                ParentFolderId = fileDTO.ParentFolderId
            };
            return Json(file);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetFile(string id)
        {
            Guid fileId = Guid.Parse(id);
            Guid userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            FileDTO file = _fileService.GetFile(userId, fileId);
            FileViewModel viewModel = new FileViewModel()
            {
                Id = file.Id,
                Name = file.Name,
                Content = file.Content,
                ParentFolderId = file.ParentFolderId
            };
            return Json(viewModel);
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteFile(string id)
        {
            Guid fileId = Guid.Parse(id);
            Guid userId = Guid.Parse(HttpContext.User.Identity.GetUserId());
            _fileService.DeleteFile(fileId, userId);
            return Ok();
        }
    }
}
