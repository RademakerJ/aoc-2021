namespace Day7
{
    public partial class Program
    {
        public static void Main(string[] _)
        {
            var horizontalPositions = ReadInput().OrderBy(position => position).ToList();

            Console.WriteLine($"Solution to problem A: {SolveProblemA(horizontalPositions)}");     // 344605
            Console.WriteLine($"Solution to problem B: {SolveProblemB(horizontalPositions)}");     // 93699985
        }

        private static int SolveProblemA(IReadOnlyList<int> horizontalPositions)
        {
            var median = horizontalPositions.Count % 2 == 0 ?
                horizontalPositions[horizontalPositions.Count / 2] :
                horizontalPositions[(int)Math.Ceiling((double)horizontalPositions.Count / 2)];

            return horizontalPositions.Sum(position => Math.Abs(median - position));
        }

        private static int SolveProblemB(IReadOnlyList<int> horizontalPositions)
        {
            var average = (int)horizontalPositions.Average();

            return horizontalPositions
                .Sum(position => GetGaussSummation(Math.Abs(average - position)));
        }

        private static int GetGaussSummation(int number)
        {
            return number * (number + 1) / 2;
        }
    }
}