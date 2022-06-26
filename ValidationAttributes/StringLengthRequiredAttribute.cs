using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class StringLengthRequiredAttribute : MyValidationAttribute
    {
        private readonly int minLength;

        public StringLengthRequiredAttribute(int minLength)
        {
            this.minLength = minLength;
        }
        public override bool IsValid(object obj)
        {
            string value = (string)obj;

            return value.Length >= minLength;
        }
    }
}
