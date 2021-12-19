using SoftUniDIFramework;
using SoftUniDIFramework.Injectors;
using WorkShopDi.Core;
using WorkShopDi.Infrastructure;

namespace WorkShopDi
{
    class Program
    {
        static void Main(string[] args)
        {
            //var serviceProvider = DependencyResolver.GetServiceProvider();
            //var engine = (Engine)serviceProvider.GetService(typeof(Engine));

            Injector injector = DependencyInjector.CreateInjector(new Module());
            Engine engine = injector.Inject<Engine>();

            engine.Run();
        }
    }
}
