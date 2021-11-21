using ConsoleCache.Commands;
using System;
using System.Linq;

namespace ConsoleCache.Parsers
{
    public class CommandParser
    {
        private const string Get = "get";
        private const string Put = "put";
        private const string Print = "print";

        private readonly PrintCommand _printCommand;
        private readonly PutCommand _putCommand;
        private readonly GetCommand _getCommand;

        public CommandParser(PrintCommand printCommand, PutCommand putCommand, GetCommand getCommand)
        {
            _printCommand = printCommand;
            _putCommand = putCommand;
            _getCommand = getCommand;
        }

        private bool TryCreateCommand(string commandName, string[] values, out ICommand command)
        {
            switch (commandName.ToLower())
            {
                case Get:
                    command = _getCommand;
                    break;
                case Put:
                    command = _putCommand;
                    break;
                case Print:
                    command = _printCommand;
                    break;
                default:
                    command = null;
                    return false;
            };

            command.Model.Values = values?.Select(x => Convert.ToInt32(x)).ToArray();

            return true;
        }

        public ICommand CreateCommand(string name, string[] values)
        {
            if (!TryCreateCommand(name, values, out var command))
            {
                throw new Exception("Error while creating command");
            }

            if (values != null && command.Model.NumberOfValues != values.Length)
            {
                throw new Exception("Wrong set of values for this command");
            }

            return command;
        }
    }
}
