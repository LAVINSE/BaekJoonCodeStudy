using System;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();

        string inputI = Console.ReadLine();
        int i = int.Parse(inputI);

        // ElementAt - index를 이용해 값 얻기
        Console.WriteLine(input.ElementAt(i - 1));
    }
}