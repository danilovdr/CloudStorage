using System;

namespace CloudStorage.BLL.Interfaces.Models
{
    public class FileDTO
    {
        public UserDTO User { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public Guid ParentFolderId { get; set; }
    }
}
