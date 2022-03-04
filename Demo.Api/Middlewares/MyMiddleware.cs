using Demo.Application.IServices;

namespace Demo.Api.Middlewares
{
    public class MyMiddleware
    {
        // 中间件类型的构造函数和Invoke方法中注入服务

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITestService testService)
        {
            _logger.LogInformation("Middleware DI Test: " + testService.Msg);

            await _next(context);
        }
    }
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}
