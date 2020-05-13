using System;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class UserFolderModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        public Guid FolderId { get; set; }
        public FolderModel Folder { get; set; }

        //Rights
        public bool CanAccess { get; set; }
        private bool _canChange;
        public bool CanChange
        {
            get
            {
                return _canChange & CanAccess;
            }
            set
            {
                _canChange = value;
            }
        }
    }
}
