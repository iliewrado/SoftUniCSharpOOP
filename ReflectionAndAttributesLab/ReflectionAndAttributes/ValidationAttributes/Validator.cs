using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ValidationAttributes.CustomAtributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj
                .GetType()
                .GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute validationAttribute =
                    (MyValidationAttribute)property
                    .GetCustomAttribute(typeof(MyValidationAttribute), false);
                
                bool isValid = validationAttribute.IsValid(property.GetValue(obj));
                
                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
