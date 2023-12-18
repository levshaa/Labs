using System;

class Program
{
    static void Main()
    {
        string[] wh = Console.ReadLine().Split();
        int w = int.Parse(wh[0]);
        int h = int.Parse(wh[1]);
        Console.ReadLine(); // number of turns before game over is useless
        string[] xy0 = Console.ReadLine().Split();
        int x0 = int.Parse(xy0[0]);
        int y0 = int.Parse(xy0[1]);

        // x0 y0 will be used to store the previous position
        // and x y the current position
        int x = x0, y = y0;

        // xs*ys is the area where the bomb could be
        // we'll first narrow down the area to a column by dichotomy on x-axis
        // then to a single window by dichotomy on y-axis
        int[] xs = new int[w];
        for (int i = 0; i < w; i++)
        {
            xs[i] = i;
        }
        int[] ys = new int[h];
        for (int i = 0; i < h; i++)
        {
            ys[i] = i;
        }

        while (true)
        {
            string info = Console.ReadLine();
            // uses infos to narrow the area where the bomb could be
            Narrow(x0, y0, x, y, ref xs, ref ys, info);
            // chooses the new location so that it allows splitting the area in half next turn
            x0 = x;
            y0 = y;
            // dichotomy along x-axis
            if (xs.Length != 1)
            {
                // the bisection between x0 and x should cut the area in 2, so:
                // (x + x0)/2 = (xs[0] + xs[xs.Length - 1])/2
                // little trick
                if (x0 == 0 && xs.Length != w)
                {
                    x = (3 * xs[0] + xs[xs.Length - 1]) / 2 - x0;
                }
                else if (x0 == w - 1 && xs.Length != w)
                {
                    x = (xs[0] + 3 * xs[xs.Length - 1]) / 2 - x0;
                }
                else
                {
                    x = xs[0] + xs[xs.Length - 1] - x0;
                }

                // to avoid fixed points
                if (x == x0)
                {
                    x += 1;
                }
                x = Math.Min(Math.Max(x, 0), w - 1);
            }
            else
            {
                // transition to the second dichotomy
                if (x != xs[0])
                {
                    x = x0 = xs[0];
                    Console.WriteLine($"{x} {y}");
                    info = Console.ReadLine();
                }
                // finishing
                if (ys.Length == 1)
                {
                    y = ys[0];
                }
                // dichotomy along y-axis
                else
                {
                    if (y0 == 0 && ys.Length != h)
                    {
                        y = (3 * ys[0] + ys[ys.Length - 1]) / 2 - y0;
                    }
                    else if (y0 == h - 1 && ys.Length != h)
                    {
                        y = (ys[0] + 3 * ys[ys.Length - 1]) / 2 - y0;
                    }
                    else
                    {
                        y = ys[0] + ys[ys.Length - 1] - y0;
                    }
                    y = Math.Min(Math.Max(y, 0), h - 1);
                }
            }

            Console.WriteLine($"{x} {y}");
        }
    }

    static void Narrow(int x0, int y0, int x, int y, ref int[] xs, ref int[] ys, string info)
    {
        // x-axis dichotomy
        if (xs.Length != 1)
        {
            if (info == "UNKNOWN")
            {
            }
            else if (info == "SAME")
            {
                xs = Array.FindAll(xs, i => Math.Abs(x0 - i) == Math.Abs(x - i));
            }
            else if (info == "WARMER")
            {
                xs = Array.FindAll(xs, i => Math.Abs(x0 - i) > Math.Abs(x - i));
            }
            else
            {
                xs = Array.FindAll(xs, i => Math.Abs(x0 - i) < Math.Abs(x - i));
            }
        }
        // y-axis dichotomy
        else
        {
            if (info == "UNKNOWN")
            {
            }
            else if (info == "SAME")
            {
                ys = Array.FindAll(ys, i => Math.Abs(y0 - i) == Math.Abs(y - i));
            }
            else if (info == "WARMER")
            {
                ys = Array.FindAll(ys, i => Math.Abs(y0 - i) > Math.Abs(y - i));
            }
            else
            {
                ys = Array.FindAll(ys, i => Math.Abs(y0 - i) < Math.Abs(y - i));
            }
        }
    }
}
