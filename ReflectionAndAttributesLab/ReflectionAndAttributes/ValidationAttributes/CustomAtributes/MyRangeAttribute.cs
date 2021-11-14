using System;

namespace ValidationAttributes.CustomAtributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException("Invalid data type");
            }
            int objAsInt = (int)obj;
            bool isInRange = objAsInt >= minValue && objAsInt <= maxValue;
            if (!isInRange)
            {
                return false;
            }
            return true;
        }
    }
}
