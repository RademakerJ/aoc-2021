namespace Day2
{
    public partial class Program
    {
        private static partial IReadOnlyList<(string, int)> ReadInput();

        public static void Main(string[] _)
        {
            var commands = ReadInput();

            Console.WriteLine($"Solution to problem A: {SolveProblemA(commands)}");     // 2027977
            Console.WriteLine($"Solution to problem B: {SolveProblemB(commands)}");     // 1903644897
        }

        private static int SolveProblemA(IReadOnlyList<(string, int)> commands)
        {
            var submarineHarry = new Submarine(new Point2D(0, 0), 0);

            foreach (var (direction, steps) in commands)
            {
                (int x, int d) = GetMovement(direction, steps);
                submarineHarry.Position.X += x;
                submarineHarry.Position.D += d;
            }

            return submarineHarry.Position.X * submarineHarry.Position.D;
        }

        private static int SolveProblemB(IReadOnlyList<(string, int)> commands)
        {
            var submarineHarry = new Submarine(new Point2D(0, 0), 0);

            foreach (var (direction, steps) in commands)
            {
                (int x, int d, int aim) = GetMovementWithAim(submarineHarry, direction, steps);
                submarineHarry.Aim += aim;
                submarineHarry.Position.X += x;
                submarineHarry.Position.D += d;
            }

            return submarineHarry.Position.X * submarineHarry.Position.D;
        }

        private static (int x, int d) GetMovement(string direction, int steps)
        {
            if (direction == "forward")
            {
                return (steps, 0);
            }

            if (direction == "up")
            {
                return (0, -steps);
            }

            return (0, steps);
        }

        private static (int x, int d, int aim) GetMovementWithAim(Submarine submarine, string direction, int steps)
        {
            if (direction == "forward")
            {
                return (steps, submarine.Aim * steps, 0);
            }

            if (direction == "up")
            {
                return (0, 0, -steps);
            }

            return (0, 0, steps);
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