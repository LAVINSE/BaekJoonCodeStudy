using System;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        int b = 42;
        int[] remain = new int[10];

        // 계산
        for(int i = 0; i < 10; i++)
        {
            int a = int.Parse(Console.ReadLine());
            remain[i] = a % b;
        }
            
        // 중복 제거
        Console.WriteLine(remain.Distinct().Count());
    }
}