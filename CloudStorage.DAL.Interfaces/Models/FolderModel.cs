using CloudStorage.DomainModels;
using System.Collections.Generic;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class FolderModel : Folder
    {
        public List<UserFolderModel> UserFolder { get; set; }
        public List<FileModel> Files { get; set; }
    }
}
