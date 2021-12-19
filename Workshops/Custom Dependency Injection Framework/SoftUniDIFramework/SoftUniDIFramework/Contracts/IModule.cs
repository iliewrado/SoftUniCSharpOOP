using System;

namespace SoftUniDIFramework.Contracts
{
    public interface IModule
    {
        void Configure();
        
        Type GetMapping(Type currrentInterface, object attribute);
        
        object GetInstance(Type type);

        void SetInstance(Type implementation, object instance);
    }
}
