using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CloudStorage.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        public FileController(IFileService fileService, IUserService userService)
        {
            _fileService = fileService;
            _userService = userService;
        }

        private IFileService _fileService;
        private IUserService _userService;

        [Authorize]
        [HttpGet]
        public IActionResult GetFilesByUser()
        {
            List<File> files = _fileService.GetFilesByUsername(User.Identity.Name);
            return Json(files);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateFile(CreateFileDTO file)
        {
            file.OwnerName = User.Identity.Name;
            _fileService.CreateFile(file);
            return Ok();
        }
    }
}
