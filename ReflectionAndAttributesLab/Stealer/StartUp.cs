using System;
using System.Reflection;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            //string result = spy
            //.StealFieldInfo(typeof(Stealer.Hacker).FullName, "username", "password");

            //string result = spy.AnalyzeAccessModifiers(typeof(Stealer.Hacker).FullName);

            //string result = spy.RevealPrivateMethods(typeof(Stealer.Hacker).FullName);

            string result = spy.CollectGettersAndSetters(typeof(Stealer.Hacker).FullName);


            Console.WriteLine(result);
        }
    }
}
