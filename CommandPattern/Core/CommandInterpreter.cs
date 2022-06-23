using System;
using System.Linq;
using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;


namespace CommandPattern.Core
{                                       // 0:50
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args) // HelloCommand Todor
        {
            string[] input = args.Split();

            string commandName = input[0];
            string[] value = input.Skip(1).ToArray();

            ICommand command = default;

            if (commandName == "HelloCommand")
            {
               command = new HelloCommand();
            }
            else if (commandName == "ExitCommand")
            {
                command = new ExitCommand();
                
            }

            string result = command.Execute(value);

            return null;

        }
    }
}
