namespace Day4
{
    public partial class Program
    {
        private static (IReadOnlyList<int>, List<List<List<int>>>) ReadInput()
        {
            var filePath = Path.Combine("Resources", "Input.txt");

            using StreamReader reader = new(filePath);
            var bingoNumbers = reader.ReadLine()?.Split(',').Select(str => int.Parse(str)).ToList();
            var bingoCardsRaw = reader.ReadToEnd()
                .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (bingoNumbers is null || bingoCardsRaw is null)
            {
                throw new Exception("This is not supposed to happen.");
            }

            return (bingoNumbers, GetBingoCards(bingoCardsRaw).ToList());
        }

        private static IEnumerable<List<List<int>>> GetBingoCards(IReadOnlyList<string> bingoCardsRaw)
        {
            foreach (var bingoCardRaw in bingoCardsRaw)
            {
                var bingoCard = new List<List<int>>();
                var rowSplit = bingoCardRaw.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

                foreach (var row in rowSplit)
                {
                    bingoCard.Add(row.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(str => int.Parse(str.Trim())).ToList());
                }

                yield return bingoCard;
            }
        }
    }
}
