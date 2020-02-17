using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        public static void Main(string[] args)
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

            foreach (var item in app.Items)
            {
                System.Console.WriteLine($"Name: {item.Name}, Quality: {item.Quality}, SellIn: {item.SellIn}");
            }

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                NormalItem(i);

                AgedBrie(Items[i]);
                BackstagePasses(i);
                SellIn(i);

                if (Items[i].SellIn < 0)
                {
                    NormalItem(i);
                    DropBackstageQuality(i);
                    AgedBrie(Items[i]);
                }

            }
        }

        private void DropBackstageQuality(int i)
        {
            if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                Items[i].Quality = Items[i].Quality - Items[i].Quality;
            }
        }

        private void SellIn(int i)
        {
            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }
        }

        private void NormalItem(int i)
        {
            var isNormalItem = Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" &&
                                Items[i].Name != "Sulfuras, Hand of Ragnaros";

            if (isNormalItem && Items[i].Quality > 0)
            {
                Items[i].Quality = Items[i].Quality - 1;
            }
        }

        private void BackstagePasses(int i)
        {
            if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert") return;
            if (Items[i].Quality >= 50) return;

            int increment = 1;

            if (Items[i].SellIn < 11 && Items[i].Quality + increment < 50)
            {
                increment++;
            }

            if (Items[i].SellIn < 6 && Items[i].Quality + increment < 50)
            {
                increment++;
            }


            Items[i].Quality += increment;
        }

        private void AgedBrie(Item item)
        {
            if (item.Name != "Aged Brie") return;
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
