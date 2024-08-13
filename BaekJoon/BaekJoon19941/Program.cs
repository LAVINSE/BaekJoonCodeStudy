using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 식탁의 길이 N
        // 사람과 햄버거의 위치

        int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = inputs[0];
        int k = inputs[1];
        string inputHP = Console.ReadLine();
        char[] hpArray = new char[inputHP.Length];

        int count = 0;

        for(int i = 0; i < inputHP.Length; i++)
        {
            hpArray[i] = inputHP[i];
        }

        for(int i = 0; i < n; i++)
        {
            if (hpArray[i] != 'P')
                continue;

            for(int j = i - k; j <= i + k; j++)
            {
                if (j >= 0 && j < n && hpArray[j] == 'H')
                {
                    count++;
                    hpArray[j] = 'X';
                    break;
                }
            }
        }

        Console.WriteLine(count);
    }
}