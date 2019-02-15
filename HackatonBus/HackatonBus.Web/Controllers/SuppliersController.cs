using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackatonBus.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace HackatonBus.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private RequestsStore _requestsStore;
        public SuppliersController(RequestsStore requestStore)
        {
            _requestsStore = requestStore;
        }

        [HttpGet]
        public Dictionary<string, int> Get()
        {
            return _requestsStore.GetRequests();
        }

        [HttpPost("{grocery}")]
        public void Post(string grocery)
        {
            _requestsStore.RemoveRequest(grocery, 1);

            // Remove from store
            // Send to bus
        }

    }
}
