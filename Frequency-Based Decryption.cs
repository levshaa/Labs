using System;

class Program
{
    static string EncodeDecalage(string text, int decalage)
    {
        char[] _text = new char[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            if (char.IsLetter(c))
            {
                int a = Char.IsLower(c) ? (int)'a' : (int)'A';
                int _c = (c - a + decalage) % 26;
                _text[i] = (char)(_c + a);
            }
            else
            {
                _text[i] = c;
            }
        }
        return new string(_text);
    }

    static double ProbaTextAnglais(string text)
    {
        int a = (int)'a';
        double[] proba = { 8.08, 1.67, 3.18, 3.99, 12.56, 2.17, 1.8, 5.27, 7.24, 0.14, 0.63, 4.04, 2.6, 7.38, 7.47, 1.91, 0.09, 6.42, 6.59, 9.15, 2.79, 1, 1.89, 0.21, 1.65, 0.07 };
        int[] frequence = new int[26];
        text = text.ToLower();
        foreach (char c in text)
        {
            int _c = c - a;
            if (0 <= _c && _c <= 25)
            {
                frequence[_c]++;
            }
        }
        int lenStr = text.Length;
        double score = 0;
        for (int i = 0; i < 26; i++)
        {
            double p = (frequence[i] / (double)lenStr) * 100;
            score += Math.Pow((proba[i] - p), 2);
        }
        return Math.Sqrt(score);
    }

    static void Main()
    {
        string message = Console.ReadLine();
        double scoreMin = double.MaxValue;
        string text = "";
        for (int i = 0; i < 26; i++)
        {
            string t = EncodeDecalage(message, i);
            double score = ProbaTextAnglais(t);
            if (score < scoreMin)
            {
                scoreMin = score;
                text = t;
            }
        }
        Console.WriteLine(text);
    }
}
