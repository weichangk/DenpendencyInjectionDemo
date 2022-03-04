using Demo.Api.Middlewares;
using Demo.Application.IServices;
using Demo.Application.Services;
using Demo.Domain.IRepositores;
using Demo.Domain.Repositores;

var builder = WebApplication.CreateBuilder(args);

// �������Զ�ע�����
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

// ʹ�� ServiceDescriptor ע�����
//builder.Services.Add(new ServiceDescriptor(typeof(IUserService), typeof(UserService), ServiceLifetime.Transient));

// �Է��͵ķ�ʽע������Ƽ���
builder.Services.AddTransient<IUserService, UserService>();

// �����͵ķ�ʽע�����
builder.Services.AddTransient(typeof(IUserRepository), typeof(UserRepository));

// �ӹ�ĳЩ�����ʵ��������ע�����
//builder.Services.AddSingleton<ITestService>(sp => new TestService("�ӹ�ĳЩ�����ʵ��������"));
builder.Services.AddTransient<ITestService, TestService>(sp =>
{
    ITestService svc = sp.GetService<TestService>();
    return new TestService("�ӹ�ĳЩ�����ʵ��������");
});

// ��������ע��
IServiceProvider provider = builder.Services.BuildServiceProvider();
ITestService testService = provider.GetRequiredService<ITestService>();
var test1Service = new Test1Service(testService);
builder.Services.AddSingleton<ITest1Service>(test1Service);// �Ծ���ʵ���ķ�ʽע�����

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMyMiddleware();// ʹ���Զ����м���������м�����͵Ĺ��캯����Invoke������ע�����

app.UseAuthorization();

app.MapControllers();

app.Run();
