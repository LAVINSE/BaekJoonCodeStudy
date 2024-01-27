using System;
using System.Collections;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int h = int.Parse(input[0]);
        int w = int.Parse(input[1]);
        int n = int.Parse(input[2]);
        int m = int.Parse(input[3]);

        double width = Math.Ceiling((double)h / (n + 1));
        double height = Math.Ceiling((double)w / (m + 1));

        Console.WriteLine(width * height);
    }
}