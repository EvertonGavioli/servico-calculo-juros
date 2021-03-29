using System;

namespace ExtensionMethods
{
    public static class DecimalExtensionMethods
    {
        public static decimal TruncateDecimal(this decimal number, int digits = 2)
        {
            decimal stepper = (decimal)(Math.Pow(10.0, digits));

            Int64 temp = (Int64)(stepper * number);

            return temp/stepper;
        }
    }
}
