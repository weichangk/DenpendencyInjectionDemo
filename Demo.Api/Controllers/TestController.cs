using Demo.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserService _userService1;
        public TestController(IServiceProvider serviceProvider)
        {
            _userService = serviceProvider.GetService<IUserService>();
            _userService1 = serviceProvider.GetRequiredService<IUserService>();
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = _userService.GetUsers();
            return Json(users);
        }
        [HttpGet("GetById")]
        public IActionResult User(int id)
        {
            var user = _userService1.GetUserById(id);
            return Json(user);
        }
    }
}
