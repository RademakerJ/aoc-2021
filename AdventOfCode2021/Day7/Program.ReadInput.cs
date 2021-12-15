namespace Day7
{
    public partial class Program
    {
        private static partial IReadOnlyList<int> ReadInput()
        {
            var filePath = Path.Combine(Path.GetFullPath(@"..\..\..\"), "Resources", "Input.txt");
            var text = File.ReadAllText(filePath);
            var lines = text.Split(',');

            return lines
                .Select(line => int.Parse(line))
                .ToList();
        }
    }
}
