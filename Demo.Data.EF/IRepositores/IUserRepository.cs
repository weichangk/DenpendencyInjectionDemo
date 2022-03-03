using Demo.Domain.Entities;

namespace Demo.Data.EF.IRepositores
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetUsers();
    }
}
