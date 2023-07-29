namespace GildedRose.Core;

public abstract class Item : IUpdateQualityItem
{
    private int _SellIn;
    private int _Quality;

    protected Item(string name, int sellIn, int quality)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }

    public virtual string Name { get; set; }

    public virtual int SellIn
    {
        get => _SellIn;

        set
        {
            if (value > -1)
            { _SellIn = value; }
        }
    }

    public virtual int Quality
    {
        get => _Quality; set

        {
            if (value > -1)
            { _Quality = value; }
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