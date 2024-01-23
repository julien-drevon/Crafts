namespace Kata
{
    public static class FizzBuzzUtils
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