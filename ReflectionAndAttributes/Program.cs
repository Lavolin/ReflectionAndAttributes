using System;
using System.Reflection;

namespace ReflectionAndAttributes
{
     class Program
    {
        public int x = 5;
        static void Main(string[] args)
        {
            Program program3 = new Program();
            Console.WriteLine(program3.x);
            FieldInfo fieldInfo = typeof(Program).GetField("x");

            var y = fieldInfo.GetValue(program3);
            Console.WriteLine(y);

            fieldInfo.SetValue(program3, 6);
            Console.WriteLine(program3.x);

            typeof(Console).GetFields(BindingFlags.Public);
        }
    }
}
