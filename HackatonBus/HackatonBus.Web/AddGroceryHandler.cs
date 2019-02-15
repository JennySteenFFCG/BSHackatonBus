using NServiceBus;
using System.Threading.Tasks;

namespace HackatonBus.Suppliers
{
    public class AddGroceryHandler :
        IHandleMessages<AddGrocery>
    {
        private RequestsStore _requestsStore;

        public AddGroceryHandler(RequestsStore requestsStore)
        {
            _requestsStore = requestsStore;
        }

        public Task Handle(AddGrocery message, IMessageHandlerContext context)
        {
            _requestsStore.AddRequest(message.Name, message.Amount);

            return Task.CompletedTask;
        }
    }
}