using System;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        string[] input = new string[t];
        char[] last = new char[t];
        char[] first = new char[t];

        for (int i = 0; i < t; i++)
        {
            input[i] = Console.ReadLine();
            last[i] = input[i].FirstOrDefault();
            first[i] = input[i][input[i].Length - 1];
        }


        for(int i =0; i < input.Length; i++)
        {
            Console.WriteLine($"{last[i]}{first[i]}");
        } 
    }
}