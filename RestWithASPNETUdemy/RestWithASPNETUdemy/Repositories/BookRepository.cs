using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
