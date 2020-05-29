using System;

namespace CloudStorage.WEB.ViewModels
{
    public class FolderViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentFolderId { get; set; }
    }
}
