using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Repositories;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
           return _converter.Parse(_repository.Create(_converter.Parse(person)));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<PersonVO> FindByName(string firtName, string lastName)
        {
            return _converter.ParseList(_repository.FindByName(firtName, lastName));
        }

        public PersonVO Update(PersonVO person)
        {
            return _converter.Parse(_repository.Update(_converter.Parse(person)));
        }
    }
}
