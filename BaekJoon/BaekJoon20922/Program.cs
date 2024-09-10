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
        // 길이가 N인 수열
        // 같은 정수를 K개 이하로 포함된 연속 부분 수열의 길이

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        //StringBuilder stringBuilder = new StringBuilder();

        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
        int n = inputs[0];
        int k = inputs[1];

        int[] sequence = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
        int[] pointsCheck = new int[sequence.Length + n];

        int start = 0;
        int end = 0;
        int answer = 0;

        while(end < n)
        {
            // 현재 숫자가 K개 아래 일 경우
            if(pointsCheck[sequence[end]] < k)
            {
                // 해당 숫자 등장 횟수 증가
                pointsCheck[sequence[end]]++;
                end++;
            }
            else
            {
                pointsCheck[sequence[start]]--;
                start++;
            }
            answer = Math.Max(answer, end - start);
        }

        writer.Write(answer);

        reader.Close();
        writer.Close();
    }
}