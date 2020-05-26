using CloudStorage.BLL.Exceptions;
using CloudStorage.BLL.Interfaces.DTO;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DAL.Interfaces.Models;
using System;
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

        public Guid Registration(UserDTO user)
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
            return userModel.Id;
        }

        public void ChangePassword(UserDTO user)
        {
            UserModel userModel = _unitOfWork.UserRepository.Get(user.Id);
            if (userModel == null)
                throw new Exception();

            userModel.Password = user.Password;
            _unitOfWork.UserRepository.Update(userModel);
            _unitOfWork.Save();
        }

        public Guid GetUserId(string name, string password)
        {
            UserModel userModel = _unitOfWork.UserRepository
                .Find(p => p.Name == name && p.Password == password)
                .FirstOrDefault();
            if (userModel == null)
                throw new Exception();

            return userModel.Id;
        }

        public string GetUserName(Guid id)
        {
            UserModel user = _unitOfWork.UserRepository.Get(id);
            if (user == null)
                throw new Exception();

            return user.Name;
        }
    }
}
