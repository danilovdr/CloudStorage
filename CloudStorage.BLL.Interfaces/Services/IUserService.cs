using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.DomainModels;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IUserService
    {
        long Registration(CreateAccountDTO userCreated);
        User GetUserByName(string name);
        bool HasUser(string name, string password);
        void UpdateUser(UpdateUserDTO userUpdated);
    }
}
