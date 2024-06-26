﻿namespace GildedRose.Core.Items;

public abstract class Item : IMUpgradableQualityItem
{
    private int _Quality;
    private int _SellIn;

    protected Item(string name, int sellIn, int quality)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }

    public virtual string Name { get; set; }

    public virtual int Quality
    {
        get => _Quality;

        set
        {
            if (value > -1)
            { _Quality = value; }
        }
    }

    public virtual int SellIn
    {
        get => _SellIn;

        set
        {
            if (value > -1)
            { _SellIn = value; }
        }
    }

    public override string ToString()
    {
        return $"nom: {Name}     sellIn:{SellIn}    Quality:{Quality}";
    }

    public abstract void UpdateQuality(UpdateQualityParameters qualityParameters);

    protected void DecreaseQuality()
    {
        Quality--;
    }

    protected void DecreaseSellin()
    {
        SellIn--;
    }

    protected void IncreaseQuality()
    {
        if (Quality < 50)
            Quality++;
    }
}