using Autofac;
using EFCoreGenericRepository.Console.RepositoryBase;
using EFCoreGenericRepository.Console.RepositoryBase.GenericRepository;
using EFCoreGenericRepository.Console.RepositoryBase.QueryRepository;
using EFCoreGenericRepository.Console.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using static Program;

namespace EFCoreGenericRepository.Console
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();


            var optionsBuilder = new DbContextOptionsBuilder<CoreContext>();

            optionsBuilder.UseSqlServer(@"db connection string");


            builder.RegisterType<CoreContext>().WithParameter("options", optionsBuilder.Options).AsSelf().AsImplementedInterfaces();

            builder.Register(c => new TodoService(c.Resolve<Repository<CoreContext>>()));

            builder.Register(c => new Repository<CoreContext>(c.Resolve<CoreContext>()));


            //builder.Register(c =>
            //{
            //    var opt = new DbContextOptionsBuilder<CoreContext>();
            //    opt.UseSqlServer(@"Server=DG-FERENLER\\SQLEXPRESS;database=Todo;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;Application Name=Api");

            //    var ctx = new CoreContext(opt.Options);

            //    return new Repository<CoreContext>(ctx);
            //});

            //builder.RegisterType<Repository<CoreContext>>().As<IRepository>();
            //builder.RegisterType<QueryRepository<CoreContext>>().As<IQueryRepository>();

            builder.RegisterType<TodoService>().As<ITodoService>();

            return builder.Build();
        }
    }
}
