using System.Collections.Generic;

namespace CloudStorage.DomainModels
{
    public class File
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }

        public User Owner { get; set; }
        public List<User> HasAccess { get; set; }
    }
}
