using System;

class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // Building width
        int H = int.Parse(inputs[1]); // Building height
        int N = int.Parse(Console.ReadLine()); // Maximum number of jumps

        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]); // Initial X position
        int Y0 = int.Parse(inputs[1]); // Initial Y position

        int xMin = 0; // Minimum possible X position
        int xMax = W - 1; // Maximum possible X position
        int yMin = 0; // Minimum possible Y position
        int yMax = H - 1; // Maximum possible Y position

        // Game loop
        while (true)
        {
            string bombDir = Console.ReadLine(); // Device code: COLDER, WARMER, SAME, or UNKNOWN

            if (bombDir == "COLDER")
            {
                // Update possible positions where you can be
                if (X0 > xMin)
                {
                    xMin = X0 + 1;
                }
                if (Y0 > yMin)
                {
                    yMin = Y0 + 1;
                }
            }
            else if (bombDir == "WARMER")
            {
                // Update possible positions where you can be
                if (X0 < xMax)
                {
                    xMax = X0 - 1;
                }
                if (Y0 < yMax)
                {
                    yMax = Y0 - 1;
                }
            }

            // Calculate next jump position using binary search
            int nextX = (xMin + xMax) / 2;
            int nextY = (yMin + yMax) / 2;

            // Output next jump position
            Console.WriteLine(nextX + " " + nextY);
        }
    }
}
