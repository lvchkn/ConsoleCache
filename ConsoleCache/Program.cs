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
            var cacheCapacity = GetCacheCapacity();

            DI.Configure(cacheCapacity);

            do
            {
                Console.Write("Enter command (get | put | print): ");
                var input = Console.ReadLine().Split(" ");

                (var isInputValid, var commandName, var values) = InputValidator.TryValidateInput(input);

                if (!isInputValid)
                {
                    throw new Exception("Wrong input");
                }

                var eventArgs = new CommandReceivedEventArgs(CreateCommand(commandName, values));

                DI.ServiceProvider.GetRequiredService<CommandLineEventsPublisher>().OnCommandReceived(eventArgs);

                Console.WriteLine();

            } while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));
        }

        private static int GetCacheCapacity()
        {
            Console.Write("Enter cache capacity: ");

            if (!int.TryParse(Console.ReadLine(), out var cacheCapacity))
            {
                throw new Exception("Cache capacity must be an integer value");
            }

            if (cacheCapacity <= 0)
            {
                throw new Exception("Cache capacity must be greater than 0");
            }

            Console.WriteLine();

            return cacheCapacity;
        }

        private static ICommand CreateCommand(string name, string[] values)
        {
            return DI.ServiceProvider.GetRequiredService<CommandParser>().CreateCommand(name, values);
        }
    }   
}

