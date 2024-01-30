using ElegantCode.Fundamental.Tests.Samples.Converter;

namespace ElegantCode.Fundamental.Tests
{
    public class GenericConverterShould
    {
        private readonly Func<ConvertFactResult, ConvertFactResult> action = x =>
        {
            { x.Label += "1"; }
            return x;
        };

        private readonly string label = "testt";

        public GenericConverterShould()
        {
            Converter = new ConverterExample();
            ConverterWithFactory = new ConverterFactoryExample();
        }

        public GenericConverter<ConvertFactModel, ConvertFactResult> Converter { get; set; }

        public GenericConverterWithFactory<ConvertFactModel, ConvertFactResult> ConverterWithFactory { get; set; }

        [Fact]
        public void TestToConvert()
        {
            int id = 25;
            var data = new ConvertFactModel() { Id = id, Label = label };

            var assert = Converter.Convert(data, action);

            assert.Should().BeEquivalentTo(new ConvertFactResult { Id = id, Label = label + "1" });
        }

        [Fact]
        public void TestToConverterFactoryAsConverterWithNullAfterConvert()
        {
            int id = 25;
            var data = new ConvertFactModel() { Id = id, Label = label };
            IGenericConverter<ConvertFactModel, ConvertFactResult> converter = new ConverterFactoryExample();
            var assert = converter.Convert(data);

            assert.Should().BeEquivalentTo(new ConvertFactResult() { Id = id, Label = label });
        }

        [Fact]
        public void TestToConvertFactoryWithNulValue()
        {
            ConvertFactModel data = null;
            var assert = ConverterWithFactory.Convert(data);
            assert.Should().BeNull();
        }

        [Fact]
        public void TestToConvertWithFactory()
        {
            Func<ConvertFactResult> factory = () => new ConvertFactResult() { Id = 42 };
            var data = new ConvertFactModel() { Id = 25, Label = label };

            var assert = ConverterWithFactory.Convert(data, factory, action);

            assert.Should().BeEquivalentTo(new ConvertFactResult { Id = 42, Label = label + "1" });
        }

        [Fact]
        public void TestToConvertWithFactoryAsNull()
        {
            int id = 25;
            var data = new ConvertFactModel() { Id = id, Label = label };

            var assert = ConverterWithFactory.Convert(data, null, action);

            Assert.Equal(id, assert.Id);
            Assert.Equal("testt1", assert.Label);
        }

        [Fact]
        public void TestToConvertWithFactoryOverrideConvert()
        {
            var data = new ConvertFactModel() { Id = 25, Label = label };

            var assert = ConverterWithFactory.Convert(data);

            assert.Should().BeEquivalentTo(new ConvertFactResult { Id = 25, Label = label });
        }

        [Fact]
        public void TestToConvertWithFactoryWithNullAfterConvert()
        {
            var data = new ConvertFactModel() { Id = 25, Label = label };

            var assert = ConverterWithFactory.Convert(data, null);

            assert.Should().BeEquivalentTo(new ConvertFactResult { Id = 25, Label = label });
        }

        [Fact]
        public void TestToConvertWithFactoryWithNullAfterConvertAndNullFactory()
        {
            var data = new ConvertFactModel() { Id = 25, Label = label };

            var assert = ConverterWithFactory.Convert(data, null, null);

            assert.Should().BeEquivalentTo(new ConvertFactResult { Id = 25, Label = label });
        }

        [Fact]
        public void TestToConvertWithNullAfterConvert()
        {
            int id = 25;
            var data = new ConvertFactModel() { Id = id, Label = label };

            var assert = Converter.Convert(data);

            assert.Should().BeEquivalentTo(new ConvertFactResult() { Id = id, Label = label });
        }

        [Fact]
        public void TestToConvertWithNulValue()
        {
            ConvertFactModel data = null;
            var assert = Converter.Convert(data);
            assert.Should().BeNull();
        }

        [Fact]
        public void ConvertExtensionForGenericConverterShould()
        {
            int id = 25;
            var data = new[] { new ConvertFactModel() { Id = id, Label = label } };

            var assert = Converter.Convert(data, action);

            assert.Should().BeEquivalentTo(new[] { new ConvertFactResult { Id = id, Label = label + "1" } });
        }

        [Fact]
        public void ConvertExtensionForGenericConverterWithFactoryShould()
        {
            Func<ConvertFactResult> factory = () => new ConvertFactResult() { Id = 42 };
            var data = new[] { new ConvertFactModel() { Id = 25, Label = label } };

            var assert = ConverterWithFactory.Convert(data, factory, action);

            assert.Should().BeEquivalentTo(new[] { new ConvertFactResult { Id = 42, Label = label + "1" } });
        }
    }
}