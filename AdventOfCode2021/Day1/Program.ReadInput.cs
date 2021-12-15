namespace Day1
{
    public partial class Program
    {
        private static partial IReadOnlyList<int> ReadInput()
        {
            var filePath = Path.Combine(Path.GetFullPath(@"..\..\..\"), "Resources", "Input.txt");
            var lines = File.ReadAllLines(filePath);

            return lines
                .Select(line => int.Parse(line))
                .ToList();
        }
    }
}
