namespace Day5
{
    public partial class Program
    {
        private static IReadOnlyList<int> ReadInput()
        {
            var filePath = Path.Combine("Resources", "Input.txt");
            var lines = File.ReadAllLines(filePath);

            return lines
                .Select(line => int.Parse(line))
                .ToList();
        }
    }
}
