using FC.Core.Extension.NumericHandlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit;
using Xunit.Abstractions;
using Shouldly;

namespace FC.Core.Extension.Test.Lists
{
    public class IEnumerableExtensionTest
    {
        private readonly ITestOutputHelper _output;
        public IEnumerableExtensionTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public async Task ForEach_Test()
        {
            var items = new List<Item>();
            Item item1 = new Item()
            {
                FirstName = "F",
                LastName = "L"
            };
            Item item2 = new Item()
            {
                FirstName = "F1",
                LastName = "L2"
            };
            items.Add(item1);
            items.Add(item2);
            // populate items
            items.ForEach(item => ActionMethod(item));

            items.ForEach(item => Print(item));
            item2.FullName.ShouldNotBeNullOrEmpty();
            
        }
        void Print(Item item)
        {
            _output.WriteLine($"FullName {item.FullName}");
        }
        void ActionMethod(Item item)
        {
            item.FullName = item.FirstName + " " + item.LastName;
            // do something to item
        }
    }
    class Item
    {
        public string FirstName { get; set; }
        public string LastName { get; set;  }
        public string FullName { get; set; }

        
    }
}
