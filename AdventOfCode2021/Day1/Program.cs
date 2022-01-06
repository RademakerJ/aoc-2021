namespace Day1
{
    public partial class Program
    {
        public static void Main(string[] _)
        {
            var depths = ReadInput();

            Console.WriteLine($"Solution to problem A: {GetAmountIncreases(depths, 1)}");   // 1581
            Console.WriteLine($"Solution to problem B: {GetAmountIncreases(depths, 3)}");   // 1618
        }

        private static int GetAmountIncreases(IReadOnlyList<int> depths, int windowSize)
        {
            var amountIncreases = 0;
            var previous = depths.Take(windowSize).Sum();

            for (int i = 0; i < depths.Count; i++)
            {
                var depthWindow = depths.Skip(i).Take(windowSize);

                if (depthWindow.LongCount() < windowSize)
                {
                    break;
                }

                var depthSum = depthWindow.Sum();

                if (depthSum > previous)
                {
                    amountIncreases++;
                }

                previous = depthSum;
            }

            return amountIncreases;
        }
    }
}



