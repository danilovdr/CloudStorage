using CloudStorage.DomainModels;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class FileModel : File
    {
        public UserModel Owner { get; set; }
        public UserModel Creator { get; set; }
        public FolderModel Parent { get; set; }
    }
}
