namespace Day7
{
    public partial class Program
    {
        private static IReadOnlyList<int> ReadInput()
        {
            var filePath = Path.Combine("Resources", "Input.txt");
            var text = File.ReadAllText(filePath);
            var lines = text.Split(',');

            return lines
                .Select(line => int.Parse(line))
                .ToList();
        }
    }
}
