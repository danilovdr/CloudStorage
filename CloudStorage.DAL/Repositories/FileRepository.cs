using CloudStorage.DAL.Interfaces.Interfaces;
using CloudStorage.DAL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudStorage.DAL.Repositories
{
    public class FileRepository : IRepository<File>
    {
        public void Create(File item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<File> Find(Func<File, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public File Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<File> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(File item)
        {
            throw new NotImplementedException();
        }
    }
}
