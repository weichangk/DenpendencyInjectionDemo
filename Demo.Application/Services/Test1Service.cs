using Demo.Application.IServices;

namespace Demo.Application.Services
{
    public class Test1Service : ITest1Service
    {
        private readonly ITestService _testService;
        public Test1Service(ITestService testService)
        {
            _testService = testService;
        }

        public void HelloTest()
        {
            Console.WriteLine($"TestService Msg: {_testService.Msg}");
        }
    }
}
