using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class BackstagePassesSpecs
    {
        List<Item> Items = new List<Item> {  new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  }};


        [Fact]
        public void BackstagePassesShouldIncreaseQualityByOneWhenSellInIsGreaterThan10()
        {
            var program = new Program();
            program.Items = Items;
            var bsPassesOldQuality = Items.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            program.UpdateQuality();

            var bsPassesNewQuality = program.Items.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            Assert.True(bsPassesNewQuality == (bsPassesOldQuality + 1));
        }

        [Fact]
        public void BackstagePassesShouldIncreaseQualityByTwoWhenSellInIsLowerThan11()
        {
            var program = new Program();
            Items.Find(x => x.Name.StartsWith("Backstage passes")).SellIn = 10;

            program.Items = Items;

            var bsPassesOldQuality = Items.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            program.UpdateQuality();

            var bsPassesNewQuality = program.Items.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            Assert.True(bsPassesNewQuality == (bsPassesOldQuality + 2));
        }

        [Fact]
        public void BackstagePassesShouldIncreaseQualityByThreeWhenSellInIsLowerThan6()
        {
            var program = new Program();
            Items.Find(x => x.Name.StartsWith("Backstage passes")).SellIn = 5;

            program.Items = Items;

            var bsPassesOldQuality = Items.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            program.UpdateQuality();

            var bsPassesNewQuality = program.Items.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            Assert.True(bsPassesNewQuality == (bsPassesOldQuality + 3));
        }

        [Fact]
        public void BackstagePassesShouldDropToZeroWhenSellInIs0()
        {
            var program = new Program();
            Items.Find(x => x.Name.StartsWith("Backstage passes")).SellIn = 0;

            program.Items = Items;

            program.UpdateQuality();

            var bsPassesNewQuality = program.Items.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            Assert.True(bsPassesNewQuality == 0);
        }

        [Fact]
        public void BackstagePassesQualityShouldNeverBeAbove50()
        {
            var program = new Program();
            Items.Find(x => x.Name.StartsWith("Backstage passes")).Quality = 49;
            Items.Find(x => x.Name.StartsWith("Backstage passes")).SellIn = 3;
            program.Items = Items;

            program.UpdateQuality();
            program.UpdateQuality();

            var bsPassesNewQuality = program.Items.FirstOrDefault(item => item.Name.StartsWith("Backstage passes"))?.Quality;

            Assert.True(bsPassesNewQuality == 50);
        }
    }
}
