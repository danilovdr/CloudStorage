using CloudStorage.DomainModels;
using System;
using System.Collections.Generic;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class FileModel : File
    {
        public UserModel Owner { get; set; }
        public UserModel Creator { get; set; }
        public Guid ParentId { get; set; }
        public FolderModel Parent { get; set; }
        public List<FilePermissionModel> FilePermissions { get; set; }
    }
}
