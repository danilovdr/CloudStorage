using CloudStorage.BLL.Exceptions;
using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.BLL.Interfaces.Models.Account;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DAL.Interfaces.Models;
using CloudStorage.DomainModels;
using System.Linq;

namespace CloudStorage.BLL.Services
{
    public class UserService : IUserService
    {
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IUnitOfWork _unitOfWork;

        public void CreateUser(CreateUserDTO user)
        {
            bool hasUser = GetUser(new UserDTO { Name = user.Name }) == null;

            if (hasUser)
            {
                throw new CreateUserException("Пользователь с таким именем уже существует", user.Name);
            }

            UserModel userModel = new UserModel()
            {
                Name = user.Name,
                Password = user.Password,
            };

            _unitOfWork.UserRepository.Create(userModel);
            _unitOfWork.Save();
        }

        public bool HasUser(LoginDTO login)
        {
            return _unitOfWork.UserRepository.Find(p => p.Name == login.Name && p.Password == login.Password).Any();
        }

        public User GetUser(UserDTO user)
        {
            return _unitOfWork.UserRepository.Find(p => p.Name == user.Name).FirstOrDefault();
        }
    }
}
