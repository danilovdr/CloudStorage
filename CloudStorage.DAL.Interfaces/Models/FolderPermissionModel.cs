using CloudStorage.DomainModels;
using System;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class FolderPermissionModel : FolderPermission
    {
        public FolderModel Folder { get; set; }
        public UserModel User { get; set; }
    }
}
