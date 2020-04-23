using CloudStorage.DAL.Interfaces.Context;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DomainModels;
using System;
using System.Linq;

namespace CloudStorage.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public UserRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public long Create(User item)
        {
            _dbContext.Users.Add(item);
            return _dbContext.Users.Last().Id;
        }

        public void Delete(long id)
        {
            User deletedUser = _dbContext.Users.FirstOrDefault(p => p.Id == id);

            if (deletedUser != null)
            {
                _dbContext.Users.Remove(deletedUser);
            }
        }

        public IQueryable<User> Find(Func<User, bool> predicate)
        {
            return _dbContext.Users.Where(predicate).AsQueryable();
        }

        public User Get(long id)
        {
            return _dbContext.Users.Find(id);
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public void Update(User item)
        {
            _dbContext.Users.Update(item);
        }
    }
}
