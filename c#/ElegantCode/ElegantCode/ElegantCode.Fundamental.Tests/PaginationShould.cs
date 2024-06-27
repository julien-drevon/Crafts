using ElegantCode.Fundamental.Core.Entities;
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
        assert.Data.Should().HaveCount(0);
        assert.Data.Should().BeEquivalentTo(source);
        assert.Pagination.PageSize.Should().Be(0);
        assert.Pagination.CurrentPage.Should().Be(1);
        assert.Pagination.Total.Should().Be(0);
        assert.Pagination.PageIndex.Should().Be(0);
        assert.Pagination.PageNumber.Should().Be(1);
        assert.Message.Should().Be("ok");
        assert.IsOk.Should().BeTrue();
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
        assert.Data.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 3, pageSize: 2);
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo(new[] { 5, 6 });
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IEnumerableShouldBePaginated()
    {
        IEnumerable<int> source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 3, pageSize: 2);
        assert.Should().NotBeNull();
        assert.Data.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 3, pageSize: 2);
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo(new[] { 5, 6 });
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
        var assert = source.ToPaginationResponse(CorrrelationToken, convert: x => x.ToString(), pageNumber: 3, pageSize: 2);
        assert.Should().NotBeNull();
        assert.Data.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, convert: x => x.ToString(), pageNumber: 3, pageSize: 2);
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo("5", "6");
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IEnumerableWithConvertAndPaginationRequestShouldBePaginated()
    {
        IEnumerable<int> source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, convert: x => x.ToString(), new PaginationQuery(3, 2));
        assert.Should().NotBeNull();
        assert.Data.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, convert: x => x.ToString(), new PaginationQuery(3, 2));
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo("5", "6");
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void IEnumerableWithPaginationRequestShouldBePaginated()
    {
        IEnumerable<int> source = null;
        var assert = source.ToPaginationResponse(CorrrelationToken, new PaginationQuery(3, 2));
        assert.Should().NotBeNull();
        assert.Data.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, new PaginationQuery(3, 2));
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo(new[] { 5, 6 });
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
        var assert = source.ToPaginationResponse(CorrrelationToken, convert: x => x.ToString(), pageNumber: 3, pageSize: 2);
        assert.Should().NotBeNull();
        assert.Data.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, convert: x => x.ToString(), pageNumber: 3, pageSize: 2);
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo("5", "6");
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
        assert.Data.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 3, pageSize: 2);
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo(new[] { 5, 6 });
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
        var assert = source.ToPaginationResponse(CorrrelationToken, convert: x => x.ToString(), new PaginationQuery(3, 2));
        assert.Should().NotBeNull();
        assert.CorrelationToken.Should().Be(CorrrelationToken);
        assert.Data.Should().BeEmpty();

        source = new List<int>() { 1, 2, 3, 4, 5, 6 };
        assert = source.ToPaginationResponse(CorrrelationToken, convert: x => x.ToString(), new PaginationQuery(3, 2));
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo("5", "6");
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
        assert.Data.Should().BeEmpty();
        assert.CorrelationToken.Should().BeEmpty();

        source = new PaginatedResponse<int>(CorrrelationToken, new List<int>() { 5, 6 }, 6, 3, 2);
        assert = source.ToPaginationResponse(x => x.ToString());
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo("5", "6");
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
        var assert = source.ToPaginationResponse(CorrrelationToken, convert: x => x.ToString(), pageNumber: 3, pageSize: 2);
        assert.Should().NotBeNull();
        assert.Data.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 }.AsQueryable();
        assert = source.ToPaginationResponse(CorrrelationToken, convert: x => x.ToString(), pageNumber: 3, pageSize: 2);
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo("5", "6");
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
        var assert = source.ToPaginationResponse(CorrrelationToken, convert: x => x.ToString(), pagination: new PaginationQuery(3, 2));
        assert.Should().NotBeNull();
        assert.Data.Should().BeEmpty();
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        source = new List<int>() { 1, 2, 3, 4, 5, 6 }.AsQueryable();
        assert = source.ToPaginationResponse(CorrrelationToken, convert: x => x.ToString(), pagination: new PaginationQuery(3, 2));
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo("5", "6");
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
        assert.IsNotAny().Should().BeTrue();

        assert = new PaginatedResponse<string>();
        assert.IsOk.Should().BeFalse();
        assert.IsNotAny().Should().BeTrue();

        assert = (new[] { "1", "2", "3" }).ToPaginationResponse(CorrrelationToken);
        assert.IsNotAny().Should().BeFalse();
        assert.IsNotAny(x => x == "1").Should().BeFalse();
        assert.IsNotAny(x => x == "42").Should().BeTrue();
        assert.CorrelationToken.Should().Be(CorrrelationToken);
    }

    [Fact]
    public void PaginationIsNotAny()
    {
        IPaginatedResponse<string> assert = null;
        assert.IsAny().Should().BeFalse();

        assert = new PaginatedResponse<string>();
        assert.IsOk.Should().BeFalse();
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
        var assert = new PaginationQuery(5, 42);
        assert.PageNumber.Should().Be(5);
        assert.PageSize.Should().Be(42);

        assert = new PaginationQuery(0, -1);
        assert.PageNumber.Should().Be(1);
        assert.PageSize.Should().Be(0);

        assert = new PaginationQuery();
        assert.PageNumber.Should().Be(1);
        assert.PageSize.Should().Be(0);
        assert.Should().BeEquivalentTo(PaginationQuery.DefaultPage);

        assert = new PaginationQuery(0, 1);
        assert.PageNumber.Should().Be(1);
        assert.PageSize.Should().Be(1); ;

        assert = new PaginationQuery(1, 0);
        assert.PageNumber.Should().Be(1);
        assert.PageSize.Should().Be(0);

        assert = new PaginationQuery(2, 1);
        assert.PageNumber.Should().Be(2);
        assert.PageSize.Should().Be(1);

        assert = new PaginationQuery(0, -1);
        assert.PageNumber.Should().Be(1);
        assert.PageSize.Should().Be(0);
    }

    [Fact]
    public void PaginationResponseShouldBePaginated()
    {
        PaginatedResponse<int> source = null;

        var assert = source.ToPaginationResponse();
        assert.Should().NotBeNull();
        assert.Data.Should().BeEmpty();
        assert.CorrelationToken.Should().BeEmpty();

        /*******************************************/
        source = new PaginatedResponse<int>(CorrrelationToken, new List<int>() { 5, 6 }, 6, 3, 2);

        assert = source.ToPaginationResponse();
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo(new[] { 5, 6 });
        assert.Pagination.PageSize.Should().Be(2);
        assert.Pagination.CurrentPage.Should().Be(3);
        assert.Pagination.Total.Should().Be(6);
        assert.Pagination.PageIndex.Should().Be(2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        /********************************************/

        var nullSource = new DummyPaginationImplementsWithNullSource<int>();
        assert = nullSource.ToPaginationResponse();
        assert.Data.Should().HaveCount(0);
        assert.Data.Should().BeEmpty();
    }

    [Fact]
    public void PaginatedResponseShouldThrowException()
    {
        var assert = Assert.Throws<ArgumentOutOfRangeException>(() => new PaginatedResponse<string>(CorrrelationToken, 0, 0));
        assert.Message.Should().Be(new ArgumentOutOfRangeException("pageNumber", 0, PaginatedResponse<string>.PAGE_UNDER_1_ERROR).Message);
    }

    [Fact]
    public void TakeFirstPage()
    {
        var source = new[] { 1, 2, 3, 4, 5, 6 };
        var assert = source.ToPaginationResponse(CorrrelationToken, pageNumber: 1, pageSize: 2);
        assert.CorrelationToken.Should().Be(CorrrelationToken);

        assert.Should().NotBeNull();
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo(new[] { 1, 2 });
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
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo(new[] { 5, 6 });
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
        assert.Data.Should().HaveCount(2);
        assert.Data.Should().BeEquivalentTo(new[] { 3, 4 });
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
        assert.Data.Should().BeEmpty();

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

        var assert = fact.GetPage(pageIndex: 3, pageSize: 1);
        assert.Should().HaveCount(1);
        assert.First().Should().Be(3);

        assert = fact.GetPage(pageIndex: 1, pageSize: 0);
        assert.Should().HaveCount(fact.Count);
        assert.First().Should().Be(fact[0]);

        assert = fact.GetPage(pageIndex: 2, pageSize: 2);
        assert.Should().HaveCount(2);
        assert.First().Should().Be(fact[2]);

        assert = fact.GetPage(pageIndex: 0, pageSize: 2);
        assert.Should().HaveCount(2);
        assert.First().Should().Be(fact[0]);
    }

    [Fact]
    public void PaginationResponseShouldCorrectlyJsonSerializingAndDeserializing()
    {
        var original = new PaginatedResponse<string>(CorrrelationToken, new[] { "tests" }, 2, 2, 1, "is a test", true); ;
        var json = JsonSerializer.Serialize(original);
        json.Should().Be(GetPaginationSerializationStringFirstAssert());
        var assert = JsonSerializer.Deserialize<PaginatedResponse<string>>(json);
        assert.Should().BeEquivalentTo(original);

        original = new PaginatedResponse<string>(CorrrelationToken, new[] { "tests", "42" }, 2, 1, 2, "is a second test", false); ;
        json = JsonSerializer.Serialize(original);
        json.Should().Be(GetPaginationSerializationStringSecondAssert());
        assert = JsonSerializer.Deserialize<PaginatedResponse<string>>(json);
        assert.Should().BeEquivalentTo(original);
    }

    private string GetPaginationSerializationStringFirstAssert()
    {
        return $"{{\"Data\":[\"tests\"],\"pagination\":{{\"currentPage\":2,\"hasNext\":false,\"hasPrevious\":true,\"isFirst\":false,\"isLast\":true,\"pageIndex\":1,\"pageNumber\":2,\"pageSize\":1,\"total\":2}},\"CorrelationToken\":\"{CorrrelationToken}\",\"IsOk\":true,\"Message\":\"is a test\"}}";
    }

    private string GetPaginationSerializationStringSecondAssert()
    {
        return $"{{\"Data\":[\"tests\",\"42\"],\"pagination\":{{\"currentPage\":1,\"hasNext\":false,\"hasPrevious\":false,\"isFirst\":true,\"isLast\":true,\"pageIndex\":0,\"pageNumber\":1,\"pageSize\":2,\"total\":2}},\"CorrelationToken\":\"{CorrrelationToken}\",\"IsOk\":false,\"Message\":\"is a second test\"}}";
    }
}

public class DummyPaginationImplementsWithNullSource<T> : IPaginatedResponse<T>
{
    public IList<T> Data { get; set; } = null;

    public IPagination Pagination { get; } = new Pagination() { CurrentPage = 1, PageIndex = 0 };

    public bool IsOk { get; set; }

    public string Message { get; set; }

    public Guid CorrelationToken { get; }
}
