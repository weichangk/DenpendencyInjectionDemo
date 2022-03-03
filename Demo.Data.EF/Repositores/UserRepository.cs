using Demo.Domain.Entities;
using Demo.Domain.DbContexts;
using Demo.Domain.IRepositores;

namespace Demo.Data.EF.Repositores
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            Console.WriteLine("Demo.Data.EF");
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