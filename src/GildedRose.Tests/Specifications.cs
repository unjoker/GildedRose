using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class Specifications
    {
        [Fact]
        public void AgedBrieQualityShouldIncreaseByOne()
        {
            var app = new Program { Items = new List<Item> { new Item { Name = "Aged Brie", Quality = 1, SellIn = 10 } } };
            app.UpdateQuality();
            Assert.Equal(10, app.Items.First().Quality);
        }
    }
}
