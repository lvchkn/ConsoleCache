using ConsoleCache.Cache;
using ConsoleCache.Runners;
using System.Linq;

namespace ConsoleCache.Commands
{
    public class PutCommand : ICommand
    {
        private readonly ICache _lruCache;
        private readonly CommandLineEventsPublisher _eventsPublisher;

        public CommandModel Model { get; set; } = new CommandModel("put", 2);

        public PutCommand(ICache lruCache, CommandLineEventsPublisher eventsPublisher)
        {
            _lruCache = lruCache;
            _eventsPublisher = eventsPublisher;
            _eventsPublisher.CommandReceived += OnEventReceived;
        }

        public void OnEventReceived(object sender, CommandReceivedEventArgs args)
        {
            if (args.Command.Model.Name != Model.Name)
            {
                return;
            }

            var values = args.Command.Model.Values.ToArray();

            Execute(values[0], values[1]);
        }

        public void Execute(int key, int value)
        {
            _lruCache.Put(key, value);
        }
    }
}
