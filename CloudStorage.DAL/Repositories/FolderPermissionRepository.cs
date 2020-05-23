using CloudStorage.DAL.Exceptions;
using CloudStorage.DAL.Interfaces.Context;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DAL.Interfaces.Models;
using System;
using System.Linq;

namespace CloudStorage.DAL.Repositories
{
    public class FolderPermissionRepository : IRepository<FolderPermissionModel>
    {
        public FolderPermissionRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public IQueryable<FolderPermissionModel> GetAll()
        {
            return _dbContext.UserFolders;
        }

        public FolderPermissionModel Get(Guid id)
        {
            return _dbContext.UserFolders.Find(id);
        }

        public IQueryable<FolderPermissionModel> Find(Func<FolderPermissionModel, bool> predicate)
        {
            return _dbContext.UserFolders.Where(predicate).AsQueryable();
        }

        public void Create(FolderPermissionModel item)
        {
            _dbContext.UserFolders.Add(item);
        }

        public void Update(FolderPermissionModel item)
        {
            _dbContext.UserFolders.Update(item);

        }

        public void Delete(Guid id)
        {
            FolderPermissionModel userFolder = _dbContext.UserFolders.Find(id);

            if (userFolder == null)
            {
                throw new UserFolderNotFoundException("Удалямая запись о пользователе-папке не найдена");
            }
        }
    }
}
