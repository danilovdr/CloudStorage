using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.DomainModels;
using System.Collections.Generic;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IFileService
    {
        void CreateFile(CreateFileDTO file);
        List<File> GetFilesByUsername(string name);
        void DeleteFile();
    }
}
