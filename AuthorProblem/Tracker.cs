using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace AuthorProblem
{
    public class Tracker 
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            foreach (var method in type.GetMethods((BindingFlags)(60)))
            {
                object[] attrib = method.GetCustomAttributes(false);

                foreach (var attr in attrib)
                {
                    AuthorAttribute authorAttr = attr as AuthorAttribute;
                    if (authorAttr != null)
                    {
                        Console.WriteLine($"{method.Name} is written by {authorAttr.Name}");
                    }
                }
            }
        }
    }
}
