using SoftUniDIFramework.Contracts;
using SoftUniDIFramework.Injectors;

namespace SoftUniDIFramework
{
    public static class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            
            return new Injector(module);
        }
    }
}
