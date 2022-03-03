using Demo.Domain.Entities;

namespace Demo.Domain.IRepositores
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetUsers();
    }
}
