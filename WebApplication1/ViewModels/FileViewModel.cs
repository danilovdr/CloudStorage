using System;

namespace CloudStorage.WEB.ViewModels
{
    public class FileViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public Guid? ParentFolderId { get; set; }
    }
}
