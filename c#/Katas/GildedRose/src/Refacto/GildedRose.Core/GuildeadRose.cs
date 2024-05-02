using GildedRose.Core.Items;

namespace GildedRose.Core;

public class GuildeadRose
{
    private List<IUpdateQualityItem> _Items;
    private UpdateQualityParameters _QualityParameters ;

    public GuildeadRose(IEnumerable<IUpdateQualityItem> items, UpdateQualityParameters updataQualityParameters )
    {
        _Items = items?.ToList();
        _QualityParameters = updataQualityParameters;

    }

    public IEnumerable<IUpdateQualityItem> Items { get => _Items; }

    public void AddItem(IUpdateQualityItem item)
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