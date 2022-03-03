using Demo.Domain.Entities;

namespace Demo.Domain.DbContexts
{
    public class DbContext
    {
        public static List<User> Users = new List<User>()
        {
            new User(){Id = 1001, Email = "zhangsan", Password = "zs123", UserName = "张三"},
            new User(){Id = 1002, Email = "lisi", Password = "ls123", UserName = "李四"},
            new User(){Id = 1003, Email = "wangwu", Password = "ww123", UserName = "王五"},
        };
    }
}