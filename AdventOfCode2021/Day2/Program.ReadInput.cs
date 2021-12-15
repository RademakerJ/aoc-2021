namespace Day2
{
    public partial class Program
    {
        private static partial IReadOnlyList<(string, int)> ReadInput()
        {
            var result = new List<(string, int)>();
            var filePath = Path.Combine(Path.GetFullPath(@"..\..\..\"), "Resources", "Input.txt");
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var split = line.Split(" ");
                result.Add((split[0], int.Parse(split[1])));
            }
            
            return result;
        }
    }
}

