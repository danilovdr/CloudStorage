using System;
using System.Collections.Generic;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class FileModel
    {
        public Guid FolderId { get; set; }
        public List<UserFolderFileModel> UserFolderFile { get; set; }
    }
}
