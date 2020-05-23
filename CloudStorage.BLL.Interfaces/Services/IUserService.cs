using CloudStorage.BLL.Interfaces.Models;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IUserService
    {
        void Registration(RegistrationDTO registration);
    }
}
