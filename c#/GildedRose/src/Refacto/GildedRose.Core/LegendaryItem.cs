namespace GildedRose.Core;

public class LegendaryItem : Item
{
    public LegendaryItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
    {
    }

    public override void UpdateQuality(UpdateQualityParameters qualityParameters)
    {
    }
}