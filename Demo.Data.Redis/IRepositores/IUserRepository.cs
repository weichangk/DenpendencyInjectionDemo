using Demo.Domain.Entities;

namespace Demo.Data.Redis.IRepositores
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetUsers();
    }
}
