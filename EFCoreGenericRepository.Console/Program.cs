using Autofac;
using EFCoreGenericRepository.Console;

class Program
{
    static void Main(string[] args)
    {
        //var container = ContainerConfig.Configure();
        //using (var scope = container.BeginLifetimeScope())
        //{
        //    var app = scope.Resolve<IApplication>();
        //    app.Run();
        //}
        var x = new Test();
    }
}
public interface IApplication
{
    void Run();
}

public interface IService
{
    void WriteInformation(string message);
}

public class Service : IService
{
    public void WriteInformation(string message)
    {
        Console.WriteLine(message);
    }
}

public class Application : IApplication
{
    private readonly IService _service;
    public Application(IService service)
    {
        _service = service;
    }

    public void Run()
    {
        _service.WriteInformation("Injected!");
    }
}