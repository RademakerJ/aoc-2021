namespace Day4
{
    public partial class Program
    {
        public static void Main(string[] _)
        {
            var (bingoNumbers, bingoCards) = ReadInput();

            Console.WriteLine($"Solution to problem A: {SolveProblem(bingoCards, bingoNumbers, 1)}");                   // 33348
            Console.WriteLine($"Solution to problem B: {SolveProblem(bingoCards, bingoNumbers, bingoCards.Count)}");    // 8112
        }

        private static int SolveProblem(List<List<List<int>>> bingoCards, IReadOnlyList<int> bingoNumbers, int nthWinner)
        {
            // Since we are going to meddle with the bingo cards, make a copy of the original bingo cards list beforehand.
            // (Otherwise we will get in trouble with problem B).
            var bingoCardsCopy = new List<List<List<int>>>(bingoCards);

            if (PlayBingo(bingoCardsCopy, bingoNumbers, nthWinner) is (List<List<int>> bingoCard, int bingoNumber))
            {
                return GetFinalScore(bingoCard, bingoNumber);
            };

            return 0;
        }

        /// <summary>
        /// Returns the nth winning card and the winning number.
        /// </summary>
        private static (List<List<int>>, int)? PlayBingo(List<List<List<int>>> bingoCards, IReadOnlyList<int> bingoNumbers, int nthWinner)
        {
            var lastWinningBingoCard = new List<List<int>>();
            int lastWinningBingoNumber = 0;
            var bingoCardsToSkip = new List<int>();
            int numberOfWinners = 0;

            foreach (var bingoNumber in bingoNumbers)
            {
                for (int i = 0; i < bingoCards.Count; i++)
                {
                    if (bingoCardsToSkip.Contains(i))
                    {
                        continue;
                    }

                    for (int row = 0; row < bingoCards[i].Count; row++)
                    {
                        for (int col = 0; col < bingoCards[i][row].Count; col++)
                        {
                            if (bingoCards[i][row][col] == bingoNumber)
                            {
                                bingoCards[i][row][col] = -1;

                                if (Bingo(bingoCards[i], (row, col)))
                                {
                                    numberOfWinners++;
                                    lastWinningBingoCard = bingoCards[i];
                                    lastWinningBingoNumber = bingoNumber;
                                    bingoCardsToSkip.Add(i);

                                    if (numberOfWinners == nthWinner)
                                    {
                                        return (lastWinningBingoCard, lastWinningBingoNumber);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return (lastWinningBingoCard, lastWinningBingoNumber);
        }

        private static bool Bingo(List<List<int>> bingoCard, (int row, int col) position)
        {
            return
                bingoCard[position.row].All(number => number == -1) ||
                bingoCard.Select(row => row[position.col]).All(number => number == -1);
        }

        private static int GetFinalScore(List<List<int>> bingoCard, int winningNumber)
        {
            return bingoCard.SelectMany(row => row).Where(number => number != -1).Sum() * winningNumber;
        }
    }
}