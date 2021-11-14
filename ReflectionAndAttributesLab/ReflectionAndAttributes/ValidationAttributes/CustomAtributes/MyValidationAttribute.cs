using System;

namespace ValidationAttributes.CustomAtributes
{
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
