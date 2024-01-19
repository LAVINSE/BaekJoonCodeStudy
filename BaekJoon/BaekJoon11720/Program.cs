using System;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        int sum = 0;

        for(int i = 0; i < n; i++)
        {
            // 문자열로 바꿔서 계산
            sum += int.Parse(input[i].ToString());
        }

        // 출력
        Console.WriteLine(sum);
    }
}