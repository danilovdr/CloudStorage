using CloudStorage.BLL.Interfaces.DTO;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IUserService
    {
        long Registration(UserCreatedDTO userCreated);
        void UpdateUserInfo(UserUpdatedDTO userUpdated);
    }
}
