namespace GildedRose.Core;

class Program
{
    IList<Item> Items;
    static void Main(string[] args)
    {
        System.Console.WriteLine("OMGHAI!");

        var app = new Program()
        {
            //Items = new List<Item>
            //                          {
            //                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            //                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            //                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            //                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            //                              new Item
            //                                  {
            //                                      Name = "Backstage passes to a TAFKAL80ETC concert",
            //                                      SellIn = 15,
            //                                      Quality = 20
            //                                  },
            //                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            //                          }

        };

        app.UpdateQuality();
        //new Item { Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19 },
        //                                  new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 },
        //                                  new Item { Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6 },
        //                                  new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
        //                                  new Item
        //                                  {
        //                                      Name = "Backstage passes to a TAFKAL80ETC concert",
        //                                      SellIn = 14,
        //                                      Quality = 21
        //                                  },
        //                                  new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = 5 }
        System.Console.ReadKey();

    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Items[i].Quality > 0)
                {
                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        Items[i].Quality = Items[i].Quality - 1;
                    }
                }
            }
            else
            {
                if (Items[i].Quality < 50)
                {
                    Items[i].Quality = Items[i].Quality + 1;

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].SellIn < 11)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }

                        if (Items[i].SellIn < 6)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                    }
                }
            }

            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != "Aged Brie")
                {
                    if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Quality > 0)
                        {
                            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }
                }
            }
        }
    }

}
