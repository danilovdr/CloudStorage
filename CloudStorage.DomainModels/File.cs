using System.Collections.Generic;

namespace CloudStorage.DomainModels
{
    public class File
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }

        public string OwnerUserName { get; set; }
        public List<string> HasAccessUserName { get; set; }
        public long FolderId { get; set; }
    }
}
