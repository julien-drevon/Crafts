namespace GildedRose.Core;

public class AgedBrie : Item
{
    public AgedBrie(string name, int sellIn, int quantity) : base(name, sellIn, quantity)
    {
    }

    public override void UpdateQuality(UpdateQualityParameters qualityParameters)
    {
        DecreaseSellin();
        IncreaseQuality();
    }


}
