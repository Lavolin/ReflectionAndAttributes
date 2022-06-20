using System;
using System.Reflection;

namespace CreateInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            //string typeToCreate = Console.ReadLine();

            Type type = typeof(Student);//Type.GetType(typeToCreate);

            var instance = (Student)Activator.CreateInstance(type,"Toshko");
            instance.Hi();

            //FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static); // == ->
            FieldInfo[] fields = type.GetFields((BindingFlags)(60));


            foreach (FieldInfo field in fields)
            {
                Console.WriteLine($"Field Name: -----------> {field.Name}");
                if (field.FieldType == typeof(string))
                {
                    field.SetValue(instance, "Manually");
                }
                Console.WriteLine(field.GetValue(instance));
                Console.WriteLine(field.Name);
                Console.WriteLine(field.IsStatic);
                Console.WriteLine(field.FieldType);
                Console.WriteLine(field.IsPublic);
                Console.WriteLine(field.IsFamily);
                Console.WriteLine(field.IsPrivate);
                Console.WriteLine();
            }

            instance.Hi();

        }
    }

    class Student
    {
        private string name;
        private string cheatingCodes = "11 , 123";
        private static string cheatingFriend = "Ely";
        private int x;
        public Student(string name)
        {
            this.name = name;
        }

        public Student(int times)
        {
            Console.WriteLine(times);
            Console.WriteLine("I am writing.");
        }

        public Student(int times, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("I am reflection.");
        }

        public void Hi()
        {
            Console.WriteLine("Buzzzz " + name);
        }
    }
}
