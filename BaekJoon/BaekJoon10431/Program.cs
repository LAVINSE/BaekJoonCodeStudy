using System;
using System.Collections;
using System.ComponentModel;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        int p = int.Parse(Console.ReadLine());
        int answer = 0;
        List<int> list = new List<int>();

        for(int i = 1; i <= p; i++)
        {
            // 값 초기화
            list.Clear();
            answer = 0;

            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            // 항상 20명, 테스트 케이스 번호 제외 , (1 <= 20) 반복
            for(int j = 1; j <= 20; j++)
            {
                // x > input[j] 조건을 만족하는 요소의 개수 반환
                answer += list.Count(x => x > input[j]);
                list.Add(input[j]);
            }

            sb.AppendLine($"{i} {answer}");
        }

        // 출력
        Console.WriteLine(sb);
    }
}