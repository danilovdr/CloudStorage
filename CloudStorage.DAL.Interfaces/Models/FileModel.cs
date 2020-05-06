using System;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class FileModel
    {
        public Guid FolderId { get; set; }
        public FolderModel Folder { get; set; }
    }
}
