using System;
using System.Reflection;

namespace JudgeReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int max = 30;

            Assembly assemply = Assembly.LoadFile(@"C:\Users\Todor\source\repos\CSharp OOP\ReflectionAndAttributes\CarTask\bin\Debug\netcoreapp3.1\CarTask.dll");

            Type[] types = assemply.GetTypes();

            score += CheckConstructorParams(types[0]);
            score += CheckConstructorLogic(types[0]);
            score += CheckReducePrice(types[0]);

            Console.WriteLine($"Your score is: {score} / from max {max}");
        }

        private static int CheckReducePrice(Type type)
        {
            try
            {
                object car = Activator.CreateInstance(type, 20m, "Car");

                var method = type.GetMethod("ReducePrice");
                if (method.IsPublic == false)
                {
                    return 0;
                }

                method.Invoke(car,new object[] { 15m });
                var priceProp = type.GetProperty("Price");
                if ((decimal)priceProp.GetValue(car) == 5m)
                {
                    return 10;
                }
            }
            catch (Exception)
            {

                
            }

            return 0;
        }

        private static int CheckConstructorLogic(Type type)
        {
            try
            {
                object car = Activator.CreateInstance(type, 20m, "Car");
                var nameProp = type.GetProperty("Model");
                var priceProp = type.GetProperty("Price");

                if ((string)nameProp.GetValue(car) == "Car" && (decimal)priceProp.GetValue(car) == 20m)
                {
                    return 10;
                }
            }
            catch (Exception)
            {

                
            }

            return 0;
        }

        private static int CheckConstructorParams(Type type)
        {

            foreach (var cons in type.GetConstructors())
            {
                var parameters = cons.GetParameters();
                if (parameters[0].ParameterType == typeof(decimal) && parameters[0].Name == "price")
                {
                    if (parameters[1].ParameterType == typeof(string) && parameters[1].Name == "model")
                    {
                        if (parameters.Length == 2)
                        {
                            return 10;

                        }
                    }

                }


            }

            return 0;
        }
    }
}
