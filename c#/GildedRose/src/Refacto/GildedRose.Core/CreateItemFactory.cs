namespace GildedRose.Core;

public class CreateItemFactory
{
    public static Item Create(ItemsName itemName, int sellIn, int quantity)
    {
        return itemName switch
        {
            ItemsName.Plus5DexterityVest => new ClassicItem(name: "+5 Dexterity Vest", sellIn, quantity),
            ItemsName.Sulfuras => new LegendaryItem(name: "Sulfuras, Hand of Ragnaros", sellIn, quantity),
            ItemsName.AgedBrie => new AgedBrie(name: "Aged Brie", sellIn, quantity),
            _ => throw new Exception()
        };
    }
}
