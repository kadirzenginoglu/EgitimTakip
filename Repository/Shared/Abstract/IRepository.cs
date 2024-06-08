using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Shared.Abstract
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(int id);
        T GetById(int id);
        void Save();

    }
}
