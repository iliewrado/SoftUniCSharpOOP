using SoftUniDIFramework.Attributes;
using SoftUniDIFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniDIFramework.Modules
{
    public abstract class AbstractModule : IModule
    {
        private readonly IDictionary<Type, Dictionary<string, Type>> implementations;
        private readonly IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        protected void CreateMapping<TInterface, TImplementation>()
        {
            Type interType = typeof(TInterface);
            Type implType = typeof(TImplementation);

            if (this.implementations.ContainsKey(interType) == false)
            {
                this.implementations.Add(interType, new Dictionary<string, Type>());
            }

            this.implementations[interType].Add(implType.Name, implType);
        }

        public object GetInstance(Type type)
        {
            instances.TryGetValue(type, out object value);
            return value;
        }

        public Type GetMapping(Type currrentInterface, object attribute)
        {
            Type result = null;
            var currentImplemetations = this.implementations[currrentInterface];

            if (currentImplemetations.Count == 0 
                && currentImplemetations == null)
            {
                throw new ArgumentException
                    ($"No available mapping for class: {currrentInterface.Name}");
            }

            if (attribute is InjectAttribute)
            {
               result = currentImplemetations
                    .Values.FirstOrDefault();
            }
            else if (attribute is NamedAttribute named)
            {
                result = currentImplemetations[named.Name];
            }

            return result;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (instances.ContainsKey(implementation) == false)
            {
                instances.Add(implementation, instance);
            }
        }
    }
}
