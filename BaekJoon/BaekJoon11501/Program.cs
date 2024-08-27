using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    { 
        // 테스트 케이스 자연수 T
        // 날의 수 N
        // 날 별 주가 N개의 자연수

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int testCase = int.Parse(reader.ReadLine());

        for(int i = 0; i < testCase; i++)
        {
            int n = int.Parse(reader.ReadLine());
            int[] stockPrices = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            // default : 마지막 가격
            int maxPrice = stockPrices.Last();
            long count = 0; // 64비트 정수형으로 표현가능

            // 배열의 마지막 인덱스 하나 앞에서 시작
            for(int j = n - 2; j >= 0; j--)
            {
                // 가장 높은 가격보다 앞에 가격이 작거나 같을 경우
                if (stockPrices[j] <= maxPrice)
                    count += maxPrice - stockPrices[j]; // 차익 더하기
                else
                    maxPrice = stockPrices[j]; // 최대 가격 >> 앞에 가격으로 변경
            }

            stringBuilder.AppendLine(count.ToString());
        }

        writer.Write(stringBuilder);

        reader.Close();
        writer.Close();
    }
}