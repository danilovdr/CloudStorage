using CloudStorage.DAL.Interfaces.Context;
using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DomainModels;
using System;
using System.Linq;

namespace CloudStorage.DAL.Repositories
{
    public class FileRepository : IRepository<File>
    {
        public FileRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public long Create(File item)
        {
            _dbContext.Files.Add(item);
            //return _dbContext.Files.Last().Id;
            return 0;
        }

        public void Delete(long id)
        {
            File deletedFile = _dbContext.Files.Find(id);

            if (deletedFile != null)
            {
                _dbContext.Files.Remove(deletedFile);
            }
        }

        public IQueryable<File> Find(Func<File, bool> predicate)
        {
            return _dbContext.Files.Where(predicate).AsQueryable();
        }

        public File Get(long id)
        {
            return _dbContext.Files.Find(id);
        }

        public IQueryable<File> GetAll()
        {
            return _dbContext.Files;
        }

        public void Update(File item)
        {
            _dbContext.Files.Update(item);
        }
    }
}
