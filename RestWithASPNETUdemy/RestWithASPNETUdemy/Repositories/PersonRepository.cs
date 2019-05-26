using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySqlContext context)
            : base(context)
        {

        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            if(!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                return FindBy(p => p.FirstName.Equals(firstName) && p.LastName.Equals(lastName)).ToList();

            else if (!string.IsNullOrEmpty(firstName))
                return FindBy(p => p.FirstName.Equals(firstName)).ToList();

            else if (!string.IsNullOrEmpty(lastName))
                return FindBy(p => p.LastName.Equals(lastName)).ToList();

            return new List<Person>();
        }

        public PagedSearchModel<Person> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page == 0 ? page : page - 1;
            var result = ExecuteQuery(string.Concat(QuerySelect(), string.Concat(QueryWhere(name), $" ORDER BY p.firstname {sortDirection} LIMIT {pageSize} OFFSET {page}")));
            var totalResults = ExecuteQuery(string.Concat(QuerySelect(), QueryWhere(name)));
            return new PagedSearchModel<Person>(result.ToList(), totalResults.Count);         
        }

        private string QuerySelect()
        {
            return @"SELECT * FROM `persons` p ";
        }

        private string QueryWhere(string name)
        {
            var query = "WHERE 1 = 1 ";
            query += (!string.IsNullOrEmpty(name))? $" AND p.firstName like '%{name}%'" : " ";
            return query;
        }

    }
}
