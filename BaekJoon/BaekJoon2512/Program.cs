using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 국가의 개수 N
        // 각 지방의 예산
        // 총 예산

        int n = int.Parse(Console.ReadLine());
        int[] budgets = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int m = int.Parse(Console.ReadLine());

        int max = budgets.Max();
        int min = 0;
        

        while(min <= max)
        {
            int mid = (min + max) / 2;
            int buget = 0;

            for(int i = 0; i < n; i++)
            {
                if (budgets[i] > mid)
                    buget += mid;
                else
                    buget += budgets[i];
            }

            if (buget <= m)
                min = mid + 1;
            else
                max = mid - 1;
        }

        Console.WriteLine(max);
    }
}