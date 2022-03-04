using Demo.Domain.Entities;

namespace Demo.Application.IServices
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserById(int id);
    }
}
