using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class ConjuredManaCakeSpecs
    {

        [Fact]
        public void ShouldDecreaseQualityByTwoBeforeSellIn()
        {
            Item item = new Item { Quality = 30, SellIn = 8, Name = "Conjured Mana Cake" };
            var program = new Program();
            program.Items = new List<Item> { item };
            program.UpdateQuality();

            Assert.Equal(28, item.Quality);
            Assert.Equal(7, item.SellIn);

        }

        [Fact]
        public void ShouldDecreaseQualityByFourAfterSellIn()
        {
            Item item = new Item { Quality = 30, SellIn = 0, Name = "Conjured Mana Cake" };
            var program = new Program();
            program.Items = new List<Item> { item };
            program.UpdateQuality();

            Assert.Equal(26, item.Quality);
            Assert.Equal(-1, item.SellIn);

        }

    }
}
