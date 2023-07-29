namespace GildedRose.Core;

public class GuildeadRose
{
    private List<Item> _Items;
    private UpdateQualityParameters _QualityParameters;

    public GuildeadRose(IEnumerable<Item> items)
    {
        _Items = items.ToList();
    }

    public IEnumerable<Item> Items { get => _Items; }

    internal void AddItem(Item item)
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