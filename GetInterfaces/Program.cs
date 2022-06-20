using System;
using System.Collections;
using System.IO;

namespace GetInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
           Type type = typeof(IList);
            Type[] interfaces = type.GetInterfaces();
            foreach (var interfaceType in interfaces)
            {
                Console.WriteLine(interfaceType.Name);
            }
        }
    }
}
