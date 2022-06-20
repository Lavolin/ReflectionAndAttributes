using System;

namespace Types
{
    class Program
    {
        static void Main(string[] args)
        {
            var typeName = Console.ReadLine();
            Type type = Type.GetType(typeName);
            Console.WriteLine(type.FullName);
            Console.WriteLine(type.IsEnum);
        }
    }
}
