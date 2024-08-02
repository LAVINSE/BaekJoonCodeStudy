using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Program
{
    private static void Main(string[] args)
    {
        // 도시의 개수
        // 도로 길이
        // 리터당 가격

        int cityCount = int.Parse(Console.ReadLine());
        int[] roadLengths = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] prices = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int prevPrice = int.MaxValue;
        long answer = 0;

        for(int i = 0; i < cityCount; i++)
        {
            int currentPrice = prices[i]; // 현재 도시 기름가격
            prevPrice = Math.Min(prevPrice, currentPrice); // 최소 기름 가격

            // 마지막 도시가 아니면 현재까지의 최소 가격으로 다음 도시까지의 거리만큼 주유
            answer += (i != cityCount - 1 ? (long)prevPrice * roadLengths[i] : 0);
        }

        Console.WriteLine(answer);
    }
}