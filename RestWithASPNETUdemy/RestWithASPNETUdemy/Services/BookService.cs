using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Repositories.Interfaces;
using RestWithASPNETUdemy.Services.Interfaces;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
