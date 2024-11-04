using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 2차원 세로 길이 H 가로 길이 W

        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int[] maps = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
        int[] heights = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

        int h = maps[0];
        int w = maps[1];

        int result = 0;

        for(int i = 1; i < w - 1; i++)
        {
            int left = 0;
            int right = 0;

            for(int j = 0; j < i; j++)
            {
                left = Math.Max(heights[j], left);
            }

            for(int k = i + 1; k < w; k++) 
            {
                right = Math.Max(heights[k], right);
            }

            if (heights[i] < left && heights[i] < right)
            {
                result += Math.Min(right, left) - heights[i];
            }
        }

        writer.Write(result.ToString());
    }
}