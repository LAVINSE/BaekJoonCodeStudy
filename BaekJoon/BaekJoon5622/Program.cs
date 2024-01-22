using System;
using System.Collections;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int time = 0;

        for(int i = 0; i < input.Length; i++)
        {
            switch(input[i])
            {
                case <= 'C':
                    time += 3;
                    break;
                case <= 'F':
                    time += 4;
                    break;
                case <= 'I':
                    time += 5;
                    break;
                case <= 'L':
                    time += 6;
                    break;
                case <= 'O':
                    time += 7;
                    break;
                case <= 'S':
                    time += 8;
                    break;
                case <= 'V':
                    time += 9;
                    break;
                case <= 'Z':
                    time += 10;
                    break;
            }
        }

        Console.WriteLine(time);
    }
}