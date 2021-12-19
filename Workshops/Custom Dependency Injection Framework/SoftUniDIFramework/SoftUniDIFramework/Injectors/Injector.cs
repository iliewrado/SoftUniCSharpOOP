using SoftUniDIFramework.Attributes;
using SoftUniDIFramework.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace SoftUniDIFramework.Injectors
{
    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            bool hasConstructorAttribute = CheckForConstructorInjection<TClass>();
            bool hasFieldAttribute = CheckForFieldInjection<TClass>();

            if (hasConstructorAttribute && hasFieldAttribute)
            {
                throw new ArgumentException
                    ("There must be only field or constructor annotated with Inject Attribute");
            }

            if (hasConstructorAttribute)
            {
                return CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAttribute)
            {
                return CreateFieldInjection<TClass>();
            }

            return default(TClass);
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass).GetFields((BindingFlags)62)
                .Any(x => x.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors()
                .Any(x => x.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            Type desireClass = typeof(TClass);
            if (desireClass == null) return default(TClass);
            ConstructorInfo[] constructors = desireClass.GetConstructors();
            int i = 0;

            foreach (var constructor in constructors)
            {
                if (CheckForConstructorInjection<TClass>() == false) continue;

                InjectAttribute inject = (InjectAttribute)constructor
                    .GetCustomAttributes<InjectAttribute>(true)
                    .FirstOrDefault();
                ParameterInfo[] parameterTypes = constructor.GetParameters();
                object[] constructorParams = new object[parameterTypes.Length];


                foreach (var paremeterType in parameterTypes)
                {
                    Attribute named = paremeterType
                        .GetCustomAttribute<NamedAttribute>(true);
                    Type dependency = null;

                    if (named == null)
                    {
                        dependency = this.module.GetMapping(paremeterType.ParameterType, inject);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(paremeterType.ParameterType, named);
                    }

                    if (paremeterType.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = module.GetInstance(dependency);
                        if (instance != null)
                        {
                            constructorParams[i++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependency);
                            constructorParams[i++] = instance;
                            module.SetInstance(paremeterType.ParameterType, instance);
                        }
                    }
                }

                return (TClass)Activator.CreateInstance(desireClass, constructorParams);
            }

            return default(TClass);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            Type desireClass = typeof(TClass);
            object desireClassInstance = module.GetInstance(desireClass);

            if (desireClassInstance == null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                module.SetInstance(desireClass, desireClassInstance);
            }

            FieldInfo[] fields = desireClass.GetFields((BindingFlags)62);

            foreach (var field in fields)
            {
                if (field.GetCustomAttributes(typeof(InjectAttribute), true).Any())
                {
                    InjectAttribute injetion = (InjectAttribute)field
                        .GetCustomAttributes(typeof(InjectAttribute), true)
                        .FirstOrDefault();

                    Type dependecy = null;

                    Attribute named = field.GetCustomAttribute(typeof(NamedAttribute), true);
                    Type type = field.FieldType;

                    if (named == null)
                    {
                        dependecy = module.GetMapping(type, injetion);
                    }
                    else
                    {
                        dependecy = module.GetMapping(type, named);
                    }

                    if (type.IsAssignableFrom(dependecy))
                    {
                        object instance = module.GetInstance(dependecy);
                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependecy);
                            module.SetInstance(dependecy, instance);
                        }

                        field.SetValue(desireClassInstance, instance);
                    }
                }
            }

            return (TClass)desireClassInstance;
        }
    }
}
