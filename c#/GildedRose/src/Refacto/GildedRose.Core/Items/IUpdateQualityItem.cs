namespace GildedRose.Core.Items
{
    public interface IUpdateQualityItem
    {
        string Name { get; set; }

        int Quality { get; set; }

        int SellIn { get; set; }

        void UpdateQuality(UpdateQualityParameters qualityParameters);
    }
}