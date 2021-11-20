using ConsoleCache.Cache;
using ConsoleCache.Runners;

namespace ConsoleCache.Commands
{
    public class PrintCommand : ICommand
    {
        private readonly ICache _lruCache;
        private readonly CommandLineEventsPublisher _eventsPublisher;

        public CommandModel Model { get; set; } = new CommandModel("print", 0);

        public PrintCommand(ICache lruCache, CommandLineEventsPublisher eventsPublisher)
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

            Execute();
        }

        public void Execute()
        {
            (_lruCache as LruCache).PrintCachedKeyValuePairs();
        }

    }
}
