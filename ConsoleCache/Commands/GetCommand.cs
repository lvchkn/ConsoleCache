using ConsoleCache.Cache;
using ConsoleCache.Presentation;
using ConsoleCache.Runners;
using System.Linq;

namespace ConsoleCache.Commands
{
    public class GetCommand : ICommand
    {
        private readonly ICache _lruCache;
        private readonly CommandLineEventsPublisher _eventsPublisher;
        private readonly Printer _printer;

        public CommandModel Model { get; set; } = new CommandModel("get", 1);

        public GetCommand(ICache lruCache, CommandLineEventsPublisher eventsPublisher, Printer printer)
        {
            _lruCache = lruCache;
            _eventsPublisher = eventsPublisher;
            _eventsPublisher.CommandReceived += OnEventReceived;
            _printer = printer;
        }

        public void OnEventReceived(object sender, CommandReceivedEventArgs args)
        {
            if(args.Command.Model.Name != Model.Name)
            {
                return;
            }

            var keyToGet = args.Command.Model.Values.First();
            var value = Execute(keyToGet);

            _printer.Print(value);
        }

        public int Execute(int key)
        {
            return _lruCache.Get(key);
        }
    }
}
