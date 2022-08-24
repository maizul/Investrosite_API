using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL
{
    public interface IRepository<T, ID>
    {
        bool Add(T obj);
        T Get(ID id);
        List<T> Get();
        bool Edit(T obj);
        void Delete(T e);
        List<T> Search(string Name);
    }
}
