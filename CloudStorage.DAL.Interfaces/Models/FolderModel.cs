using CloudStorage.DomainModels;
using System.Collections.Generic;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class FolderModel : Folder
    {
        public List<UserFolderModel> UserFolder { get; set; }
        public List<UserFolderFileModel> UserFolderFile { get; set; }
    }
}
