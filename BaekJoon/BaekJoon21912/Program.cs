using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 지난 일수 N, X일동안
        // 방문자 수

        int[] days = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] visitors = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int n = days[0]; // 지난 일수
        int x = days[1]; // 연속

        int sum = 0;
        int maxSum = 0;
        int count = 1;

        // x일동안 방문한 방문자수 합
        for(int i = 0; i < x; i++)
            sum += visitors[i];

        // 저장
        maxSum = sum;

        for (int i = x; i < n; i++)
        {
            // 새로 추가된 날을 더하고 기존에 있던 날을 뺌
            sum = sum + visitors[i] - visitors[i - x];

            if (sum > maxSum)
            {
                maxSum = sum;
                count = 1;
            }
            else if (sum == maxSum)
            {
                count++;
            }
        }

        if (maxSum == 0)
        {
            Console.WriteLine("SAD");
        }
        else
        {
            Console.WriteLine(maxSum);
            Console.WriteLine(count);
        }
    }
}