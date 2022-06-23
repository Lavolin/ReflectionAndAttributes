using System;

namespace AuthorProblem
{
    [AuthorAttribute("Todor")]
    [AuthorAttribute("Helper")]
    public class StartUp
    {
        [AuthorAttribute("Todor")]
        [AuthorAttribute("Helper")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

        }


        [AuthorAttribute("Todor")]
        public void Test()
        {

        }
    }
}
