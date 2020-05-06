using CloudStorage.DomainModels;
using System.Collections.Generic;

namespace CloudStorage.DAL.Interfaces.Models
{
    public class UserModel : User
    {
        public string Password { get; set; }
        public List<UserFolderModel> UserFolder { get; set; }
    }
}
