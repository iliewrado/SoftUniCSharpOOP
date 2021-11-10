using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Static
                | BindingFlags.NonPublic | BindingFlags.Public);
            
            StringBuilder spy = new StringBuilder();

            object classInstance = Activator.CreateInstance(classType, null);

            spy.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields
                .Where(x => requestedFields.Contains(x.Name)))
            {
                spy.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return spy.ToString().Trim();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType
                .GetFields(BindingFlags.Public 
                | BindingFlags.Instance 
                | BindingFlags.Static);
            MethodInfo[] classPublicMethods = classType
                .GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] classNonPublicMethods = classType
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder spy = new StringBuilder();

            foreach (FieldInfo field in classFields)
            {
                spy.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in classNonPublicMethods
                .Where(x => x.Name.StartsWith("get")))
            {
                spy.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo method in classPublicMethods
                .Where(x => x.Name.StartsWith("set")))
            {
                spy.AppendLine($"{method.Name} have to be private!");
            }

            return spy.ToString().TrimEnd();

        }
        public string RevealPrivateMethods(string investigatedClass)
        {
            StringBuilder spy = new StringBuilder();

            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] methods = classType
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            spy.AppendLine($"All Private Methods of Class: {investigatedClass}");
            spy.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in methods)
            {
                spy.AppendLine(method.Name);
            }

            return spy.ToString().TrimEnd();
        }
        public string CollectGettersAndSetters(string investigatedClass)
        {
            StringBuilder spy = new StringBuilder();

            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] classMethods = classType
                .GetMethods(BindingFlags.Public 
                | BindingFlags.Instance 
                | BindingFlags.NonPublic);
            foreach (var method in classMethods.Where(x => x.Name.StartsWith("get")))
            {
                spy.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (var method in classMethods.Where(x => x.Name.StartsWith("set")))
            {
                spy.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return spy.ToString().Trim();
        }
    }
}
