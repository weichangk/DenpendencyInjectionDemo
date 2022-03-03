using Microsoft.AspNetCore.Mvc;
using Demo.Application.IServices;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Users()
        { 
            var users = _userService.GetUsers();
            return Json(users);
        }
    }
}
