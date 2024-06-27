// See https://aka.ms/new-console-template for more information
using GildedRose.Core;
using GildedRose.Core.Items;
using System.Linq;

Console.WriteLine("OMGHAI!");

var app = new Program();

var itemems = new[]
{
    CreateItemFactory.Create(ItemsName.Plus5DexterityVest, sellIn: 10, quality: 20),
    CreateItemFactory.Create(ItemsName.AgedBrie, sellIn: 2, quality: 0),
    CreateItemFactory.Create(ItemsName.ElixirOfMangoust, sellIn: 5, quality: 7),
    CreateItemFactory.Create(ItemsName.Sulfuras, sellIn: 0, quality: 80),
    CreateItemFactory.Create(ItemsName.BackstagePassesTAFKAL80ETCConcert, sellIn: 15, quality: 20),
    CreateItemFactory.Create(ItemsName.ConjuredManaCake, sellIn: 3, quality: 6),
};

var guildedRose = new GuildeadRose(itemems, new UpdateQualityParameters());

Console.WriteLine();
Console.WriteLine("liste des objet en guilde");
Console.WriteLine();
guildedRose.Consult(x => DisplayListItems(x));
Console.WriteLine();
Console.WriteLine("************************************");
Console.WriteLine("update Quality");
guildedRose.UpdateQuality();

Console.WriteLine("************************************");
Console.WriteLine();
Console.WriteLine("Liste apres update");
Console.WriteLine();
guildedRose.Consult(x => DisplayListItems(x));

System.Console.ReadKey();

static void DisplayListItems(IEnumerable<IMUpgradableQualityItem> items)
{
    foreach (var item in items) { Console.WriteLine(item); }
}