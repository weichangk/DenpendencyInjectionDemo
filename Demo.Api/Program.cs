using Demo.Api.Middlewares;
using Demo.Application.IServices;
using Demo.Application.Services;
using Demo.Domain.IRepositores;
using Demo.Domain.Repositores;

var builder = WebApplication.CreateBuilder(args);

// 输出框架自动注册服务
Console.WriteLine("{0,-30}{1,-15}{2}", "Service Type", "Lifetime", "Implementation");
Console.WriteLine("-------------------------------------------------------------");
new WebHostBuilder().UseKestrel().Configure(app => { })
    .ConfigureServices(services => {
        IServiceProvider serviceProvider = services.BuildServiceProvider();
        foreach (var svc in services)
        {
            if (svc.ImplementationType != null)
            {
                Console.WriteLine("{0,-30}{1,-15}{2}", svc.ServiceType.Name, svc.Lifetime, svc.ImplementationType.Name);
                continue;
            }
            object instance = serviceProvider.GetService(svc.ServiceType);
            Console.WriteLine("{0,-30}{1,-15}{2}", svc.ServiceType.Name, svc.Lifetime, instance.GetType().Name);
        }
    }).Build();
Console.WriteLine("-------------------------------------------------------------");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 使用 ServiceDescriptor 注册服务
//builder.Services.Add(new ServiceDescriptor(typeof(IUserService), typeof(UserService), ServiceLifetime.Transient));

// 以泛型的方式注册服务（推荐）
builder.Services.AddTransient<IUserService, UserService>();

// 以类型的方式注册服务
builder.Services.AddTransient(typeof(IUserRepository), typeof(UserRepository));

// 接管某些服务的实例化过程注册服务
//builder.Services.AddSingleton<ITestService>(sp => new TestService("接管某些服务的实例化过程"));
builder.Services.AddTransient<ITestService, TestService>(sp =>
{
    ITestService svc = sp.GetService<TestService>();
    return new TestService("接管某些服务的实例化过程");
});

// 服务依赖注册
IServiceProvider provider = builder.Services.BuildServiceProvider();
ITestService testService = provider.GetRequiredService<ITestService>();
var test1Service = new Test1Service(testService);
builder.Services.AddSingleton<ITest1Service>(test1Service);// 以具体实例的方式注册服务

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMyMiddleware();// 使用自定义中间件，测试中间件类型的构造函数和Invoke方法中注入服务

app.UseAuthorization();

app.MapControllers();

app.Run();
