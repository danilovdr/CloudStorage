using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudStorage.BLL.Services
{
    public class FileService : IFileService
    {
        public FileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IUnitOfWork _unitOfWork;

        public void CreateFile(CreateFileDTO file)
        {
            File newFile = new File()
            {
                Name = file.Name,
                Content = file.Content,
                OwnerName = file.OwnerName
            };

            _unitOfWork.Files.Create(newFile);
            _unitOfWork.Save();
        }

        public void DeleteFile()
        {
            throw new NotImplementedException();
        }

        public List<File> GetFilesByUsername(string name)
        {
            return _unitOfWork.Files.Find(p => p.OwnerName == name).ToList();
        }
    }
}
