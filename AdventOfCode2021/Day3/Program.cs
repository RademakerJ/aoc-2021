namespace Day3
{
    public partial class Program
    {
        public static void Main(string[] _)
        {
            var bitsMatrix = ReadInput();

            Console.WriteLine($"Solution to problem A: {SolveProblemA(bitsMatrix)}");     // 3009600
            Console.WriteLine($"Solution to problem B: {SolveProblemB(bitsMatrix)}");     // 6940518
        }

        /// <summary>
        /// Power consumption.
        /// </summary>
        private static int SolveProblemA(IReadOnlyList<IReadOnlyList<int>> matrix)
        {
            var gammaBits = new List<int>();

            for (int i = 0; i < matrix[0].Count; i++)
            {
                var column = matrix.Select(row => row[i]).ToList();

                gammaBits.Add(GetMostCommonBit(column, tieBreakerBit: 1));
            }

            var gamma = GetBitSequence(gammaBits);
            var epsilon = GetBitSequence(gammaBits.Select(bit => bit == 1 ? 0 : 1).ToList());

            return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
        }

        /// <summary>
        /// Life support rating.
        /// </summary>
        private static int SolveProblemB(IReadOnlyList<IReadOnlyList<int>> matrix)
        {
            var oxygenSequence = new string(
                 GetBitSequence(GetMostCommonBits(matrix, tieBreakerBit: 1, takeLeastCommonBit: false)));

            var scrubberSequence = new string(
                GetBitSequence(GetMostCommonBits(matrix, tieBreakerBit: 0, takeLeastCommonBit: true)));

            return Convert.ToInt32(oxygenSequence, 2) * Convert.ToInt32(scrubberSequence, 2);
        }

        private static IReadOnlyList<int> GetMostCommonBits(IReadOnlyList<IReadOnlyList<int>> matrix, int tieBreakerBit, bool takeLeastCommonBit)
        {
            var indicesToSkip = new List<int>();

            for (int i = 0; i < matrix[0].Count; i++)
            {
                var column = matrix.Where((_, i) => !indicesToSkip.Contains(i)).Select(row => row[i]).ToList();

                for (int j = 0; j < matrix.Count; j++)
                {
                    if (matrix[j][i] != GetMostCommonBit(column, tieBreakerBit, !takeLeastCommonBit))
                    {
                        indicesToSkip.Add(j);
                    }
                }
            }

            for (int k = 0; k < matrix.Count; k++)
            {
                if (!indicesToSkip.Contains(k))
                {
                    return matrix[k].ToList();
                }
            }

            // We are just going to assume that this is not going to happen :^).
            return Array.Empty<int>();
        }

        private static int GetMostCommonBit(IReadOnlyList<int> column, int tieBreakerBit, bool orderByDescending = false)
        {
            var bitCountGroupings = column.GroupBy(bit => bit);
            bitCountGroupings = orderByDescending ?
                bitCountGroupings.OrderByDescending(group => group.Count()) :
                bitCountGroupings.OrderBy(group => group.Count());

            return bitCountGroupings.Count() == 1 ? bitCountGroupings.First().Key :
                   bitCountGroupings.First().Count() == bitCountGroupings.ElementAt(1).Count() ? tieBreakerBit :
                   bitCountGroupings.First().Key;
        }

        private static string GetBitSequence(IReadOnlyList<int> mostCommonBits)
        {
            var bitSequenceX = new string(
                mostCommonBits
                    .Select(bit => bit.ToString())
                    .SelectMany(bit => bit)
                    .ToArray());

            return bitSequenceX;
        }
    }
}