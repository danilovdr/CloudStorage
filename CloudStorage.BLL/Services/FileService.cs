using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.BLL.Interfaces.Models.File;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.BLL.Interfaces.ViewModels.File;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudStorage.BLL.Services
{
    public class FileService : IFileService
    {
        public void CreateFile(CreateFileDTO createFile)
        {
            throw new NotImplementedException();
        }

        public void DeleteFile(DeleteFileDTO deleteFile)
        {
            throw new NotImplementedException();
        }

        public FilesByUserViewMode GetFilesByUser(FilesByUserDTO filesByUser)
        {
            throw new NotImplementedException();
        }

        public void UpdateFile(UpdateFileDTO updateFile)
        {
            throw new NotImplementedException();
        }

        public bool UserHasAccess(UserHasAccessDTO userHasAccess)
        {
            throw new NotImplementedException();
        }
    }
}
