using ConsoleCache.Commands;
using System;

namespace ConsoleCache.Runners
{
    public class CommandReceivedEventArgs : EventArgs
    {
        public ICommand Command { get; set; }

        public CommandReceivedEventArgs(ICommand command)
        {
            Command = command;
        }
    }

    public class CommandLineEventsPublisher
    {
        public event EventHandler<CommandReceivedEventArgs> CommandReceived;

        public void OnCommandReceived(CommandReceivedEventArgs args)
        {
            CommandReceived?.Invoke(this, args);
        }
    }
}
