using System;
using System.Reflection;
using System.Text;

namespace ConstructorReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Student);

            ConstructorInfo[] constructors = type.GetConstructors();

            foreach (var constructor in constructors)
            {
                ParameterInfo[] parameters = constructor.GetParameters();
                Console.WriteLine($"Constructor with {parameters.Length} count of params");
                foreach (var parameter in parameters)
                {
                    Console.Write(parameter.ParameterType + " ");
                    Console.WriteLine(parameter.Name);
                }
                Student student = (Student)constructors[2].Invoke(new object[] { });
                student.Hi();

                ConstructorInfo constructor1 = type.GetConstructor(new Type[] { typeof(String) });

                constructor1.Invoke(new object[] { "Ely" });
            }
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

        

        public void Hi()
        {
            Console.WriteLine("Buzzzz " + name);
        }
    }
}
