using System;
using System.Collections.Generic;
using System.Text;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class UserFolderFileModel
    {
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        
        public Guid FolderId { get; set; }
        public FolderModel Folder { get; set; }

        public Guid FileId { get; set; }
        public FileModel File { get; set; }

        //Rights
        public bool CanAccess { get; set; }
        public bool CanChange { get; set; }
    }
}
