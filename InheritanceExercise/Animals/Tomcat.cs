using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            :base(name, age, gender)
        {

        }
        private const string gender = "Male";
        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
