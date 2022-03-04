using Demo.Api.Attributes;
using Demo.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyDITestController : Controller
    {
        // 属性注入
        [PropertyFromService] public IUserService userService { get; set; }
        [PropertyFromService] public ITestService testService { get; set; }
        [PropertyFromService] public ITest1Service test1Service { get; set; }

        [HttpGet]
        public IActionResult Users()
        {
            var users = userService.GetUsers();
            Console.WriteLine(testService.Msg);
            test1Service.HelloTest();
            return Json(users);
        }
    }
}
