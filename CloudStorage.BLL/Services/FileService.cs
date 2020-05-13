using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DomainModels;

namespace CloudStorage.BLL.Services
{
    public class FileService : IFileService
    {
        public FileService(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        private IUnitOfWork _unitOfWork;
        private IUserService _userService;

        public void CreateFile(FileDTO file)
        {
            User user = _userService.GetUser(file.User);
        }

        public void UpdateFile(FileDTO file)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteFile(FileDTO file)
        {
            throw new System.NotImplementedException();
        }

        public File GetFile(FileDTO file)
        {
            throw new System.NotImplementedException();
        }
    }
}
