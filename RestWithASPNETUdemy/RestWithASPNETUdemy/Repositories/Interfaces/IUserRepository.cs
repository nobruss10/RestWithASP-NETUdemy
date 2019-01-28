using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repositories.Interfaces
{
    public interface IUserRepository 
    {
        User FindByLogin(string login);
    }
}
