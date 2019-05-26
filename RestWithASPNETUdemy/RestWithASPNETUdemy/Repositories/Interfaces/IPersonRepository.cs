using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repositories.Interfaces;
using RestWithASPNETUdemy.shared;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        List<Person> FindByName(string firtName, string lastName);
        PagedSearchModel<Person> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
