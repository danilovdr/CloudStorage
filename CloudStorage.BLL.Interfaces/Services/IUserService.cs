using CloudStorage.BLL.Interfaces.DTO;
using System;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IUserService
    {
        Guid Registration(UserDTO user);
        Guid GetUserId(string name, string password);
        string GetUserName(Guid id);
        void ChangePassword(UserDTO user);
    }
}
