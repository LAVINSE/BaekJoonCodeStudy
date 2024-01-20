using System;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        List<string> resultList = new List<string>();
        string result = string.Empty;

        for (int i = 0; i < t; i++)
        {
            string[] input = Console.ReadLine().Split();
            int r = int.Parse(input[0]);

            // 문자열 길이만큼 반복
            for(int j = 0; j < input[1].Length; j++)
            {
                // t 만큼 반복
                for(int k = 0; k < r; k++)
                {
                    // 문자 합치기
                    result += input[1][j];
                }
            }

            // 정답 추가
            resultList.Add(result);
            // 정답 초기화
            result = string.Empty;
        }

        for(int i = 0; i < resultList.Count; i++)
        {
            // 저장된 정답 출력
            Console.WriteLine(resultList[i]);
        }
    }
}