namespace GildedRose.Core;

public class ClassicItem : Item
{
    public ClassicItem(string name, int sellIn, int quality)
        : base(name, sellIn, quality)
    {
    }

    public override void UpdateQuality(UpdateQualityParameters qualityParameters)
    {
        DecreaseQuality();
        DecreaseSellin();
    }
}