using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.DomainModels;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IUserService
    {
        void CreateUser(CreateUserDTO user);
        User GetUser(UserDTO user);
    }
}
