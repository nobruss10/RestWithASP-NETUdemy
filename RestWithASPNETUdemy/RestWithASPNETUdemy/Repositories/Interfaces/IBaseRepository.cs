using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Create(T model);
        T FindById(long id);
        List<T> FindAll();
        T Update(T model);
        void Delete(long id);
    }
}
