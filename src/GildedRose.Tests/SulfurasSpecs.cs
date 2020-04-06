using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class SulfurasSpecs
    {
        [Fact]
        public void SulfurasQualityShouldNeverChange()
        {
            var program = new Program();
            program.Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };

            program.UpdateQuality();

            Assert.Equal(80, program.Items[0].Quality);
        }


    }
}
