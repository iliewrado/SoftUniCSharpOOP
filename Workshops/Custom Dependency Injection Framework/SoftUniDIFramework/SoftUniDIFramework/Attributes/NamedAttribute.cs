using System;

namespace SoftUniDIFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field, AllowMultiple = true)]
    public class NamedAttribute : Attribute
    {
        public string Name { get; }
        public NamedAttribute(string name)
        {
            Name = name;
        }
    }
}
