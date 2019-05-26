using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repositories.Interfaces;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        List<Person> FindByName(string firtName, string lastName);
    }
}
