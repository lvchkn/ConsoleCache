using System;
using Microsoft.Extensions.DependencyInjection;
using ConsoleCache.Commands;
using ConsoleCache.Parsers;
using ConsoleCache.Validators;
using ConsoleCache.Configuration;
using ConsoleCache.Runners;

namespace ConsoleCache
{
    class Program
    {
        static void Main()
        {
            DI.Configure();

            do
            {
                Console.Write("Type command: ");
                var input = Console.ReadLine().Split(" ");

                (var isInputValid, var commandName, var values) = InputValidator.TryValidateInput(input);

                if (!isInputValid)
                {
                    throw new Exception();
                }

                var eventArgs = new CommandReceivedEventArgs(CreateCommand(commandName, values));

                DI.ServiceProvider.GetRequiredService<CommandLineEventsPublisher>().OnCommandReceived(eventArgs);

                Console.WriteLine();

            } while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));
        }

        private static ICommand CreateCommand(string name, string[] values)
        {
            return DI.ServiceProvider.GetRequiredService<CommandParser>().CreateCommand(name, values);
        }
    }   
}

