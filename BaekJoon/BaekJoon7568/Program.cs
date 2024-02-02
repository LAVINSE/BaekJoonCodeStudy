using System;
using System.Collections;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] weight = new int[n];
        int[] height = new int[n];
        int count = 0;

        // 입력
        for(int i = 0; i < n; i++)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            weight[i] = input[0];
            height[i] = input[1];
        }

        for(int i =0; i < n; i++)
        {
            count = 0;

            for(int j = 0; j < n; j++)
            {
                if(height[i] < height[j] && weight[i] < weight[j])
                {
                    count++;
                }
            }

            Console.WriteLine(count + 1);
        }
    }
}