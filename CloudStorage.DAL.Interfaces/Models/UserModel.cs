using CloudStorage.DomainModels;
using System.Collections.Generic;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class UserModel : User
    {
        public string Password { get; set; }
        
        public List<FolderPermissionModel> FolderPermissions { get; set; }
        public List<FilePermissionModel> FilePermissions { get; set; }
    }
}
