using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.UsesCases;
using FluentAssertions;
using System.Net.Http.Headers;

namespace Rpg.Core.Tests
{
    public class RpgEngine
    {
        [Fact]
        public void CreateWorld()
        {
            var me = new Sprite();
            var worldId = Guid.NewGuid();
            var world = new World(worldId);

            world.Id.Should().Be(worldId);
            world.Elements.Should().BeEmpty();

            world.AddElement(me);
            world.Elements.Should().HaveCount(1);
            world.Elements.First().Should().Be(me);

            me.X.Should().Be(0);
            me.Y.Should().Be(0);

            var secondWorld = new World(worldId, new[] { me });

            secondWorld.Elements.First().Should().Be(me);

        }

        [Fact]
        public void GivenAUser_IWantçCreateAWorld()
        {
            var worldDriver = new WorldDriver();
            var worldDriverRequest = new WorldDriverRequest(Guid.NewGuid());
            var expect = worldDriver.CreateWorld(worldDriverRequest);
            expect.Id.Should().Be(worldDriverRequest.Id);
        }
    }

    public class WorldDriverRequest : IValidateRequest<CreateWorldUseCaseQuery>
    {

        public WorldDriverRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; internal set; }

        public Guid CorrelationToken => throw new NotImplementedException();

        public (CreateWorldUseCaseQuery UseCaseQuery, Error Error) ValidateRequest()
        {
            throw new NotImplementedException();
        }
    }

    public class CreateWorldUseCaseQuery : IUSeCaseQuery
    {

        public Guid CorrelationToken { get; }
    }

    public class WorldDriver
    {
        public WorldDriver()
        {
        }

        public WorldResponse CreateWorld(WorldDriverRequest worldDriverRequest)
        {
            return new WorldResponse(worldDriverRequest.Id);
        }
    }

    public class WorldResponse
    {
        public WorldResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; internal set; }
    }

    public class World
    {
        private HashSet<Sprite> _Elements = new();

        public World(Guid guid)
        {
            this.Id = guid;
        }

        public World(Guid guid, IEnumerable<Sprite> sprites)
            : this(guid)
        {
            this._Elements = new HashSet<Sprite>(sprites);
        }

        public IEnumerable<Sprite> Elements { get => this._Elements; }
        public Guid Id { get; }

        public void AddElement(Sprite sprite)
        {
            _Elements.Add(sprite);
        }
    }

    public class Sprite
    {
        public int X { get; }
        public int Y { get; }
    }
}