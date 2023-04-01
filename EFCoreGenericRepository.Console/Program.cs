using Autofac;
using EFCoreGenericRepository.Console;
using EFCoreGenericRepository.Console.RepositoryBase;
using EFCoreGenericRepository.Console.RepositoryBase.GenericRepository;
using EFCoreGenericRepository.Console.Services;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {        
        var container = ContainerConfig.Configure();
        using (var scope = container.BeginLifetimeScope())
        {
            var todoService = scope.Resolve<TodoService>();
            
            var data = todoService.GetPaginatedListAsync().Result?.FirstOrDefault()?.TodoName;

            Console.WriteLine("Data is : " + data);
        }
    }
}
