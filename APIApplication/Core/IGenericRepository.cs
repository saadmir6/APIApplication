using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIApplication.Core
{
    public interface IGenericRepository<T>

    {
        IEnumerable<T> GetAll();

        T GetById(object id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(object T);

        void Save();


    }
}
