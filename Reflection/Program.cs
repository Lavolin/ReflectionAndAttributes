using System;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTypeInfo(new Writer());
            Console.WriteLine("5:");
            PrintTypeInfo(5);
            Console.WriteLine("Array:");
            PrintTypeInfo(new int[] {1, 2, 3});
        }

        public static void PrintTypeInfo(object obj)
        {
            Type type = obj.GetType();
            Console.WriteLine(type.Name);
            Console.WriteLine(type.FullName);
            Console.WriteLine(type.IsValueType);
            Console.WriteLine(type.Attributes);
            Console.WriteLine(type.BaseType);
            Console.WriteLine(type.IsGenericType);
            Console.WriteLine(type.IsArray);
            Console.WriteLine(type.Assembly);
            Console.WriteLine(type.BaseType);

        }
    }

    class Writer
    {

    }
}
