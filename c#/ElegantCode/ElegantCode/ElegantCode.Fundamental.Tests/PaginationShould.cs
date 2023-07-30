using ElegantCode.Fundamental.Core.Utils;
using FluentAssertions;
using System.Text.Json;

namespace ElegantCode.Fundamental.Tests;

public class PaginationShould
{
    private Guid CorrrelationToken = Guid.NewGuid();

    [Fact]
    public void ComputePageInt()
    {
        var assert = 9.ComputeNbOfPage(2);
        assert.Should().Be(5);
    }

    [Fact]
    public void ComputePageLong()
    {
        var assert = ((long)9).ComputeNbOfPage(2);
        assert.Should().Be(5);
    }

    [Fact]
    public void IPaginationWithOnePage()
    {
        var source = new List<int>() { };
        var assert = new PaginatedResponse<int>(CorrrelationToken, source, 0, 1, source.Count, "ok", true);
        assert.Datas.Should().HaveCount(0);
        assert.Datas.Should().BeEquivalentTo(source);
        assert.Pagination.PageSize.Should().Be(0);
        assert.Pagination.CurrentPage.Should().Be(1);
        assert.Pagination.Total.Should().Be(0);
        assert.Pagination.PageIndex.Should().Be(0);
        assert.Pagination.PageNumber.Should().Be(1);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IPaginationWith0PageShouldRiseException()
    {
        var source = new List<int>() { };
        Assert.Throws<ArgumentOutOfRangeException>(() => new PaginatedResponse<int>(CorrrelationToken, source, 0, 0, source.Count, "ok", true));
    }

    [Fact]
    public void ICollectionShouldBePaginated()
    {
        ICollection<int> source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 3, pageSize: 2);
        assert.Should().NotBeNull();
        assert.Datas.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 3, pageSize: 2);
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo(new[] { 5, 6 });
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IEnumerableShouldBePaginates()
    {
        IEnumerable<int> source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 3, pageSize: 2);
        assert.Should().NotBeNull();
        assert.Datas.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 3, pageSize: 2);
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo(new[] { 5, 6 });
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IEnumerableShouldBePaginatesAndConvert()
    {
        IEnumerable<int> source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, x => x.ToString(), pageNumber: 3, pageSize: 2);
        assert.Should().NotBeNull();
        assert.Datas.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, x => x.ToString(), pageNumber: 3, pageSize: 2);
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo("5", "6");
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IEnumerableWithConvertAndPaginationRequestShouldBePaginates()
    {
        IEnumerable<int> source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, x => x.ToString(), new PaginationRequest(3, 2));
        assert.Should().NotBeNull();
        assert.Datas.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, x => x.ToString(), new PaginationRequest(3, 2));
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo("5", "6");
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IEnumerableWithPaginationRequestShouldBePaginates()
    {
        IEnumerable<int> source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, new PaginationRequest(3, 2));
        assert.Should().NotBeNull();
        assert.Datas.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, new PaginationRequest(3, 2));
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo(new[] { 5, 6 });
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IListShouldBePaginatedAndConvert()
    {
        IList<int> source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, x => x.ToString(), pageNumber: 3, pageSize: 2);
        assert.Should().NotBeNull();
        assert.Datas.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, x => x.ToString(), pageNumber: 3, pageSize: 2);
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo("5", "6");
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IListShouldBePaginated()
    {
        IList<int> source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 3, pageSize: 2);
        assert.Should().NotBeNull();
        assert.Datas.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 3, pageSize: 2);
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo(new[] { 5, 6 });
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IListWthConvertAndPaginationRequestShouldBePaginated()
    {
        IList<int> source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, x => x.ToString(), new PaginationRequest(3, 2));
        assert.Should().NotBeNull();
        assert.CorrelationToken.Should().Be(CorrrelationToken);
        assert.Datas.Should().BeEmpty();

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, x => x.ToString(), new PaginationRequest(3, 2));
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo("5", "6");
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IPaginationResponseShouldBeConvert()
    {
        IPaginatedResponse<int> source = null;
        var assert = source.ToPaginationResponse(x => x.ToString());
        assert.Should().NotBeNull();
        assert.Datas.Should().BeEmpty();
        assert.CorrelationToken.Should().BeEmpty();

        source = new PaginatedResponse<int>(CorrrelationToken, new List<int>() { 5, 6 }, 6, 3, 2);
        assert = source.ToPaginationResponse(x => x.ToString());
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo("5", "6");
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IQueryableShouldBePaginatedAndConvert()
    {
        IQueryable<int> source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, x => x.ToString(), pageNumber: 3, pageSize: 2);
        assert.Should().NotBeNull();
        assert.Datas.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 }.AsQueryable();
        assert = source.ToPaginationResponse(CorrrelationToken, x => x.ToString(), pageNumber: 3, pageSize: 2);
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo("5", "6");
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IQueryableWithConvertAndPaginationRequestShouldBePaginated()
    {
        IQueryable<int> source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, x => x.ToString(), new PaginationRequest(3, 2));
        assert.Should().NotBeNull();
        assert.Datas.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 }.AsQueryable();
        assert = source.ToPaginationResponse(CorrrelationToken, x => x.ToString(), new PaginationRequest(3, 2));
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo("5", "6");
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void PaginationIsAny()
    {
        IPaginatedResponse<string> assert = null;
        assert.IsAny().Should().BeFalse();

        assert = new PaginatedResponse<string>();
        assert.IsAny().Should().BeFalse();

        assert = (new[] { "1", "2", "3" }).ToPaginationResponse(CorrrelationToken);
        assert.IsAny().Should().BeTrue();
        assert.IsAny(x => x == "1").Should().BeTrue();
        assert.IsAny(x => x == "42").Should().BeFalse();
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void PaginationRequestNonGeneric()
    {
        var assert = new PaginationRequest(5, 42);
        assert.PageNumber.Should().Be(5);
        assert.PageSize.Should().Be(42);

        assert = new PaginationRequest(0, -1);
        assert.PageNumber.Should().Be(1);
        assert.PageSize.Should().Be(0);

        assert = new PaginationRequest();
        assert.PageNumber.Should().Be(1);
        assert.PageSize.Should().Be(0);
        assert.Should().BeEquivalentTo(PaginationRequest.DefaultPage);

        assert = new PaginationRequest(1, 0);
        assert.PageNumber.Should().Be(1);
        assert.PageSize.Should().Be(0);

        assert = new PaginationRequest(2, 1);
        assert.PageNumber.Should().Be(2);
        assert.PageSize.Should().Be(1);

        assert = new PaginationRequest(0, -1);
        assert.PageNumber.Should().Be(1);
        assert.PageSize.Should().Be(0);
    }

    [Fact]
    public void PaginationResponseShouldBePaginated()
    {
        PaginatedResponse<int> source = null;
        var assert = source.ToPaginationResponse();
        assert.Should().NotBeNull();
        assert.Datas.Should().BeEmpty();
        assert.CorrelationToken.Should().BeEmpty();

        source = new PaginatedResponse<int>(CorrrelationToken, new List<int>() { 5, 6 }, 6, 3, 2);
        assert = source.ToPaginationResponse();
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo(new[] { 5, 6 });
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void PaginatedResponseShouldThrowException()
    {
        var assert = Assert.Throws<ArgumentOutOfRangeException>(() => new PaginatedResponse<string>(CorrrelationToken, 0, 0));
        assert.Message.Should().Be(new ArgumentOutOfRangeException("pageNumber", 0, PaginatedResponse<string>.PAGE_UNDER_1).Message);
    }

    [Fact]
    public void TakeFirstPage()
    {
        var source = new[] { 1, 2, 3, 4, 5, 6 };
        var assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 1, pageSize: 2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        assert.Should().NotBeNull();
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo(new[] { 1, 2 });
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(1);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.IsLast.Should().BeFalse();
        assert.Pagination.IsFirst.Should().BeTrue();
        assert.Pagination.HasNext.Should().BeTrue();
        assert.Pagination.HasPrevious.Should().BeFalse();
        assert.Pagination.PageIndex.Should().Be(0);
    }

    [Fact]
    public void TakeLastPage()
    {
        var source = new[] { 1, 2, 3, 4, 5, 6 };
        var assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 3, pageSize: 2);

        assert.CorrelationToken.Should().Be(CorrrelationToken);
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo(new[] { 5, 6 });
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.IsLast.Should().BeTrue();
        assert.Pagination.IsFirst.Should().BeFalse();
        assert.Pagination.HasNext.Should().BeFalse();
        assert.Pagination.HasPrevious.Should().BeTrue();
        assert.Pagination.PageIndex.Should().Be(2);
    }

    [Fact]
    public void TakeMiddlePage()
    {
        var source = new[] { 1, 2, 3, 4, 5, 6 };
        var assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 2, pageSize: 2);

        assert.CorrelationToken.Should().Be(CorrrelationToken);
        assert.Should().NotBeNull();
        assert.Datas.Should().HaveCount(2);
        assert.Datas.Should().BeEquivalentTo(new[] { 3, 4 });
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(2);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.IsLast.Should().BeFalse();
        assert.Pagination.IsFirst.Should().BeFalse();
        assert.Pagination.HasNext.Should().BeTrue();
        assert.Pagination.HasPrevious.Should().BeTrue();
        assert.Pagination.PageIndex.Should().Be(1);
    }

    [Fact]
    public void TakePageOfEmpty()
    {
        int[] source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 3, pageSize: 2);
        assert.Should().NotBeNull();
        assert.Datas.Should().BeEmpty();

        assert.CorrelationToken.Should().Be(CorrrelationToken);
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(1);
        assert.Pagination.Total.Should().Be(0);
        assert.Pagination.IsLast.Should().BeTrue();
        assert.Pagination.IsFirst.Should().BeTrue();
        assert.Pagination.HasNext.Should().BeFalse();
        assert.Pagination.HasPrevious.Should().BeFalse();
        assert.Pagination.PageIndex.Should().Be(0);
    }

    [Fact]
    public void TestGetPage()
    {
        var fact = new List<int> { 1, 2, 3, 4 };

        var assert = fact.GetPage(3, 1);
        assert.Should().HaveCount(1);
        assert.First().Should().Be(3);

        assert = fact.GetPage(1, 0);
        assert.Should().HaveCount(fact.Count);
        assert.First().Should().Be(fact[0]);

        assert = fact.GetPage(2, 2);
        assert.Should().HaveCount(2);
        assert.First().Should().Be(fact[2]);

        assert = fact.GetPage(0, 2);
        assert.Should().HaveCount(2);
        assert.First().Should().Be(fact[0]);
    }

    [Fact]
    public void PaginationResponseShouldCorrectlyJsonSerializingAndDeserializing()
    {
        var original = new PaginatedResponse<string>(CorrrelationToken, new[] { "tests" }, 2, 2, 1, "is a test", true); ;
        var json = JsonSerializer.Serialize(original);

        var assert = JsonSerializer.Deserialize<PaginatedResponse<string>>(json);
        assert.Should().BeEquivalentTo(original);

        original = new PaginatedResponse<string>(CorrrelationToken, new[] { "tests", "42" }, 2, 1, 2, "is a test", false); ;
        json = JsonSerializer.Serialize(original);

        assert = JsonSerializer.Deserialize<PaginatedResponse<string>>(json);
        assert.Should().BeEquivalentTo(original);
    }
}