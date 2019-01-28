using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Interfaces
{
    public interface IUserService
    {
        object FindByLogin(User user);
    }
}
