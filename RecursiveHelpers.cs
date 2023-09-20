namespace DataStructures
{
    public static class RecursiveHelpers
    {
        public static int Fibonacci(this int value)
        {
            if (value >= 3) return (value - 1).Fibonacci() + (value - 2).Fibonacci();

            return 1;
        }

        public static int Factorial(this int value)
        {
            if (value >= 1) return value * (value - 1).Factorial();

            return 1;
        }

        public static int Sum(this int n)
        {
            if (n == 0) return 0;

            return n + (n - 1).Sum();
        }
    }
}
