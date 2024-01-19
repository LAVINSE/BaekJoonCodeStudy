using System;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();
        char inputC = input[0];
        int ascCode = Convert.ToInt32(inputC);
        Console.WriteLine(ascCode);
    }
}