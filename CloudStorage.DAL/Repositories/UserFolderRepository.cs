using CloudStorage.DAL.Exceptions;
using CloudStorage.DAL.Interfaces.Context;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DAL.Interfaces.Models;
using System;
using System.Linq;

namespace CloudStorage.DAL.Repositories
{
    public class UserFolderRepository : IRepository<UserFolderModel>
    {
        public UserFolderRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public IQueryable<UserFolderModel> GetAll()
        {
            return _dbContext.UserFolders;
        }

        public UserFolderModel Get(Guid id)
        {
            return _dbContext.UserFolders.Find(id);
        }

        public IQueryable<UserFolderModel> Find(Func<UserFolderModel, bool> predicate)
        {
            return _dbContext.UserFolders.Where(predicate).AsQueryable();
        }

        public void Create(UserFolderModel item)
        {
            _dbContext.UserFolders.Add(item);
        }

        public void Update(UserFolderModel item)
        {
            _dbContext.UserFolders.Update(item);

        }

        public void Delete(Guid id)
        {
            UserFolderModel userFolder = _dbContext.UserFolders.Find(id);

            if (userFolder == null)
            {
                throw new UserFolderNotFoundException("Удалямая запись о пользователе-папке не найдена");
            }
        }
    }
}
