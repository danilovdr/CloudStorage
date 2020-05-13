using System;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class UserFileModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        public Guid FileId { get; set; }
        public FileModel File { get; set; }

        //Rights
        public bool CanAccess { get; set; }
        public bool CanChange { get; set; }
    }
}
