using Autofac;
using static Program;

namespace EFCoreGenericRepository.Console
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<Service>().As<IService>();

            return builder.Build();
        }
    }
}
