using System.Collections.Generic;

namespace HackatonBus.Suppliers
{
    public class GroceryStore
    {
        private readonly Dictionary<string, int> _requests;

        public GroceryStore()
        {
            _requests = new Dictionary<string, int>();
        }

        public Dictionary<string, int> CurrentGroceries() => _requests;

        public void AddRequest(string newRequest, int numberOfItems)
        {
            if (_requests.TryGetValue(newRequest, out int currentNumberOfItems))
            {
                _requests[newRequest] = currentNumberOfItems + numberOfItems;
            }

            _requests.TryAdd(newRequest, numberOfItems);
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