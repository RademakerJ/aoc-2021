namespace Day2
{
    public partial class Program
    {
        public static void Main(string[] _)
        {
            var commands = ReadInput();

            Console.WriteLine($"Solution to problem A: {SolveProblemA(commands)}");     // 2027977
            Console.WriteLine($"Solution to problem B: {SolveProblemB(commands)}");     // 1903644897
        }

        private static int SolveProblemA(IReadOnlyList<(string, int)> commands)
        {
            var submarine = new Submarine(new Point2D(0, 0), 0);

            foreach (var (direction, steps) in commands)
            {
                MoveWithoutAim(submarine, direction, steps);
            }

            return submarine.Position.X * submarine.Position.D;
        }

        private static int SolveProblemB(IReadOnlyList<(string, int)> commands)
        {
            var submarine = new Submarine(new Point2D(0, 0), 0);

            foreach (var (direction, steps) in commands)
            {
                MoveWithAim(submarine, direction, steps);
            }

            return submarine.Position.X * submarine.Position.D;
        }

        private static void MoveWithoutAim(Submarine submarine, string direction, int steps)
        {
            if (direction == "forward")
            {
                submarine.Position.X += steps;
            }

            if (direction == "up")
            {
                submarine.Position.D -= steps;
            }

            if (direction == "down")
            {
                submarine.Position.D += steps;
            }
        }

        private static void MoveWithAim(Submarine submarine, string direction, int steps)
        {
            if (direction == "forward")
            {
                submarine.Position.X += steps;
                submarine.Position.D += submarine.Aim * steps;
            }

            if (direction == "up")
            {
                submarine.Aim -= steps;
            }

            if (direction == "down")
            {
                submarine.Aim += steps;
            }
        }

        private record Submarine
        {
            public Point2D Position { get; set; }

            public int Aim { get; set; }

            public Submarine(Point2D position, int aim)
            {
                Position = position;
                Aim = aim;
            }
        }

        /// <summary>
        /// X = horizontal position, D = depth.
        /// </summary>
        private record Point2D
        {
            public int X { get; set; }

            public int D { get; set; }

            public Point2D(int x, int d)
            {
                X = x;
                D = d;
            }
        }
    }
}