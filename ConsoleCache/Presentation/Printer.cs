using System;

namespace ConsoleCache.Presentation
{
    public class Printer
    {     
        public void Print(int value)
        {
            Console.WriteLine($"Cached value: {value}");
        }

        public void Print(string value)
        {
            Console.WriteLine(value);
        }
    }
}
