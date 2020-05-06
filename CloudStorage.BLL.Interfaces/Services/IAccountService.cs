using CloudStorage.BLL.Interfaces.Models.Account;

namespace CloudStorage.BLL.Interfaces.Services
{
    public interface IAccountService
    {
        void CreateAccount(CreateAccountDTO createAccount);
        bool AccountExist(LoginDTO login);
    }
}
