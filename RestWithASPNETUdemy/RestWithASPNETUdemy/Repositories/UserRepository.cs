using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repositories.Interfaces;
using System;
using System.Linq;

namespace RestWithASPNETUdemy.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext _context;
        public UserRepository(MySqlContext context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }
    }
}
