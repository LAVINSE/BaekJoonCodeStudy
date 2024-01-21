using System;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 공백기준으로 문자열 분리
        string[] input = Console.ReadLine().Split();
        int count = 0;

        // 공백으로 시작하거나 끝날 경우 예외처리
        for(int i = 0; i < input.Length; i++)
        {
            if(input[i] == "")
            {
                // 공백 수
                count++;
            }
        }

        // 출력
        Console.WriteLine(input.Length - count);
    }
}