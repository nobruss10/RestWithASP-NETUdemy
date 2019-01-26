using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repositories.Interfaces;

namespace RestWithASPNETUdemy.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(MySqlContext context)
            :base(context)
        {

        }
    }
}
