// See https://aka.ms/new-console-template for more information
using GildedRose.Core;
using GildedRose.Core.Items;

Console.WriteLine("OMGHAI!");

var app = new Program();

var itemems = new[]
{
            CreateItemFactory.Create(ItemsName.Plus5DexterityVest, 10, 20),
            CreateItemFactory.Create(ItemsName.AgedBrie, 2, 0),
            CreateItemFactory.Create(ItemsName.ElixirOfMangoust, 5, 7),
            CreateItemFactory.Create(ItemsName.Sulfuras, 0, 80),
            CreateItemFactory.Create(ItemsName.BackstagePassesTAFKAL80ETCConcert, 15, 20),
            CreateItemFactory.Create(ItemsName.ConjuredManaCake, 3, 6),
        };

var guildedRose = new GuildeadRose(itemems);

guildedRose.UpdateQuality();

System.Console.ReadKey();