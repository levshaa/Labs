using System;

class Program
{
    static void Main()
    {
        Func<string, string, string> xor = (a, b) =>
        {
            var res = "";
            for (int i = 0; i < a.Length; i++)
            {
                int xorResult = Convert.ToInt32(a[i].ToString(), 16) ^ Convert.ToInt32(b[i].ToString(), 16);
                res += xorResult.ToString("X");
            }
            return res;
        };

        string input1 = Console.ReadLine();
        string input2 = Console.ReadLine();
        string input3 = Console.ReadLine();

        string xorResult = xor(xor(input1, input2), input3);
        string result = "";

        for (int i = 0; i < xorResult.Length; i += 2)
        {
            string hexByte = xorResult.Substring(i, 2);
            int decimalValue = Convert.ToInt32(hexByte, 16);
            result += (char)decimalValue;
        }

        Console.WriteLine(result);
    }
}
