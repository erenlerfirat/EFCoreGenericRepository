using Autofac;
using EFCoreGenericRepository.Console.RepositoryBase;
using EFCoreGenericRepository.Console.RepositoryBase.GenericRepository;
using EFCoreGenericRepository.Console.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCoreGenericRepository.Console
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            var optionsBuilder = new DbContextOptionsBuilder<CoreContext>();

            optionsBuilder.UseSqlServer(@"Server=DG-FERENLER\SQLEXPRESS;database=Todo;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;Application Name=Api");

            builder.RegisterType<CoreContext>().WithParameter("options", optionsBuilder.Options).AsSelf().AsImplementedInterfaces();

            builder.Register(c => new TodoService(c.Resolve<Repository<CoreContext>>()));

            builder.Register(c => new Repository<CoreContext>(c.Resolve<CoreContext>()));

            builder.RegisterType<TodoService>().As<ITodoService>();

            return builder.Build();
        }
    }
}
