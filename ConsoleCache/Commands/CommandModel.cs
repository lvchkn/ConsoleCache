using System.Collections.Generic;

namespace ConsoleCache.Commands
{
    public class CommandModel
    {
        private int _numberOfValues;
        public string Name { get; set; }
        public int NumberOfValues
        {
            get { return _numberOfValues; }
            private set
            {
                if (value > 0)
                {
                    _numberOfValues = value;
                }
            }
        }
        public ICollection<int> Values { get; set; }

        public CommandModel(string name, int numberOfValues)
        {
            Name = name;
            NumberOfValues = numberOfValues;
        }
    }
}
