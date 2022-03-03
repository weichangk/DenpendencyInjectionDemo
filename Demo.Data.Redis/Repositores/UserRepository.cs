using Demo.Domain.Entities;
using Demo.Domain.DbContexts;
using Demo.Domain.IRepositores;

namespace Demo.Data.Redis.Repositores
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            Console.WriteLine("Demo.Data.Redis");
        }

        public User GetUserById(int id)
        {
            return DbContext.Users.SingleOrDefault(u => u.Id == id);
        }

        public List<User> GetUsers()
        {
            return DbContext.Users;
        }
    }
}