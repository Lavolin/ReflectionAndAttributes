using System;
using System.Linq;
using System.Reflection;
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

           

            //if (commandName == "HelloCommand")
            //{
            //   command = new HelloCommand();
            //}
            //else if (commandName == "ExitCommand")
            //{
            //    command = new ExitCommand();

            //}
            //else if (commandName == "BeepCommand")
            //{
            //    command = new BeepCommand();
            //}

            //Find command by name with Reflection
            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName + "Command");

            if (type == null)
            {
                throw new InvalidOperationException("Missing command");
            }

            Type commandInterface = type.GetInterface("ICommand");

            if (commandInterface == null)
            {
                throw new InvalidOperationException("Not a command");

            }

            // Instance

            var command = Activator.CreateInstance(type) as ICommand;

            string result = command.Execute(value);

            return result;

        }
    }
}
