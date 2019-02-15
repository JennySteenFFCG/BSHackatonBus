using System.Collections.Generic;
using System.Linq;

namespace HackatonBus.Suppliers
{
    public class RequestsStore
    {
        private Dictionary<string, int> _requests;

        public RequestsStore()
        {
            _requests = new Dictionary<string, int>();
        }

        public void AddRequest(string newRequest, int numberOfItems)
        {
            if (_requests.TryGetValue(newRequest, out int currentNumberOfItems))
            {
                _requests[newRequest] = currentNumberOfItems + numberOfItems;
            }

            _requests.TryAdd(newRequest, numberOfItems);
        }

        public Dictionary<string, int> GetRequests()
        {
            return _requests;
        }

        public void RemoveRequest(string newRequest, int numberOfItems)
        {
            if (_requests.TryGetValue(newRequest, out int currentNumberOfItems))
            {
                _requests[newRequest] = currentNumberOfItems - numberOfItems;
            }

            _requests.TryAdd(newRequest, -numberOfItems);
        }
    }
}
