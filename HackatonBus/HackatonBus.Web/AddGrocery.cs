using NServiceBus;

namespace HackatonBus.Suppliers
{
    public class AddGrocery : ICommand
    {
        public string Name { get; set; }
        public int Amount => 1;
    }
}