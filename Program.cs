using System;

namespace MoonRobotSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Moon Robot Simulation!");

            // Get the size of the map from the user
            Console.Write("Enter the size of the map (between 2 and 100): ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size < 2 || size > 100)
            {
                Console.Write("Invalid input. Enter the size of the map (between 2 and 100): ");
            }

            // Create a new Moon object with the specified size
            Moon moon = new Moon(size);

            // Create a new Robot object with the Moon object as a parameter
            Robot robot = new Robot(moon);

            Console.WriteLine("Commands:");
            Console.WriteLine("PLACE X,Y,D");
            Console.WriteLine("LEFT");
            Console.WriteLine("RIGHT");
            Console.WriteLine("MOVE");
            Console.WriteLine("REPORT");
            Console.WriteLine("EXIT");

            // Enter the command loop
            while (true)
            {
                Console.Write("Enter a command: ");
                string input = Console.ReadLine().ToUpper();

                if (input == "EXIT")
                {
                    break;
                }

                robot.Execute(input);
            }
        }
    }
}

