using System.Collections.Generic;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class File
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public User Owner { get; set; }
        public List<User> HasAccess { get; set; }
    }
}
