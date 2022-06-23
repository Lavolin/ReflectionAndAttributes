using System;
using System.Reflection;

namespace Attributes
{
    class Program               
    {
        static void Main(string[] args)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            Type[] types2 = Assembly.GetAssembly(typeof(Console)).GetTypes();

            Product product = new Product()
            {
                ID = 5,
                Model = "The Best",
                Name = "TT",
            };

            SerializeToJson(product);
        }

        public static string SerializeToJson<T>(T instance)
        {
            string result = "";

            Type type = typeof(T);

            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                SerializableAttribute serializableAttribute =
                    prop.GetCustomAttribute(typeof(SerializableAttribute)) as SerializableAttribute;

                if (serializableAttribute != null)
                {

                    Console.WriteLine($"Deep: {serializableAttribute.IsDeep}, X: {serializableAttribute.X}");
                    Console.WriteLine($"{{{prop.Name}:{prop.GetValue(instance)}}}");
                }
            }

            return result;
        }
    }
    class Product
    {
        [SerializableAttribute(IsDeep = true)]
        public int ID { get; set; }
        [SerializableAttribute(X = 6, IsDeep = true)]
        public string Name { get; set; }
        [SerializableAttribute(X = 5, IsDeep = true)]
        public string Model { get; set; }
        public int Quantity { get; set; }
        [SerializableAttribute]
        public bool IsFake { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class SerializableAttribute : Attribute
    {
        public SerializableAttribute(bool isDeep, int x)
        {
            IsDeep = isDeep;
            X = x;
        }

        public SerializableAttribute() : this(false, 3)
        {

        }
        public bool IsDeep { get; set; }

        public int X { get; set; }
    }
}
