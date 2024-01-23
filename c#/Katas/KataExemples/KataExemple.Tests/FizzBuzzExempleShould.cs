using FluentAssertions;
using Kata;

namespace KataExemple
{
    public class FizzBuzzExempleShould
    {
        [Fact]
        public void WhenIGot1_FizzBuzzReturn1()
        {
            FizzBuzzUtils.FizzBuzz(1).Should().Be("1");
        }

        [Fact]
        public void WhenIGot2_FizzBuzzReturn2()
        {
            FizzBuzzUtils.FizzBuzz(2).Should().Be("2");
        }

        [Fact]
        public void WhenIGot3_FizzBuzzReturnFizz()
        {
            FizzBuzzUtils.FizzBuzz(3).Should().Be("Fizz");
        }

        [Fact]
        public void WhenIGot6_FizzBuzzReturnFizz()
        {
            FizzBuzzUtils.FizzBuzz(6).Should().Be("Fizz");
        }

        [Fact]
        public void WhenIGot5_FizzBuzzReturnBuzz()
        {
            FizzBuzzUtils.FizzBuzz(5).Should().Be("Buzz");
        }

        [Fact]
        public void WhenIGot15_FizzBuzzReturnBuzz()
        {
            FizzBuzzUtils.FizzBuzz(10).Should().Be("Buzz");
        }

        [Fact]
        public void WhenIGot15_FizzBuzzReturnFizzBuzz()
        {
            FizzBuzzUtils.FizzBuzz(15).Should().Be("FizzBuzz");
        }

        [Fact]
        public void WhenIGot30_FizzBuzzReturnBuzz()
        {
            FizzBuzzUtils.FizzBuzz(30).Should().Be("FizzBuzz");
        }
    }
}