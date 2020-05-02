using CloudStorage.BLL.Exceptions;
using CloudStorage.BLL.Interfaces.Models;
using CloudStorage.BLL.Interfaces.Services;
using CloudStorage.DAL.Interfaces.Interfaces;
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

        public long Registration(CreateAccountDTO userCreate)
        {
            if (_unitOfWork.Users.Find(p => p.Name == userCreate.Name).Any())
            {
                throw new UserCreateException("Пользователь с таким именем уже существует", userCreate.Name);
            }

            if (_unitOfWork.Users.Find(p => p.Email == userCreate.Email).Any())
            {
                throw new UserCreateException("Пользователь с таким email уже существует", userCreate.Email);
            }

            User user = new User()
            {
                Name = userCreate.Name,
                Email = userCreate.Password,
                Password = userCreate.Password
            };

            long id = _unitOfWork.Users.Create(user);
            _unitOfWork.Save();
            return id;
        }

        public User GetUserByName(string name)
        {
            return _unitOfWork.Users.Find(p => p.Name == name).FirstOrDefault();
        }

        public bool HasUser(string name, string password)
        {
            return _unitOfWork.Users.Find(p => p.Name == name && p.Password == password).Any();
        }

        public void UpdateUser(UpdateUserDTO userUpdate)
        {
            User user = _unitOfWork.Users.Get(userUpdate.Id);

            if (userUpdate.Name != null && userUpdate.Name != user.Name)
            {
                if (_unitOfWork.Users.Find(p => p.Name == userUpdate.Name).Any())
                {
                    throw new UserUpdateException("Пользователь с таким именем уже существует", userUpdate.Name);
                }

                user.Name = userUpdate.Name;
            }

            if (userUpdate.Email != null && userUpdate.Email != user.Email)
            {
                if (_unitOfWork.Users.Find(p => p.Email == userUpdate.Email).Any())
                {
                    throw new UserUpdateException("Пользователь с таким email уже существует", userUpdate.Email);
                }

                user.Email = userUpdate.Email;
            }

            user.Password = userUpdate.Password;

            _unitOfWork.Users.Update(user);
            _unitOfWork.Save();
        }
    }
}
