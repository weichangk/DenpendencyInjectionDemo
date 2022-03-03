using Microsoft.AspNetCore.Mvc;
using Demo.Application.Services;

namespace Demo.Mvc.Controllers
{

    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public IActionResult Index()
        {
            
            var data = _userService.GetUsers();
            return View(data);
        }
    }
}