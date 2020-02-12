using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class BackstagePasses
    {
        [Fact]
        public void QualityIncreasesBy2WhenSellingDateIs10DaysOrLess()
        {
            var program = new Program();
            program.Items = new List<Item> {  new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 10,
                                                      Quality = 20
                                                  } };
            program.UpdateQuality();

            Assert.True(program.Items[0].Quality == 22);
        }

        [Fact]
        public void QualityIncreasesBy3WhenSellingDateIs5DaysOrLess()
        {
            var program = new Program();
            program.Items = new List<Item> {  new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 5,
                                                      Quality = 20
                                                  } };
            program.UpdateQuality();

            Assert.True(program.Items[0].Quality == 23);
        }

        [Fact]
        public void QualityDropsTo0AfterSellingDate()
        {
            var program = new Program();
            program.Items = new List<Item> {  new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 0,
                                                      Quality = 20
                                                  } };
            program.UpdateQuality();

            Assert.True(program.Items[0].Quality == 0);
        }

    }
}
