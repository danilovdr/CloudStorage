using CloudStorage.BLL.Exceptions;
using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DomainModels;
using System.Linq;

namespace CloudStorage.BLL.Services
{
    public class UserService : IUserService
    {
        public User GetUserByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool HasUser(string name, string password)
        {
            throw new System.NotImplementedException();
        }

        public long Registration(CreateAccountDTO userCreated)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(UpdateUserDTO userUpdated)
        {
            throw new System.NotImplementedException();
        }
    }
}
