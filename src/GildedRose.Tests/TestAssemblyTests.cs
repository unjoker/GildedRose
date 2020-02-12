using GildedRose.Console;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        List<Item> Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                                          };

        public TestAssemblyTests()
        {

        }

        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }

        [Fact]
        public void QualityShouldNeverBeNegative()
        {
            var program = new Program();
            program.Items = Items;
            program.UpdateQuality();

            Assert.DoesNotContain(program.Items, item => item.Quality < 0);
        }
        [Fact]
        public void QualityShouldNeverBeGreaterThan50()
        {
            var program = new Program();
            program.Items = Items;
            program.UpdateQuality();

            Assert.DoesNotContain(program.Items, item => item.Quality > 50 && item.Name != "Sulfuras, Hand of Ragnaros");
        }

        [Fact]
        public void SulfurasQualityShouldNeverChange()
        {
            var program = new Program();
            program.Items = Items;

            var sulfurasOldQuality = Items.FirstOrDefault(item => item.Name == "Sulfuras, Hand of Ragnaros")?.Quality;

            program.UpdateQuality();

            var sulfurasNewQuality = program.Items.FirstOrDefault(item => item.Name == "Sulfuras, Hand of Ragnaros")?.Quality;

            Assert.Equal(sulfurasOldQuality, sulfurasNewQuality);
        }

        [Fact]
        public void AgedBrieQualityShouldIncrease()
        {
            var program = new Program();
            program.Items = Items;

            var agedBrieOldQuality = Items.FirstOrDefault(item => item.Name == "Aged Brie")?.Quality;

            program.UpdateQuality();

            var agedBrieNewQuality = program.Items.FirstOrDefault(item => item.Name == "Aged Brie")?.Quality;

            Assert.True(agedBrieOldQuality < agedBrieNewQuality);
        }

        [Fact]
        public void QualityShouldDegradeTwiceAsFastAfterSellByDateHAsPassed()
        {
            var program = new Program();

            program.Items = new List<Item> {
                new Item { Name = "Conjured Mana Cake", SellIn = 1, Quality = 10 } 
            };

            var cakeOldQuality = program.Items.FirstOrDefault(item => item.Name == "Conjured Mana Cake")?.Quality - 3;

            program.UpdateQuality();
            program.UpdateQuality();

            var cakeNewQuality = program.Items.FirstOrDefault(item => item.Name == "Conjured Mana Cake")?.Quality;

            Assert.Equal(cakeOldQuality, cakeNewQuality);
        }
		
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
    }
}