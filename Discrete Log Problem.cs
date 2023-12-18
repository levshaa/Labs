using System;

class Solution
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        long G = long.Parse(inputs[0]);
        long H = long.Parse(inputs[1]);
        long Q = long.Parse(inputs[2]);

        long result = SolveDiscreteLog(G, H, Q);
        Console.WriteLine(result);
    }

    static long SolveDiscreteLog(long G, long H, long Q)
    {
        long p = Q;
        long g = G;
        long h = H;

        long m = (long)Math.Sqrt(p) + 1;

        // Precompute g^(-m) mod p
        long gm = ModuloInverse(ModuloPower(g, m, p), p);

        // Build a table of g^j mod p for 0 <= j < m
        long[] precomputedValues = new long[m];
        long value = 1;

        for (long j = 0; j < m; ++j)
        {
            precomputedValues[j] = value;
            value = (value * g) % p;
        }

        // Search for a solution
        for (long i = 0; i < m; ++i)
        {
            long target = (h * ModuloPower(gm, i, p)) % p;

            for (long j = 0; j < m; ++j)
            {
                if (target == precomputedValues[j])
                {
                    return i * m + j;
                }
            }
        }

        return -1; // No solution found
    }

    static long ModuloPower(long baseValue, long exponent, long modulus)
    {
        long result = 1;

        while (exponent > 0)
        {
            if (exponent % 2 == 1)
            {
                result = (result * baseValue) % modulus;
            }

            baseValue = (baseValue * baseValue) % modulus;
            exponent /= 2;
        }

        return result;
    }

    static long ModuloInverse(long a, long m)
    {
        // Extended Euclidean Algorithm
        long m0 = m;
        long y = 0, x = 1;

        while (a > 1)
        {
            long q = a / m;
            long t = m;

            m = a % m;
            a = t;
            t = y;

            y = x - q * y;
            x = t;
        }

        return (x < 0) ? x + m0 : x;
    }
}
