using Demo.Domain.Entities;
using Demo.Domain.DbContexts;
using Demo.Domain.IRepositores;

namespace Demo.Domain.Repositores
{
    public class UserRepository : IUserRepository
    {
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