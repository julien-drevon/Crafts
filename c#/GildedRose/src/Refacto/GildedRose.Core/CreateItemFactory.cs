using GildedRose.Core.Items;

namespace GildedRose.Core;

public class CreateItemFactory
{
    public static Item Create(ItemsName itemName, int sellIn, int quality)
    {
        return itemName switch
        {
            ItemsName.Plus5DexterityVest => new ClassicItem(name: "+5 Dexterity Vest", sellIn, quality),
            ItemsName.Sulfuras => new LegendaryItem(name: "Sulfuras, Hand of Ragnaros", sellIn, quality),
            ItemsName.AgedBrie => new QualityIncreaseItem(name: "Aged Brie", sellIn, quality),
            ItemsName.BackstagePassesTAFKAL80ETCConcert => new QualityIncreaseItem(name: "Backstage passes to a TAFKAL80ETC concert", sellIn, quality, true),
            ItemsName.ElixirOfMangoust => new ClassicItem(name: "Elixir of the Mongoose", sellIn, quality),
            ItemsName.ConjuredManaCake => new ClassicItem(name: "Conjured Mana Cake", sellIn, quality),

            _ => throw new Exception(),
        }; ; ;
    }
}