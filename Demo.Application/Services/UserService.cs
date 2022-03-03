using Demo.Application.IServices;
using Demo.Domain.Entities;
using Demo.Domain.IRepositores;

namespace Demo.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}