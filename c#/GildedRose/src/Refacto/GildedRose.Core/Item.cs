namespace GildedRose.Core;

public abstract class Item : IUpdateQualityItem
{
    private int sellIn;
    private int quality;

    protected Item(string name, int sellIn, int quantity)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quantity;
    }

    public virtual string Name { get; set; }

    public virtual int SellIn
    {
        get => sellIn;
        set
        {
            if (value > -1)
            { sellIn = value; }
        }
    }

    public virtual int Quality
    {
        get => quality; set
        {
            if (value > -1)
            { quality = value; }
        }
    }

    public abstract void UpdateQuality(UpdateQualityParameters qualityParameters);

    protected void IncreaseQuality()
    {
        if (Quality < 50)
            Quality++;
    }
    protected void DecreaseQuality()
    {
        Quality--;
    }

    protected int DecreaseSellin()
    {
        return SellIn--;
    }
}
