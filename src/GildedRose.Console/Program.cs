using System.Collections.Generic;

namespace GildedRose.Console
{
    class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
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
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                DecreaseSellInValue(item);

                UpdateNormalItemQuality(item);
                
                UpdateAgedBrieQuality(item);

                UpdateBackstagePassQuality(item);

            }
        }

        private static void UpdateAgedBrieQuality(Item item)
        {
            if (!IsAgedBrie(item)) return;
            
                var points = item.SellIn < 0 ? 2 : 1;

                IncreaseQuality(item, points );

            
        }

        private static void DropBackstagePassQuality(Item item)
        {
            if (!IsBackstagePass(item)) return;
            
            item.Quality = 0;
            
        }

        private static void UpdateNormalItemQuality(Item item)
        {
            if (IsAgedBrie(item) || IsBackstagePass(item)) return;

            var points = item.SellIn < 0 ? 2 : 1;
            DecreaseQuality(item, points);
        }


        private static void DecreaseSellInValue(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros") return;
            
                item.SellIn = item.SellIn - 1;
            
        }

        private static void UpdateBackstagePassQuality(Item item)
        {
            if (!IsBackstagePass(item)) return;

            if (item.SellIn < 0)
            {
                DropBackstagePassQuality(item);
            }
            else
            {
                var points =
                    item.SellIn > 10 ? 1 :
                    item.SellIn < 11 && item.SellIn > 5 ? 2 :
                    item.SellIn < 6 && item.SellIn > 0 ? 3 : 0;

                IncreaseQuality(item, points);
            }

        }

        private static bool IsBackstagePass(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool IsAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private static void IncreaseQuality(Item item, int points)
        {
            if (item.Quality >= 50) return;
            
                item.Quality =  item.Quality + points > 50 ? 50 : item.Quality + points;
            
        }

        private static void DecreaseQuality(Item item, int points)
        {
            var canDecreaseQuality = item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros";
            if (!canDecreaseQuality) return;
            
            item.Quality = item.Quality - points < 0 ? 0 : item.Quality - points;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
