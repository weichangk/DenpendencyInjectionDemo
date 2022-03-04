using Demo.Application.IServices;

namespace Demo.Application.Services
{
    public class TestService : ITestService
    {
        public string Msg { get; }
        public TestService(string msg)
        {
            Msg = msg;
        }
    }
}
