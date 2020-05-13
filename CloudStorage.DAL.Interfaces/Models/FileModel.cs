using CloudStorage.DomainModels;
using System;
using System.Collections.Generic;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class FileModel : File
    {
        public Guid ParentFolderId { get; set; }
        public FolderModel ParentFolder { get; ; set; }

        public List<UserFileModel> UserFile { get; set; }
    }
}
