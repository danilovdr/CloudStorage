using CloudStorage.DAL.Interfaces.Context;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DAL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudStorage.DAL.Repositories
{
    public class FilePermissionRepository : IRepository<FilePermissionModel>
    {
        public FilePermissionRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public void Create(FilePermissionModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FilePermissionModel> Find(Func<FilePermissionModel, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public FilePermissionModel Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FilePermissionModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(FilePermissionModel item)
        {
            throw new NotImplementedException();
        }
    }
}
