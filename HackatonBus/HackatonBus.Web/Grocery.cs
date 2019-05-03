using NServiceBus;

namespace HackatonBus.Suppliers
{
    public class Grocery : IMessage
    {
        public string Name { get; set; }
    }
}