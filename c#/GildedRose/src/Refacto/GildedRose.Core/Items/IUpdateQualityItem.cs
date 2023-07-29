namespace GildedRose.Core.Items
{
    public interface IUpdateQualityItem
    {
        string Name { get; }

        int Quality { get; }

        int SellIn { get; }
        void UpdateQuality(UpdateQualityParameters qualityParameters);
    }
}