using CloudStorage.DomainModels;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class FilePermissionModel : FilePermission
    {
        public FileModel File { get; set; }
        public UserModel User { get; set; }
    }
}
