using System;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj) // Person Name, Age
        {
            PropertyInfo[] propertyInfos = obj
                .GetType() // Person
                .GetProperties() // Name, Age, Salary
                .Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute)).Any()) // Name, Age
                .ToArray();
                

            foreach (var propertyInfo in propertyInfos)
            {
                object value = propertyInfo.GetValue(obj);

                MyValidationAttribute[] attributes = propertyInfo
                    .GetCustomAttributes<MyValidationAttribute>()
                    .ToArray();

                foreach (var attribute in attributes)
                {
                    bool isValid = attribute.IsValid(value);

                    if (!isValid) return false;
                }
            }

            return true;
        }
    }
}