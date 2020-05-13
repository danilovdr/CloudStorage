using CloudStorage.DomainModels;
using System;
using System.Collections.Generic;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class FolderModel : Folder
    {
        public Guid ParentFolderId { get; set; }
        public FolderModel ParentFolder { get; set; }

        public List<FolderModel> Folders { get; set; }
        public List<FileModel> Files { get; set; }

        public List<UserFolderModel> UserFolder { get; set; }
    }
}
