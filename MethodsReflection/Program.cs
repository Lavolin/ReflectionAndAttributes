using System;
using System.Reflection;
using System.Text;

namespace MethodsReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Student);
            MethodInfo[] methods = type.GetMethods((BindingFlags)(60));
            Student student = new Student();
            foreach (var method in methods)
            {
                Console.WriteLine($"{method.Name} -> {method.ReturnParameter.ParameterType}, {method.GetParameters().Length} count of params");

                object result = null;
                if (method.GetParameters().Length == 0)
                {
                    result = method.Invoke(student, new object[] { });

                    Console.WriteLine($"Invoking: {method.Name} -> {result}");
                }
            }

            PropertyInfo[] propertyInfos = typeof(Student).GetProperties();
            student.Name = "Toshko";
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Console.WriteLine(propertyInfo.Name);
                Console.WriteLine(propertyInfo.GetValue(student));
                propertyInfo.SetValue(student, "Adi");
            }
            Console.WriteLine(student.Name);

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
            Console.WriteLine("Setwam name w konstructora: " + name);
            this.name = name;
        }

        public Student(string name, int x, int y, StringBuilder text)
        {

        }
        public Student()
        {

            Console.WriteLine("Prazen konstruktor");
        }

        public string Name { get; set; }

        public string Hi(int x)
        {
            Console.WriteLine("Buzzzz " + name);
            return null;
        }

        private string PrivateMethod()
        {
            Console.WriteLine("KU KU");
            return "ima li nqkoi?";
        }
    }
}
