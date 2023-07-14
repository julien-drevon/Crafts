using FluentAssertions;

namespace KataExemple
{
    public class FizzBuzzExempleShould
    {
        [Fact]
        public void WhenIGot1_FizzBuzzReturn1()
        {
            Utils.FizzBuzz(1).Should().Be("1");
        }

        [Fact]
        public void WhenIGot2_FizzBuzzReturn2()
        {
            Utils.FizzBuzz(2).Should().Be("2");
        }

        [Fact]
        public void WhenIGot3_FizzBuzzReturnFizz()
        {
            Utils.FizzBuzz(3).Should().Be("Fizz");
        }

        [Fact]
        public void WhenIGot6_FizzBuzzReturnFizz()
        {
            Utils.FizzBuzz(6).Should().Be("Fizz");
        }

        [Fact]
        public void WhenIGot5_FizzBuzzReturnBuzz()
        {
            Utils.FizzBuzz(5).Should().Be("Buzz");
        }

        [Fact]
        public void WhenIGot15_FizzBuzzReturnBuzz()
        {
            Utils.FizzBuzz(10).Should().Be("Buzz");
        }

        [Fact]
        public void WhenIGot15_FizzBuzzReturnFizzBuzz()
        {
            Utils.FizzBuzz(15).Should().Be("FizzBuzz");
        }

        [Fact]
        public void WhenIGot30_FizzBuzzReturnBuzz()
        {
            Utils.FizzBuzz(30).Should().Be("FizzBuzz");
        }
    }


    public static class Utils
    {

        public static string FizzBuzz(int value)
        {

            if (value % 15 == 0) return "FizzBuzz";
            if (value % 5 == 0) return "Buzz";
            if (value % 3 == 0) return "Fizz";

            return value.ToString();
        }
    }
}