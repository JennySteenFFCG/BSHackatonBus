using HackatonBus.Suppliers;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using NServiceBus.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackatonBus.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly GroceryStore _groceryStore;
        private readonly IMessageSession _messageSession;
        private static readonly ILog Log = LogManager.GetLogger<AddGroceryHandler>();

        public SuppliersController(IMessageSession messageSession, GroceryStore groceryStore)
        {
            _groceryStore = groceryStore;
            _messageSession = messageSession;
        }

        [HttpGet]
        public Dictionary<string, int> Get()
        {
            return _groceryStore.CurrentGroceries();
        }

        [HttpPost("{grocery}")]
        public async Task Post(string grocery)
        {
            var groceryToChef = new Grocery()
            {
                Name = grocery
            };

            await _messageSession.Send(groceryToChef)
                .ConfigureAwait(false);

            Log.Info($"Posted a lovely {groceryToChef.Name}");
            _groceryStore.RemoveRequest(grocery, 1);
        }
    }
}