using CloudStorage.DomainModels;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class FolderModel : Folder
    {
        public UserModel Owner { get; set; }
        public FolderModel Parent { get; set; }
    }
}
