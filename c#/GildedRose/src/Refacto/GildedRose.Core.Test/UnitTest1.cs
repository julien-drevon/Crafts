using FluentAssertions;
using GildedRose.Core.Items;

namespace GildedRose.Core.Test;

public class UnitTest1
{
    [Fact]
    public void GivenAPlayer_WhenIPlacedASulfuras_ThenShouldNoChange()
    {
        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.Sulfuras, 0, 80) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ItemToCompare(name: "Sulfuras, Hand of Ragnaros", sellIn: 0, quality: 80) });
    }

    [Fact]
    public void GivenAPlayer_WhenIPlaceHelmetVest_Shouldloose1PointQuanlitySelling()
    {
        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.Plus5DexterityVest, 10, 20) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ItemToCompare(name: "+5 Dexterity Vest", sellIn: 9, quality: 19) });
    }

    [Fact]
    public void GivenAPlayer_WhenIPlaceAgedBrie_Shouldloose1PointSellingIncrease1PointQuyality()
    {
        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.AgedBrie, 2, 0) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ItemToCompare(name: "Aged Brie", sellIn: 1, quality: 1) });
    }

    [Fact]
    public void GivenAPlayer_WhenIPlaceAgedBrie_ShouldTheirQualityNeverExceed50()
    {
        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.AgedBrie, 2, 50) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ItemToCompare(name: "Aged Brie", sellIn: 1, quality: 50) });
    }

    [Fact]
    public void GivenAPlayer_WhenIPlaceObjectAt0_ShouldNeverDecreaseUnder0()
    {
        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.Plus5DexterityVest, 0, 0) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ItemToCompare(name: "+5 Dexterity Vest", sellIn: 0, quality: 0) });
    }

    [Fact]
    public void GivenAPlayer_WhenIPlaceConcerTicket_ShouldBeTakeQualityWhileIsNotUnder10ToSellin()
    {
        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.BackstagePassesTAFKAL80ETCConcert, 14, 1) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ItemToCompare(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 13, quality: 2) });
    }

    [Fact]
    public void GivenAPlayer_WhenIPlaceConcerTicket_ShouldBeTake2MoreQualityWhileIsUnder11ButUpper6DayToSellin()
    {
        var guildedRose = new GuildeadRose();
        guildedRose.AddItem(CreateItem(ItemsName.BackstagePassesTAFKAL80ETCConcert, 10, 1));
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ItemToCompare(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 9, quality: 3) });
    }

    [Fact]
    public void GivenAPlayer_WhenIPlaceConcerTicket_ShouldBeTake3MoreQualityWhileIsUnder6DayToSellin()
    {
        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.BackstagePassesTAFKAL80ETCConcert, 5, 1) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ItemToCompare(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 4, quality: 4) });
    }

    [Fact]
    public void GivenAPlayer_WhenIPlaceConcerTicket_ShouldBeHaveQualityAt0WhenSellinIs0()
    {
        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.BackstagePassesTAFKAL80ETCConcert, 0, 1) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ItemToCompare(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 0, quality: 0) });
    }

    [Fact]
    public void GivenAPlayer_WhenIPlaceAgedBrie_ShouldBeHaveQualityIncreaseSellinIs0()
    {
        var guildedRose = new GuildeadRose(new[] { CreateItem(ItemsName.AgedBrie, 0, 1) });
        guildedRose.UpdateQuality();

        guildedRose.Items.Should().BeEquivalentTo(new[] { new ItemToCompare(name: "Aged Brie", sellIn: 0, quality: 2) });
    }

    private Item CreateItem(ItemsName itemsName, int sellin, int quality)
    {
        return CreateItemFactory.Create(itemsName, sellin, quality);
    }
}

internal class ItemToCompare : Item
{
    public ItemToCompare(string name, int sellIn, int quality) : base(name, sellIn, quality)
    {
    }

    public override void UpdateQuality(UpdateQualityParameters qualityParameters)
    {
        throw new NotImplementedException();
    }
}