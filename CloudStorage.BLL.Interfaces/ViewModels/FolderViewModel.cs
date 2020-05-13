using CloudStorage.DomainModels;
using System.Collections.Generic;

namespace CloudStorage.BLL.Interfaces.ViewModels
{
    public class FolderViewModel
    {
        public string Name { get; set; }
        public List<Folder> Folders { get; set; }
        public List<File> Files { get; set; }
    }
}
