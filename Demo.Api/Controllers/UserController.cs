using Microsoft.AspNetCore.Mvc;
using Demo.Application.IServices;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITestService _testService;
        private readonly ITest1Service _test1Service;

        public UserController(IUserService userService,
            ITestService testService,
            ITest1Service test1Service)
        {
            // 构造函数注入
            _userService = userService;
            _testService = testService;
            _test1Service = test1Service;
        }

        [HttpGet]
        public IActionResult Users()
        { 
            var users = _userService.GetUsers();
            Console.WriteLine(_testService.Msg);
            _test1Service.HelloTest();
            return Json(users);
        }

        [HttpGet("GetById")]
        public IActionResult User([FromServices] IUserService userService, int id)
        {
            // 在 Controller Action 中使用内置特性 FromServicesAttribute 注入
            var user = userService.GetUserById(id);
            return Json(user);
        }
    }
}
