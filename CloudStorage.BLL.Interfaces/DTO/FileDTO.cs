using System;

namespace CloudStorage.BLL.Interfaces.Models
{
    public class FileDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public Guid? ParentFolderId { get; set; }
    }
}
