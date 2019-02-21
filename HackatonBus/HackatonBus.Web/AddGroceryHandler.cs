using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace HackatonBus.Suppliers
{
    public class AddGroceryHandler : IHandleMessages<Grocery>
    {
        private readonly GroceryStore _groceryStore;
        private static readonly ILog Log = LogManager.GetLogger<AddGroceryHandler>();

        public AddGroceryHandler(GroceryStore groceryStore)
        {
            _groceryStore = groceryStore;
        }

        public Task Handle(Grocery message, IMessageHandlerContext context)
        {
            Log.Info($"Chef needs a {message.Name}.");

            _groceryStore.AddRequest(message.Name, 1);

            return Task.CompletedTask;
        }
    }
}