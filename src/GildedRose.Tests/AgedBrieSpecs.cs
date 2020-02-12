using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    
    public class AgedBrieSpecs
    {
        [Fact]
        public void AgedBrieQualityShouldIncreaseAsTimePasses()
        {
            var program = new Program();
            program.Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };

            var agedBrieOldQuality = program.Items[0].Quality;

            program.UpdateQuality();

            var agedBrieNewQuality = program.Items[0].Quality;

            Assert.True(agedBrieOldQuality < agedBrieNewQuality);
        }
    }
}
