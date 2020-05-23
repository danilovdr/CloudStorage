using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.DomainModels;
using System;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IFileService
    {
        void CreateFile(FileDTO file, Guid userId);
        void UpdateFile(FileDTO file, Guid userId);
        void DeleteFile(Guid fileId, Guid userId);
        FileDTO GetFile(Guid fileId, Guid userId);
    }
}
