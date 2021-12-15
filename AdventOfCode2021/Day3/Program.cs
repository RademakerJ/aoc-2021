namespace Day3
{
    public partial class Program
    {
        private static partial IReadOnlyList<string> ReadInput();

        public static void Main(string[] _)
        {
            var bits = ReadInput();

            Console.WriteLine($"Solution to problem A: {SolveProblemA(bits)}");     // 3009600
            Console.WriteLine($"Solution to problem B: {SolveProblemB(bits)}");     // 6940518
        }

        private static int SolveProblemA(IReadOnlyList<string> bits)
        {
            var matrix = GetMatrix(bits);

            var (gammaRate, epsilonRate) = GetGammaAndEpsilonRate(matrix);

            return gammaRate * epsilonRate;
        }

        private static int SolveProblemB(IReadOnlyList<string> bits)
        {
            var matrix = GetMatrix(bits);

            var (oxygenRate, scrubberRate) = GetOxygenScrubberRate(matrix);

            return oxygenRate * scrubberRate;
        }

        private static (int oxygenRate, int scrubberRate) GetOxygenScrubberRate(IReadOnlyList<IReadOnlyList<int>> matrix)
        {
            var oxygenSequence = GetBitSequence(matrix, 1, false);
            var scrubberSequence = GetBitSequence(matrix, 0, true);

            var oxygenSequenceStr = new string(oxygenSequence.Select(bit => bit.ToString()).SelectMany(bit => bit).ToArray());
            var scrubberSequenceStr = new string(scrubberSequence.Select(bit => bit.ToString()).SelectMany(bit => bit).ToArray());

            var oxygenRate = Convert.ToInt32(oxygenSequenceStr, 2);
            var scrubberRate = Convert.ToInt32(scrubberSequenceStr, 2);

            return (oxygenRate, scrubberRate);
        }

        private static IReadOnlyList<int> GetBitSequence(IReadOnlyList<IReadOnlyList<int>> matrix, int mostCommonBitChoice, bool leastCommon)
        {
            var matrixIndexToSkip = new List<int>();

            for (int i = 0; i < matrix[0].Count; i++)
            {
                var column = matrix.Where((r, i) => !matrixIndexToSkip.Contains(i)).Select(row => row[i]);

                var bitGrouping = column.GroupBy(bit => bit);
                bitGrouping = leastCommon ? bitGrouping.OrderBy(group => group.Count()) : bitGrouping.OrderByDescending(group => group.Count());

                var mostCommonBit = bitGrouping.Count() == 1 ? bitGrouping.First().Key :
                    bitGrouping.First().Count() == bitGrouping.ElementAt(1).Count() ? mostCommonBitChoice :
                    bitGrouping.First().Key;

                for (int j = 0; j < matrix.Count; j++)
                {
                    if (matrix[j][i] != mostCommonBit)
                    {
                        matrixIndexToSkip.Add(j);
                    }
                }
            }

            var bitsToSequence = new List<int>();
            for (int j = 0; j < matrix.Count; j++)
            {
                if (!matrixIndexToSkip.Contains(j))
                {
                    bitsToSequence = matrix[j].ToList();
                    break;
                }
            }

            return bitsToSequence;
        }

        private static (int gammaRate, int epsilonRate) GetGammaAndEpsilonRate(IReadOnlyList<IReadOnlyList<int>> matrix)
        {
            var bits = new List<int>();
            var gammaRate = 0;
            var epsilonRate = 0;

            for (int i = 0; i < matrix[0].Count; i++)
            {
                var column = matrix.Select(row => row[i]);

                var mostCommonBit = column
                    .GroupBy(bit => bit)
                    .OrderByDescending(group => group.Count())
                    .Select(group => group.Key)
                    .First();

                bits.Add(mostCommonBit);
            }

            var bitSequence = new string(bits.Select(bit => bit.ToString()).SelectMany(bit => bit).ToArray());
            var bitSequenceEpsilon = new string(bits.Select(bit => (bit == 1 ? 0 : 1).ToString()).SelectMany(bit => bit).ToArray());

            gammaRate = Convert.ToInt32(bitSequence, 2);
            epsilonRate = Convert.ToInt32(bitSequenceEpsilon, 2);

            return (gammaRate, epsilonRate);
        }

        private static IReadOnlyList<IReadOnlyList<int>> GetMatrix(IReadOnlyList<string> bits)
        {
            var matrix = new List<List<int>>();

            foreach (var bit in bits)
            {
                var row = new List<int>();

                foreach (char c in bit)
                {
                    row.Add(int.Parse(c.ToString()));
                }

                matrix.Add(row);
            }

            return matrix;
        }
    }
}