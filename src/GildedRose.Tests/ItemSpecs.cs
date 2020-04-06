using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class ItemSpecs
    {
        [Fact]
        public void QualityShouldNeverBeNegative()
        {
            var program = new Program();
            program.Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 } };
            program.UpdateQuality();

            Assert.Equal(0, program.Items[0].Quality);
        }

        [Fact]
        public void QualityShouldNeverBeGreaterThan50()
        {
            var program = new Program();
            program.Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 50 } };
            program.UpdateQuality();

            Assert.Equal(49, program.Items[0].Quality);
        }

        [Fact]
        public void QualityShouldDegradeBy1BeforeSellingByDateHasPassed()
        {
            var program = new Program();

            program.Items = new List<Item> {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 50 }
            };

            program.UpdateQuality();
            program.UpdateQuality();

            Assert.Equal(48, program.Items[0].Quality);
        }

        [Fact]
        public void QualityShouldDegradeTwiceAsFastAfterSellByDateHasPassed()
        {
            var program = new Program();

            program.Items = new List<Item> {
                new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 50 }
            };

            program.UpdateQuality();

            Assert.Equal(48, program.Items[0].Quality);
        }


    }
}
