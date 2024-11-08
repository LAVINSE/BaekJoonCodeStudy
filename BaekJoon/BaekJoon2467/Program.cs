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
        // 전체 용액의 수 N
        // N개의 오름차순 용액

        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int n = int.Parse(reader.ReadLine());
        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

        int start = 0;
        int end = n - 1;

        int answer1 = 0;
        int answer2 = 0;

        int max = int.MaxValue;

        while(start < end)
        {
            int sum = inputs[start] + inputs[end];

            if(max > Math.Abs(sum))
            {
                max = Math.Abs(sum);
                answer1 = inputs[start];
                answer2 = inputs[end];
            }

            if (sum > 0)
                end--;
            else 
                start++;  
        }

        writer.Write($"{answer1} {answer2}");
    }
}