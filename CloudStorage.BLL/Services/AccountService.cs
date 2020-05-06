using CloudStorage.BLL.Interfaces.Models.Account;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DAL.Interfaces.Models;
using System.Linq;

namespace CloudStorage.BLL.Services
{
    class AccountService : IAccountService
    {
        public AccountService(IRepository<UserModel> userRepository)
        {
            _userRepository = userRepository;
        }

        private IRepository<UserModel> _userRepository;

        public void CreateAccount(CreateAccountDTO createAccount)
        {
            UserModel user = new UserModel()
            {
                Name = createAccount.Name,
                Password = createAccount.Password,
            };

            _userRepository.Create(user);
        }

        public bool AccountExist(LoginDTO login)
        {
            return _userRepository.Find(p => p.Name == login.Name && p.Password == login.Password).Any();
        }
    }
}
