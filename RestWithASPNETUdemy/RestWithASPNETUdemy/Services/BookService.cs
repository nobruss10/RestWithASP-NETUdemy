using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Repositories.Interfaces;
using RestWithASPNETUdemy.Services.Interfaces;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly BookConverter _converter;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            return _converter.Parse(_repository.Create(_converter.Parse(book)));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            return _converter.Parse(_repository.Update(_converter.Parse(book)));
        }
    }
}
