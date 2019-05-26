using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
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
    }
}
