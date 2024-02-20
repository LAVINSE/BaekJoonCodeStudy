using System;
using System.Collections;
using System.Text;

public class Program
{
    private static void FindHeart(string[] array, int n, out int x, out int y)
    {
        x = y = -1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (array[i][j] == '*')
                {
                    x = i + 1;
                    y = j;
                    return;
                }
            }
        }
    }

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] array = new string[n];
        int x;
        int y;
        int answer = 0;
        int subX = 0;
        int subY = 0;

        for (int i = 0; i < n; i++)
            array[i] = Console.ReadLine();

        
        FindHeart(array, n, out x, out y);

        Console.WriteLine($"{x + 1} {y + 1}");

        
        for (int i = 1; y - i >= 0; i++)
        {
            if (array[x][y - i] != '*')
                break;
            answer++;
        }

        Console.Write($"{answer} ");
        answer = 0;

        for (int i = 1; y + i < n; i++)
        {
            if (array[x][y + i] != '*')
                break;
            answer++;
        }

        Console.Write($"{answer} ");
        answer = 0;
        
        for (int i = 1; x + i < n; i++)
        {
            if (array[x + i][y] != '*')
            {
                subX = x + i - 1;
                subY = y;
                break;
            }
            answer++;
        }

        Console.Write($"{answer} ");
        answer = 0;

        for (int i = 1; subX + i < n; i++)
        {
            if (array[subX + i][subY - 1] != '*')
                break;
            answer++;
        }

        Console.Write($"{answer} ");
        answer = 0;

        for (int i = 1; subX + i < n; i++)
        {
            if (array[subX + i][subY + 1] != '*')
                break;
            answer++;
        }

        Console.Write($"{answer} ");
    }
}