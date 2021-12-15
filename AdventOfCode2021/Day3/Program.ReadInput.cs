namespace Day3
{
    public partial class Program
    {
        private static partial IReadOnlyList<string> ReadInput()
        {
            var filePath = Path.Combine(Path.GetFullPath(@"..\..\..\"), "Resources", "Input.txt");

            return File.ReadAllLines(filePath);
        }
    }
}

