using System;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static string SerializeToJson<T>(object instance)
        {
            string result = "";

            Type type = typeof(T);
            //1.42.07
            return result;
        }
    }

    class Product
    {
        [SerializableAttribute]
        public int ID { get; set; }
        [SerializableAttribute]
        public string Name { get; set; }
        [SerializableAttribute]
        public string Model { get; set; }
        public int  Quantity { get; set; }
        public bool IsFake { get; set; }
    }

    public class SerializableAttribute : Attribute
    {

    }
}
