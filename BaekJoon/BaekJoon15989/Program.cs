using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 첫째 줄에 테스트 케이스 개수 T
        // 정수 N

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int t = int.Parse(reader.ReadLine());
        int[,] dp = new int[10001, 4];

        dp[1, 1] = 1; // 1
        dp[2, 1] = 1; // 1 + 1
        dp[2, 2] = 1; // 2
        dp[3, 1] = 1; // 1 + 1 + 1
        dp[3, 2] = 1; // 1 + 2
        dp[3, 3] = 1; // 3

        // 점화식
        // i를 1,2,3의 합으로 나타낸다
        // 1,2,3으로 끝나는 수식
        for (int i = 4; i <= 10000; i++)
        {
            dp[i, 1] = dp[i - 1, 1];
            dp[i, 2] = dp[i - 2, 1] + dp[i - 2, 2];
            dp[i, 3] = dp[i - 3, 1] + dp[i - 3, 2] + dp[i - 3, 3];
        }

        for(int i = 0; i < t; i++)
        {
            int n = int.Parse(reader.ReadLine());
            stringBuilder.Append(dp[n, 1] + dp[n, 2] + dp[n, 3] + "\n");
        }

        writer.WriteLine(stringBuilder.ToString());

        reader.Close();
        writer.Close();
    }
}