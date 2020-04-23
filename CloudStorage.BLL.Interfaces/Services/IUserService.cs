using CloudStorage.BLL.Interfaces.DTO;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IUserService
    {
        void Login(UserLoginDTO userLogin);
        long Registration(UserCreateDTO userCreated);
        void UpdateUser(UserUpdateDTO userUpdated);
    }
}
