using System;

namespace SoftUniDIFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field, AllowMultiple = true)]
    public class InjectAttribute : Attribute
    {
    }
}
