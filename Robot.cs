using System;

namespace MoonRobotSimulation
{
    enum Direction
    {
        North,
        East,
        South,
        West
    }

    class Robot
    {
        private int x;
        private int y;
        private Direction direction;
        private readonly Moon moon;

        public Robot(Moon moon)
        {
            this.moon = moon;
        }

        public void Place(int x, int y, Direction direction)
        {
            if (moon.IsWithinBounds(x, y))
            {
                this.x = x;
                this.y = y;
                this.direction = direction;
            }
        }

        public void Left()
        {
            direction = (Direction)(((int)direction - 1 + 4) % 4);
        }

        public void Right()
        {
            direction = (Direction)(((int)direction + 1) % 4);
        }

        public void Move()
        {
            int newX = x;
            int newY = y;

            switch (direction)
            {
                case Direction.North:
                    newY++;
                    break;
                case Direction.East:
                    newX++;
                    break;
                case Direction.South:
                    newY--;
                    break;
                case Direction.West:
                    newX--;
                    break;
            }

            if (moon.IsSafe(newX, newY))
            {
                x = newX;
                y = newY;
            }
            else
            {
                Console.WriteLine("The robot cannot move in that direction.");
            }
        }

        public void Execute(string command)
        {
            string[] tokens = command.Split(' ');

            if (tokens.Length > 0)
            {
                switch (tokens[0].ToUpper())
                {
                    case "PLACE":
                        if (tokens.Length == 4 && Enum.TryParse(tokens[3], out Direction direction))
                        {
                            int x = int.Parse(tokens[1]);
                            int y = int.Parse(tokens[2]);
                            Place(x, y, direction);
                        }
                        else
                        {
                            Console.WriteLine("Invalid PLACE command.");
                        }
                        break;

                    case "LEFT":
                        Left();
                        break;

                    case "RIGHT":
                        Right();
                        break;

                    case "MOVE":
                        Move();
                        break;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }

        public void Report()
        {
            Console.WriteLine($"{x},{y},{direction}");
        }
    }
}

