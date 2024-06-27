namespace GildedRose.Core.Items
{
    public interface IMUpgradableQualityItem
    {
        string Name { get; }

        int Quality { get; }

        int SellIn { get; }

        void UpdateQuality(UpdateQualityParameters qualityParameters);
    }
}