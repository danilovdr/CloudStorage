using CloudStorage.BLL.Interfaces.Models;
using System;

namespace CloudStorage.BLL.Interfaces.Models
{
    public class FolderDTO
    {
        public string Name { get; set; }
        public UserDTO User { get; set; }
        public Guid ParentFolderId { get; set; }
    }
}
