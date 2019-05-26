using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

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
