namespace GildedRose.Core;

public class CreateItemFactory
{
    public static Item Create(ItemsName itemName, int sellIn, int quantity)
    {
        return itemName switch
        {
            ItemsName.Plus5DexterityVest => new ClassicItem(name: "+5 Dexterity Vest", sellIn, quantity),
            ItemsName.Sulfuras => new LegendaryItem(name: "Sulfuras, Hand of Ragnaros", sellIn, quantity),
            ItemsName.AgedBrie => new QualityIncreaseItem(name: "Aged Brie", sellIn, quantity),
            ItemsName.BackstagePassesTAFKAL80ETCConcert => new QualityIncreaseItem(name: "Backstage passes to a TAFKAL80ETC concert", sellIn, quantity, true),
            ItemsName.ElixirOfMangoust => new ClassicItem(name:    "Elixir of the Mongoose", sellIn, quantity),
            ItemsName.ConjuredManaCake => new ClassicItem(name: "Conjured Mana Cake", sellIn, quantity),

            _ => throw new Exception(),
        }; ; ;
    }
}