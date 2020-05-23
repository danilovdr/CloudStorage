using System;

namespace CloudStorage.BLL.Interfaces.Models
{
    public class FolderDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentFolderId { get; set; }
    }
}
