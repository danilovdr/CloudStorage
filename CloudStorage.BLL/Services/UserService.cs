using CloudStorage.BLL.Exceptions;
using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DAL.Interfaces.Models;
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

        public void Registration(RegistrationDTO user)
        {
            bool hasUser = _unitOfWork.UserRepository.Find(p => p.Name == user.Name).Any();
            if (hasUser)
                throw new CreateUserException("Пользователь с таким именем уже существует", user.Name);

            UserModel userModel = new UserModel()
            {
                Name = user.Name,
                Password = user.Password
            };

            _unitOfWork.UserRepository.Create(userModel);
            _unitOfWork.Save();
        }
    }
}
