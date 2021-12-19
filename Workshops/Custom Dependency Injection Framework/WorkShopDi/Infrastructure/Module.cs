using SoftUniDIFramework.Modules;
using WorkShopDi.Contracts;
using WorkShopDi.Services;

namespace WorkShopDi.Infrastructure
{
    public class Module : AbstractModule
    {
        public override void Configure()
        {
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IWriter, ConsoleWriter>();
            CreateMapping<IWriter, FileWriter>();
        }
    }
}
