using GildedRose.Core.Items;

namespace GildedRose.Core;

public class GuildeadRose
{
    private List<IMUpgradableQualityItem> _Items;
    private UpdateQualityParameters _QualityParameters ;

    public GuildeadRose(IEnumerable<IMUpgradableQualityItem> items, UpdateQualityParameters updataQualityParameters )
    {
        _Items =items is null ? new() : items?.ToList();
        _QualityParameters = updataQualityParameters;

    }

    public void Consult(Action<IEnumerable<IMUpgradableQualityItem>> howISee)
    {
        howISee(_Items.AsEnumerable());
    }

    public void AddItem(IMUpgradableQualityItem item)
    {
        _Items.Add(item);
    }

    public void UpdateQuality()
    {
        foreach (var item in _Items)
        {
            item.UpdateQuality(_QualityParameters);
        }
    }
}