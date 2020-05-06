using System;

namespace CloudStorage.DomainModels
{
    public class Folder
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
