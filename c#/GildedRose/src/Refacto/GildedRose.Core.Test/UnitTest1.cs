using FluentAssertions;

namespace GildedRose.Core.Test;

public class UnitTest1
{
    [Fact]
    public void GivenAPlayer_WhenIPlacedASulfuras_ThenShouldNoChange()
    {
        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.Sulfuras, 0, 80) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new LegendaryItem(name: "Sulfuras, Hand of Ragnaros", sellIn: 0, quality: 80) });
    }

    [Fact]
    public void GivenAPlayer_WhenIPlaceHelmetVest_Shouldloose1PointQuanlitySelling()
    {

        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.Plus5DexterityVest, 10, 20) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ClassicItem(name: "+5 Dexterity Vest", sellIn: 9, quality: 19) });
    }

    [Fact]
    public void GivenAPlayer_WhenIPlaceAgedBrie_Shouldloose1PointSellingIncrease1PointQuyality()
    {

        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.AgedBrie, 2, 0) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ClassicItem(name: "Aged Brie", sellIn: 1, quality: 1) });
    }
    [Fact]
    public void GivenAPlayer_WhenIPlaceAgedBrie_ShouldTheirQualityNeverExceed50()
    {

        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.AgedBrie, 2, 50) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ClassicItem(name: "Aged Brie", sellIn: 1, quality: 50) });
    }
    [Fact]
    public void GivenAPlayer_WhenIPlaceObjectAt0_ShouldNeverDecreaseUnder0()
    {

        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.Plus5DexterityVest, 0, 0) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ClassicItem(name: "+5 Dexterity Vest", sellIn: 0, quality: 0) });
    }

    private Item CreateItem(ItemsName itemsName, int sellin, int quality)
    {
        return CreateItemFactory.Create(itemsName, sellin, quality);
    }
}

public class GuildeadRose
{
    private List<Item> _Items;
    UpdateQualityParameters _QualityParameters;
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

