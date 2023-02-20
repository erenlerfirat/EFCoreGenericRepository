using Autofac;
using static Program;

namespace EFCoreGenericRepository.Console
{
    internal class Test
    {
        public Test()
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}
