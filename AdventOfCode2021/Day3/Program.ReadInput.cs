namespace Day3
{
    public partial class Program
    {
        private static partial IReadOnlyList<IReadOnlyList<int>> ReadInput()
        {
            var filePath = Path.Combine(Path.GetFullPath(@"..\..\..\"), "Resources", "Input.txt");
            var lines = File.ReadAllLines(filePath);

            return GetMatrix(lines);
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

