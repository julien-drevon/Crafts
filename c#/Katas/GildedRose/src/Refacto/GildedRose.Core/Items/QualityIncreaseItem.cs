namespace GildedRose.Core.Items;

public class QualityIncreaseItem : Item
{
    public QualityIncreaseItem(string name, int sellIn, int quantity, bool isApprocheSellinItem = false)
        : base(name, sellIn, quantity)
    {
        IsApprocheIncreaseSelling = isApprocheSellinItem;
    }

    public bool IsApprocheIncreaseSelling { get; }

    public override void UpdateQuality(UpdateQualityParameters qualityParameters)
    {
        if (IsApprocheIncreaseSelling && SellIn == 0)
        {
            Quality = 0;
            return;
        }

        ClassicQualityChange();
        ApproachQualityItemChange();
    }

    private void ApproachQualityItemChange()
    {
        if (IsApprocheIncreaseSelling && SellIn < 11)
        {
            IncreaseQuality();
        }
        if (IsApprocheIncreaseSelling && SellIn < 6)
        {
            IncreaseQuality();
        }
    }

    private void ClassicQualityChange()
    {
        DecreaseSellin();
        IncreaseQuality();
    }
}