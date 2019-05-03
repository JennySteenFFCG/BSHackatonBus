using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace HackatonBus.Suppliers.Tests
{
    public class RequestStoreTests
    {
        private GroceryStore _groceryStore;

        [SetUp]
        public void Setup()
        {
            _groceryStore = new GroceryStore();
        }

        [Test]
        public void Should_add_request_to_store()
        {
            var newRequest = "tomatoe"; 
            _groceryStore.AddRequest(newRequest, 1);

            var requests = _groceryStore.CurrentGroceries();
            requests.Count.Should().Be(1);
            requests.Single().Key.Should().Be(newRequest);
            requests.Single().Value.Should().Be(1);
        }

        [Test]
        public void Should_add_up_numberOfItems_when_there_is_already_a_grocery_of_a_certain_type()
        {
            var newRequest = "tomatoe";
            _groceryStore.AddRequest(newRequest, 1);
            _groceryStore.AddRequest(newRequest, 2);

            var requests = _groceryStore.CurrentGroceries();
            requests.Count.Should().Be(1);
            requests.Single().Value.Should().Be(3);
        }

        [Test]
        public void Should_remove_request_from_store()
        {
            var newRequest = "tomatoe";
            _groceryStore.AddRequest(newRequest, 1);

            _groceryStore.RemoveRequest(newRequest, 1);
            var requests = _groceryStore.CurrentGroceries();
            requests.Single().Value.Should().Be(0);
        }

        [Test]
        public void Should_set_request_numberOfItems_to_minus()
        {
            var newRequest = "tomatoe";
            _groceryStore.AddRequest(newRequest, 1);

            _groceryStore.RemoveRequest(newRequest, 2);
            var requests = _groceryStore.CurrentGroceries();
            requests.Single().Value.Should().Be(-1);
        }
    }
}